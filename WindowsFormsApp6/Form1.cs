using Conexiones.Metodos;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnUbicacion_Click(object sender, EventArgs e)
        {
            ConexionSQLServer.Conectar();
            //FormatoMiles_Simbolo
            MessageBox.Show(ConexionSQLServer.Respuesta);
            // Se crea el OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();
            // Se muestra al usuario esperando una acción
            DialogResult result = dialog.ShowDialog();

            // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
            // la mostramos en el PictureBox de la inferfaz
            if (result == DialogResult.OK)
            {
                string filename = dialog.FileName;

                if (Regex.IsMatch(filename.ToLower(), @"^.*\.(txt)$"))
                {
                    ConexionSQLServer.Guardar_Arcivo(filename, "conexion", "conexion", "txt");
                    MessageBox.Show(ConexionSQLServer.error);
                }
                else
                {
                    MessageBox.Show("El archivo seleccionado no es valido \n la extención debe ser .tex");
                }
            }
        }
    }
}
