using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UVRasterizer.MeshData;
using UVRasterizer.Rasterizer;
using UVRasterizer.ObjLoader;

namespace UVRasterizer
{
    public partial class MainForm : Form
    {
        private IRasterizer rasterizer = new DebugRasterizer();
        private Mesh mesh;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            pictureBoxRasterizedImage.Image = rasterizer.RasterizeData();
        }

        private void buttonLoadOBJ_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "OBJ Models (.obj)|*.obj|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                OBJToMesh OBJConverter = new OBJToMesh();
                mesh = OBJConverter.ImportFile(fileDialog.FileName);

            }
        }
    }
}
