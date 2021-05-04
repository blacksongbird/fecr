using FECR.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace FECR.Controllers
{
    public class FacturaController : ApiController
    {
        public class lineadetalle_local
        {
            [JsonProperty("Consecutivo")]
            public String Consecutivo1;
        }


        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Factura factura = new Factura();
            factura.CodigoActividad1 = form.Get("CodActividad");
            factura.Clave1 = form.Get("Clave");
            factura.NumeroConsecutivo1 = form.Get("NumConsecutivo");
            factura.FechaEmision1 = Convert.ToDateTime(form.Get("FechaEmision"));

            Identificacion idemisor = new Identificacion();
            idemisor.Numero1 = form.Get("Emisor");
            Persona emisor = new Persona();
            emisor.IdentificacionNumero1 = idemisor;
            factura.EmisorPersona1 = emisor;

            Identificacion idreceptor = new Identificacion();
            idreceptor.Numero1 = form.Get("Receptor");
            Persona receptor = new Persona();
            receptor.IdentificacionNumero1 = idreceptor;
            factura.ReceptorPersona1 = receptor;

            factura.CondicionVenta1 = form.Get("CondVenta");
            factura.PlazoCredito1 = form.Get("PlazoCredito");
            factura.MedioPago1 = form.Get("MedioPago");

            string[] respuesta = new string[2];
            respuesta[0] = factura.Update_Factura();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Models.Factura factura = new Factura();
            Models.DetalleServicio detalleservicio = new DetalleServicio();

            
            factura.CodigoActividad1 = form.Get("CodActividad");
            factura.Clave1 = form.Get("Clave");
            factura.NumeroConsecutivo1 = form.Get("NumConsecutivo");
            factura.FechaEmision1 = Convert.ToDateTime(form.Get("FechaEmision"));

            Identificacion idemisor = new Identificacion();
            idemisor.Numero1 = form.Get("Emisor");
            Persona emisor = new Persona();
            emisor.IdentificacionNumero1 = idemisor;
            factura.EmisorPersona1 = emisor;

            Identificacion idreceptor = new Identificacion();
            idreceptor.Numero1 = form.Get("Receptor");
            Persona receptor = new Persona();
            receptor.IdentificacionNumero1= idreceptor;
            factura.ReceptorPersona1 = receptor;

            factura.CondicionVenta1 = form.Get("CondVenta");
            factura.PlazoCredito1 = form.Get("PlazoCredito");
            factura.MedioPago1 = form.Get("MedioPago");

            var msgadevolver = factura.Insert_Factura();

            DetalleServicio detalleservicio1 = new DetalleServicio();
            detalleservicio1.Clave1 = factura;

            JArray jObject = JArray.Parse(form.Get("LineaDetalleFactura"));
            JToken jUser3 = jObject;
            var lista = jUser3.ToObject<List<lineadetalle_local>>();
            List<LineaDetalle> listalineadetalleobj = new List<LineaDetalle>();
            foreach (lineadetalle_local item in lista)
            {
                LineaDetalle lineadetalle = new LineaDetalle();
                lineadetalle.Consecutivo1 = Convert.ToInt32(item.Consecutivo1);
                listalineadetalleobj.Add(lineadetalle);
            }
            detalleservicio1.LineaDetalleFactura1 = listalineadetalleobj;

            detalleservicio1.Insert_DetalleServicio();

            string[] respuesta = new string[2];
            respuesta[0] = msgadevolver;
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Factura factura = new Factura();
            factura.Clave1 = form.Get("Clave");

            string[] respuesta = new string[2];
            respuesta[0] = factura.Delete_Factura();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            Factura factura = new Factura();
            factura.Clave1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Factura>(HttpStatusCode.Created, factura.Select_Factura());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Factura factura = new Factura();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Factura>>(HttpStatusCode.Created, factura.Select_Todo_Factura());
            return response;
        }
    }
}
