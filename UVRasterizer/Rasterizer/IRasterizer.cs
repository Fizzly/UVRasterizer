using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using UVRasterizer.MeshData;

namespace UVRasterizer.Rasterizer
{
    public interface IRasterizer
    {
        Bitmap RasterizeData();
        Bitmap RasterizeData(Mesh mesh);
    }
}
