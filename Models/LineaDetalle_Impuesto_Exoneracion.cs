using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class LineaDetalle_Impuesto_Exoneracion
    {

        private LineaDetalle LineaDetalleConsecutivo;
        private Impuesto ImpuestoCodigo;
        private Exoneracion TipoDocumento;
        private Exoneracion NumeroDocumento;

        public LineaDetalle LineaDetalleConsecutivo1 { get => LineaDetalleConsecutivo; set => LineaDetalleConsecutivo = value; }
        public Impuesto ImpuestoCodigo1 { get => ImpuestoCodigo; set => ImpuestoCodigo = value; }
        public Exoneracion TipoDocumento1 { get => TipoDocumento; set => TipoDocumento = value; }
        public Exoneracion NumeroDocumento1 { get => NumeroDocumento; set => NumeroDocumento = value; }

        public string Insert_LineaDetalle_Impuesto_Exoneracion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                    instancia_conexion.inicializa();
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC INSERT_LINEADETALLE_IMPUESTO_EXONERACION ?,?,?,?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(LineaDetalleConsecutivo1.Consecutivo1, 1);
                    instancia_conexion.annadir_parametro(ImpuestoCodigo1.Codigo1, 2);
                    if (NumeroDocumento1.NumeroDocumento1 != "")
                    {
                        instancia_conexion.annadir_parametro(TipoDocumento1.TipoDocumento1, 2);
                        instancia_conexion.annadir_parametro(NumeroDocumento1.NumeroDocumento1, 2);
                    }
                    else
                    {
                        instancia_conexion.annadir_parametro(DBNull.Value, 2);
                        instancia_conexion.annadir_parametro(DBNull.Value, 2);
                    }

                    CONTENEDOR = instancia_conexion.busca();
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return "Se ha agregado la línea detalle de impuestos y exoneraciones de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }


        public List<LineaDetalle_Impuesto_Exoneracion> Select_LineaDetalle_Impuesto_Exoneracion_Por_LineaDetalle(Int32 consecutivolineadetalle)
        {
            List<LineaDetalle_Impuesto_Exoneracion> listalineadetalle_impuesto_exoneracion = new List<LineaDetalle_Impuesto_Exoneracion>();

            ConexionconBD instancia_conexion = new ConexionconBD();


            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_LINEADETALLE_IMPUESTO_EXONERACION_POR_LINEADETALLE ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(consecutivolineadetalle, 1);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {

                        LineaDetalle_Impuesto_Exoneracion lineadetalle_impuesto_exoneracion = new LineaDetalle_Impuesto_Exoneracion();
                        Exoneracion exoneracion = new Exoneracion();
                        if (CONTENEDOR["TIPODOCUMENTO"] != DBNull.Value)
                        {
                            exoneracion.TipoDocumento1 = CONTENEDOR["TIPODOCUMENTO"].ToString();
                            exoneracion.NumeroDocumento1 = CONTENEDOR["NUMERODOCUMENTO"].ToString();
                        }

                        Impuesto impuesto = new Impuesto();
                        impuesto.Codigo1 = CONTENEDOR["CODIGO"].ToString();

                        LineaDetalle lineadetalle = new LineaDetalle();
                        lineadetalle.Consecutivo1 = Convert.ToInt32(CONTENEDOR["CONSECUTIVO"].ToString());

                        lineadetalle_impuesto_exoneracion.NumeroDocumento1 = exoneracion;
                        lineadetalle_impuesto_exoneracion.TipoDocumento1 = exoneracion;
                        lineadetalle_impuesto_exoneracion.ImpuestoCodigo1 = impuesto;
                        lineadetalle_impuesto_exoneracion.LineaDetalleConsecutivo1 = lineadetalle;

                        listalineadetalle_impuesto_exoneracion.Add(lineadetalle_impuesto_exoneracion);

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listalineadetalle_impuesto_exoneracion;
                }
                else
                {
                    return listalineadetalle_impuesto_exoneracion;
                }
            }
            catch (Exception error)
            {
                return listalineadetalle_impuesto_exoneracion;
            }
        }


    }
}