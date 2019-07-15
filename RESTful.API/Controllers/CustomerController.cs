using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RESTful.API.Models;
using System.Web.Script.Serialization;

namespace RESTful.API.Controllers
{
    public class CustomerController : ApiController
    {
        #region GET REQUESTS
        [HttpGet]
        [Route("api/v1/customers")]
        public Response<List<CustomerDetails>> GetCustomers()
        {
            return new Response<List<CustomerDetails>>() {
                Code = Status.Success, ErrorMessage = "", Body = CustomerMockData.CustomerList
            };
        }

        [HttpGet]
        [Route("api/v1/customers/{Id}/orders")]
        public Response<List<CustomerOrder>> GetCustomerOrder(int Id)
        {
            return new Response<List<CustomerOrder>>()
            {
                Code = Status.Success,
                ErrorMessage = "",
                Body = OrderMockData.CustomerOrders.Where(x=>x.CustomerId == Id).ToList()
            };

        }

        #endregion

        #region POST REQUESTS
        [HttpPost]
        [Route("api/v1/customers")]
        public Response<string> AddNewCustomer(Models.CustomerDetails customer)
        {
            CustomerMockData.CustomerList.Add(customer);
            return new Response<string>() {
                Body = "Customer Added",
                Code = Status.Success
            };
        }
       
        [HttpPost]
        [Route("api/v1/customers/{Id}")]
        public Response<CustomerDetails> GetCustomer(int Id)
        {
            return new Response<CustomerDetails>() {
                Body = CustomerMockData.CustomerList.Where(x => x.Id == Id).FirstOrDefault(),
                Code = Status.Success,
            };
        }

        [HttpPost]
        [Route("api/v1/customers/{Id}/orders")]
        public Response<string> CreateCustomerOrder(int Id, [FromBody]CustomerOrder orderDetails)
        {
            var CustDetails = OrderMockData.CustomerOrders.Where(x => x.CustomerId == Id).FirstOrDefault();
            CustDetails.OrderList.Add( new Order() { 
                Id = 2,
                Amount = new Price() { Amount = orderDetails.OrderList[0].Amount.Amount, Currency = orderDetails.OrderList[0].Amount.Currency}
            });

            return new Response<string>()
            {
                Code = Status.Success,
                ErrorMessage = "",
                Body = "Order Created."
            };
        }
        #endregion

        #region PUT REQUESTS
        [HttpPut]
        [Route("api/v1/customers")]
        public void UpdateAllCustomers()
        {

        }

        [HttpPut]
        [Route("api/v1/customers/{Id}")]
        public Response<string> UpdateCustomer(int Id,Models.CustomerDetails customerDetails)
        {
            var customer = CustomerMockData.CustomerList.Where(x => x.Id == Id).FirstOrDefault();
            customer.FullName = customerDetails.FullName;
            customer.PhoneNumber = customerDetails.PhoneNumber;
            return new Response<string>() { Body = "Updated.", Code = Status.Success};
        }

        [HttpPut]
        [Route("api/v1/customers/{Id}/orders")]
        public Response<string> UpdateCustomerOrders(int Id, [FromBody]JsonPatch.Model.PatchOperation fieldvalue)
        {
            var CustDetails = OrderMockData.CustomerOrders.Where(x => x.CustomerId == Id).FirstOrDefault();
            var CustOrders = CustDetails.OrderList;
            var op = new JsonPatch.JsonPatchDocument<Order>();
            foreach (var order in CustOrders)
            {
                op.Add(fieldvalue.path, fieldvalue.value);
                op.ApplyUpdatesTo(order);
            }
            return new Response<string>() { Body = "Updated.", Code = Status.Success };
        }

        #endregion

        #region PATCH REQUESTS
        [HttpPatch]
        [Route("api/v1/customers")]
        public Response<string> UpdateAllCustomerField([FromBody]JsonPatch.Model.PatchOperation fieldvalue)
        {
            var existingcustomer = CustomerMockData.CustomerList;
            var op = new JsonPatch.JsonPatchDocument<CustomerDetails>();
            foreach (CustomerDetails c in existingcustomer) {
                op.Add(fieldvalue.path, fieldvalue.value);
                op.ApplyUpdatesTo(c);
            }
            return new Response<string>() { Body = "Updated successfully.", Code = Status.Success };
        }

        [HttpPatch]
        [Route("api/v1/customers/{Id}")]
        public Response<string> UpdateCustomerField(int Id, [FromBody]JsonPatch.Model.PatchOperation fieldvalue)
        {
            var existingcustomer = CustomerMockData.CustomerList.Where(x => x.Id == Id).FirstOrDefault();
            var op = new JsonPatch.JsonPatchDocument<CustomerDetails>();
            op.Add(fieldvalue.path, fieldvalue.value);
            op.ApplyUpdatesTo(existingcustomer);
            return new Response<string>() { Body = "Updated successfully.", Code = Status.Success };
        }

        [HttpPatch]
        [Route("api/v1/customers/{Id}")]
        public Response<string> UpdateCustomerOrdersField(int Id, [FromBody]JsonPatch.Model.PatchOperation fieldvalue)
        {
            var existingcustomer = CustomerMockData.CustomerList.Where(x => x.Id == Id).FirstOrDefault();
            var op = new JsonPatch.JsonPatchDocument<CustomerDetails>();
            op.Add(fieldvalue.path, fieldvalue.value);
            op.ApplyUpdatesTo(existingcustomer);
            return new Response<string>() { Body = "Updated successfully.", Code = Status.Success };
        }



        //[HttpPatch]
        //[Route("api/v1/customers/{Id}")]
        //public Response<string> UpdateCustomerField(int Id, CustomerDetails newupdate)
        //{
        //    CustomerDetails CustomerUpdate = CustomerMockData.CustomerList.Where(x => x.Id == Id).FirstOrDefault();
        //    if (CustomerUpdate != null)
        //    {
        //        CustomerUpdate.FullName = newupdate.FullName;
        //        CustomerUpdate.PhoneNumber = newupdate.PhoneNumber;
        //        return new Response<string>() { Body = "Updated successfully.", Code = Status.Success };
        //    }
        //    return new Response<string>() { Body = "Customer not found.", Code = Status.Warning };
        //}
        #endregion

        #region DELETE REQUESTS
        [HttpDelete]
        [Route("api/v1/customers")]
        public Response<string> DeleteAllCustomers()
        {
            CustomerMockData.CustomerList.RemoveAll(x=>x.Id > 0);
            return new Response<string>() { Body = "All deleted.", Code = Status.Success };
        }

        [HttpDelete]
        [Route("api/v1/customers/{Id}")]
        public Response<string> DeleteCustomer(int Id)
        {
            var ExistinfCustomer = CustomerMockData.CustomerList.Where(x => x.Id == Id).FirstOrDefault();
            CustomerMockData.CustomerList.Remove(ExistinfCustomer);
            return new Response<string>() { Body = "Deleted.", Code = Status.Success };
        }

        [HttpDelete]
        [Route("api/v1/customers/{Id}/orders/")]
        public Response<string> DeleteCustomerOrders(int Id)
        {
            var order = OrderMockData.CustomerOrders.RemoveAll(x=>x.CustomerId == Id);
            return new Response<string>() {
                 Body="Orders deleted.",
                 Code = Status.Success
            };
        }

        #endregion
    }
}
