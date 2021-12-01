using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyRapChieuPhim.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
            private set => instance = value;
        }

        private AccountDAO() { }

        public bool Login_admin(string userName, string passWord)
        {
            DataTable result;
            try
            {
                string pass = MD5Helper.PasswordEncryption(passWord);

                string query = "USP_Login_admin @username , @password";

                result = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, pass });
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return result.Rows.Count > 0;

        }

        public bool Login_employee(string userName, string passWord)
        {
            string pass = MD5Helper.PasswordEncryption(passWord);

            string query = "USP_Login_employee @username , @password";

            DataTable result = DataProvider.Instance.ExcuteQuery(query, new object[] { userName, pass });
            return result.Rows.Count > 0;
        }

        public DataTable GetAccountList()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM View_GetAccount");
        }

        public DataTable GetTypeAccount()
        {
            return DataProvider.Instance.ExcuteQuery("SELECT * FROM View_GetAccountType");
        }

        public DataTable GetAccountByName()
        {
            return DataProvider.Instance.ExcuteQuery("select * from View_GetSearchByName");
        }

    }
}
