﻿using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;

using System;
using System.Collections.Generic;
using System.Composition;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface IPersistInvoiceOperation
    {
        PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request);
    }

    [Export(typeof(IPersistInvoiceOperation))]
    public class PersistInvoiceOperation : IPersistInvoiceOperation
    {
        #region Declarations

        private PersistInvoiceRequest _Request;
        private PersistInvoiceResponse _Response;

        [Import]
        public IInvoiceDao InvoiceDao { get; set; }

        #endregion Declarations

        public PersistInvoiceResponse PersistInvoice(PersistInvoiceRequest Request)
        {
            _Request = Request;
            _Response = new PersistInvoiceResponse();

            persist();

            return _Response;
        }

        private void persist()
        {
            InvoiceDao.Persist(_Request.Invoice);

            _Response.InvoiceId = _Request.Invoice.Id;
        }
    }
}