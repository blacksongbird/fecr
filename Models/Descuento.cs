using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Descuento
    {
        private decimal MontoDescuento;
        private string _NaturalezaDescuento;

        public decimal MontoDescuento1 { get => MontoDescuento; set => MontoDescuento = value; }
        public string NaturalezaDescuento { get => _NaturalezaDescuento; set => _NaturalezaDescuento = value; }


        public String Insert_Descuento()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_DESCUENTO ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(MontoDescuento1, 1);
                instancia_conexion.annadir_parametro(NaturalezaDescuento, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado el descuento de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Descuento()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_DESCUENTO ?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(MontoDescuento1, 1);
                instancia_conexion.annadir_parametro(NaturalezaDescuento, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado el descuento de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public Descuento Select_Descuento()
        {
            ConexionconBD instancia_conexion = new ConexionconBD();
            Descuento descuento = new Descuento();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_DESCUENTO ?,?";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    instancia_conexion.annadir_parametro(MontoDescuento1, 1);
                    instancia_conexion.annadir_parametro(NaturalezaDescuento, 2);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        descuento.MontoDescuento1 = Convert.ToDecimal(CONTENEDOR["MONTODESCUENTO"].ToString());
                        descuento.NaturalezaDescuento = CONTENEDOR["_NATURALEZADESCUENTO"].ToString();

                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return descuento;
                }
                else
                {
                    return descuento;
                }
            }
            catch (Exception error)
            {
                return descuento;
            }
        }

        public List<Descuento> Select_Todo_Descuento()
        {
            List<Descuento> listadescuentos = new List<Descuento>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_DESCUENTO";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Descuento descuento = new Descuento();
                        descuento.MontoDescuento1 = Convert.ToDecimal(CONTENEDOR["MONTODESCUENTO"].ToString());
                        descuento.NaturalezaDescuento = CONTENEDOR["_NATURALEZADESCUENTO"].ToString();
                        listadescuentos.Add(descuento);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listadescuentos;
                }
                else
                {
                    return listadescuentos;
                }
            }
            catch (Exception error)
            {
                return listadescuentos;
            }
        }

    }
}