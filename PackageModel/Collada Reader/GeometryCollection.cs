using Microsoft.Xna.Framework;
using PackageModel.Duplicated_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PackageModel.Collada_Reader
{
    class GeometryCollection
    {
        public static CompiledGeometry MergeGeometries(GeometryInstance[] Instances)
        {
            //These are the vertices and indices for ALL of the triangles - 6 mb of memory preallocated for performance
            List<VertexDeferredLighting> TriangleVertices = new List<VertexDeferredLighting>(50000); //4 mb allocated
            HashSet<VertexDeferredLighting> TriangleVerticesHash = new HashSet<VertexDeferredLighting>(); //hashset for collision checks
            Dictionary<VertexDeferredLighting, int> TriangleIndices = new Dictionary<VertexDeferredLighting, int>();

            List<int> Indices = new List<int>(500000); //2 mb allocated

            List<Vector3> VerticesLines = new List<Vector3>();
            List<int> IndicesLines = new List<int>();
            HashSet<Vector3> VLinesHash = new HashSet<Vector3>();
            Dictionary<Vector3, int> VLinesIndices = new Dictionary<Vector3, int>();

            //DEBUG LOGGING
            Console.WriteLine("Merging geometry instances...");
            //Draw the first instance of the progress bar
            ConsoleTools.drawTextProgressBar(0, Instances.Count());

            //Allows fast duplicate checks
            HashSet<InternalTriangle> DuplicateCheck = new HashSet<InternalTriangle>();

            Int32 CompletedInstances = 0;

            ProcessInstanceList(Instances,
                TriangleVertices, TriangleVerticesHash, TriangleIndices,
                Indices, DuplicateCheck, VerticesLines, IndicesLines, VLinesHash, VLinesIndices, 0,
                   Instances.Count(), ref CompletedInstances);

            //Account for the progress bar resetting cursor position
            Console.WriteLine();

            //And output

            CompiledGeometry output = new CompiledGeometry();
            output.Vertices = TriangleVertices.ToArray();
            output.Indices = Indices.ToArray();
            output.VerticesLines = VerticesLines.ToArray();
            output.IndicesLines = IndicesLines.ToArray();

            return output;
        }

        static object SyncLock = new object();

        private static void ProcessInstanceList(GeometryInstance[] Instances,
            List<VertexDeferredLighting> TriangleVertices,
            HashSet<VertexDeferredLighting> TriangleVerticesHash,
            Dictionary<VertexDeferredLighting, int> TriangleIndexLookupTable,
            List<int> TrianglesIndices,
            HashSet<InternalTriangle> DuplicateCheck,
            List<Vector3> VerticesLines,
            List<int> IndicesLines,
            HashSet<Vector3> VerticesLinesHash,
            Dictionary<Vector3, int> LinesIndexLookupTable,
            int StartIndex,
            int EndIndex,
            ref int CompletedInstances)
        {

            for (int instanceIndex = StartIndex; instanceIndex < EndIndex; instanceIndex++)
            {
                #region Process Triangles
                var instance = Instances[instanceIndex];
                foreach (Triangle tri in instance.Instanced.Triangles)
                {
                    //First check if the entire triangle is a duplicate
                    InternalTriangle tr = new InternalTriangle()
                    {
                        v1 = tri.v1,
                        v2 = tri.v2,
                        v3 = tri.v3
                    };

                    if (!DuplicateCheck.Contains(tr))
                    {
                        lock (SyncLock)
                            DuplicateCheck.Add(tr);
                        //Now, we are going to add the vertices to the list if they don't exist. 
                        //If they do, we use them instead
                        ProcessTriangle(TriangleVertices, TriangleVerticesHash, TriangleIndexLookupTable, TrianglesIndices, tri);
                    }

                }

                #endregion
                //and process the lines

                #region Process Lines
                for (int index = 0; index < instance.Instanced.VerticesLines.Count(); index += 2)
                {
                    Vector3 v1 = instance.Instanced.VerticesLines[index];
                    Vector3 v2 = instance.Instanced.VerticesLines[index + 1];

                    ProcessLine(v1, v2, VerticesLines, IndicesLines, VerticesLinesHash, LinesIndexLookupTable);
                }
                #endregion

                //And increment the amount of merged geometries
                Interlocked.Increment(ref CompletedInstances);

                ConsoleTools.drawTextProgressBar(CompletedInstances, Instances.Count());
            }
        }

        private static void ProcessTriangle(List<VertexDeferredLighting> Vertices, HashSet<VertexDeferredLighting> VHash, Dictionary<VertexDeferredLighting, int> IndexList, List<int> Indices, Triangle tri)
        {
            //Process all 3 vertices
            ProcessVertex(Vertices, VHash, IndexList, Indices, tri.v1);
            ProcessVertex(Vertices, VHash, IndexList, Indices, tri.v2);
            ProcessVertex(Vertices, VHash, IndexList, Indices, tri.v3);
        }


        private static void ProcessVertex(List<VertexDeferredLighting> Vertices, HashSet<VertexDeferredLighting> VHash, Dictionary<VertexDeferredLighting, int> IndexList, List<int> Indices, VertexDeferredLighting vertex)
        {
            if (!VHash.Contains(vertex))
            {
                //It's a new one, add it to the list
                lock (SyncLock)
                    Vertices.Add(vertex);
                lock (SyncLock)
                    VHash.Add(vertex);

                //Optimization
                IndexList.Add(vertex, Vertices.Count - 1);

                //then add the vertex
                Indices.Add(
                    Vertices.Count - 1
                    );
            }
            else
            {
                //It exists, just add the index
                Indices.Add(
                    IndexList[vertex]
                    );
            }
        }

        private static void ProcessLine(Vector3 vertex1, Vector3 vertex2, List<Vector3> Vertices, List<int> Indices, HashSet<Vector3> VHash, Dictionary<Vector3, int> VIndices)
        {
            ProcessVertexLines(vertex1, Vertices, Indices, VHash, VIndices);
            ProcessVertexLines(vertex2, Vertices, Indices, VHash, VIndices);
        }
        private static void ProcessVertexLines(Vector3 vertex, List<Vector3> Vertices, List<int> Indices, HashSet<Vector3> VHash, Dictionary<Vector3, int> VIndices)
        {
            if (!VHash.Contains(vertex))
            {
                Vertices.Add(vertex);
                VHash.Add(vertex);
                VIndices.Add(vertex, Vertices.Count - 1);
            }
            else
            {
                //It exists, just add to the index list
                Indices.Add(VIndices[vertex]);
            }
        }

    }


    struct InternalTriangle
    {
        public VertexDeferredLighting v1;
        public VertexDeferredLighting v2;
        public VertexDeferredLighting v3;

        public override int GetHashCode()
        {
            unchecked
            {
                var v = v1.Position.X + v1.Position.Y + v1.Position.Z
                    + v2.Position.X + v2.Position.Y + v2.Position.Z
                    + v3.Position.X + v3.Position.Y + v3.Position.Z;

                return v.GetHashCode();
            }
        }
    }
}
