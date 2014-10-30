using ColladaDotNet;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PackageModel.Collada_Reader;
using PackageModel.Duplicated_Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace PackageModel
{
    class ColladaGeometry
    {
        public string[] MaterialNames;
        public Triangle[][] TrianglesByMaterial;

        public bool HasTriangles = false;

        public Vector3[] VerticesLines;

        public bool HasLines = false;

        private GeometrySource GeometrySource;

        public ColladaGeometry(Collada_Geometry geometry)
        {
            //Dictionary of stuff
            List<string> Materials = new List<string>();
            List<Triangle[]> TrisMaterials = new List<Triangle[]>();

            List<Vector3> LinesVerts = new List<Vector3>();
            ///////////////////////////////

            GeometrySource = new GeometrySource(geometry);

            bool HasNormals = false; //Tells whether to fetch the normals too
            if (geometry.Mesh.Vertices.Input.Count() > 1)
                HasNormals = true;

            string VerticesID = geometry.Mesh.Vertices.ID;
            string PositionID = geometry.Mesh.Vertices.Input[0].source;
            string NormalsID = HasNormals ? geometry.Mesh.Vertices.Input[1].source : "";

            //Check if it has triangles and lines
            if (geometry.Mesh.Triangles != null && geometry.Mesh.Triangles.Count() > 0)
                HasTriangles = true;
            if (geometry.Mesh.Lines != null && geometry.Mesh.Lines.Count() > 0)
                HasLines = true;

            if (HasTriangles)
                foreach (Collada_Triangles triangles in geometry.Mesh.Triangles)
                {
                    //Add it to the materials list so you can create a unique geometry later
                    Materials.Add(triangles.Material);
                    //Check if it has texture coordinates
                    bool hasTexCoord = triangles.Input.Count() > 1;
                    string texCoordID = "";
                    //And get the id of the texCoord list
                    if (hasTexCoord)
                        texCoordID = triangles.Input[1].source.Substring(1);

                    //Create the list of triangles
                    List<Triangle> Tris = new List<Triangle>();

                    //Built vertex list
                    List<VertexDeferredLighting> Vertices = new List<VertexDeferredLighting>();
                    Vector3[] Normals = HasNormals ? GeometrySource.GetArray3D(NormalsID) : new Vector3[1];
                    Vector3[] Vertices2 = GeometrySource.GetArray3D(PositionID);
                    Vector2[] TexCoords = hasTexCoord ? GeometrySource.GetArray2D(texCoordID) : new Vector2[1];

                    for (int vertex = 0; vertex < Vertices2.Count(); vertex++)
                    {
                        var v = new VertexDeferredLighting();
                        v.Position = Vertices2[vertex];

                        if (HasNormals)
                            v.Normal = Normals[vertex];
                        else
                            v.Normal = new Vector3(0, 0, 1);

                        Vertices.Add(v);
                    }


                    int[] IndicesArray = triangles.P.Value();
                    if (hasTexCoord)
                        for (int index = 0; index < IndicesArray.Count(); index += 6)
                        {
                            Triangle tri = new Triangle() { 
                                v1 = Vertices[IndicesArray[index]], 
                                v2 = Vertices[IndicesArray[index + 2]], 
                                v3 = Vertices[IndicesArray[index + 4]] 
                            };
                            //Calculate Binormal and tangent
                            BinormalTangentCalculator.Calculate(tri);

                            //Set texCoords
                            tri.v1.TexCoord = TexCoords[IndicesArray[index + 1]];
                            tri.v2.TexCoord = TexCoords[IndicesArray[index + 3]];
                            tri.v3.TexCoord = TexCoords[IndicesArray[index + 5]];
                            //And add it to the triangles list
                            Tris.Add(tri);
                        }
                    else
                        for (int index = 0; index < IndicesArray.Count(); index += 3)
                        {
                            Triangle tri = new Triangle()
                            {
                                v1 = Vertices[IndicesArray[index]],
                                v2 = Vertices[IndicesArray[index + 1]],
                                v3 = Vertices[IndicesArray[index + 2]]
                            };



                            //Calculate Binormal and tangent
                            BinormalTangentCalculator.Calculate(tri);

                            //Set texCoords for the colored texture sampler
                            tri.v1.TexCoord = new Vector2(0, 0);
                            tri.v2.TexCoord = new Vector2(0, 1);
                            tri.v3.TexCoord = new Vector2(1, 1);
                            //And add it to the triangles list
                            Tris.Add(tri);

                        }
                    //Assign to output
                    TrisMaterials.Add(Tris.ToArray());
                }



            if (HasLines)
                foreach (Collada_Lines lines in geometry.Mesh.Lines)
                {
                    Vector3[] Vertices = GeometrySource.GetArray3D(PositionID);
                    int[] P = lines.P.Value();
                    for (int index = 0; index < P.Count(); index += 2)
                    {
                        LinesVerts.Add(Vertices[P[index]]);
                        LinesVerts.Add(Vertices[P[index + 1]]);
                    }
                }

            //And add to output
            MaterialNames = Materials.ToArray();
            TrianglesByMaterial = TrisMaterials.ToArray();
            VerticesLines = LinesVerts.ToArray();
        }

        public UniqueColladaGeometry MakeUniqueInstance(Matrix Transform, Dictionary<string, RectangleF> MaterialsDB)
        {
            //Declarations
            UniqueColladaGeometry outputGeometry = new UniqueColladaGeometry();
            List<Triangle> newTriangles = new List<Triangle>();
            List<Vector3> newVerticesLines = new List<Vector3>();
            //And start the loop over the materials for the vertices
            if (HasTriangles)
            {
                UpdateVertices(newTriangles, Transform, MaterialsDB);
            }

            if (HasLines)
            {
                //And over the Vertices for lines
                foreach (Vector3 v in VerticesLines)
                {
                    var newV = Vector3.Transform(v, Transform);
                    newVerticesLines.Add(newV);
                }
            }
            //And combine
            outputGeometry.Triangles = newTriangles.ToArray();
            outputGeometry.VerticesLines = newVerticesLines.ToArray();
            return outputGeometry;
        }
        private void UpdateVertices(List<Triangle> newTriangles, Matrix Transform, Dictionary<string, RectangleF> MaterialsDB)
        {

            for (int index = 0; index < TrianglesByMaterial.Count(); index++)
            {
                //Resolve the vertex array using that material
                var vArray = TrianglesByMaterial[index];
                //Resolve it's texture rectangle
                RectangleF TextureRect = MaterialsDB[MaterialNames[index]];
                //And turn it into a GPU Vector
                Vector4 TextureVector = new Vector4(TextureRect.X, TextureRect.Y, TextureRect.Width, TextureRect.Height);

                //Now loop over each vertex
                foreach (Triangle v in vArray)
                {

                    var newTriangle = new Triangle();
                    newTriangle.v1 = v.v1;
                    newTriangle.v2 = v.v2;
                    newTriangle.v3 = v.v3;
                    //Multiply it by the geometry matrix
                    newTriangle.v1.Position = Vector3.Transform(v.v1.Position, Transform);
                    newTriangle.v2.Position = Vector3.Transform(v.v2.Position, Transform);
                    newTriangle.v3.Position = Vector3.Transform(v.v3.Position, Transform);
                    //Give it the information on the texture size
                    newTriangle.v1.TexRect = TextureVector;
                    newTriangle.v2.TexRect = TextureVector;
                    newTriangle.v3.TexRect = TextureVector;
                    //And add it to the output
                    newTriangles.Add(newTriangle);
                }
            }
        }

    }



    public class UniqueColladaGeometry
    {
        public Triangle[] Triangles;
        public Vector3[] VerticesLines;

    }


}
