using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Satchpack.Domain.Entities;

namespace Satchpack.Domain.AbstractRepository
{
    /// <summary>
    /// Represents the data access layer for persisting Invoices.
    /// 
    /// Root Aggregate: Invoice
    /// Aggregate Members: Customer
    ///                    InvoiceStatus
    ///                    ShippingMethod
    /// </summary>
    public interface IInvoiceDAL
    {
        bool CreateInvoice(DAL_Object invoice);
        bool UpdateInvoice(DAL_Object invoice);
        bool DeleteInvoice(DAL_Object invoice);
        DAL_Object RetrieveInvoices();
        DAL_Object RetrieveInvoiceById(int invoiceId);
    }
}
