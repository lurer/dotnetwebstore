using BLL.BussinessTransactions;
using System;

using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace BLL.AuthenticationServices
{
    public class PasswordUtility
    {

        //Stjålet fra http://brockallen.com/2012/10/19/password-management-made-easy-in-asp-net-with-the-crypto-api/
        public static string HashMyPassword(string plainPassword)
        {
            return Crypto.HashPassword(plainPassword);
          
        }

        public static bool CheckUsedPasswordAgainstHashed(string username, string plainPassword)
        {
            var userFromDb = new UserTransaction().getUserByEmail(username);
            var hashedPassword = userFromDb.Password;
            var doesPasswordMatch = Crypto.VerifyHashedPassword(hashedPassword, plainPassword);
            return doesPasswordMatch;
        }
    }
}
