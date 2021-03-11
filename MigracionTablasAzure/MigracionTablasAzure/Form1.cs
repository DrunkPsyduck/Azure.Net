using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using Microsoft.Azure.Cosmos.Table;
using System.IO;
using System.Xml.Linq;

namespace MigracionTablasAzure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnmigrar_Click(object sender, EventArgs e)
        {
            String keys = ConfigurationSettings.AppSettings["storageaccountkey"];
            CloudStorageAccount account = CloudStorageAccount.Parse(keys);
            CloudTableClient client = account.CreateCloudTableClient();
            CloudTable tabla = client.GetTableReference("tablaalumnos");//recursos de azure en minusculas
            tabla.CreateIfNotExists();
            Stream content = this.GetType().Assembly.GetManifestResourceStream("MigracionTablasAzure.alumnos_tables_storage.xml");
            XDocument docxml = XDocument.Load(content);

            var consulta = from datos in docxml.Descendants("alumno")
                           select new Alumno
                           {
                               IdAlumno = datos.Element("idalumno").Value,
                               Nombre = datos.Element("nombre").Value,
                               curso = datos.Element("curso").Value,
                               Apellidos = datos.Element("apellidos").Value,
                               Nota = datos.Element("nota").Value
                           };
            foreach(Alumno alum in consulta)
            {
                TableOperation insert = TableOperation.Insert(alum);
                tabla.Execute(insert);
            }
            this.lblmensaje.Text = "Todo OK";
        }
    }
}
