using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVRasterizer.MeshData
{
    public class Vector2
    {
        public float x;
        public float y;

        public Vector2()
        {

        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }


        public static double Angle(Vector2 a, Vector2 b)
        {
            double sin = a.x * b.y - b.x * a.y;
            double cos = a.x * b.x + a.y * b.y;

            return Math.Atan2(sin, cos) * (180 / Math.PI);
            //return Math.Atan2(-(b.y - a.y), b.x - a.x);
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vector2 operator *(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }

        public float magnitude
        {
            get
            {
              return (float)Math.Sqrt(x * x + y * y);
            }
        }
    }
}
