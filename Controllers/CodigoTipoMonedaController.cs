using FECR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FECR.Controllers
{
    public class CodigoTipoMonedaController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            CodigoTipoMoneda codigotipomoneda = new CodigoTipoMoneda();
            codigotipomoneda.CodigoMoneda1 = form.Get("CodigoTipo");
            codigotipomoneda.TipoCambio1 = Convert.ToDecimal(form.Get("TipoCambio"));

            string[] respuesta = new string[2];
            respuesta[0] = codigotipomoneda.Update_CodigoTipoMoneda();
            respuesta[1] = form.Get("CodigoTipo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            CodigoTipoMoneda codigotipomoneda = new CodigoTipoMoneda();
            codigotipomoneda.CodigoMoneda1 = form.Get("CodigoTipo");
            codigotipomoneda.TipoCambio1 = Convert.ToDecimal(form.Get("TipoCambio"));

            string[] respuesta = new string[2];
            respuesta[0] = codigotipomoneda.Insert_CodigoTipoMoneda();
            respuesta[1] = form.Get("CodigoTipo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            CodigoTipoMoneda codigotipomoneda = new CodigoTipoMoneda();
            codigotipomoneda.CodigoMoneda1 = form.Get("CodigoTipo");

            string[] respuesta = new string[2];
            respuesta[0] = codigotipomoneda.Delete_CodigoTipoMoneda();
            respuesta[1] = form.Get("CodigoTipo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            CodigoTipoMoneda codigotipomoneda = new CodigoTipoMoneda();

            HttpResponseMessage response = Request.CreateResponse<List<Models.CodigoTipoMoneda>>(HttpStatusCode.Created, codigotipomoneda.Select_Todo_CodigoTipoMoneda());
            return response;
        }
    }
}
