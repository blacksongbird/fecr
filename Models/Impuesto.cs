using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FECR.Models
{
    public class Impuesto
    {
        private string Codigo;
        private string CodigoTarifa;
        private decimal Tarifa;
        private decimal FactorIVA;
        private decimal Monto;
        private decimal MontoExportacion;

        public string Codigo1 { get => Codigo; set => Codigo = value; }
        public string CodigoTarifa1 { get => CodigoTarifa; set => CodigoTarifa = value; }
        public decimal Tarifa1 { get => Tarifa; set => Tarifa = value; }
        public decimal FactorIVA1 { get => FactorIVA; set => FactorIVA = value; }
        public decimal Monto1 { get => Monto; set => Monto = value; }
        public decimal MontoExportacion1 { get => MontoExportacion; set => MontoExportacion = value; }
        

        public String Insert_Impuesto()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC INSERT_IMPUESTO ?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Codigo1, 2);
                instancia_conexion.annadir_parametro(CodigoTarifa1, 2);
                instancia_conexion.annadir_parametro(Tarifa1, 1);
                instancia_conexion.annadir_parametro(FactorIVA1, 1);
                instancia_conexion.annadir_parametro(Monto1, 1);
                instancia_conexion.annadir_parametro(MontoExportacion1, 1);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha agregado el impuesto de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Update_Impuesto()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC UPDATE_IMPUESTO ?,?,?,?,?,?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Codigo1, 2);
                instancia_conexion.annadir_parametro(CodigoTarifa1, 2);
                instancia_conexion.annadir_parametro(Tarifa1, 3);
                instancia_conexion.annadir_parametro(FactorIVA1, 3);
                instancia_conexion.annadir_parametro(Monto1, 3);
                instancia_conexion.annadir_parametro(MontoExportacion1, 3);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha actualizado el impuesto de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public String Delete_Impuesto()
        {

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                instancia_conexion.inicializa();
                string CONSULTA;
                System.Data.OleDb.OleDbDataReader CONTENEDOR;

                CONSULTA = "EXEC DELETE_IMPUESTO ?";
                instancia_conexion.annadir_consulta(CONSULTA);
                instancia_conexion.annadir_parametro(Codigo1, 2);

                CONTENEDOR = instancia_conexion.busca();
                instancia_conexion.conexion.Close();
                instancia_conexion.conexion.Dispose();
                CONTENEDOR.Close();
                return "Se ha eliminado el impuesto de forma correcta.";
            }
            catch (Exception error)
            {
                return error.Message;
            }
        }

        public List<Impuesto> Select_Todo_Impuesto()
        {
            List<Impuesto> listaimpuestos = new List<Impuesto>();

            ConexionconBD instancia_conexion = new ConexionconBD();

            try
            {
                if (instancia_conexion.inicializa())
                {
                    string CONSULTA;
                    System.Data.OleDb.OleDbDataReader CONTENEDOR;

                    CONSULTA = "EXEC SELECT_TODO_IMPUESTO";
                    instancia_conexion.annadir_consulta(CONSULTA);
                    CONTENEDOR = instancia_conexion.busca();

                    while (CONTENEDOR.Read())
                    {
                        Impuesto impuesto = new Impuesto();
                        impuesto.Codigo1 = CONTENEDOR["CODIGO"].ToString();
                        impuesto.CodigoTarifa1 = CONTENEDOR["CODIGOTARIFA"].ToString();
                        impuesto.Tarifa1 = Convert.ToDecimal(CONTENEDOR["TARIFA"].ToString());
                        impuesto.FactorIVA1 = Convert.ToDecimal(CONTENEDOR["FACTOR_IVA"].ToString());
                        impuesto.Monto1 = Convert.ToDecimal(CONTENEDOR["MONTO"].ToString());
                        impuesto.MontoExportacion1 = Convert.ToDecimal(CONTENEDOR["MONTOEXPORTACION"].ToString());
                        listaimpuestos.Add(impuesto);
                    }
                    instancia_conexion.conexion.Close();
                    instancia_conexion.conexion.Dispose();
                    CONTENEDOR.Close();
                    return listaimpuestos;
                }
                else
                {
                    return listaimpuestos;
                }
            }
            catch (Exception error)
            {
                return listaimpuestos;
            }
        }

    }
}