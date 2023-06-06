using BankApplication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace BankApplicationTest
{
    [TestClass]
    public class BankSystemTests
    {
        [TestMethod]
        public void TransferbetweenAccounts_ShouldTransferCorrectAmount()
        {
            Users.DefaultUserCreation();
            Customer c1 = Users.customerList.FirstOrDefault(x => x.Name == "Anas");

            float transfer = 100f;
            string account1 = "Sparkonto";
            string account2 = "L�nekonto";

            string expected = "2009,7087";

            BankSystem.ExchangeRate(c1, c1, account1, account2, transfer);

            Assert.AreEqual(expected, c1.accounts["L�nekonto"][0]);
        }
        [TestMethod]
        public void Loan_ShouldAddTheCorrectAmount()
        {
            Users.DefaultUserCreation();
            Customer customer = Users.customerList.FirstOrDefault(x => x.Name == "Tobias");
            var loanamount = 200;
            var actual = (double.Parse(customer.accounts["L�nekonto"][0]) + loanamount).ToString();
            var expected = "2200";

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void OpenAccount_ShouldAddTheAccount()
        {

            var customer = new Customer("John", "123", new Dictionary<string, List<string>>());


            string newAccount = "Nytt konto";
            string curchoice = "$";

            BankSystem.OpenAccount(customer, newAccount, curchoice);

            Assert.IsTrue(customer.accounts.ContainsKey("Nytt konto"));

        }
    }
}
