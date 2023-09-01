using Pharmcy.Attributes;
using Pharmcy.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Pharmcy.Controllers
{
    public class CustomerController : ApiController
    {
        [HttpGet]

        public async Task<HttpResponseMessage> GetAllCustomers()
        {
            try
            {


                SqlConnection conn = new SqlConnection(ConnectionString.constr());

                string query = "exec sp_executesql @SQL ";

                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL", "GetAllCustomers");
                SqlDataReader reader = comm.ExecuteReader();
                List<Customer> cust = new List<Customer>();
                while (reader.Read())
                {
                    cust.Add(new Customer()
                    {
                        c_id = int.Parse(reader[0].ToString()),
                        c_name = reader[1].ToString(),
                        c_email = reader[2].ToString(),
                        c_phone = reader[3].ToString()
                    });

                }
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, cust);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET api/<controller>/5
        [HttpGet]
        public async Task<HttpResponseMessage> GetCustomer(int id)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConnectionString.constr());

                string query = "EXEC sp_executesql @SQL1 ,@Params1,@c_id";
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL1", "GetCustomer @c_id");
                comm.Parameters.AddWithValue("@Params1", "@c_id int");
                comm.Parameters.AddWithValue("@c_id", id);

                using (SqlDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Customer cust = (new Customer()
                        {
                            c_id = int.Parse(reader[0].ToString()),
                            c_name = reader[1].ToString(),
                            c_email = reader[2].ToString(),
                            c_phone = reader[3].ToString()
                        });

                        conn.Close();
                        return Request.CreateResponse(HttpStatusCode.OK, cust);
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound);
                    }
                }

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> PostCustomer([FromBody] Customer cust)
        {
            int er = -1;
            try
            {

                SqlConnection conn = new SqlConnection(ConnectionString.constr());
                string query = "EXEC sp_executesql @SQL, @Params,@c_name,@c_phone, @c_email ;";
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL", "InsertCustomer @c_name,@c_phone,@c_email");
                comm.Parameters.AddWithValue("@Params", "@c_name varchar(50),@c_phone char(11),@c_email varchar(50)");
                comm.Parameters.AddWithValue("@c_name", cust.c_name);
                comm.Parameters.AddWithValue("@c_phone", cust.c_phone);
                comm.Parameters.AddWithValue("@c_email", cust.c_email);
                er = comm.ExecuteNonQuery();
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, "Inserted " + er + " Row Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT api/<controller>/5
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> PutCustomer(int id, [FromBody] Customer cust)
        {
            int er = -1;
            try
            {

                SqlConnection conn = new SqlConnection(ConnectionString.constr());

                string query = "EXEC sp_executesql @SQL, @Params,@c_id, @c_name,@c_phone , @c_email";
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL", "UpdateCustomer @c_id, @c_name,@c_phone,@c_email");
                comm.Parameters.AddWithValue("@Params", "@c_id int ,@c_name varchar(50),@c_phone char(11),@c_email varchar(50)");
                comm.Parameters.AddWithValue("@c_id ", id);
                comm.Parameters.AddWithValue("@c_name", cust.c_name);
                comm.Parameters.AddWithValue("@c_phone", cust.c_phone);
                comm.Parameters.AddWithValue("@c_email", cust.c_email);
                er = comm.ExecuteNonQuery();
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, "Updated Successfully" );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }



        // DELETE api/<controller>/5
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> DeleteCustomerByIsDeleted(int id)
        {
            int er = -1;

            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString.constr());
                Customer cust = new Customer();
                string query;

                query = " EXEC sp_executesql @SQL, @Params,@c_id";
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL", "DeleteByIsDeleted @c_id");
                comm.Parameters.AddWithValue("@Params", "@c_id int");
                comm.Parameters.AddWithValue("@c_id", id);
                er = comm.ExecuteNonQuery();
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted "+er+" Row Successfully " );
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [System.Web.Http.HttpDelete]

        public async Task<HttpResponseMessage> DeleteCustomerTransaction(int id)
        {
            try
            {

                SqlConnection conn = new SqlConnection(ConnectionString.constr());
                Customer cust = new Customer();
                string query;
                query = " EXEC sp_executesql @SQL, @Params,@c_id";
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL", "InsertAndDeleteInTransaction @c_id");
                comm.Parameters.AddWithValue("@Params", "@c_id INT");
                comm.Parameters.AddWithValue("@c_id", id);
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
        [System.Web.Http.HttpDelete]

        public async Task<HttpResponseMessage> DeleteCustomerPermenant(int id)
        {
            int er = -1;
            try
            {

                SqlConnection conn = new SqlConnection(ConnectionString.constr());
                Customer cust = new Customer();
                string query;
                query = "EXEC sp_executesql @SQL, @Params,@c_id";
                conn.Open();
                SqlCommand comm = new SqlCommand(query, conn);
                comm.Parameters.AddWithValue("@SQL", "DeleteCustomer @c_id");
                comm.Parameters.AddWithValue("@Params", "@c_id int");
                comm.Parameters.AddWithValue("@c_id", id);
                er = comm.ExecuteNonQuery();
                conn.Close();
                return Request.CreateResponse(HttpStatusCode.OK, "Deleted "+er+" Row Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}