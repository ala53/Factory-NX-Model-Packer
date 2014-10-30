using ColladaDotNet;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    class GeometrySource
    {
        public Dictionary<string, Vector3[]> VertexSources3D = new Dictionary<string, Vector3[]>();
        public Dictionary<string, Vector2[]> VertexSources2D = new Dictionary<string, Vector2[]>();

        public GeometrySource(Collada_Geometry geometry)
        {
            foreach (Collada_Source source in geometry.Mesh.Source)
            {
                float[] values = source.Float_Array.Value();
                if (source.Technique_Common.Accessor.Stride == 2) //2D array
                {
                    List<Vector2> Vertices = new List<Vector2>();
                    for (int i = 0; i < values.Count(); i += 2)
                    {
                        Vertices.Add(new Vector2(
                            values[i],
                            values[i + 1]
                            ));
                    }
                    VertexSources2D.Add(source.ID, Vertices.ToArray());
                }
                else
                {
                    List<Vector3> Vertices = new List<Vector3>();
                    for (int i = 0; i < values.Count(); i += 3)
                    {
                        //3d array
                        Vertices.Add(new Vector3(
                            values[i],
                            values[i + 1],
                            values[i + 2]
                            ));
                    }
                    VertexSources3D.Add(source.ID, Vertices.ToArray());
                }
            }
        }

        public Vector2[] GetArray2D(string ID)
        {
            if (ID.StartsWith("#"))
                return VertexSources2D[ID.Substring(1)];
            else
                return VertexSources2D[ID];
        }

        public Vector3[] GetArray3D(string ID)
        {
            if (ID.StartsWith("#"))
                return VertexSources3D[ID.Substring(1)];
            else
                return VertexSources3D[ID];
        }
    }

}
