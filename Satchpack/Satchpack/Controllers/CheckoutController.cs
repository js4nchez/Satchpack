using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Satchpack.PayPalSandbox;
using Satchpack.Models;
using Satchpack.Domain.Entities;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Satchpack.Controllers
{
    public class CheckoutController : Controller
    {
        private PayPalAPIAAInterfaceClient sandboxApi;
        public CheckoutController()
        {
            sandboxApi = new PayPalAPIAAInterfaceClient();
        }

        /// <summary>
        /// Initiates the PayPal checkout process.
        /// Redirects the user to the PayPal site to retrieve customer info.
        /// </summary>
        public ActionResult Checkout()
        {
            // This object holds the payment details (SetExpressCheckoutReq).
            ShoppingCart cart = GetCart();
            SetExpressCheckoutReq expressCheckout = new SetExpressCheckoutReq()
            {
                SetExpressCheckoutRequest = new SetExpressCheckoutRequestType()
                {
                    SetExpressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType()
                    {
                        ReturnURL = ConfigurationManager.AppSettings["ReturnURL"].ToString(),
                        CancelURL = ConfigurationManager.AppSettings["CancelURL"].ToString(),
                        OrderDescription = "Satchpack Order",
                        PaymentAction = PaymentActionCodeType.Sale,
                        OrderTotal = new BasicAmountType()
                        {
                            currencyID = CurrencyCodeType.USD,
                            Value = cart.TotalCost.ToString()
                        }
                    },
                    Version = ConfigurationManager.AppSettings["PaypalVersion"].ToString()
                }
            };

            // Initiate the paypal checkout process and redirect to paypal
            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            SetExpressCheckoutResponseType response = sandboxApi.SetExpressCheckout(ref creds, expressCheckout);
            if (response.Errors != null && response.Errors.Length > 0)
                throw new Exception("Exception while calling Paypal " + response.Errors[0].LongMessage);

            return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + response.Token);
        }

        /// <summary>
        /// Receives the customer data and asks for confirmation from the user.
        /// </summary>
        /// <param name="token">The string that identifies the user's session for a transaction.</param>
        public ActionResult ReviewTransaction(string token)
        {
            // Retrieves customer information based on their session token.
            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            GetExpressCheckoutDetailsReq checkoutDetails = new GetExpressCheckoutDetailsReq();
            checkoutDetails.GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType()
            {
                Token = token,
                Version = ConfigurationManager.AppSettings["PaypalVersion"].ToString()
            };
            GetExpressCheckoutDetailsResponseType response = sandboxApi.GetExpressCheckoutDetails(ref creds, checkoutDetails);

            // Extracting customer info into Satchpack objects to display to the user for review.
            string payerId = response.GetExpressCheckoutDetailsResponseDetails.PayerInfo.PayerID;
            double orderTotal;
            PayerInfoType payer = response.GetExpressCheckoutDetailsResponseDetails.PayerInfo;
            PaymentDetailsType paymentDetails = response.GetExpressCheckoutDetailsResponseDetails.PaymentDetails[0];

            if (Double.TryParse(paymentDetails.OrderTotal.Value, out orderTotal))
            {
                Invoice invoice = new Invoice()
                {
                    Customer = new Customer()
                    {
                        Address1 = payer.Address.Street1,
                        Address2 = payer.Address.Street2,
                        City = payer.Address.CityName,
                        State = payer.Address.StateOrProvince,
                        PostalCode = payer.Address.PostalCode,
                        FirstName = payer.PayerName.FirstName,
                        LastName = payer.PayerName.LastName,
                        Country = payer.Address.CountryName,
                        Email = payer.Payer,
                        Phone = payer.ContactPhone
                    },
                    InvoiceTotal = orderTotal
                };

                TransactionDetails transactionDetails = new TransactionDetails()
                {
                    Invoice = invoice,
                    PayerId = payerId,
                    Token = token
                };
                return View(transactionDetails);
            }
            else
            {
                throw new Exception("Error processing the order total");
            }
        }

        /// <summary>
        /// Returns the view that assures the user of the cancellation of their order.
        /// </summary>
        public ActionResult CancelTransaction()
        {
            ShoppingCart cart = GetCart();
            cart = new ShoppingCart();
            Session["Cart"] = cart;
            return View();
        }

        /// <summary>
        /// Submits the payment to PayPal as confirmed by the user.
        /// </summary>
        /// <param name="token">The string that identifies the user's session for a transaction.</param>
        public ActionResult OrderSubmitted(TransactionDetails transaction)
        {
            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            DoExpressCheckoutPaymentResponseType response = sandboxApi.DoExpressCheckoutPayment(ref creds, new DoExpressCheckoutPaymentReq()
            {
                DoExpressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType()
                {
                    DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType()
                    {
                        PaymentActionSpecified = true,
                        PaymentAction = PaymentActionCodeType.Sale,
                        PayerID = transaction.PayerId,
                        Token = transaction.Token,
                        PaymentDetails = new PaymentDetailsType[]
                        {
                            new PaymentDetailsType()
                            {
                                OrderTotal = new BasicAmountType()
                                {
                                    Value = transaction.Invoice.InvoiceTotal.ToString(),
                                    currencyID = CurrencyCodeType.USD
                                }
                            }
                        }
                    },
                    Version = ConfigurationManager.AppSettings["PaypalVersion"]
                }
            });

            if (response.Errors != null && response.Errors.Length > 0)
            {
                ViewBag.Message = "There were a few complications with your order. Your order has been placed on hold.";
            }
            else
            {
                ViewBag.Message = "Your order has been successfully submitted.";
                SendEmail(transaction);
            }
            return View();
        }

        /// <summary>
        /// Returns the neccessary credentials to make PayPal API calls.
        /// </summary>
        private CustomSecurityHeaderType RetrieveSecurityHeaders()
        {
            // Credentials for accessing paypal API.
            CustomSecurityHeaderType securityHeader = new CustomSecurityHeaderType();
            securityHeader.Credentials = new UserIdPasswordType()
            {
                Username = ConfigurationManager.AppSettings["Username"],
                Password = ConfigurationManager.AppSettings["Password"],
                Signature = ConfigurationManager.AppSettings["Signature"]
            };
            return securityHeader;
        }

        /// <summary>
        /// Retrieves the current session's ShoppingCart.
        /// If there currently is no ShoppingCart, then one is created for this session.
        /// </summary>
        private ShoppingCart GetCart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="details"></param>
        private void SendEmail(TransactionDetails details)
        {
            Customer customer = details.Invoice.Customer;
            MailMessage message = new MailMessage();
            message.From = new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]);
            message.Subject = "New Order";
            message.Body = string.Format(@"Transaction Details:\n\r\n\r
                                          \tFirst Name:  {0}\n\r
                                          \tLast Name:   {1}\n\r
                                          \tAddress 1:   {2}\n\r
                                          \tAddress 2:   {3}\n\r
                                          \tCity:        {4}\n\r
                                          \tState:       {5}\n\r
                                          \tPostal Code: {6}\n\r
                                          \tCountry:     {7}\n\r
                                          \tEmail:       {8}\n\r
                                          \tPhone:       {9}\n\r\n\r
                                          \tOrder Total: {10}",
                                                              customer.FirstName,
                                                              customer.LastName,
                                                              customer.Address1,
                                                              customer.Address2,
                                                              customer.City,
                                                              customer.State,
                                                              customer.PostalCode,
                                                              customer.Country,
                                                              customer.Email,
                                                              customer.Phone,
                                                              details.Invoice.InvoiceTotal);
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["SupportEmail"]));
            message.To.Add(new MailAddress(ConfigurationManager.AppSettings["PersonalEmail"]));

            SmtpClient server = new SmtpClient(
                ConfigurationManager.AppSettings["EmailHost"].ToString(),
                int.Parse(ConfigurationManager.AppSettings["EmailPort"].ToString()));

            server.Credentials = new NetworkCredential(
                ConfigurationManager.AppSettings["SupportEmail"].ToString(),
                ConfigurationManager.AppSettings["SupportEmailPassword"].ToString());
            server.Send(message);
        }
    }
}