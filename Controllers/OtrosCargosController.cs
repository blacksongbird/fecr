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
    public class OtrosCargosController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            OtrosCargos otroscargos = new OtrosCargos();
            otroscargos.TipoDocumento1 = form.Get("TipoDoc");
            otroscargos.NumeroIdentidadTercero1 = form.Get("NumIdTercero");
            otroscargos.NombreTercero1 = form.Get("NombreTercero");
            otroscargos.Detalle1 = form.Get("Detalle");
            otroscargos.Porcentaje1 = Convert.ToDecimal(form.Get("Porcentaje"));
            otroscargos.MontoCargo1 = Convert.ToDecimal(form.Get("MontoCargo"));

            Factura clavefactura = new Factura();
            clavefactura.Clave1 = form.Get("Clave");
            DetalleServicio clave = new DetalleServicio();
            clave.Clave1 = clavefactura;
            otroscargos.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = otroscargos.Update_OtrosCargos();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            OtrosCargos otroscargos = new OtrosCargos();
            otroscargos.TipoDocumento1 = form.Get("TipoDoc");
            otroscargos.NumeroIdentidadTercero1 = form.Get("NumIdTercero");
            otroscargos.NombreTercero1 = form.Get("NombreTercero");
            otroscargos.Detalle1 = form.Get("Detalle");
            otroscargos.Porcentaje1 = Convert.ToDecimal(form.Get("Porcentaje"));
            otroscargos.MontoCargo1 = Convert.ToDecimal(form.Get("MontoCargo"));

            Factura clavefactura = new Factura();
            clavefactura.Clave1 = form.Get("Clave");
            DetalleServicio clave = new DetalleServicio();
            clave.Clave1 = clavefactura;
            otroscargos.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = otroscargos.Insert_OtrosCargos();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            OtrosCargos otroscargos = new OtrosCargos();

            Factura clavefactura = new Factura();
            clavefactura.Clave1 = form.Get("Clave");
            DetalleServicio clave = new DetalleServicio();
            clave.Clave1 = clavefactura;
            otroscargos.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = otroscargos.Delete_OtrosCargos();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            OtrosCargos otroscargos = new OtrosCargos();

            Factura clavefactura = new Factura();
            clavefactura.Clave1 = id;
            DetalleServicio clave = new DetalleServicio();
            clave.Clave1 = clavefactura;
            otroscargos.Clave1 = clave;

            HttpResponseMessage response = Request.CreateResponse<Models.OtrosCargos>(HttpStatusCode.Created, otroscargos.Select_OtrosCargos());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            OtrosCargos otroscargos = new OtrosCargos();

            HttpResponseMessage response = Request.CreateResponse<List<Models.OtrosCargos>>(HttpStatusCode.Created, otroscargos.Select_Todo_OtrosCargos());
            return response;
        }
    }
}
