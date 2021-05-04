using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Identificacion
    {
        private string Numero;
        private string Tipo;

        public string Numero1 { get => Numero; set => Numero = value; }
        public string Tipo1 { get => Tipo; set => Tipo = value; }


        public String Insert_Identificacion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_IDENTIFICACION ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Numero1, 2);
                instancia_conexion.annadir_parametro(Tipo1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado la identificación de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_Identificacion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_IDENTIFICACION ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Numero1, 2);
                instancia_conexion.annadir_parametro(Tipo1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado la identificación de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Identificacion()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_IDENTIFICACION ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Numero1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado la identificación de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public Identificacion Select_Identificacion()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            Identificacion identificacion = new Identificacion();
            identificacion.Tipo1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_IDENTIFICACION ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Numero1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        identificacion.Numero1 = CONTENEDOR["NUMERO"].ToString();
                        identificacion.Tipo1 = CONTENEDOR["TIPO"].ToString();
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return identificacion;
                }
                else
                {
                    return identificacion;
                }
            }
            catch (Exception error)
            {
                return identificacion;
            }
        }

        public List<Identificacion> Select_Todo_Identificacion()
        {
            List<Identificacion> listaidentificaciones = new List<Identificacion>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_IDENTIFICACION";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Identificacion identificacion = new Identificacion();
                        identificacion.Numero1 = CONTENEDOR["NUMERO"].ToString();
                        identificacion.Tipo1 = CONTENEDOR["TIPO"].ToString();
                        listaidentificaciones.Add(identificacion);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listaidentificaciones;
                }
                else
                {
                    return listaidentificaciones;
                }
            }
            catch (Exception error)
            {
                return listaidentificaciones;
            }
        }
    }
}