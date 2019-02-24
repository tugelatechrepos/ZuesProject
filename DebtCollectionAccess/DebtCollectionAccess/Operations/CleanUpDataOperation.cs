using DebtCollectionAccess.Contracts;
using DebtCollectionAccess.Dao;
using ProjectCoreLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace DebtCollectionAccess.Operations
{
    public interface ICleanUpDataOperation
    {
        DataCleanUpResponse CleanUpData();
    }

    public class CleanUpDataOperation : ICleanUpDataOperation
    {
        #region Declarations

        private DataCleanUpResponse _Response;

        public IDataCleanUpDao DataCleanUpDao { get; set; }

        #endregion Declarations

        public DataCleanUpResponse CleanUpData()
        {
            _Response = new DataCleanUpResponse { ValidationResults = new ValidationResults() };
            _Response.ValidationResults =  DataCleanUpDao.CleanUpData();          
         
            return _Response;
        }
    }
}
