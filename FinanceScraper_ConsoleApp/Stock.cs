//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinanceScraper_ConsoleApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string LastPrice { get; set; }
        public string Change { get; set; }
        public string ChangeRate { get; set; }
        public string Currency { get; set; }
        public string MarketTime { get; set; }
        public string Volume { get; set; }
        public string Shares { get; set; }
        public string AverageVolume { get; set; }
        public string MarketCap { get; set; }
    }
}
