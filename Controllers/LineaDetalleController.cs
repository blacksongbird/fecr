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
    public class LineaDetalleController : ApiController
    {
        public class LineaDetalle_Impuesto_Exoneracion_Local
        {
            [JsonProperty("LineaDetalleConsecutivo")]
            public String LineaDetalleConsecutivo;
            [JsonProperty("ImpuestoCodigo")]
            public String ImpuestoCodigo;
            [JsonProperty("ExoneracionTipo")]
            public String TipoDocumento;
            [JsonProperty("ExoneracionNumeroDocumento")]
            public String NumeroDocumento;
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            LineaDetalle lineadetalle = new LineaDetalle();
            lineadetalle.NumeroLinea1 = Convert.ToInt32(form.Get("NumeroLinea"));
            lineadetalle.PartidaArancelaria1 = form.Get("PartidaArancelaria");
            lineadetalle.Codigo1 = form.Get("Codigo");
            lineadetalle.Cantidad1 = Convert.ToDecimal(form.Get("Cantidad").Replace('.', ','));
            lineadetalle.UnidadMedida1 = form.Get("UnidadMedida");
            lineadetalle.UnidadMedidaComercial1 = form.Get("UnidadMedidaComercial");
            lineadetalle.Detalle1 = form.Get("Detalle");
            lineadetalle.PrecioUnitario1 = Convert.ToDecimal(form.Get("PrecioUnitario").Replace('.', ','));
            lineadetalle.MontoTotal1 = Convert.ToDecimal(form.Get("MontoTotal").Replace('.', ','));
            lineadetalle.Subtotal1 = Convert.ToDecimal(form.Get("Subtotal").Replace('.', ','));
            lineadetalle.BaseImponible1 = Convert.ToDecimal(form.Get("BaseImponible").Replace('.', ','));
            lineadetalle.ImpuestoNeto1 = Convert.ToDecimal(form.Get("ImpuestoNeto").Replace('.', ','));
            lineadetalle.MontoTotalLinea1 = Convert.ToDecimal(form.Get("MontoTotalLinea").Replace('.', ','));
            lineadetalle.Consecutivo1 = Convert.ToInt32(form.Get("Consecutivo"));

            Descuento monto = new Descuento();
            monto.MontoDescuento1 = Convert.ToDecimal(form.Get("MontoDescuento"));
            lineadetalle.MontoDescuento1 = monto;

            Descuento naturaleza = new Descuento();
            naturaleza.NaturalezaDescuento = form.Get("NaturalezaDescuento");
            lineadetalle.NaturalezaDescuento = naturaleza;

            CodigoComercial tipo = new CodigoComercial();
            tipo.Tipo1 = form.Get("CodigoComercialTipo");
            lineadetalle.CodigoComercialTipo1 = tipo;

            CodigoComercial codigo = new CodigoComercial();
            codigo.Codigo1 = form.Get("CodigoComercialCodigo");
            lineadetalle.CodigoComercialCodigo1 = codigo;


            JArray jObject = JArray.Parse(form.Get("ListaActualDeLineaDetalle_Impuesto_Exoneracion"));
            JToken jUser = jObject;
            var lista = jUser.ToObject<List<LineaDetalle_Impuesto_Exoneracion_Local>>();
            List<Models.LineaDetalle_Impuesto_Exoneracion> lineadetalle_impuesto_s = new List<LineaDetalle_Impuesto_Exoneracion>();
            foreach (var item in lista)
            {

                Impuesto impuesto = new Impuesto();
                impuesto.Codigo1 = item.ImpuestoCodigo;
                Exoneracion exoneracion = new Exoneracion();
                exoneracion.TipoDocumento1 = item.TipoDocumento;
                exoneracion.NumeroDocumento1 = item.NumeroDocumento;
                LineaDetalle_Impuesto_Exoneracion lineadetalle_impuesto_exoneracion = new LineaDetalle_Impuesto_Exoneracion();
                lineadetalle_impuesto_exoneracion.NumeroDocumento1 = exoneracion;
                lineadetalle_impuesto_exoneracion.TipoDocumento1 = exoneracion;
                lineadetalle_impuesto_exoneracion.ImpuestoCodigo1 = impuesto;
                lineadetalle_impuesto_s.Add(lineadetalle_impuesto_exoneracion);
            }

            lineadetalle.ListaLineaDetalleImpuestoExoneracion1 = lineadetalle_impuesto_s;
            string[] respuesta = new string[2];
            respuesta[0] = lineadetalle.Update_LineaDetalle();
            respuesta[1] = form.Get("Consecutivo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            LineaDetalle lineadetalle = new LineaDetalle();
            lineadetalle.NumeroLinea1 = Convert.ToInt32(form.Get("NumeroLinea"));
            lineadetalle.PartidaArancelaria1 = form.Get("PartidaArancelaria");
            lineadetalle.Codigo1 = form.Get("Codigo");
            lineadetalle.Cantidad1 = Convert.ToDecimal(form.Get("Cantidad").Replace('.', ','));
            lineadetalle.UnidadMedida1 = form.Get("UnidadMedida");
            lineadetalle.UnidadMedidaComercial1 = form.Get("UnidadMedidaComercial");
            lineadetalle.Detalle1 = form.Get("Detalle");
            lineadetalle.PrecioUnitario1 = Convert.ToDecimal(form.Get("PrecioUnitario").Replace('.', ','));
            lineadetalle.MontoTotal1 = Convert.ToDecimal(form.Get("MontoTotal").Replace('.', ','));
            lineadetalle.Subtotal1 = Convert.ToDecimal(form.Get("Subtotal").Replace('.', ','));
            lineadetalle.BaseImponible1 = Convert.ToDecimal(form.Get("BaseImponible").Replace('.', ','));
            lineadetalle.ImpuestoNeto1 = Convert.ToDecimal(form.Get("ImpuestoNeto").Replace('.', ','));
            lineadetalle.MontoTotalLinea1 = Convert.ToDecimal(form.Get("MontoTotalLinea").Replace('.', ','));
            lineadetalle.Consecutivo1 = Convert.ToInt32(form.Get("Consecutivo"));

            Descuento monto = new Descuento();
            monto.MontoDescuento1 = Convert.ToDecimal(form.Get("MontoDescuento"));
            lineadetalle.MontoDescuento1 = monto;

            Descuento naturaleza = new Descuento();
            naturaleza.NaturalezaDescuento = form.Get("NaturalezaDescuento");
            lineadetalle.NaturalezaDescuento = naturaleza;

            CodigoComercial tipo = new CodigoComercial();
            tipo.Tipo1 = form.Get("CodigoComercialTipo");
            lineadetalle.CodigoComercialTipo1 = tipo;

            CodigoComercial codigo = new CodigoComercial();
            codigo.Codigo1 = form.Get("CodigoComercialCodigo");
            lineadetalle.CodigoComercialCodigo1 = codigo;


            JArray jObject = JArray.Parse(form.Get("ListaActualDeLineaDetalle_Impuesto_Exoneracion"));
            JToken jUser = jObject;
            var lista = jUser.ToObject<List<LineaDetalle_Impuesto_Exoneracion_Local>>();
            List<Models.LineaDetalle_Impuesto_Exoneracion> lineadetalle_impuesto_s = new List<LineaDetalle_Impuesto_Exoneracion>();
            foreach (var item in lista)
            {

                Impuesto impuesto = new Impuesto();
                impuesto.Codigo1 = item.ImpuestoCodigo;
                Exoneracion exoneracion = new Exoneracion();
                exoneracion.TipoDocumento1 = item.TipoDocumento;
                exoneracion.NumeroDocumento1 = item.NumeroDocumento;
                LineaDetalle_Impuesto_Exoneracion lineadetalle_impuesto_exoneracion = new LineaDetalle_Impuesto_Exoneracion();
                lineadetalle_impuesto_exoneracion.NumeroDocumento1 = exoneracion;
                lineadetalle_impuesto_exoneracion.TipoDocumento1 = exoneracion;
                lineadetalle_impuesto_exoneracion.ImpuestoCodigo1 = impuesto;
                lineadetalle_impuesto_s.Add(lineadetalle_impuesto_exoneracion);
            }

            lineadetalle.ListaLineaDetalleImpuestoExoneracion1 = lineadetalle_impuesto_s;
            string[] respuesta = new string[2];
            respuesta[0] = lineadetalle.Insert_LineaDetalle();
            respuesta[1] = form.Get("Consecutivo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpDelete]
        public HttpResponseMessage Delete(FormDataCollection form)
        {
            LineaDetalle lineadetalle = new LineaDetalle();
            lineadetalle.Consecutivo1 = Convert.ToInt32(form.Get("Consecutivo"));

            string[] respuesta = new string[2];
            respuesta[0] = lineadetalle.Delete_LineaDetalle();
            respuesta[1] = form.Get("Consecutivo");

            HttpResponseMessage response = Request.CreateResponse<string[]>(HttpStatusCode.Created, respuesta);
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get([FromUri] int id)
        {
            LineaDetalle lineadetalle = new LineaDetalle();
            lineadetalle.Consecutivo1 = id;

            HttpResponseMessage response = Request.CreateResponse<Models.LineaDetalle>(HttpStatusCode.Created, lineadetalle.Select_LineaDetalle());
            return response;
        }

        [HttpGet]
        public HttpResponseMessage Get()
        {
            LineaDetalle lineadetalle = new LineaDetalle();

            HttpResponseMessage response = Request.CreateResponse<List<Models.LineaDetalle>>(HttpStatusCode.Created, lineadetalle.Select_Todo_LineaDetalle());
            return response;
        }
    }
}
