using Dapper;
using Pharmcy.Attributes;
using Pharmcy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Pharmcy.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]
        // GET api/Customers
        public async Task<HttpResponseMessage> GetAllCustomers([FromUri] int page_number, int limit)
        {
            try
            {
                var Paramaters = new DynamicParameters();
                Paramaters.Add("@Page_Number", page_number);
                Paramaters.Add("@Limit", limit);

                var results = await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("GetAllCustomers", Paramaters, commandType: CommandType.StoredProcedure);

                IEnumerable<Customer> customers = results.Read<Customer>().ToList();

                HttpContext.Current.Response.Headers.Add("Customers-total-count", results.Read<int>().FirstOrDefault().ToString());

                return Request.CreateResponse(HttpStatusCode.OK, customers);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }


        // GET api/<controller>/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetCustomer(int c_id)
        {

            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@c_id", c_id);

                IEnumerable<Customer> customer = await SingletonSqlConnection.Instance.Connection.QueryAsync<Customer>
                    ("GetCustomer", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // POST api/<controller>
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> PostCustomer([FromBody] Customer customer)
        {
                try
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@c_name", customer.c_name);
                    Parameters.Add("@c_phone", customer.c_phone);
                    Parameters.Add("@c_email", customer.c_email);

                    IEnumerable <Customer> cust = await SingletonSqlConnection.Instance.Connection.QueryAsync<Customer>(
                        "InsertCustomer", Parameters, commandType: CommandType.StoredProcedure);
                    return Request.CreateResponse(HttpStatusCode.Created, "Inserted Successfully");
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            
        }
        // PUT api/<controller>/5
        [System.Web.Http.HttpPut]
    
       
        //under moderating
        public async Task<HttpResponseMessage> PutCustomer(int c_id, [FromBody] Customer customer)
        {
            try
            {

                var Parmaters = new DynamicParameters();
                Parmaters.Add("@c_id", c_id);
                Parmaters.Add("@c_name", customer.c_name);
                Parmaters.Add("@c_phone", customer.c_phone);
                Parmaters.Add("@c_email", customer.c_email);



                IEnumerable<int> UpdatedCustomer = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>(
                    "UpdateCustomer", Parmaters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.UpdatedSuccessfully("Customer"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }







        // DELETE api/<controller>/5
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> DeleteCustomerByIsDeleted(int c_id)
        {
            using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
            {
                try
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@c_id", c_id);

                    IEnumerable<dynamic> customer = await SingletonSqlConnection.Instance.Connection.QueryAsync<dynamic>(
                        "DeleteByIsDeleted", Parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                    transaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, Messages.DeletedSuccessfully("Customer"));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
        }
    
 
        [System.Web.Http.HttpDelete]
        public async Task<HttpResponseMessage> DeleteCustomerTransaction(int c_id)
        {
            using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
            {
                try
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@c_id", c_id);

                    IEnumerable<dynamic> customer = await SingletonSqlConnection.Instance.Connection.QueryAsync<dynamic>(
                        "InsertAndDeleteInTransaction", Parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                    transaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, Messages.DeletedSuccessfully("Customer"));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
        }
        public async Task<HttpResponseMessage> DeleteCustomerPermenant(int c_id)
        {
            using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
            {
                try
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@c_id", c_id);

                    IEnumerable<dynamic> customer = await SingletonSqlConnection.Instance.Connection.QueryAsync<dynamic>(
                        "DeleteCustomer", Parameters, commandType: CommandType.StoredProcedure, transaction: transaction);
                    transaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, Messages.DeletedSuccessfully("Customer"));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                }
            }
        }

    }
}