using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class ResumenFactura
    {
        private Decimal TotalServGravados;
        private Decimal TotalServExentos;
        private Decimal TotalServExonerado;
        private Decimal TotalMercanciasGravadas;
        private Decimal TotalMercanciasExentas;
        private Decimal TotalMercanciasExoneradas;
        private Decimal TotalGravado;
        private Decimal TotalExento;
        private Decimal TotalExonerado;
        private Decimal TotalVenta;
        private Decimal TotalDescuentos;
        private Decimal TotalVentaNeta;
        private Decimal TotalImpuesto;
        private Decimal TotalIVADevuelto;
        private Decimal TotalOtrosCargos;
        private Decimal TotalComprobante;
        private Factura Clave;
        private CodigoTipoMoneda CodigoTipoMoneda;
        private String Confirmacion;

        public decimal TotalServGravados1 { get => TotalServGravados; set => TotalServGravados = value; }
        public decimal TotalServExentos1 { get => TotalServExentos; set => TotalServExentos = value; }
        public decimal TotalServExonerado1 { get => TotalServExonerado; set => TotalServExonerado = value; }
        public decimal TotalMercanciasGravadas1 { get => TotalMercanciasGravadas; set => TotalMercanciasGravadas = value; }
        public decimal TotalMercanciasExentas1 { get => TotalMercanciasExentas; set => TotalMercanciasExentas = value; }
        public decimal TotalMercanciasExoneradas1 { get => TotalMercanciasExoneradas; set => TotalMercanciasExoneradas = value; }
        public decimal TotalGravado1 { get => TotalGravado; set => TotalGravado = value; }
        public decimal TotalExento1 { get => TotalExento; set => TotalExento = value; }
        public decimal TotalExonerado1 { get => TotalExonerado; set => TotalExonerado = value; }
        public decimal TotalVenta1 { get => TotalVenta; set => TotalVenta = value; }
        public decimal TotalDescuentos1 { get => TotalDescuentos; set => TotalDescuentos = value; }
        public decimal TotalVentaNeta1 { get => TotalVentaNeta; set => TotalVentaNeta = value; }
        public decimal TotalImpuesto1 { get => TotalImpuesto; set => TotalImpuesto = value; }
        public decimal TotalIVADevuelto1 { get => TotalIVADevuelto; set => TotalIVADevuelto = value; }
        public decimal TotalOtrosCargos1 { get => TotalOtrosCargos; set => TotalOtrosCargos = value; }
        public decimal TotalComprobante1 { get => TotalComprobante; set => TotalComprobante = value; }
        public Factura Clave1 { get => Clave; set => Clave = value; }
        public CodigoTipoMoneda CodigoTipoMoneda1 { get => CodigoTipoMoneda; set => CodigoTipoMoneda = value; }
        public string Confirmacion1 { get => Confirmacion; set => Confirmacion = value; }

        public String Insert_ResumenFactura()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_RESUMENFACTURA ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TotalServGravados1, 1);
                instancia_conexion.annadir_parametro(TotalServExentos1, 1);
                instancia_conexion.annadir_parametro(TotalServExonerado1, 1);
                instancia_conexion.annadir_parametro(TotalMercanciasGravadas1, 1);
                instancia_conexion.annadir_parametro(TotalMercanciasExentas1, 1);
                instancia_conexion.annadir_parametro(TotalMercanciasExoneradas1, 1);
                instancia_conexion.annadir_parametro(TotalGravado1, 1);
                instancia_conexion.annadir_parametro(TotalExento1, 1);
                instancia_conexion.annadir_parametro(TotalExonerado1, 1);
                instancia_conexion.annadir_parametro(TotalVenta1, 1);
                instancia_conexion.annadir_parametro(TotalDescuentos1, 1);
                instancia_conexion.annadir_parametro(TotalVentaNeta1, 1);
                instancia_conexion.annadir_parametro(TotalImpuesto1, 1);
                instancia_conexion.annadir_parametro(TotalIVADevuelto1, 1);
                instancia_conexion.annadir_parametro(TotalOtrosCargos1, 1);
                instancia_conexion.annadir_parametro(TotalComprobante1, 1);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);
                instancia_conexion.annadir_parametro(CodigoTipoMoneda1.CodigoMoneda1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado el resumen de factura de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_ResumenFactura()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_RESUMENFACTURA ?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TotalServGravados1, 1);
                instancia_conexion.annadir_parametro(TotalServExentos1, 1);
                instancia_conexion.annadir_parametro(TotalServExonerado1, 1);
                instancia_conexion.annadir_parametro(TotalMercanciasGravadas1, 1);
                instancia_conexion.annadir_parametro(TotalMercanciasExentas1, 1);
                instancia_conexion.annadir_parametro(TotalMercanciasExoneradas1, 1);
                instancia_conexion.annadir_parametro(TotalGravado1, 1);
                instancia_conexion.annadir_parametro(TotalExento1, 1);
                instancia_conexion.annadir_parametro(TotalExonerado1, 1);
                instancia_conexion.annadir_parametro(TotalVenta1, 1);
                instancia_conexion.annadir_parametro(TotalDescuentos1, 1);
                instancia_conexion.annadir_parametro(TotalVentaNeta1, 1);
                instancia_conexion.annadir_parametro(TotalImpuesto1, 1);
                instancia_conexion.annadir_parametro(TotalIVADevuelto1, 1);
                instancia_conexion.annadir_parametro(TotalOtrosCargos1, 1);
                instancia_conexion.annadir_parametro(TotalComprobante1, 1);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);
                instancia_conexion.annadir_parametro(CodigoTipoMoneda1.CodigoMoneda1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado el resumen de factura de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_ResumenFactura()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_RESUMENFACTURA ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado el resumen de factura de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public ResumenFactura Select_ResumenFactura()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            ResumenFactura resumenfactura = new ResumenFactura();
            resumenfactura.Confirmacion1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_RESUMENFACTURA ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.Clave1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        resumenfactura.TotalServGravados1 = Convert.ToDecimal(CONTENEDOR["TOTALSERVGRAVADOS"].ToString());

                        resumenfactura.TotalServExentos1 = Convert.ToDecimal(CONTENEDOR["TOTALSERVEXENTOS"].ToString());

                        resumenfactura.TotalServExonerado1 = Convert.ToDecimal(CONTENEDOR["TOTALSERVEXONERADO"].ToString());

                        resumenfactura.TotalMercanciasGravadas1 = Convert.ToDecimal(CONTENEDOR["TOTALMERCANCIASGRAVADAS"].ToString());

                        resumenfactura.TotalMercanciasExentas1 = Convert.ToDecimal(CONTENEDOR["TOTALMERCANCIASEXENTAS"].ToString());

                        resumenfactura.TotalMercanciasExoneradas1 = Convert.ToDecimal(CONTENEDOR["TOTALMERCEXONERADA"].ToString());

                        resumenfactura.TotalGravado1 = Convert.ToDecimal(CONTENEDOR["TOTALGRAVADO"].ToString());

                        resumenfactura.TotalExento1 = Convert.ToDecimal(CONTENEDOR["TOTALEXENTO"].ToString());

                        resumenfactura.TotalExonerado1 = Convert.ToDecimal(CONTENEDOR["TOTALEXONERADO"].ToString());

                        resumenfactura.TotalVenta1 = Convert.ToDecimal(CONTENEDOR["TOTALVENTA"].ToString());

                        resumenfactura.TotalDescuentos1 = Convert.ToDecimal(CONTENEDOR["_TOTALDESCUENTOS"].ToString());

                        resumenfactura.TotalVentaNeta1 = Convert.ToDecimal(CONTENEDOR["TOTALVENTANETA"].ToString());

                        resumenfactura.TotalImpuesto1 = Convert.ToDecimal(CONTENEDOR["TOTALIMPUESTO"].ToString());

                        resumenfactura.TotalIVADevuelto1 = Convert.ToDecimal(CONTENEDOR["TOTALIVADEVUELTO"].ToString());

                        resumenfactura.TotalOtrosCargos1 = Convert.ToDecimal(CONTENEDOR["TOTALOTROSCARGOS"].ToString());

                        resumenfactura.TotalComprobante1 = Convert.ToDecimal(CONTENEDOR["TOTALCOMPROBANTE"].ToString());

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        resumenfactura.Clave1 = clave;

                        CodigoTipoMoneda codigo = new CodigoTipoMoneda();
                        codigo.CodigoMoneda1 = CONTENEDOR["CODIGOTIPOMONEDACODIGO"].ToString();
                        resumenfactura.CodigoTipoMoneda1 = codigo;

                        resumenfactura.Confirmacion1 = "".ToString();

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return resumenfactura;
                }
                else
                {
                    return resumenfactura;
                }
            }
            catch (Exception error)
            {
                resumenfactura.Confirmacion1 = "Error";
                return resumenfactura;
            }
        }

        public List<ResumenFactura> Select_Todo_ResumenFactura()
        {
            List<ResumenFactura> listaresumenfactura = new List<ResumenFactura>();

            ConexionconBD instancia_conexion = new ConexionconBD();
            

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_RESUMENFACTURA";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        ResumenFactura resumenfactura = new ResumenFactura();

                        resumenfactura.TotalServGravados1 = Convert.ToDecimal(CONTENEDOR["TOTALSERVGRAVADOS"].ToString());

                        resumenfactura.TotalServExentos1 = Convert.ToDecimal(CONTENEDOR["TOTALSERVEXENTOS"].ToString());

                        resumenfactura.TotalServExonerado1 = Convert.ToDecimal(CONTENEDOR["TOTALSERVEXONERADO"].ToString());

                        resumenfactura.TotalMercanciasGravadas1 = Convert.ToDecimal(CONTENEDOR["TOTALMERCANCIASGRAVADAS"].ToString());

                        resumenfactura.TotalMercanciasExentas1 = Convert.ToDecimal(CONTENEDOR["TOTALMERCANCIASEXENTAS"].ToString());

                        resumenfactura.TotalMercanciasExoneradas1 = Convert.ToDecimal(CONTENEDOR["TOTALMERCEXONERADA"].ToString());

                        resumenfactura.TotalGravado1 = Convert.ToDecimal(CONTENEDOR["TOTALGRAVADO"].ToString());

                        resumenfactura.TotalExento1 = Convert.ToDecimal(CONTENEDOR["TOTALEXENTO"].ToString());

                        resumenfactura.TotalExonerado1 = Convert.ToDecimal(CONTENEDOR["TOTALEXONERADO"].ToString());

                        resumenfactura.TotalVenta1 = Convert.ToDecimal(CONTENEDOR["TOTALVENTA"].ToString());

                        resumenfactura.TotalDescuentos1 = Convert.ToDecimal(CONTENEDOR["_TOTALDESCUENTOS"].ToString());

                        resumenfactura.TotalVentaNeta1 = Convert.ToDecimal(CONTENEDOR["TOTALVENTANETA"].ToString());

                        resumenfactura.TotalImpuesto1 = Convert.ToDecimal(CONTENEDOR["TOTALIMPUESTO"].ToString());

                        resumenfactura.TotalIVADevuelto1 = Convert.ToDecimal(CONTENEDOR["TOTALIVADEVUELTO"].ToString());

                        resumenfactura.TotalOtrosCargos1 = Convert.ToDecimal(CONTENEDOR["TOTALOTROSCARGOS"].ToString());

                        resumenfactura.TotalComprobante1 = Convert.ToDecimal(CONTENEDOR["TOTALCOMPROBANTE"].ToString());

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        resumenfactura.Clave1 = clave;

                        CodigoTipoMoneda codigo = new CodigoTipoMoneda();
                        codigo.CodigoMoneda1 = CONTENEDOR["CODIGOTIPOMONEDACODIGO"].ToString();
                        resumenfactura.CodigoTipoMoneda1 = codigo;

                        resumenfactura.Confirmacion1 = "".ToString();

                        listaresumenfactura.Add(resumenfactura);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listaresumenfactura;
                }
                else
                {
                    return listaresumenfactura;
                }
            }
            catch (Exception error)
            {
                return listaresumenfactura;
            }
        }

    }
}