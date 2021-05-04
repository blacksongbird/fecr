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
    public class UbicacionController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.Provincia1 = form.Get("Provincia");
            ubicacion.Canton1 = form.Get("Canton");
            ubicacion.Distrito1 = form.Get("Distrito");
            ubicacion.Barrio1 = form.Get("Barrio");
            ubicacion.OtrasSenas1 = form.Get("OtrasSenas");
            ubicacion.ID1 = Convert.ToInt32(form.Get("ID"));

            string[] respuesta = new string[2];
            respuesta[0] = ubicacion.Update_Ubicacion();
            respuesta[1] = form.Get("ID");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.Provincia1 = form.Get("Provincia");
            ubicacion.Canton1 = form.Get("Canton");
            ubicacion.Distrito1 = form.Get("Distrito");
            ubicacion.Barrio1 = form.Get("Barrio");
            ubicacion.OtrasSenas1 = form.Get("OtrasSenas");
            ubicacion.ID1 = Convert.ToInt32(form.Get("ID"));

            string[] respuesta = new string[2];
            respuesta[0] = ubicacion.Insert_Ubicacion();
            respuesta[1] = form.Get("ID");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Ubicacion ubicacion = new Ubicacion();
            ubicacion.ID1 = Convert.ToInt32(form.Get("ID"));

            string[] respuesta = new string[2];
            respuesta[0] = ubicacion.Delete_Ubicacion();
            respuesta[1] = form.Get("ID");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Ubicacion ubicacion = new Ubicacion();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Ubicacion>>(HttpStatusCode.Created, ubicacion.Select_Todo_Ubicacion());
            return response;
        }
    }
}
