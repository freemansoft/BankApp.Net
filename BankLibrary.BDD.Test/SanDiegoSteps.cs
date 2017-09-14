using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BankLibrary.BDD.Test
{
    [Binding]
    public class SanDiegoSteps
    {
        [Given(@"I have an account with ""(.*)"" dollars in it")]
        public void GivenIHaveAnAccountWithDollarsInIt(int p0)
        {
            AccountExample account = new AccountExample(null);
            account.SetFirstName("Bill").SetLastName("Gates").SetupAccount();
            account.Deposit(new decimal(p0));
            ScenarioContext.Current.Add("account", account);

        }
        
        [When(@"I deposit ""(.*)"" dollars")]
        public void WhenIDepositDollars(int p0)
        {
            AccountExample account = ScenarioContext.Current.Get<AccountExample>("account");
            account.Deposit(new decimal(p0));
        }

        [When(@"I withdraw ""(.*)"" dollars")]
        public void WhenIWithdrawDollars(int p0)
        {
            AccountExample account = ScenarioContext.Current.Get<AccountExample>("account");
            account.Debit(new decimal(p0));
        }


        [Then(@"My balance should be ""(.*)"" dollars")]
        public void ThenMyBalanceShouldBeDollars(int p0)
        {
            AccountExample account = ScenarioContext.Current.Get<AccountExample>("account");
            Assert.AreEqual(new Decimal(p0), account.GetBalance());
        }
    }
}
