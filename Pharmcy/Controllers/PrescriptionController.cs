using Dapper;
using Pharmcy.Attributes;
using Pharmcy.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Pharmcy.Controllers
{
    public class PrescriptionController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> GetAll([FromUri] int PAGENO, int LIMIT)
        {
            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@PAGENO", PAGENO);
                Parameters.Add("@LIMIT", LIMIT);

                var results = await SingletonSqlConnection.Instance.Connection.QueryMultipleAsync("GetAll", Parameters, commandType: CommandType.StoredProcedure);

                List<Prescription> ins = results.Read<Prescription>().ToList();

                HttpContext.Current.Response.Headers.Add("Number of Prescription", results.Read<int>().FirstOrDefault().ToString());

                return Request.CreateResponse(HttpStatusCode.OK, ins);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }

        [HttpGet]

        public async Task<HttpResponseMessage> GetByID([FromUri] int p_id)
        {


            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("@p_id", p_id);

                IEnumerable<Prescription> ins = await SingletonSqlConnection.Instance.Connection.QueryAsync<Prescription>("GETByID", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, ins.First());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, Messages.Exception(ex));
            }
        }
        [HttpPost]
        public async Task<HttpResponseMessage> InsertPrescription([FromBody] Prescription pre)
        {

            try
            {

                var Parameters = new DynamicParameters();
                Parameters.Add("@p_date", pre.p_date);
                Parameters.Add("@ph_id", pre.ph_id);
                Parameters.Add("@cust_id", pre.cust_id);
               

                IEnumerable<int> re = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("insertPre", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.InsertedSuccessfully("Prescription"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Messages.Exception(ex));
            }
        }
        [HttpPut]
        public async Task<HttpResponseMessage> UpdatePrescription([FromBody] Prescription pre, [FromUri] int p_id)
        {

            try
            {

                var Parameters = new DynamicParameters();
                Parameters.Add("@p_id", p_id);
                Parameters.Add("@p_date", pre.p_date);
                Parameters.Add("@ph_id", pre.ph_id);
                Parameters.Add("@cust_id", pre.cust_id);

                IEnumerable<int> re = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("UpdatePre", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.UpdatedSuccessfully("Prescription"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Messages.Exception(ex));
            }
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeletePrescription([FromUri] int p_id)
        {

            try
            {
                var Parameters = new DynamicParameters();
                Parameters.Add("p_id", p_id);

                IEnumerable<int> re = await SingletonSqlConnection.Instance.Connection.QueryAsync<int>("DeletePre", Parameters, commandType: CommandType.StoredProcedure);

                return Request.CreateResponse(HttpStatusCode.OK, Messages.DeletedSuccessfully("Prescription"));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, Messages.Exception(ex));
            }
        }
    }
}
//author :Sara Mustafa