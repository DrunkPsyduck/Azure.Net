using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.File;

namespace EjemploSotrageFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void botonleerfile_Click(object sender, EventArgs e)
        {
            //clave de acceso a storage
            String key = CloudConfigurationManager.GetSetting("storagecnnstring");

            CloudStorageAccount account = CloudStorageAccount.Parse(key);

            //El acceso al rescurso se realiza mediante un recurso especializado
            CloudFileClient client = account.CreateCloudFileClient();

            //acceso al recurso compartido Shared que se ha creado en storage file

            CloudFileShare filesshare = client.GetShareReference("ejemplo");

            //Los ficheros se encuentran en la raiz (/) del Shared
            CloudFileDirectory raiz = filesshare.GetRootDirectoryReference();
            CloudFile file = raiz.GetFileReference("CochesSQL.txt");

            String contenido = await file.DownloadTextAsync();
            this.txtcontenido.Text = contenido;
        }
    }
}
