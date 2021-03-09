using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EjemploStorageBLOB
{
    public partial class Form1 : Form
    {
        ServiceStorageBlobs service;
        public Form1()
        {
            InitializeComponent();
            this.service = new ServiceStorageBlobs();
            CargarContainers();
        }

        private async void btncrear_ClickAsync(object sender, EventArgs e)
        {
            await this.service.CreateContainerAsync(this.txtcontenedor.Text);
            this.CargarContainers();
        }

        private void CargarContainers()
        {
            this.lstcontenedores.Items.Clear();
            foreach(String c in this.service.GetContainers())
            {
                this.lstcontenedores.Items.Add(c);
            }
        }

        private async void btnsubir_ClickAsync(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                String path = ofd.FileName;
                String filename = path.Substring(path.LastIndexOf(@"\")+1);
                String containername = this.lstcontenedores.SelectedItem.ToString();
                await this.service.UploadBlob(containername, filename, path);
                this.CargarBlobs();
            }
        }

        private void CargarBlobs()
        {
            this.lsvblobs.Items.Clear();
            String containerName = this.lstcontenedores.SelectedItem.ToString();
            foreach(CloudBlockBlob blob in this.service.GetBlobs(containerName))
            {
                String uri = blob.StorageUri.PrimaryUri.ToString();
                String size = blob.Properties.Length.ToString();
                ListViewItem it = new ListViewItem();
                it.Text = uri;
                it.SubItems.Add(size);
                this.lsvblobs.Items.Add(it);
            }
        }

        private void lstcontenedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lstcontenedores.SelectedIndex != -1)
            {
                this.CargarBlobs();
            }
        }

        private void lsvblobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.lsvblobs.SelectedItems.Count != 0)
            {
                String uri = this.lsvblobs.SelectedItems[0].Text;
                this.pictureBox1.Load(uri);

            }
        }

        private async void btndelete_Click(object sender, EventArgs e)
        {
            //devuelve url https://example/image.jpg
            String uri = this.lsvblobs.SelectedItems[0].Text;
            String filename = uri.Substring(uri.LastIndexOf("/") + 1);
            String containerName = this.lstcontenedores.SelectedItem.ToString();
            await this.service.DeleteBlobAsync(containerName, filename);
            this.CargarContainers();
        }
    }
}
