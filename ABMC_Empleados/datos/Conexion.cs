using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMC_Empleados.datos
{
    internal class Conexion
    {
        SqlConnection con;
        public Conexion()
        {
            con = new SqlConnection("Server=EMIMICHELLI\\EMI;Database=empleado_db;integrated security=true");
        }

        public SqlConnection conectar()
        {
            try

            {
                con.Open();
                return con;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        public bool desconectar()
        {
            try

            {
                con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
