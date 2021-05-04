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
    public class IdentificacionController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = form.Get("Numero");
            identificacion.Tipo1 = form.Get("Tipo");

            string[] respuesta = new string[2];
            respuesta[0] = identificacion.Update_Identificacion();
            respuesta[1] = form.Get("Numero");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = form.Get("Numero");
            identificacion.Tipo1 = form.Get("Tipo");

            string[] respuesta = new string[2];
            respuesta[0] = identificacion.Insert_Identificacion();
            respuesta[1] = form.Get("Numero");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = form.Get("Numero");

            string[] respuesta = new string[2];
            respuesta[0] = identificacion.Delete_Identificacion();
            respuesta[1] = form.Get("Numero");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.Identificacion>(HttpStatusCode.Created, identificacion.Select_Identificacion());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Identificacion identificacion = new Identificacion();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Identificacion>>(HttpStatusCode.Created, identificacion.Select_Todo_Identificacion());
            return response;
        }
    }
}
