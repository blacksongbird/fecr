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
    public class InformacionReferenciaController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            InformacionReferencia informacionreferencia = new InformacionReferencia();
            informacionreferencia.TipoDoc1 = form.Get("TipoDoc");
            informacionreferencia.Numero1 = form.Get("Numero");
            informacionreferencia.FechaEmision1 = Convert.ToDateTime(form.Get("FechaEmisionReferencia"));
            informacionreferencia.Codigo1 = form.Get("Codigo");
            informacionreferencia.Razon1 = form.Get("Razon");

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            informacionreferencia.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = informacionreferencia.Update_InformacionReferencia();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            InformacionReferencia informacionreferencia = new InformacionReferencia();
            informacionreferencia.TipoDoc1 = form.Get("TipoDoc");
            informacionreferencia.Numero1 = form.Get("Numero");
            informacionreferencia.FechaEmision1 = Convert.ToDateTime(form.Get("FechaEmisionReferencia"));
            informacionreferencia.Codigo1 = form.Get("Codigo");
            informacionreferencia.Razon1 = form.Get("Razon");

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            informacionreferencia.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = informacionreferencia.Insert_InformacionReferencia();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            InformacionReferencia informacionreferencia = new InformacionReferencia();

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            informacionreferencia.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = informacionreferencia.Delete_InformacionReferencia();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            InformacionReferencia informacionreferencia = new InformacionReferencia();
            Factura clave = new Factura();
            clave.Clave1 = id;
            informacionreferencia.Clave1 = clave;

            HttpResponseMessage response = Request.CreateResponse<Models.InformacionReferencia>(HttpStatusCode.Created, informacionreferencia.Select_InformacionReferencia());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            InformacionReferencia informacionreferencia = new InformacionReferencia();

            HttpResponseMessage response = Request.CreateResponse<List<Models.InformacionReferencia>>(HttpStatusCode.Created, informacionreferencia.Select_Todo_InformacionReferencia());
            return response;
        }
    }
}
