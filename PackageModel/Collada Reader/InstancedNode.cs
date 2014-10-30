using ColladaDotNet;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    class InstancedNode
    {
        public List<InstanceNode> Children = new List<InstanceNode>();
        public List<InstanceGeometry> GeometryInstances = new List<InstanceGeometry>();
        public string NodeName;
        public string NodeId;

        public InstancedNode()
        {

        }

        public InstancedNode(Collada_Node node)
        {
            //Decode the geometry instances
            if (node.Instance_Geometry != null)
                foreach (Collada_Instance_Geometry geometry in node.Instance_Geometry)
                {
                    var m = new InstanceGeometry();
                    m.Geometry = geometry;
                    m.Matrix = Matrix.Identity;
                    GeometryInstances.Add(m);
                }

            //and process it's children
            if (node.node != null)
                foreach (Collada_Node Node in node.node)
                {
                    var m = new InstanceNode();
                    m.Node = Node;
                    m.Matrix = Matrix.Identity;

                    Children.Add(m);
                }
            //Set its name and Id
            NodeId = node.ID;
            NodeName = node.Name;
        }

        /// <summary>
        /// What this does (for reference):
        /// It goes through the list of child nodes.
        /// First, it resolves all node instances to their respective nodes.
        /// Then, it gets their nodes and copies them, multiplying the matrix internally so that it has the correct scale for
        /// this instance.
        /// It then does the same with the geometry.
        /// </summary>
        /// <param name="Nodes"></param>
        public void ProcessChildren(Dictionary<string, InstancedNode> Nodes)
        {
            List<InstanceNode> NewNodes = new List<InstanceNode>();
            foreach (InstanceNode child in Children)
            {
                //Get the child node's matrix
                var mMatrix = Matrix.Identity;
                if (child.Node.Matrix != null)
                {
                    var mC = child.Node.Matrix[0].Value();
                    mMatrix *= new Matrix(
                            mC[0], mC[4], mC[8], mC[12],
                            mC[1], mC[5], mC[9], mC[13],
                            mC[2], mC[6], mC[10], mC[14],
                            mC[3], mC[7], mC[11], mC[15]);
                }
                if (child.Node.Instance_Node != null)
                {
                    //Then, for each of the referenced instances, add it's children and geometries
                    foreach (Collada_Instance_Node instanceNode in child.Node.Instance_Node)
                    {
                        //Lookup it's node
                        var Node = Nodes[instanceNode.URL.Substring(1)];
                        //Add it's children and geometries, making sure to multiply the matrices
                        foreach (InstanceNode node in Node.Children)
                        {
                            var m = node;
                            m.Matrix *= mMatrix;
                            NewNodes.Add(m);
                        }
                        //And the geometry, making sure to multiply the matrices
                        foreach (InstanceGeometry geom in Node.GeometryInstances)
                        {
                            var m = geom;
                            m.Matrix *= mMatrix;
                            GeometryInstances.Add(m);
                        }
                    }
                }

                //Just in case there's also some geometries
                if (child.Node.Instance_Geometry != null)
                {
                    foreach (Collada_Instance_Geometry geo in child.Node.Instance_Geometry)
                    {
                        var geom = new InstanceGeometry();
                        geom.Matrix = child.Matrix;
                        geom.Geometry = geo;

                        GeometryInstances.Add(geom);
                    }
                }
            }
            Children = NewNodes;
        }

        /// <summary>
        /// Compiles the node (which is typically a component) to it's respective geometries
        /// </summary>
        /// <param name="ColladaFile"></param>
        /// <param name="Geometries"></param>
        /// <param name="materials"></param>
        /// <param name="map"></param>
        /// <returns></returns>
        public GeometryInstance[] CompileNode(Collada ColladaFile, Dictionary<string, ColladaGeometry> Geometries, MaterialList materials, TextureMap map)
        {
            List<GeometryInstance> CompiledInstances = new List<GeometryInstance>();
            foreach (InstanceGeometry geo in GeometryInstances)
            {
                CompiledInstances.Add(new GeometryInstance(geo.Geometry, geo.Matrix, ColladaFile, Geometries, materials, map));
            }
            return CompiledInstances.ToArray();
        }
        public GeometryInstance[] CreateInstanceOfNode(Collada ColladaFile, Matrix InstanceMatrix, Dictionary<string, ColladaGeometry> Geometries, MaterialList materials, TextureMap map)
        {
            List<GeometryInstance> CompiledInstances = new List<GeometryInstance>();
            foreach (InstanceGeometry geo in GeometryInstances)
            {
                CompiledInstances.Add(new GeometryInstance(geo.Geometry, geo.Matrix * InstanceMatrix, ColladaFile, Geometries, materials, map));
            }
            return CompiledInstances.ToArray();
        }



        public struct InstanceGeometry
        {
            public Matrix Matrix;
            public Collada_Instance_Geometry Geometry;
        }
        public struct InstanceNode
        {
            public Matrix Matrix;
            public Collada_Node Node;
        }
    }
}
