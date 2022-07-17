using System;
namespace DataObjects
{
    //https://json2csharp.com/
    public class Customer
    {
        public string customerid { get; set; }
        public string active { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string servicetype { get; set; }
        public string serviceFrequency { get; set; }
        public DateTime startedworkingday { get; set; }
        public string furtherinstruction { get; set; }
        public double price { get; set; }
        public string paymentmethod { get; set; }
        public int cleanerprice { get; set; }
        public double duration { get; set; }
    }
}
