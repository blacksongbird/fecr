using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class LineaDetalle
    {
        private int NumeroLinea;
        private String PartidaArancelaria;
        private String Codigo;
        private Decimal Cantidad;
        private String UnidadMedida;
        private String UnidadMedidaComercial;
        private String Detalle;
        private Decimal PrecioUnitario;
        private Decimal MontoTotal;
        private Decimal Subtotal;
        private Decimal BaseImponible;
        private Decimal ImpuestoNeto;
        private Decimal MontoTotalLinea;
        private int Consecutivo;
        private Descuento MontoDescuento;
        private Descuento _NaturalezaDescuento;
        private CodigoComercial CodigoComercialTipo;
        private CodigoComercial CodigoComercialCodigo;
        private List<LineaDetalle_Impuesto_Exoneracion> ListaLineaDetalleImpuestoExoneracion;

        public int NumeroLinea1 { get => NumeroLinea; set => NumeroLinea = value; }
        public string PartidaArancelaria1 { get => PartidaArancelaria; set => PartidaArancelaria = value; }
        public string Codigo1 { get => Codigo; set => Codigo = value; }
        public decimal Cantidad1 { get => Cantidad; set => Cantidad = value; }
        public string UnidadMedida1 { get => UnidadMedida; set => UnidadMedida = value; }
        public string UnidadMedidaComercial1 { get => UnidadMedidaComercial; set => UnidadMedidaComercial = value; }
        public string Detalle1 { get => Detalle; set => Detalle = value; }
        public decimal PrecioUnitario1 { get => PrecioUnitario; set => PrecioUnitario = value; }
        public decimal MontoTotal1 { get => MontoTotal; set => MontoTotal = value; }
        public decimal Subtotal1 { get => Subtotal; set => Subtotal = value; }
        public decimal BaseImponible1 { get => BaseImponible; set => BaseImponible = value; }
        public decimal ImpuestoNeto1 { get => ImpuestoNeto; set => ImpuestoNeto = value; }
        public decimal MontoTotalLinea1 { get => MontoTotalLinea; set => MontoTotalLinea = value; }
        public int Consecutivo1 { get => Consecutivo; set => Consecutivo = value; }
        public Descuento MontoDescuento1 { get => MontoDescuento; set => MontoDescuento = value; }
        public Descuento NaturalezaDescuento { get => _NaturalezaDescuento; set => _NaturalezaDescuento = value; }
        public CodigoComercial CodigoComercialTipo1 { get => CodigoComercialTipo; set => CodigoComercialTipo = value; }
        public CodigoComercial CodigoComercialCodigo1 { get => CodigoComercialCodigo; set => CodigoComercialCodigo = value; }
        public List<LineaDetalle_Impuesto_Exoneracion> ListaLineaDetalleImpuestoExoneracion1 { get => ListaLineaDetalleImpuestoExoneracion; set => ListaLineaDetalleImpuestoExoneracion = value; }

        public String Insert_LineaDetalle()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_LINEADETALLE ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(NumeroLinea1, 1);
                instancia_conexion.annadir_parametro(PartidaArancelaria1, 2);
                instancia_conexion.annadir_parametro(Codigo1, 2);
                instancia_conexion.annadir_parametro(Cantidad1, 1);
                instancia_conexion.annadir_parametro(UnidadMedida1, 2);
                instancia_conexion.annadir_parametro(UnidadMedidaComercial1, 2);
                instancia_conexion.annadir_parametro(Detalle1, 2);
                instancia_conexion.annadir_parametro(PrecioUnitario1, 1);
                instancia_conexion.annadir_parametro(MontoTotal1, 1);
                instancia_conexion.annadir_parametro(Subtotal1, 1);
                instancia_conexion.annadir_parametro(BaseImponible1, 1);
                instancia_conexion.annadir_parametro(ImpuestoNeto1, 1);
                instancia_conexion.annadir_parametro(MontoTotalLinea1, 1);
                instancia_conexion.annadir_parametro(Consecutivo1, 1);
                instancia_conexion.annadir_parametro(MontoDescuento1.MontoDescuento1, 1);
                instancia_conexion.annadir_parametro(NaturalezaDescuento.NaturalezaDescuento, 2);
                instancia_conexion.annadir_parametro(CodigoComercialTipo1.Tipo1, 2);
                instancia_conexion.annadir_parametro(CodigoComercialCodigo1.Codigo1, 2);

                CONTENEDOR = instancia_conexion.busca();

                foreach (var item in ListaLineaDetalleImpuestoExoneracion1)
                {
                    LineaDetalle lineadetalle = new LineaDetalle();
                    lineadetalle.Consecutivo1 = this.Consecutivo1;
                    item.LineaDetalleConsecutivo1 = lineadetalle;
                    item.Insert_LineaDetalle_Impuesto_Exoneracion();
                }

                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado la línea detalle de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_LineaDetalle()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_LINEADETALLE ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(NumeroLinea1, 1);
                instancia_conexion.annadir_parametro(PartidaArancelaria1, 2);
                instancia_conexion.annadir_parametro(Codigo1, 2);
                instancia_conexion.annadir_parametro(Cantidad1, 1);
                instancia_conexion.annadir_parametro(UnidadMedida1, 2);
                instancia_conexion.annadir_parametro(UnidadMedidaComercial1, 2);
                instancia_conexion.annadir_parametro(Detalle1, 2);
                instancia_conexion.annadir_parametro(PrecioUnitario1, 1);
                instancia_conexion.annadir_parametro(MontoTotal1, 1);
                instancia_conexion.annadir_parametro(Subtotal1, 1);
                instancia_conexion.annadir_parametro(BaseImponible1, 1);
                instancia_conexion.annadir_parametro(ImpuestoNeto1, 1);
                instancia_conexion.annadir_parametro(MontoTotalLinea1, 1);
                instancia_conexion.annadir_parametro(Consecutivo1, 1);
                instancia_conexion.annadir_parametro(MontoDescuento1.MontoDescuento1, 1);
                instancia_conexion.annadir_parametro(NaturalezaDescuento.NaturalezaDescuento, 2);
                instancia_conexion.annadir_parametro(CodigoComercialTipo1.Tipo1, 2);
                instancia_conexion.annadir_parametro(CodigoComercialCodigo1.Codigo1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado la línea detalle de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_LineaDetalle()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_LINEADETALLE ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Consecutivo1, 1);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado la línea detalle de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public LineaDetalle Select_LineaDetalle()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            LineaDetalle lineadetalle = new LineaDetalle();
            lineadetalle.PartidaArancelaria1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_LINEADETALLE ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Consecutivo1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        lineadetalle.NumeroLinea1 = Convert.ToInt32(CONTENEDOR["NUMEROLINEA"].ToString());

                        lineadetalle.PartidaArancelaria1 = CONTENEDOR["PARTIDAARANCELARIA"].ToString();

                        lineadetalle.Codigo1 = CONTENEDOR["CODIGO"].ToString();

                        lineadetalle.Cantidad1 = Convert.ToDecimal(CONTENEDOR["CANTIDAD"].ToString());

                        lineadetalle.UnidadMedida1 = CONTENEDOR["UNIDADMEDIDA"].ToString();

                        lineadetalle.UnidadMedidaComercial1 = CONTENEDOR["UNIDADMEDIDACOMERCIAL"].ToString();

                        lineadetalle.Detalle1 = CONTENEDOR["DETALLE"].ToString();

                        lineadetalle.PrecioUnitario1 = Convert.ToDecimal(CONTENEDOR["PRECIOUNITARIO"].ToString());

                        lineadetalle.MontoTotal1 = Convert.ToDecimal(CONTENEDOR["MONTOTOTAL"].ToString());

                        lineadetalle.Subtotal1 = Convert.ToDecimal(CONTENEDOR["SUBTOTAL"].ToString());

                        lineadetalle.BaseImponible1 = Convert.ToDecimal(CONTENEDOR["BASEIMPONIBLE"].ToString());

                        lineadetalle.ImpuestoNeto1 = Convert.ToDecimal(CONTENEDOR["IMPUESTONETO"].ToString());

                        lineadetalle.MontoTotalLinea1 = Convert.ToDecimal(CONTENEDOR["MONTOTOTALLINEA"].ToString());

                        lineadetalle.Consecutivo1 = Convert.ToInt32(CONTENEDOR["CONSECUTIVO"].ToString());

                        Descuento montodescuento = new Descuento();
                        montodescuento.MontoDescuento1 = Convert.ToDecimal(CONTENEDOR["MONTODESCUENTO"].ToString());
                        lineadetalle.MontoDescuento1 = montodescuento;

                        Descuento naturalezadescuento = new Descuento();
                        naturalezadescuento.NaturalezaDescuento = CONTENEDOR["_NATURALEZADESCUENTO"].ToString();
                        lineadetalle.NaturalezaDescuento = naturalezadescuento;

                        CodigoComercial codigocomercialtipo = new CodigoComercial();
                        codigocomercialtipo.Tipo1 = CONTENEDOR["CODIGOCOMERCIALTIPO"].ToString();
                        lineadetalle.CodigoComercialTipo1 = codigocomercialtipo;

                        CodigoComercial codigocomercialcodigo = new CodigoComercial();
                        codigocomercialcodigo.Codigo1 = CONTENEDOR["CODIGOCOMERCIALCODIGO"].ToString();
                        lineadetalle.CodigoComercialCodigo1 = codigocomercialcodigo;

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return lineadetalle;
                }
                else
                {
                    return lineadetalle;
                }
            }
            catch (Exception error)
            {
                lineadetalle.PartidaArancelaria1 = "Error";
                return lineadetalle;
            }
        }

        public List<LineaDetalle> Select_Todo_LineaDetalle()
        {
            List<LineaDetalle> listalineadetalle = new List<LineaDetalle>();

            ConexionconBD instancia_conexion = new ConexionconBD();
            

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_LINEADETALLE";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {

                        LineaDetalle lineadetalle = new LineaDetalle();

                        lineadetalle.NumeroLinea1 = Convert.ToInt32(CONTENEDOR["NUMEROLINEA"].ToString());

                        lineadetalle.PartidaArancelaria1 = CONTENEDOR["PARTIDAARANCELARIA"].ToString();

                        lineadetalle.Codigo1 = CONTENEDOR["CODIGO"].ToString();

                        lineadetalle.Cantidad1 = Convert.ToDecimal(CONTENEDOR["CANTIDAD"].ToString());

                        lineadetalle.UnidadMedida1 = CONTENEDOR["UNIDADMEDIDA"].ToString();

                        lineadetalle.UnidadMedidaComercial1 = CONTENEDOR["UNIDADMEDIDACOMERCIAL"].ToString();

                        lineadetalle.Detalle1 = CONTENEDOR["DETALLE"].ToString();

                        lineadetalle.PrecioUnitario1 = Convert.ToDecimal(CONTENEDOR["PRECIOUNITARIO"].ToString());

                        lineadetalle.MontoTotal1 = Convert.ToDecimal(CONTENEDOR["MONTOTOTAL"].ToString());

                        lineadetalle.Subtotal1 = Convert.ToDecimal(CONTENEDOR["SUBTOTAL"].ToString());

                        lineadetalle.BaseImponible1 = Convert.ToDecimal(CONTENEDOR["BASEIMPONIBLE"].ToString());

                        lineadetalle.ImpuestoNeto1 = Convert.ToDecimal(CONTENEDOR["IMPUESTONETO"].ToString());

                        lineadetalle.MontoTotalLinea1 = Convert.ToDecimal(CONTENEDOR["MONTOTOTALLINEA"].ToString());

                        lineadetalle.Consecutivo1 = Convert.ToInt32(CONTENEDOR["CONSECUTIVO"].ToString());

                        Descuento montodescuento = new Descuento();
                        montodescuento.MontoDescuento1 = Convert.ToDecimal(CONTENEDOR["MONTODESCUENTO"].ToString());
                        lineadetalle.MontoDescuento1 = montodescuento;

                        Descuento naturalezadescuento = new Descuento();
                        naturalezadescuento.NaturalezaDescuento = CONTENEDOR["_NATURALEZADESCUENTO"].ToString();
                        lineadetalle.NaturalezaDescuento = naturalezadescuento;

                        CodigoComercial codigocomercialtipo = new CodigoComercial();
                        codigocomercialtipo.Tipo1 = CONTENEDOR["CODIGOCOMERCIALTIPO"].ToString();
                        lineadetalle.CodigoComercialTipo1 = codigocomercialtipo;

                        CodigoComercial codigocomercialcodigo = new CodigoComercial();
                        codigocomercialcodigo.Codigo1 = CONTENEDOR["CODIGOCOMERCIALCODIGO"].ToString();
                        lineadetalle.CodigoComercialCodigo1 = codigocomercialcodigo;

                        List<LineaDetalle_Impuesto_Exoneracion> lista = new List<LineaDetalle_Impuesto_Exoneracion>();
                        LineaDetalle_Impuesto_Exoneracion lineadetalle_Impuesto_Exoneracion = new LineaDetalle_Impuesto_Exoneracion();

                        lista = lineadetalle_Impuesto_Exoneracion.Select_LineaDetalle_Impuesto_Exoneracion_Por_LineaDetalle(lineadetalle.Consecutivo1);
                        lineadetalle.ListaLineaDetalleImpuestoExoneracion1 = lista;

                        listalineadetalle.Add(lineadetalle);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listalineadetalle;
                }
                else
                {
                    return listalineadetalle;
                }
            }
            catch (Exception error)
            {
                return listalineadetalle;
            }
        }

    }
}