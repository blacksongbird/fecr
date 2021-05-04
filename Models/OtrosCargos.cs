using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class OtrosCargos
    {
        private String TipoDocumento;
        private String NumeroIdentidadTercero;
        private String NombreTercero;
        private String Detalle;
        private Decimal Porcentaje;
        private Decimal MontoCargo;
        private DetalleServicio Clave;

        public string TipoDocumento1 { get => TipoDocumento; set => TipoDocumento = value; }
        public string NumeroIdentidadTercero1 { get => NumeroIdentidadTercero; set => NumeroIdentidadTercero = value; }
        public string NombreTercero1 { get => NombreTercero; set => NombreTercero = value; }
        public string Detalle1 { get => Detalle; set => Detalle = value; }
        public decimal Porcentaje1 { get => Porcentaje; set => Porcentaje = value; }
        public decimal MontoCargo1 { get => MontoCargo; set => MontoCargo = value; }
        public DetalleServicio Clave1 { get => Clave; set => Clave = value; }

        public String Insert_OtrosCargos()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_OTROSCARGOS ?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDocumento1, 2);
                instancia_conexion.annadir_parametro(NumeroIdentidadTercero1, 2);
                instancia_conexion.annadir_parametro(NombreTercero1, 2);
                instancia_conexion.annadir_parametro(Detalle1, 2);
                instancia_conexion.annadir_parametro(Porcentaje1, 1);
                instancia_conexion.annadir_parametro(MontoCargo1, 1);
                instancia_conexion.annadir_parametro(Clave1.Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado otro cargo de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_OtrosCargos()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_OTROSCARGOS ?,?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDocumento1, 2);
                instancia_conexion.annadir_parametro(NumeroIdentidadTercero1, 2);
                instancia_conexion.annadir_parametro(NombreTercero1, 2);
                instancia_conexion.annadir_parametro(Detalle1, 2);
                instancia_conexion.annadir_parametro(Porcentaje1, 1);
                instancia_conexion.annadir_parametro(MontoCargo1, 1);
                instancia_conexion.annadir_parametro(Clave1.Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado otro cargo de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_OtrosCargos()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_OTROSCARGOS ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado otro cargo de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public OtrosCargos Select_OtrosCargos()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            OtrosCargos otroscargos = new OtrosCargos();
            otroscargos.TipoDocumento1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_OTROSCARGOS ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.Clave1.Clave1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        otroscargos.TipoDocumento1 = CONTENEDOR["TIPODOCUMENTO"].ToString();

                        otroscargos.NumeroIdentidadTercero1 = CONTENEDOR["NUMEROIDENTIDADTERCERO"].ToString();
                        
                        otroscargos.NombreTercero1 = CONTENEDOR["NOMBRETERCERO"].ToString();

                        otroscargos.Detalle1 = CONTENEDOR["DETALLE"].ToString();

                        otroscargos.Porcentaje1 = Convert.ToDecimal(CONTENEDOR["PORCENTAJE"].ToString());

                        otroscargos.MontoCargo1 = Convert.ToDecimal(CONTENEDOR["MONTOCARGO"].ToString());

                        Factura clavefactura = new Factura();
                        clavefactura.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        DetalleServicio clave = new DetalleServicio();
                        clave.Clave1 = clavefactura;
                        otroscargos.Clave1 = clave;

                        otroscargos.Clave1 = clave.Select_DetalleServicio();


                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return otroscargos;
                }
                else
                {
                    return otroscargos;
                }
            }
            catch (Exception error)
            {
                otroscargos.TipoDocumento1 = "Error";
                return otroscargos;
            }
        }

        public List<OtrosCargos> Select_Todo_OtrosCargos()
        {
            List<OtrosCargos> listaotroscargos = new List<OtrosCargos>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_OTROSCARGOS";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        
                        OtrosCargos otroscargos = new OtrosCargos();

                        otroscargos.TipoDocumento1 = CONTENEDOR["TIPODOCUMENTO"].ToString();

                        otroscargos.NumeroIdentidadTercero1 = CONTENEDOR["NUMEROIDENTIDADTERCERO"].ToString();

                        otroscargos.NombreTercero1 = CONTENEDOR["NOMBRETERCERO"].ToString();

                        otroscargos.Detalle1 = CONTENEDOR["DETALLE"].ToString();

                        otroscargos.Porcentaje1 = Convert.ToDecimal(CONTENEDOR["PORCENTAJE"].ToString());

                        otroscargos.MontoCargo1 = Convert.ToDecimal(CONTENEDOR["MONTOCARGO"].ToString());

                        Factura clavefactura = new Factura();
                        clavefactura.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        DetalleServicio clave = new DetalleServicio();
                        clave.Clave1 = clavefactura;
                        otroscargos.Clave1 = clave;

                        listaotroscargos.Add(otroscargos);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listaotroscargos;
                }
                else
                {
                    return listaotroscargos;
                }
            }
            catch (Exception error)
            {
                return listaotroscargos;
            }
        }

    }
}