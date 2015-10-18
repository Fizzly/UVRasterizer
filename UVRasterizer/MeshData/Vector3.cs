using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UVRasterizer.MeshData
{
    public class Vector3
    {
        public float x;
        public float y;
        public float z;

        public Vector3()
        {

        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator *(Vector3 v1,  float val)
        {
            return new Vector3(v1.x * val, v1.y * val, v1.z * val);
        }

        public static Vector3 operator /(Vector3 v1, float val)
        {
            return new Vector3(v1.x / val, v1.y / val , v1.z / val);
        }


        public float magnitude
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z*z);
            }
        }

        public static Vector3 Normalize(Vector3 v1)
        {
            var magnitude = v1.magnitude;

            // Check that we are not attempting to normalize a vector of magnitude 0
            if (magnitude == 0)
            {
                return null;
            }

            // Check that we are not attempting to normalize a vector of magnitude NaN
            if (double.IsNaN(magnitude))
            {
                return null;
            }

            // Special Cases
            if (double.IsInfinity(v1.magnitude))
            {
                var x =
                    v1.x == 0 ? 0 :
                        v1.x == -0 ? -0 :
                            double.IsPositiveInfinity(v1.x) ? 1 :
                                double.IsNegativeInfinity(v1.x) ? -1 :
                                    double.NaN;
                var y =
                    v1.y == 0 ? 0 :
                        v1.y == -0 ? -0 :
                            double.IsPositiveInfinity(v1.y) ? 1 :
                                double.IsNegativeInfinity(v1.y) ? -1 :
                                    double.NaN;
                var z =
                    v1.z == 0 ? 0 :
                        v1.z == -0 ? -0 :
                            double.IsPositiveInfinity(v1.z) ? 1 :
                                double.IsNegativeInfinity(v1.z) ? -1 :
                                    double.NaN;

                var result = new Vector3((float)x, (float)y, (float)z);

                // If this was a special case return the special case result
                return result;
            }

            // Run the normalization as usual
            return NormalizeOrNaN(v1);
        }

        public Vector3 Normalize()
        {
            return Normalize(this);
        }


        private static Vector3 NormalizeOrNaN(Vector3 v1)
        {
            // find the inverse of the vectors magnitude
            float inverse = 1 / v1.magnitude;

            return new Vector3(
                // multiply each component by the inverse of the magnitude
                v1.x * inverse,
                v1.y * inverse,
                v1.z * inverse);
        }

        private const string NORMALIZE_0 =
            "Cannot normalize a vector when it's magnitude is zero";

        private const string NORMALIZE_NaN =
            "Cannot normalize a vector when it's magnitude is NaN";

        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
