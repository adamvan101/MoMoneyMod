using ICities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MoMoneyMod
{
    public class MoMoney : IUserMod
    {
        public string Name
        {
            get
            {
                return "Mo' Money Mod";
            }
        }
        public string Description
        {
            get
            {
                return "Adds an entry box where you can give yourself a specific amount of money. Accidentally placed the wrong road and don't want to pay the price? Give yourself a full refund.";
            }
        }
    }
}