using System;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MPZ_Patterns.Facade
{
    public class TradeSystem
    {
        public Auction Auction { get; set; }
        
        public Market Market { get; set; }

        public int Trade(ResourceSet resourceSet) 
        {

        }
    }
}
