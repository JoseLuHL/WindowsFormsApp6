using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace Conexiones.Metodos
{
   public static class ConexionSQLServer
    {
        public static string error;
        public static string ValorConfig;
        public static int x;
        private static SqlConnection conexion = new SqlConnection();
        private static string cadenaC;
        private static string CadenaLocal=""; //Se utiliza para asignar una cadena en el proyecto
        public static string Respuesta;
        //Propiedad para la sentencia a ejecutar()
        //Para asignarle la cadena de conexión()
        public static void Conectar()
        {
            try
            {
                //Si no se ha asignado la cadena en el proyecto se utiliza la que esta en el archivo
                if (CadenaLocal != "")
                    cadenaC = CadenaLocal;                   
                else
                    cadenaC = cadena(); //Asignamos la cadena de conexion.

                conexion.ConnectionString = cadenaC;
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();               
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
        }
        private static void Cerrar_Conexion()
        {
            if (conexion.State == ConnectionState.Open)
                conexion.Open();            
        }
        private static string cadena()
        {
                string conexionTxt;
                conexionTxt = Application.StartupPath + @"\conexion\conexion.txt"; //ARCHIVO DE TEXTO PARA GUARDAR DATOS
                string[] lines = System.IO.File.ReadAllLines(conexionTxt);
                string[] conexion = System.IO.File.ReadAllLines(conexionTxt);
                return conexion[0];                     
        }
        //Permite ejecutar una sentencia en la base de datos()
        public static void Sentencia(string Query)
        {
            Conectar();
            SqlCommand Cmd = new SqlCommand(Query, conexion);
            Cmd.ExecuteNonQuery();
            Cerrar_Conexion();
        }
        //Permite cargar los datos al DGV()
        public static void CargarDatos(DataGridView Dgv, string Consulta)
        {
            try
            {
                DataTable Tabla = new DataTable();
                SqlDataAdapter DataAd = new SqlDataAdapter(Consulta, conexion);
                DataAd.Fill(Tabla);
                Dgv.DataSource = Tabla;
                DataAd.Dispose();
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
        }
        public static DataTable LlenarTabla( string Consulta)
        {
            DataTable Tabla = new DataTable();
            try
            {
                Conectar();
                SqlDataAdapter DataAd = new SqlDataAdapter(Consulta, conexion);
                DataAd.Fill(Tabla);
                DataAd.Dispose();
                Tabla.Dispose();
            }
            catch (Exception ex)
            {
                Respuesta = ex.Message;
            }
            return Tabla;

        }
        public static DataTable LlenarTablaAsync(string Consulta)
        {
            DataTable Tabla = new DataTable();
            try
            {
                SqlDataAdapter DataAd = new SqlDataAdapter();
                 DataAd = new SqlDataAdapter(Consulta, conexion);
                DataAd.Fill(Tabla);
                DataAd.Dispose();
                Tabla.Dispose();
               
            }
            catch (Exception e)
            {
                Respuesta = e.Message;
            }
            return Tabla;

        }
        public static void Solo_Numeros(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                {
                    e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
                }
        }
        public static void Solo_Letras(KeyPressEventArgs e)
        {

            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '\b')
            {
                e.Handled = true;
            }

        }
        public static string ValidarCelda(string valor)
        {
           string retornar="";

           if (valor == null)
               retornar = "";
           else
               retornar = valor;
            
           return valor;
        }
        public static void EstilosDgv(DataGridView DGV)
        {
            DGV.DefaultCellStyle.BackColor = Color.WhiteSmoke;
            DGV.DefaultCellStyle.Font = new Font("Century Gothic", 10);
            Font prFont = new Font("Century Gothic", 10, FontStyle.Bold);
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                DGV.Columns[i].HeaderCell.Style.Font = prFont;
                DGV.Columns[i].HeaderCell.Style.ForeColor = Color.Black;
                DGV.Columns[i].HeaderCell.Style.BackColor = Color.Gainsboro;
                DGV.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            DGV.EnableHeadersVisualStyles = false;
        }

        public static string EliminarCaracteres(string valor)  //Elimina los caracteres de una cadena como: (".", "$" y ",")
        {
            return valor.Replace(".", "").Replace("$", "").Replace(",", "");
        }

        public static string FormatoMiles(string valor)  //Asigna el formato de mil a un numero
        {
            double val = Convert.ToDouble(EliminarCaracteres(valor));
            string retorna = val.ToString("##,##0");
            return retorna;
        }
        public static string FormatoMiles_Simbolo(string valor)  //Asigna el formato de mil a un numero
        {
            double val = Convert.ToDouble(valor);
            string retorna = "$"+ val.ToString("##,##0");
            return retorna;
        }
        //metodo de enter y precione un tap
        //formato de nero y quitar el numero ...

        public static void Guardar_Arcivo(string direcionIMG, string NombreCarpeta, string nombreArchivo, string extencion)
        {
            try
            {
                //Direcion que contiene la carpeta del paciente, se crea con el numero de identificacion
                string CarpetaPaciente = Application.StartupPath + @"\" + NombreCarpeta + @"\";
                //Se utiliza para almacenar la ruta donde se guardara el examen
                //preguntamos si la carpeta existe
                if (Directory.Exists(CarpetaPaciente))
                {
                    //Ruta que contiene la carpeta con el numero de la atencion
                    File.Copy(direcionIMG, CarpetaPaciente + nombreArchivo + "." + extencion, true);
                }
                else
                {
                    Directory.CreateDirectory(CarpetaPaciente);
                    File.Copy(direcionIMG, CarpetaPaciente + nombreArchivo + "." + extencion, true);
                }
                error = "";
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
        }

    }

}

