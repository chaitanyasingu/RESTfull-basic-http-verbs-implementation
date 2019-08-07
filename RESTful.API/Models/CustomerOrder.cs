using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RESTful.API.Models
{
    public enum Currency
    {
        usd = 1,
        euro = 2,
        inr = 3


    }
    public class Price
    {
        public string Currency { get; set; }
        public double Amount { get; set; }
    }
    public class Order
    {
        public int Id { get; set; }
        public Price Amount { get; set; }
        public bool IsDelivered { get; set; }
    }

    public class CustomerOrder 
    {
        public int CustomerId { get; set; }
        public List<Order> OrderList{ get; set; }
    }

    public static class OrderMockData
    {
        public static List<CustomerOrder> CustomerOrders = new List<CustomerOrder>() {
            new CustomerOrder() { CustomerId = 1, OrderList = new List<Order>() {
                new Order() { Id =1, Amount = new Price() {Currency = Currency.euro.ToString(), Amount = 10.50 } }
            }
            },
            new CustomerOrder() { CustomerId = 2, OrderList = new List<Order>() {
                new Order() { Id =1, Amount = new Price() {Currency = Currency.euro.ToString(), Amount = 20.50 } },
                new Order() { Id =2, Amount = new Price() {Currency = Currency.euro.ToString(), Amount = 30.50 } },
                new Order() { Id =3, Amount = new Price() {Currency = Currency.euro.ToString(), Amount = 40.50 } }
            }
            },
            new CustomerOrder() { CustomerId = 3, OrderList = new List<Order>() {
                new Order() { Id =1, Amount = new Price() {Currency = Currency.euro.ToString(), Amount = 10.50 } },
                new Order() { Id =2, Amount = new Price() {Currency = Currency.euro.ToString(), Amount = 10.50 } }
            }
            }
        };
    }
}