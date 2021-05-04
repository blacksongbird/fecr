using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Exoneracion
    {
        private string TipoDocumento;
        private string NumeroDocumento;
        private string NombreInstitucion;
        private DateTime FechaEmision;
        private int PorcentajeExoneracion;
        private decimal MontoExoneracion;

        public string TipoDocumento1 { get => TipoDocumento; set => TipoDocumento = value; }
        public string NumeroDocumento1 { get => NumeroDocumento; set => NumeroDocumento = value; }
        public string NombreInstitucion1 { get => NombreInstitucion; set => NombreInstitucion = value; }
        public DateTime FechaEmision1 { get => FechaEmision; set => FechaEmision = value; }
        public int PorcentajeExoneracion1 { get => PorcentajeExoneracion; set => PorcentajeExoneracion = value; }
        public decimal MontoExoneracion1 { get => MontoExoneracion; set => MontoExoneracion = value; }


        public String Insert_Exoneracion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_EXONERACION ?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDocumento1, 2);
                instancia_conexion.annadir_parametro(NumeroDocumento1, 2);
                instancia_conexion.annadir_parametro(NombreInstitucion1, 2);
                instancia_conexion.annadir_parametro(FechaEmision1, 4);
                instancia_conexion.annadir_parametro(PorcentajeExoneracion1, 1);
                instancia_conexion.annadir_parametro(MontoExoneracion1, 1);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado la exoneración de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_Exoneracion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_EXONERACION ?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDocumento1, 2);
                instancia_conexion.annadir_parametro(NumeroDocumento1, 2);
                instancia_conexion.annadir_parametro(NombreInstitucion1, 2);
                instancia_conexion.annadir_parametro(FechaEmision1, 4);
                instancia_conexion.annadir_parametro(PorcentajeExoneracion1, 1);
                instancia_conexion.annadir_parametro(MontoExoneracion1, 1);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado la exoneración de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Exoneracion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_EXONERACION ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(TipoDocumento1, 2);
                instancia_conexion.annadir_parametro(NumeroDocumento1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado la exoneración de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public List<Exoneracion> Select_Todo_Exoneracion()
        {
            List<Exoneracion> listaexoneraciones = new List<Exoneracion>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_EXONERACION";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Exoneracion exoneracion = new Exoneracion();
                        exoneracion.TipoDocumento1 = CONTENEDOR["TIPODOCUMENTO"].ToString();
                        exoneracion.NumeroDocumento1 = CONTENEDOR["NUMERODOCUMENTO"].ToString();
                        exoneracion.NombreInstitucion1 = CONTENEDOR["NOMBREINSTITUCION"].ToString();
                        exoneracion.FechaEmision1 = Convert.ToDateTime(CONTENEDOR["FECHAEMISION"].ToString());
                        exoneracion.PorcentajeExoneracion1 = Convert.ToInt32(CONTENEDOR["PORCENTAJEEXONERACION"].ToString());
                        exoneracion.MontoExoneracion1 = Convert.ToDecimal(CONTENEDOR["MONTOEXONERACION"].ToString());
                        listaexoneraciones.Add(exoneracion);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listaexoneraciones;
                }
                else
                {
                    return listaexoneraciones;
                }
            }
            catch (Exception error)
            {
                return listaexoneraciones;
            }
        }

    }
}