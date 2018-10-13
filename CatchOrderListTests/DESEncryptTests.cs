using Microsoft.VisualStudio.TestTools.UnitTesting;
using Express.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Express.DBUtility.Tests
{
    [TestClass()]
    public class DESEncryptTests
    {
        [TestMethod()]
        public void EncryptTest()
        {
            string data = DESEncrypt.Encrypt("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=**/dbms.mdb;Jet OleDb:DataBase Password='';");

        }
    }
}