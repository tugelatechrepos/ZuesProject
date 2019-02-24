using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Text;

namespace DebtCollectionAccess.Dao
{
    public interface IUserDao
    {
        ICollection<Users> GetUserList();
    }

    [Export(typeof(IUserDao))]
    public class UserDao : IUserDao
    {
        #region Declarations

        private DebtCollectionContext _DbContext;

        #endregion Declarations

        public ICollection<Users> GetUserList()
        {
            ICollection<Users> resultList = null;

            using (_DbContext = new DebtCollectionContext())
            {
                var query = _DbContext.Users.AsQueryable();
                resultList = query.ToList();
            }
            return resultList;
        }
    }
}
