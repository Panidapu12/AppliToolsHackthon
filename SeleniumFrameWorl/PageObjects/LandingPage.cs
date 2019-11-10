using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliToolHackathon
{
    public class LandingPage
    {
        [FindsBy(How = How.Id, Using = "showExpensesChart")]
        public IWebElement ShowExpenseChartButton { get; set; }

        [FindsBy(How = How.Id, Using = "amount")]
        public IWebElement Amount_RecentTransactions { get; set; }
        [FindsBy(How = How.Id, Using = "transactionsTable")]
        public IWebElement RecentTransactionsTable { get; set; }

        [FindsBy(How = How.Id, Using = "flashSale")]
        public IWebElement flashSale1 { get; set; }

        [FindsBy(How = How.Id, Using = "flashSale2")]
        public IWebElement flashSale2 { get; set; }

    }
}
