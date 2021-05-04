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
    public class ResumenFacturaController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            ResumenFactura resumenfactura = new ResumenFactura();
            resumenfactura.TotalServGravados1 = Convert.ToDecimal(form.Get("TotalServGravados"));
            resumenfactura.TotalServExentos1 = Convert.ToDecimal(form.Get("TotalServExentos"));
            resumenfactura.TotalServExonerado1 = Convert.ToDecimal(form.Get("TotalServExonerado"));
            resumenfactura.TotalMercanciasGravadas1 = Convert.ToDecimal(form.Get("TotalMercanciasGravadas"));
            resumenfactura.TotalMercanciasExentas1 = Convert.ToDecimal(form.Get("TotalMercanciasExentas"));
            resumenfactura.TotalMercanciasExoneradas1 = Convert.ToDecimal(form.Get("TotalMercanciasExoneradas"));
            resumenfactura.TotalGravado1 = Convert.ToDecimal(form.Get("TotalGravado"));
            resumenfactura.TotalExento1 = Convert.ToDecimal(form.Get("TotalExento"));
            resumenfactura.TotalExonerado1 = Convert.ToDecimal(form.Get("TotalExonerado"));
            resumenfactura.TotalVenta1 = Convert.ToDecimal(form.Get("TotalVenta"));
            resumenfactura.TotalDescuentos1 = Convert.ToDecimal(form.Get("TotalDescuentos"));
            resumenfactura.TotalVentaNeta1 = Convert.ToDecimal(form.Get("TotalVentaNeta"));
            resumenfactura.TotalImpuesto1 = Convert.ToDecimal(form.Get("TotalImpuesto"));
            resumenfactura.TotalIVADevuelto1 = Convert.ToDecimal(form.Get("TotalIVADevuelto"));
            resumenfactura.TotalOtrosCargos1 = Convert.ToDecimal(form.Get("TotalOtrosCargos"));
            resumenfactura.TotalComprobante1 = Convert.ToDecimal(form.Get("TotalComprobante"));
            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            resumenfactura.Clave1 = clave;
            CodigoTipoMoneda codigomoneda = new CodigoTipoMoneda();
            codigomoneda.CodigoMoneda1 = form.Get("CodigoTipoMoneda");
            resumenfactura.CodigoTipoMoneda1 = codigomoneda;


            string[] respuesta = new string[2];
            respuesta[0] = resumenfactura.Update_ResumenFactura();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            ResumenFactura resumenfactura = new ResumenFactura();
            resumenfactura.TotalServGravados1 = Convert.ToDecimal(form.Get("TotalServGravados"));
            resumenfactura.TotalServExentos1 = Convert.ToDecimal(form.Get("TotalServExentos"));
            resumenfactura.TotalServExonerado1 = Convert.ToDecimal(form.Get("TotalServExonerado"));
            resumenfactura.TotalMercanciasGravadas1 = Convert.ToDecimal(form.Get("TotalMercanciasGravadas"));
            resumenfactura.TotalMercanciasExentas1 = Convert.ToDecimal(form.Get("TotalMercanciasExentas"));
            resumenfactura.TotalMercanciasExoneradas1 = Convert.ToDecimal(form.Get("TotalMercanciasExoneradas"));
            resumenfactura.TotalGravado1 = Convert.ToDecimal(form.Get("TotalGravado"));
            resumenfactura.TotalExento1 = Convert.ToDecimal(form.Get("TotalExento"));
            resumenfactura.TotalExonerado1 = Convert.ToDecimal(form.Get("TotalExonerado"));
            resumenfactura.TotalVenta1 = Convert.ToDecimal(form.Get("TotalVenta"));
            resumenfactura.TotalDescuentos1 = Convert.ToDecimal(form.Get("TotalDescuentos"));
            resumenfactura.TotalVentaNeta1 = Convert.ToDecimal(form.Get("TotalVentaNeta"));
            resumenfactura.TotalImpuesto1 = Convert.ToDecimal(form.Get("TotalImpuesto"));
            resumenfactura.TotalIVADevuelto1 = Convert.ToDecimal(form.Get("TotalIVADevuelto"));
            resumenfactura.TotalOtrosCargos1 = Convert.ToDecimal(form.Get("TotalOtrosCargos"));
            resumenfactura.TotalComprobante1 = Convert.ToDecimal(form.Get("TotalComprobante"));

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            resumenfactura.Clave1 = clave;

            CodigoTipoMoneda codigomoneda = new CodigoTipoMoneda();
            codigomoneda.CodigoMoneda1 = form.Get("CodigoTipoMoneda");
            resumenfactura.CodigoTipoMoneda1 = codigomoneda;

            string[] respuesta = new string[2];
            respuesta[0] = resumenfactura.Insert_ResumenFactura();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            ResumenFactura resumenfactura = new ResumenFactura();

            Factura clave = new Factura();
            clave.Clave1 = form.Get("Clave");
            resumenfactura.Clave1 = clave;

            string[] respuesta = new string[2];
            respuesta[0] = resumenfactura.Delete_ResumenFactura();
            respuesta[1] = form.Get("Clave");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            ResumenFactura resumenfactura = new ResumenFactura();
            Factura clave = new Factura();
            clave.Clave1 = id;
            resumenfactura.Clave1 = clave;

            HttpResponseMessage response = Request.CreateResponse<Models.ResumenFactura>(HttpStatusCode.Created, resumenfactura.Select_ResumenFactura());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            ResumenFactura resumenfactura = new ResumenFactura();

            HttpResponseMessage response = Request.CreateResponse<List<Models.ResumenFactura>>(HttpStatusCode.Created, resumenfactura.Select_Todo_ResumenFactura());
            return response;
        }
    }
}
