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
    public class ExoneracionController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Exoneracion exoneracion = new Exoneracion();
            exoneracion.TipoDocumento1 = form.Get("TipoDoc");
            exoneracion.NumeroDocumento1 = form.Get("NumDoc");
            exoneracion.NombreInstitucion1 = form.Get("NomIns");
            exoneracion.FechaEmision1 = Convert.ToDateTime(form.Get("FechaEmision"));
            exoneracion.PorcentajeExoneracion1 = Convert.ToInt32(form.Get("Porcentaje"));
            exoneracion.MontoExoneracion1 = Convert.ToDecimal(form.Get("Monto"));

            string[] respuesta = new string[3];
            respuesta[0] = exoneracion.Update_Exoneracion();
            respuesta[1] = form.Get("TipoDoc");
            respuesta[2] = form.Get("NumDoc");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Exoneracion exoneracion = new Exoneracion();
            exoneracion.TipoDocumento1 = form.Get("TipoDoc");
            exoneracion.NumeroDocumento1 = form.Get("NumDoc");
            exoneracion.NombreInstitucion1 = form.Get("NomIns");
            exoneracion.FechaEmision1 = Convert.ToDateTime(form.Get("FechaEmision"));
            exoneracion.PorcentajeExoneracion1 = Convert.ToInt32(form.Get("Porcentaje"));
            exoneracion.MontoExoneracion1 = Convert.ToDecimal(form.Get("Monto"));

            string[] respuesta = new string[3];
            respuesta[0] = exoneracion.Insert_Exoneracion();
            respuesta[1] = form.Get("TipoDoc");
            respuesta[2] = form.Get("NumDoc");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Exoneracion exoneracion = new Exoneracion();
            exoneracion.TipoDocumento1 = form.Get("TipoDoc");
            exoneracion.NumeroDocumento1 = form.Get("NumDoc");

            string[] respuesta = new string[3];
            respuesta[0] = exoneracion.Delete_Exoneracion();
            respuesta[1] = form.Get("TipoDoc");
            respuesta[2] = form.Get("NumDoc");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Exoneracion exoneracion = new Exoneracion();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Exoneracion>>(HttpStatusCode.Created, exoneracion.Select_Todo_Exoneracion());
            return response;
        }
    }
}
