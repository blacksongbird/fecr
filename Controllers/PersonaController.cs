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
    public class PersonaController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            Persona persona = new Persona();
            persona.Nombre1 = form.Get("NombrePersona");

            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = form.Get("IdentificacionPersona");
            persona.IdentificacionNumero1 = identificacion;

            persona.NombreComercial1 = form.Get("NombreComercial");

            Ubicacion ubicacionid = new Ubicacion();
            ubicacionid.ID1 = Convert.ToInt32(form.Get("UbicacionPersona"));
            persona.UbicacionID1 = ubicacionid;

            TelefonoFax telefono = new TelefonoFax();
            telefono.NumTelefono1 = Convert.ToInt32(form.Get("TelefonoPersona"));
            persona.TelefonoNumero1 = telefono;

            TelefonoFax fax = new TelefonoFax();
            fax.NumTelefono1 = Convert.ToInt32(form.Get("FaxPersona"));
            persona.FaxNumero1 = fax;

            persona.CorreoElectronico1 = form.Get("CorreoPersona");

            string[] respuesta = new string[2];
            respuesta[0] = persona.Update_Persona();
            respuesta[1] = form.Get("IdentifiacionPersona");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            Persona persona = new Persona();
            persona.Nombre1 = form.Get("NombrePersona");

            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = form.Get("IdentificacionPersona");
            persona.IdentificacionNumero1 = identificacion;

            persona.NombreComercial1 = form.Get("NombreComercial");

            Ubicacion ubicacionid = new Ubicacion();
            ubicacionid.ID1 = Convert.ToInt32(form.Get("UbicacionPersona"));
            persona.UbicacionID1 = ubicacionid;

            TelefonoFax telefono = new TelefonoFax();
            telefono.NumTelefono1 = Convert.ToInt32(form.Get("TelefonoPersona"));
            persona.TelefonoNumero1 = telefono;

            TelefonoFax fax = new TelefonoFax();
            fax.NumTelefono1 = Convert.ToInt32(form.Get("FaxPersona"));
            persona.FaxNumero1 = fax;

            persona.CorreoElectronico1 = form.Get("CorreoPersona");

            string[] respuesta = new string[2];
            respuesta[0] = persona.Insert_Persona();
            respuesta[1] = form.Get("IdentificacionPersona");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            Persona persona = new Persona();

            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = form.Get("IdentificacionPersona");
            persona.IdentificacionNumero1 = identificacion;

            string[] respuesta = new string[2];
            respuesta[0] = persona.Delete_Persona();
            respuesta[1] = form.Get("IdentificacionPersona");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] String id)
        {
            Persona persona = new Persona();
            Identificacion identificacion = new Identificacion();
            identificacion.Numero1 = id;
            persona.IdentificacionNumero1 = identificacion;

            HttpResponseMessage response = Request.CreateResponse<Models.Persona>(HttpStatusCode.Created, persona.Select_Persona());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            Persona persona = new Persona();

            HttpResponseMessage response = Request.CreateResponse<List<Models.Persona>>(HttpStatusCode.Created, persona.Select_Todo_Persona());
            return response;
        }
    }
}
