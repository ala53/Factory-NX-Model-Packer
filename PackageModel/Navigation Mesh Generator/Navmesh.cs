using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using PackageModel.Duplicated_Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Navigation_Mesh_Generator
{
    /// <summary>
    /// More or less, an octree implementation for pathfinding.
    /// </summary>
    public class Navmesh
    {
        /// <summary>
        /// 2 array of 1 ft cubes. marked as filled or not
        /// </summary>
        public bool[,,] FilledGeometry;
        /// <summary>
        /// Optimized grid navigation mesh. Built on a series of squares.
        /// </summary>
        public HashSet<NavMeshArea> MeshAreas = new HashSet<NavMeshArea>();

        /// <summary>
        /// Creates a navmesh based on the geometry.
        /// </summary>
        /// <param name="width">Width in feet of the model</param>
        /// <param name="depth">Depth in feet of the model</param>
        public Navmesh(int width, int height, int depth, VertexDeferredLighting[] Triangles)
        {
            FilledGeometry = new bool[width, height, depth];
        }
    }

    public struct NavMeshArea
    {

        public float edgeLength;
        public Vector3 center;
        public bool filled;
    }
}
