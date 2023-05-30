using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace pryAgricultura
{
    class clsProduccion
    {
        private string cadena;
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        public clsProduccion()
        {
            cadena = clsConexion.getCadena();

            conector = new OleDbConnection(cadena);
            comando = new OleDbCommand();
            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Produccion";
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] vector = new DataColumn[2];
            vector[0] = tabla.Columns["localidad"];
            vector[1] = tabla.Columns["cultivo"];
            tabla.PrimaryKey = vector;
        }

        public DataTable getProduccion()
        {
            return tabla;
        }

        public bool actualizar(int localidad, int cultivo, int toneladas)
        {
            bool valor = true;
            
            //Vector para guardar las dos claves de la tabla y poder buscarla con el find
            Object[] clave = new object[2];
            clave[0] = localidad;
            clave[1] = cultivo;

            DataRow filaBuscada = tabla.Rows.Find(clave);
            if (filaBuscada == null)
            {
                //Crea una variable registro
                DataRow fila = tabla.NewRow();
                fila["localidad"] = localidad;
                fila["cultivo"] = cultivo;
                fila["toneladas"] = toneladas;
                tabla.Rows.Add(fila);
                OleDbCommandBuilder ocb = new OleDbCommandBuilder(adaptador);
                adaptador.Update(tabla);
            }
            else
            {
                valor = false;
            }
            return valor;
        }

        public void graficar(int localidad, Chart chart)
        {

        }
    }
}
