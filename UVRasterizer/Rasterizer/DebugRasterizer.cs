using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace UVRasterizer.Rasterizer
{
    class DebugRasterizer : IRasterizer
    {
        private const int WIDTH = 128;
        private const int HEIGHT = 128;

        private Bitmap bitmap;

        public Bitmap RasterizeData()
        {
            bitmap = new Bitmap(WIDTH, HEIGHT);

            DrawData();

            return bitmap;
        }

        private void DrawData()
        {
            for(int x = 0; x < WIDTH; x++)
            {
                for (int y = 0; y < HEIGHT; y++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(x,y,255));
                }
            }
        }

        public Bitmap RasterizeData(MeshData.Mesh mesh)
        {
 	        throw new NotImplementedException();
        }
    }
}
