using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Otros
    {
        private String OtroTexto;
        private String OtroContenido;
        private Factura Clave;

        public string OtroTexto1 { get => OtroTexto; set => OtroTexto = value; }
        public string OtroContenido1 { get => OtroContenido; set => OtroContenido = value; }
        public Factura Clave1 { get => Clave; set => Clave = value; }

        public String Insert_Otros()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_OTROS ?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(OtroTexto1, 2);
                instancia_conexion.annadir_parametro(OtroContenido1, 2);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado información de otros de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_Otros()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_OTROS ?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(OtroTexto1, 2);
                instancia_conexion.annadir_parametro(OtroContenido1, 2);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado información de otros de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Otros()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_OTROS ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Clave1.Clave1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado información de otros de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public Otros Select_Otros()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            Otros otros = new Otros();
            otros.OtroTexto1 = "No Existe";

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_OTROS ?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Clave1.Clave1.ToString(), 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        otros.OtroTexto1 = CONTENEDOR["OTROTEXTO"].ToString();

                        otros.OtroContenido1 = CONTENEDOR["OTROCONTENIDO"].ToString();

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        otros.Clave1 = clave;

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return otros;
                }
                else
                {
                    return otros;
                }
            }
            catch (Exception error)
            {
                otros.OtroTexto1 = "Error";
                return otros;
            }
        }

        public List<Otros> Select_Todo_Otros()
        {
            List<Otros> listaotros = new List<Otros>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_OTROS";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {

                        Otros otros = new Otros();

                        otros.OtroTexto1 = CONTENEDOR["OTROTEXTO"].ToString();

                        otros.OtroContenido1 = CONTENEDOR["OTROCONTENIDO"].ToString();

                        Factura clave = new Factura();
                        clave.Clave1 = CONTENEDOR["CLAVE"].ToString();
                        otros.Clave1 = clave;

                        listaotros.Add(otros);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listaotros;
                }
                else
                {
                    return listaotros;
                }
            }
            catch (Exception error)
            {
                return listaotros;
            }
        }

    }
}