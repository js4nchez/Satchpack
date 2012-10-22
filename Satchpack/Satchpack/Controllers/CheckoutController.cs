﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Satchpack.PayPalSandbox;
using Satchpack.Models;
using Satchpack.Domain.Entities;

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
            // This object holds the payment details.
            SetExpressCheckoutReq expressCheckout = new SetExpressCheckoutReq()
            {
                SetExpressCheckoutRequest = new SetExpressCheckoutRequestType()
                {
                    SetExpressCheckoutRequestDetails = new SetExpressCheckoutRequestDetailsType()
                    {
                        ReturnURL = "http://localhost:25540/Shopping/ReviewTransaction",
                        CancelURL = "http://localhost:25540/Shopping/CancelTransaction",
                        OrderDescription = "Satchpack Order",
                        PaymentAction = PaymentActionCodeType.Sale,
                        OrderTotal = new BasicAmountType()
                        {
                            currencyID = CurrencyCodeType.USD,
                            Value = "90.00"
                        }
                    },
                    Version = "60.0"
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
            GetExpressCheckoutDetailsReq checkoutDetails = new GetExpressCheckoutDetailsReq();
            checkoutDetails.GetExpressCheckoutDetailsRequest = new GetExpressCheckoutDetailsRequestType()
            {
                Token = token,
                Version = "60.0"
            };

            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            GetExpressCheckoutDetailsResponseType response = sandboxApi.GetExpressCheckoutDetails(ref creds, checkoutDetails);
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
            return View();
        }

        /// <summary>
        /// Submits the payment to PayPal as confirmed by the user.
        /// </summary>
        /// <param name="token">The string that identifies the user's session for a transaction.</param>
        public ActionResult OrderSubmitted(TransactionDetails transactionDetails)
        {
            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            DoExpressCheckoutPaymentResponseType response = sandboxApi.DoExpressCheckoutPayment(ref creds, new DoExpressCheckoutPaymentReq()
            {
                DoExpressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType()
                {
                    DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType()
                    {
                        Token = transactionDetails.Token,
                        PayerID = transactionDetails.PayerId,
                        PaymentAction = PaymentActionCodeType.Sale,
                        PaymentDetails = new PaymentDetailsType[] { new PaymentDetailsType() { OrderTotal = new BasicAmountType() { Value = transactionDetails.Invoice.InvoiceTotal.ToString() } } }
                    }
                }
            });
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
                Username = "bus_1350451002_biz_api1.satchpack.com",
                Password = "1350451057",
                Signature = "An5ns1Kso7MWUdW4ErQKJJJ4qi4-AAJIh61ld-z-TGnvds8gBpPq6JQU"
            };
            return securityHeader;
        }
    }
}
