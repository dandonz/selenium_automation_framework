using System;
namespace DataObjects
{
    /// <summary>
    /// Assignment Data Object
    /// </summary>
    public class Assignment
    {
        public string id { get; set; }
        public string assignmentdate { get; set; }
        public string cleanerid { get; set; }
        public string customerid { get; set; }
        public string workingdate { get; set; }
        public string customeraddress { get; set; }
        public string customername { get; set; }
        public string cleanerassignmentprice { get; set; }
        public string assignmentprice { get; set; }
    }
}
