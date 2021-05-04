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
    public class ImpuestoController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Impuesto impuesto = new Impuesto();
            impuesto.Codigo1 = form.Get("Codigo");
            impuesto.CodigoTarifa1 = form.Get("CodTarifa");
            impuesto.Tarifa1 = Convert.ToDecimal(form.Get("Tarifa"));
            impuesto.FactorIVA1 = Convert.ToDecimal(form.Get("FactorIVA"));
            impuesto.Monto1 = Convert.ToDecimal(form.Get("Monto"));
            impuesto.MontoExportacion1 = Convert.ToDecimal(form.Get("MontoExportacion"));

            string[] respuesta = new string[2];
            respuesta[0] = impuesto.Update_Impuesto();
            respuesta[1] = form.Get("Codigo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Impuesto impuesto = new Impuesto();
            impuesto.Codigo1 = form.Get("Codigo");
            impuesto.CodigoTarifa1 = form.Get("CodTarifa");
            impuesto.Tarifa1 = Convert.ToDecimal(form.Get("Tarifa"));
            impuesto.FactorIVA1 = Convert.ToDecimal(form.Get("FactorIVA"));
            impuesto.Monto1 = Convert.ToDecimal(form.Get("Monto"));
            impuesto.MontoExportacion1 = Convert.ToDecimal(form.Get("MontoExportacion"));

            string[] respuesta = new string[2];
            respuesta[0] = impuesto.Insert_Impuesto();
            respuesta[1] = form.Get("Codigo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Impuesto impuesto = new Impuesto();
            impuesto.Codigo1 = form.Get("Codigo");

            string[] respuesta = new string[2];
            respuesta[0] = impuesto.Delete_Impuesto();
            respuesta[1] = form.Get("Codigo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Impuesto impuesto = new Impuesto();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Impuesto>>(HttpStatusCode.Created, impuesto.Select_Todo_Impuesto());
            return response;
        }
    }
}
