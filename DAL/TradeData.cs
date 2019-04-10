using System;

namespace Binance.Models
{
    public class TradeData
    {
        public long Id { get; set; }
        public string e { get; set; }
        public DateTime E { get; set; }
        public string s { get; set; }
        public long a { get; set; }
        public decimal p { get; set; }
        public decimal q { get; set; }
        public long f { get; set; }
        public long l { get; set; }
        public DateTime T { get; set; }
        public bool m { get; set; }
        public bool M { get; set; }
    }
}