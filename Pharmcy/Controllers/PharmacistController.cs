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
using System.Web.Mvc;
using Dapper;
using System.Data;
using WebGrease.Css.Extensions;
using System.Web;
using System.Web.Util;

namespace Pharmcy.Controllers
{
    public class PharmacistController : ApiController
    {
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetAllPharmacist([FromUri] int num_pages,int limit)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@num_pages", num_pages);
                Parameters.Add("@limit", limit);
                 var resultes = await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("GetAllPharmacist",
                    Parameters,commandType: CommandType.StoredProcedure);
                List<Pharmacist> ph= resultes.Read<Pharmacist>().ToList();
                HttpContext.Current.Response.Headers.Add("total_Pharmacists", resultes.Read<int>().FirstOrDefault().ToString());
                return Request.CreateResponse(HttpStatusCode.OK,ph );

            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }

            
             


    }

        // GET api/values/5
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetPharmacist(int id)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ph_id", id);
               IEnumerable<Pharmacist>ph=await SingletonSqlConnection.Instance.Connection.QueryAsync<Pharmacist>("GetPharmacist",
                    Parameters, commandType: CommandType.StoredProcedure);
                
                return Request.CreateResponse(HttpStatusCode.OK, ph.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> PostPharmacist([FromBody] Pharmacist ph)
        {
             
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@ph_name", ph.ph_name);
                Parameters.Add("@ph_salary", ph.ph_salary);
                Parameters.Add("@ph_email", ph.ph_email);
                IEnumerable <int> er= await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("PostPharmacist", Parameters,
                    commandType: CommandType.StoredProcedure);
                
                return Request.CreateResponse(HttpStatusCode.OK, Messages.InsertedSuccessfully("Pharmacist"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,Messages.Exception(ex));
            }
        }

        // PUT api/values/5
        [System.Web.Http.HttpPut]
        public async Task<HttpResponseMessage> PutPharmacist(int id, [FromBody] Pharmacist ph)
        {
             
            try
            {
                var Parameters= new DynamicParameters();
                Parameters.Add("@ph_name", ph.ph_name);
                Parameters.Add("@ph_salary", ph.ph_salary);
                Parameters.Add("@ph_email", ph.ph_email);
                Parameters.Add("@ph_id", id);
                IEnumerable<int> re = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("putpharmacist", Parameters,
                    commandType: CommandType.StoredProcedure);
         
                return Request.CreateResponse(HttpStatusCode.OK,Messages.UpdatedSuccessfully("Pharmacist"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest,Messages.Exception(ex));
            }
        }

        // DELETE api/values/5
        [System.Web.Http.HttpDelete]
        public async Task<HttpResponseMessage> DeletePharmacist(int id)
        {
            using (SqlTransaction transaction=SingletonSqlConnection.Instance.Connection.BeginTransaction())
            {
                try
                {
                    var Parameters = new DynamicParameters();
                    Parameters.Add("@ph_id", id);
                    IEnumerable<int> ph = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("DeletePharmacist", Parameters,
                        commandType: CommandType.StoredProcedure, transaction: transaction);
                    transaction.Commit();
                    return Request.CreateResponse(HttpStatusCode.OK, Messages.DeletedSuccessfully("Pharmacist"));
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
                }
            }
        }
    }
}
