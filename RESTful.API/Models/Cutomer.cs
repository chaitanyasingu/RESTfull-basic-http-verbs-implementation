using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful.API.Models
{
    public class Customer
    {
        public int Id { get; set; }
    }

    public class CustomerDetails : Customer
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsSalaryCredited { get; set; }
    }

    public static class CustomerMockData
    {
        public static List<CustomerDetails> CustomerList = new List<CustomerDetails>() {
            new CustomerDetails() {Id = 1, FullName = "Aalder van Linden", PhoneNumber = "0634343434" },
            new CustomerDetails() {Id = 2, FullName = "Michael van Linden", PhoneNumber = "0634343435" },
            new CustomerDetails() {Id = 3, FullName = "Jphn Voost", PhoneNumber = "0634343436" },
            new CustomerDetails() {Id = 4, FullName = "Jasper Kragt", PhoneNumber = "0634343437" },
            new CustomerDetails() {Id = 5, FullName = "Remko Leviers", PhoneNumber = "0634343438" },
            new CustomerDetails() {Id = 6, FullName = "Detlef", PhoneNumber = "0634343439" },
        };
    }
}