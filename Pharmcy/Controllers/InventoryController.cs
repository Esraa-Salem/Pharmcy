using Dapper;
using Pharmcy.Attributes;
using Pharmcy.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Pharmcy.Controllers
{
    public class InventoryController : ApiController
    {
     

            [HttpGet]
            public async Task<HttpResponseMessage> GetAllInventories(int page_number = 1, int limit =5)
            {

                using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
                {
                    try
                    {
                        var parms = new DynamicParameters();
                        parms.Add("@page_number", page_number);
                        parms.Add("@LIMIT", limit);
                        var results = await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("GetAllInventories", parms, commandType: CommandType.StoredProcedure, transaction: transaction);

                        List<dynamic> inventories = results.Read<dynamic>().ToList();

                        HttpContext.Current.Response.Headers.Add("Inventories-total-records", results.Read<int>().FirstOrDefault().ToString());
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK, inventories);


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }

                }
            }

            // GET api/<controller>/5
            [HttpGet]
            public async Task<HttpResponseMessage> GetInventoryUsingId(int id)
            {
                using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
                {
                    try
                    {
                        var parms = new DynamicParameters();
                        parms.Add("@INV_ID", id);

                        IEnumerable<Inventory> inventory = await SingletonSqlConnection.Instance.Connection.QueryAsync<Inventory>
                                                                 ("GetInventoryById", parms, commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK, inventory.First());


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }

                }
            }

            // POST api/<controller>
            [HttpPost]
            public async Task<HttpResponseMessage> PostInventory([FromBody] Inventory inventory)
            {
                using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
                {
                    try
                    {
                        var parms = new DynamicParameters();
                        parms.Add("@INV_Name", inventory.in_name);
                        parms.Add("@INV_LOCATION", inventory.in_location);

                        IEnumerable<Inventory> Inventories = await SingletonSqlConnection.Instance.Connection.QueryAsync<Inventory>
                                                                 ("PostInventory", parms, commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.Created, Messages.InsertedSuccessfully("Inventory"));


                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }

                }
            }

            // PUT api/<controller>/5
            [HttpPut]
            public async Task<HttpResponseMessage> PutInventory(int INV_ID, [FromBody] Inventory inventory)
            {
                using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
                {
                    try
                    {
                        var parms = new DynamicParameters();

                        parms.Add("@INV_ID", INV_ID);
                        parms.Add("@INV_Name", inventory.in_name);
                        parms.Add("@INV_LOCATION", inventory.in_location);

                        IEnumerable<Inventory> Inventories = await SingletonSqlConnection.Instance.Connection.QueryAsync<Inventory>
                                                                 ("PutInventory", parms, commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.OK, Messages.UpdatedSuccessfully("Inventory"));

                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                    }

                }
            }

            // DELETE api/<controller>/5
            [HttpDelete]
            public async Task<HttpResponseMessage> DeleteInventory(int INV_ID)
            {
                using (SqlTransaction transaction = SingletonSqlConnection.Instance.Connection.BeginTransaction())
                {
                    try
                    {
                        var parms = new DynamicParameters();
                        parms.Add("@INV_ID", INV_ID);


                        IEnumerable<Inventory> Inventories = await SingletonSqlConnection.Instance.Connection.QueryAsync<Inventory>
                                                                 ("DeleteInventory", parms, commandType: CommandType.StoredProcedure, transaction: transaction);
                        transaction.Commit();
                        return Request.CreateResponse(HttpStatusCode.NoContent, Messages.DeletedSuccessfully("Inventory"));


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

