using OpenQA.Selenium.DevTools.V117.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_specflow
{
    internal class CustomerDeposit
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public CustomerDeposit() { Name = ""; Amount = ""; }
        public CustomerDeposit(string name, string amount) { Name = name; Amount = amount; }
    }
}
