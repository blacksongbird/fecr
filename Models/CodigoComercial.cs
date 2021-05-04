using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class CodigoComercial
    {
        private string Tipo;
        private string Codigo;

        public string Tipo1 { get => Tipo; set => Tipo = value; }
        public string Codigo1 { get => Codigo; set => Codigo = value; }

        public String Insert_CodigoComercial()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_CODIGOCOMERCIAL ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Tipo1, 2);
                instancia_conexion.annadir_parametro(Codigo1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado el código comercial de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_CodigoComercial()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_CODIGOCOMERCIAL ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Tipo1, 2);
                instancia_conexion.annadir_parametro(Codigo1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado el código comercial de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public CodigoComercial Select_CodigoComercial()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            CodigoComercial codigocomercial = new CodigoComercial();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_CODIGOCOMERCIAL ?,?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(Tipo1, 2);
                    instancia_conexion.annadir_parametro(Codigo1, 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        codigocomercial.Tipo1 = CONTENEDOR["TIPO"].ToString();
                        codigocomercial.Codigo1 = CONTENEDOR["CODIGO"].ToString();

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return codigocomercial;
                }
                else
                {
                    return codigocomercial;
                }
            }
            catch (Exception error)
            {
                return codigocomercial;
            }
        }

        public List<CodigoComercial> Select_Todo_CodigoComercial()
        {
            List<CodigoComercial> listacodigoscomerciales = new List<CodigoComercial>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_CODIGOCOMERCIAL";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();
                    
                    while (CONTENEDOR.Read())
                    {
                        CodigoComercial codigocomercial = new CodigoComercial();
                        codigocomercial.Tipo1 = CONTENEDOR["TIPO"].ToString();
                        codigocomercial.Codigo1 = CONTENEDOR["CODIGO"].ToString();
                        listacodigoscomerciales.Add(codigocomercial);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listacodigoscomerciales;
                }
                else
                {
                    return listacodigoscomerciales;
                }
            }
            catch (Exception error)
            {
                return listacodigoscomerciales;
            }
        }
    }
}