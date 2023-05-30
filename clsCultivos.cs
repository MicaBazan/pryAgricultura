using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace pryAgricultura
{
    class clsCultivos
    {
        private string cadena;
        private OleDbConnection conector;
        private OleDbCommand comando;
        private OleDbDataAdapter adaptador;
        private DataTable tabla;

        public clsCultivos()
        {
            cadena = clsConexion.getCadena();

            conector = new OleDbConnection(cadena);
            comando = new OleDbCommand();
            comando.Connection = conector;
            comando.CommandType = CommandType.TableDirect;
            comando.CommandText = "Cultivos";
            adaptador = new OleDbDataAdapter(comando);
            tabla = new DataTable();
            adaptador.Fill(tabla);

            DataColumn[] vector = new DataColumn[1];
            vector[0] = tabla.Columns["cultivo"];
            tabla.PrimaryKey = vector;
        }

        public DataTable getCultivos()
        {
            return tabla;
        }

        public void ver(ComboBox combo)
        {
            combo.DisplayMember = "nombre";
            combo.ValueMember = "cultivo";
            combo.DataSource = tabla;
        }
    }
}
