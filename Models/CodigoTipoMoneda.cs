using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class CodigoTipoMoneda
    {
        private string CodigoMoneda;
        private decimal TipoCambio;

        public string CodigoMoneda1 { get => CodigoMoneda; set => CodigoMoneda = value; }
        public decimal TipoCambio1 { get => TipoCambio; set => TipoCambio = value; }


        public String Insert_CodigoTipoMoneda()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_CODIGOTIPOMONEDA ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(CodigoMoneda1, 2);
                instancia_conexion.annadir_parametro(TipoCambio1, 1);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado el código del tipo de moneda de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_CodigoTipoMoneda()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_CODIGOTIPOMONEDA ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(CodigoMoneda1, 2);
                instancia_conexion.annadir_parametro(TipoCambio1, 1);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado el código del tipo de moneda de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_CodigoTipoMoneda()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_CODIGOTIPOMONEDA ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(CodigoMoneda1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado el código del tipo de moneda de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public List<CodigoTipoMoneda> Select_Todo_CodigoTipoMoneda()
        {
            List<CodigoTipoMoneda> listacodigostipomoneda = new List<CodigoTipoMoneda>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_CODIGOTIPOMONEDA";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        CodigoTipoMoneda codigotipomoneda = new CodigoTipoMoneda();
                        codigotipomoneda.CodigoMoneda1 = CONTENEDOR["CODIGOMONEDA"].ToString();
                        codigotipomoneda.TipoCambio1 = Convert.ToDecimal(CONTENEDOR["TIPOCAMBIO"].ToString());
                        listacodigostipomoneda.Add(codigotipomoneda);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listacodigostipomoneda;
                }
                else
                {
                    return listacodigostipomoneda;
                }
            }
            catch (Exception error)
            {
                return listacodigostipomoneda;
            }
        }

    }
}