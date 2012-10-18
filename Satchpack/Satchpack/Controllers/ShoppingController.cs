﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Satchpack.PayPalSandbox;

namespace Satchpack.Controllers
{
    public class ShoppingController : Controller
    {
        private PayPalAPIAAInterfaceClient sandboxApi;
        public ShoppingController()
        {
            sandboxApi = new PayPalAPIAAInterfaceClient();
        }

        public ActionResult Product()
        {
            return View();
        }

        public ActionResult EditCart()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            SetExpressCheckoutRequestDetailsType sdt = new SetExpressCheckoutRequestDetailsType();
            PaymentDetailsType pdt = new PaymentDetailsType()
            {
                OrderDescription = "Satchpack order",
                OrderTotal = new BasicAmountType()
                {
                    currencyID = CurrencyCodeType.USD,
                    Value = "90.00"
                }
            };
            sdt.PaymentDetails = new PaymentDetailsType[] { pdt };
            sdt.ReturnURL = "http://localhost:25540/Shopping/Review";
            sdt.CancelURL = "http://localhost:25540/";

            SetExpressCheckoutReq expressCheckout = new SetExpressCheckoutReq()
            {
                SetExpressCheckoutRequest = new SetExpressCheckoutRequestType()
                {
                    SetExpressCheckoutRequestDetails = sdt,
                    Version = "60.0"
                }
            };

            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            SetExpressCheckoutResponseType response = sandboxApi.SetExpressCheckout(ref creds, expressCheckout);
            if (response.Errors != null && response.Errors.Length > 0)
            {
                throw new Exception("Exception while calling Paypal " + response.Errors[0].LongMessage);
            }

            return Redirect("https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=" + response.Token);
        }

        public ActionResult Review(string token)
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

            return View();
        }

        public ActionResult SubmitOrder(string token)
        {
            CustomSecurityHeaderType creds = RetrieveSecurityHeaders();
            sandboxApi.DoExpressCheckoutPayment(ref creds, new DoExpressCheckoutPaymentReq()
            {
                DoExpressCheckoutPaymentRequest = new DoExpressCheckoutPaymentRequestType()
                {
                    DoExpressCheckoutPaymentRequestDetails = new DoExpressCheckoutPaymentRequestDetailsType()
                    {
                        Token = token
                    }
                }
            });
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private CustomSecurityHeaderType RetrieveSecurityHeaders()
        {
            // Credentials for accessing paypal api.
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