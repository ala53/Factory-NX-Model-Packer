using Microsoft.Xna.Framework;
using PackageModel.Duplicated_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel
{
    class BinormalTangentCalculator
    {
        public static void Calculate(Triangle tri)
        {
            tri.v1.Tangent = Tangent(tri.v1);
            tri.v2.Tangent = Tangent(tri.v2);
            tri.v3.Tangent = Tangent(tri.v3);

            tri.v1.Binormal = Binormal(tri.v1);
            tri.v2.Binormal = Binormal(tri.v2);
            tri.v3.Binormal = Binormal(tri.v3);

            tri.v1.Normal = Vector3.Normalize(tri.v1.Normal);
            tri.v2.Normal = Vector3.Normalize(tri.v2.Normal);
            tri.v3.Normal = Vector3.Normalize(tri.v3.Normal);

            tri.v1.Binormal = Vector3.Normalize(tri.v1.Binormal);
            tri.v2.Binormal = Vector3.Normalize(tri.v2.Binormal);
            tri.v3.Binormal = Vector3.Normalize(tri.v3.Binormal);

            tri.v1.Tangent = Vector3.Normalize(tri.v1.Tangent);
            tri.v2.Tangent = Vector3.Normalize(tri.v2.Tangent);
            tri.v3.Tangent = Vector3.Normalize(tri.v3.Tangent);

            //A special case:
            //Sometimes, when normal is -1, the tangent = 0, which breaks as NaN because Cross(Normal, Tangent) = 0
            if (float.IsNaN(tri.v1.Tangent.X) || float.IsNaN(tri.v1.Tangent.Y) || float.IsNaN(tri.v1.Tangent.Z) ||
                float.IsNaN(tri.v2.Tangent.X) || float.IsNaN(tri.v2.Tangent.Y) || float.IsNaN(tri.v2.Tangent.Z) ||
                    float.IsNaN(tri.v3.Tangent.X) || float.IsNaN(tri.v3.Tangent.Y) || float.IsNaN(tri.v3.Tangent.Z))
            {
                tri.v1.Tangent = Tangent(tri.v1, new Vector3(0, 1, 0));
                tri.v2.Tangent = Tangent(tri.v2, new Vector3(0, 1, 0));
                tri.v3.Tangent = Tangent(tri.v3, new Vector3(0, 1, 0));

                tri.v1.Binormal = Binormal(tri.v1);
                tri.v2.Binormal = Binormal(tri.v2);
                tri.v3.Binormal = Binormal(tri.v3);

                tri.v1.Binormal = Vector3.Normalize(tri.v1.Binormal);
                tri.v2.Binormal = Vector3.Normalize(tri.v2.Binormal);
                tri.v3.Binormal = Vector3.Normalize(tri.v3.Binormal);

                tri.v1.Tangent = Vector3.Normalize(tri.v1.Tangent);
                tri.v2.Tangent = Vector3.Normalize(tri.v2.Tangent);
                tri.v3.Tangent = Vector3.Normalize(tri.v3.Tangent);
            }
        }

        public static Vector3 Tangent(VertexDeferredLighting v)
        {
            var t = Vector3.Cross(new Vector3(0, 0, 1), v.Normal);

            return t;
        }
        private static Vector3 Tangent(VertexDeferredLighting v, Vector3 Tan)
        {
            var t = Vector3.Cross(Tan, v.Normal);

            return t;
        }
        public static Vector3 Binormal(VertexDeferredLighting v)
        {
            return Vector3.Cross(v.Normal, v.Tangent);
        }
    }

}
