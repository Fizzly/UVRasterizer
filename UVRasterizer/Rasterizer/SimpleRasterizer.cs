using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using UVRasterizer.MeshData;

namespace UVRasterizer.Rasterizer
{
    class SimpleRasterizer : IRasterizer
    {
        public Bitmap RasterizeData()
        {
            return null;
        }

        public Bitmap RasterizeData(MeshData.Mesh mesh)
        {

            int resolution = 512;


            Bitmap bitmap = new Bitmap(resolution,resolution);

            Vector2 vertexUV1;
            Vector2 vertexUV2;
            Vector2 vertexUV3;

            float step = (1f / resolution);

            int trianglecount = 0;

            for (int index = 0; index < mesh.triangles.Length; index+=3)
            {

                Vector3 normal = mesh.normals[mesh.triangles[index]] + mesh.normals[mesh.triangles[index + 1]] + mesh.normals[mesh.triangles[index + 2]];

                normal = normal / 3;


                normal.Normalize();

                
                vertexUV1 = mesh.uv[mesh.triangles[index  ]];
                vertexUV2 = mesh.uv[mesh.triangles[index+1]];
                vertexUV3 = mesh.uv[mesh.triangles[index+2]];

                /* get the bounding box of the triangle */
                float minX = Math.Min(vertexUV1.x, Math.Min(vertexUV2.x, vertexUV3.x));
                float maxY = Math.Max(vertexUV1.y, Math.Max(vertexUV2.y, vertexUV3.y));
                float minY = Math.Min(vertexUV1.y, Math.Min(vertexUV2.y, vertexUV3.y));
                float maxX = Math.Max(vertexUV1.x, Math.Max(vertexUV2.x, vertexUV3.x));

                // Crop rect to size of texture and iterate through every pixel in that rect
                int pixMinX = (int)Math.Max(Math.Floor(minX * resolution) - 1, 0); int pixMaxX = (int)Math.Min(Math.Ceiling(maxX * resolution) + 1, resolution);
                int pixMinY = (int)Math.Max(Math.Floor(minY * resolution) - 1, 0); int pixMaxY = (int)Math.Min(Math.Ceiling(maxY * resolution) + 1, resolution);

                //HeronsForumula finds the area of a triangle based on its side lengths (The vertex positions are used as inputs here)
                float area = HeronsForumula(vertexUV1, vertexUV2, vertexUV3);

                for (int x = pixMinX; x < pixMaxX; x++)
                {
                    for (int y = pixMinY; y < pixMaxY; y++)
                    {
                        Vector2 pixel = new Vector2(((float)x) * step, ((float)y) * step);
                        //Early rejection of pixel if outside of triangle or outside of texture.

                        //bitmap.SetPixel(x, y, Color.Black);

                        double angle = Vector2.Angle(vertexUV1 - pixel, vertexUV2 - pixel) + Vector2.Angle(vertexUV2 - pixel, vertexUV3 - pixel) + Vector2.Angle(vertexUV3 - pixel, vertexUV1 - pixel);
                        if (angle > 359.9)
                        {
                            bitmap.SetPixel(x, resolution - y, Color.FromArgb((int)(((normal.x * 0.5f) + 0.5f) * 255f), (int)(((normal.y * 0.5f) + 0.5f) * 255f), 128));
                           // bitmap.SetPixel(x, resolution - y, Color.FromArgb(128,128, 255));
                        }

                    }
                }

            }

            
            return bitmap;
        }


        float HeronsForumula(Vector2 a, Vector2 b, Vector2 c)
        {
            float ab = (a - b).magnitude;
            float bc = (b - c).magnitude;
            float ca = (c - a).magnitude;
            float s = 0.5f * (ab + bc + ca);
            return (float)Math.Sqrt(s * (s - ab) * (s - bc) * (s - ca));
        }
    }
}
