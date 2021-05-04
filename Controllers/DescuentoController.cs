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
    public class DescuentoController : ApiController
    {

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Descuento descuento = new Descuento();
            descuento.MontoDescuento1 = Convert.ToDecimal(form.Get("Monto"));
            descuento.NaturalezaDescuento = form.Get("Naturaleza");

            string[] respuesta = new string[3];
            respuesta[0] = descuento.Insert_Descuento();
            respuesta[1] = form.Get("Monto");
            respuesta[2] = form.Get("Naturaleza");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Descuento descuento = new Descuento();
            descuento.MontoDescuento1 = Convert.ToDecimal(form.Get("Monto"));
            descuento.NaturalezaDescuento = form.Get("Naturaleza");

            string[] respuesta = new string[3];
            respuesta[0] = descuento.Delete_Descuento();
            respuesta[1] = form.Get("Monto");
            respuesta[2] = form.Get("Naturaleza");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Descuento descuento = new Descuento();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Descuento>>(HttpStatusCode.Created, descuento.Select_Todo_Descuento());
            return response;
        }
    }
}
