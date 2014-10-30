using ColladaDotNet;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    class ModularNode
    {
        public string Name;
        public string Id;

        public Collada_Node Base;

        public List<INodePointer> NodePointers = new List<INodePointer>();

        public List<InstanceGeometry> Geometries = new List<InstanceGeometry>();

        public Matrix Matrix = Matrix.Identity;

        public struct InstanceGeometry
        {
            public Collada_Instance_Geometry Geometry;
            public Matrix Matrix;
        }
        public struct INodePointer
        {
            public string NodeRefID;
            public Matrix Matrix;
        }

        public ModularNode()
        {

        }

        public ModularNode(Collada_Node Node)
            : this(Node, Matrix.Identity)
        {

        }
        public ModularNode(Collada_Node Node, Matrix ProcessingMatrix)
        {
            Base = Node;
            Matrix = ProcessingMatrix;
            Name = Base.Name;
            Id = Base.ID;

            TraceBaseNodes();
        }

        /// <summary>
        /// This method traces all the child nodes, splitting them into either Geometries or Node Pointers.
        /// </summary>
        public void TraceBaseNodes()
        {
            //Get all nodes (including this one) in the geometry
            var NodesContained = TraceNodesInclusive(Base);
            foreach (InstancedNode.InstanceNode node in NodesContained)
            {
                //Trace the node references
                if (node.Node.Instance_Node != null)
                    foreach (Collada_Instance_Node ptr in node.Node.Instance_Node)
                    {
                        var NPtr = new INodePointer();
                        NPtr.NodeRefID = ptr.URL.Substring(1);
                        NPtr.Matrix = node.Matrix * Matrix;

                        NodePointers.Add(NPtr);
                    }

                //And the geometries
                if (node.Node.Instance_Geometry != null)
                    foreach (Collada_Instance_Geometry geo in node.Node.Instance_Geometry)
                    {
                        var IGeometry = new InstanceGeometry();
                        IGeometry.Matrix = node.Matrix * Matrix;
                        IGeometry.Geometry = geo;

                        Geometries.Add(IGeometry);
                    }
            }

        }

        /// <summary>
        /// Call this after all nodes have had their base nodes traced. 
        /// It resolves all Node References to their respective geometries.
        /// </summary>
        /// <param name="ComponentNodes"></param>
        public void TracePointers(Dictionary<string, ModularNode> ComponentNodes)
        {
            var NewPtrs = new List<INodePointer>();
            foreach (INodePointer ptr in NodePointers)
            {
                var ResolvedNode = ComponentNodes[ptr.NodeRefID];
                //And copy it's geometries
                foreach (InstanceGeometry geo in ResolvedNode.Geometries)
                {
                    var newGeo = geo;
                    newGeo.Matrix *= ptr.Matrix;

                    Geometries.Add(newGeo);
                }

                //And it's references
                foreach (INodePointer nPtr in ResolvedNode.NodePointers)
                {
                    var newPtr = nPtr;
                    newPtr.Matrix *= ptr.Matrix;

                    NewPtrs.Add(newPtr);
                }
            }

            NodePointers = NewPtrs;
        }

        public bool IsNodeTracingCompleted()
        {
            return NodePointers.Count == 0;
        }


        #region Trace all the child Nodes

        /// <summary>
        /// The internal recursive call to trace nodes. Not intended for external use.
        /// </summary>
        /// <param name="Parent"></param>
        /// <param name="Nodes"></param>
        /// <param name="ParentMatrix"></param>
        static void InternalTraceNodes(Collada_Node Parent, List<InstancedNode.InstanceNode> Nodes, Matrix ParentMatrix)
        {
            if (Parent.node != null)
                foreach (Collada_Node child in Parent.node)
                {
                    var mMatrix = ParentMatrix;
                    if (child.Matrix != null)
                    {
                        var mC = child.Matrix[0].Value();
                        mMatrix *= new Matrix(
                            mC[0], mC[4], mC[8], mC[12],
                            mC[1], mC[5], mC[9], mC[13],
                            mC[2], mC[6], mC[10], mC[14],
                            mC[3], mC[7], mC[11], mC[15]);
                    }

                    InstancedNode.InstanceNode n = new InstancedNode.InstanceNode();
                    n.Node = child;
                    n.Matrix = mMatrix;
                    Nodes.Add(n);
                    InternalTraceNodes(child, Nodes, mMatrix);
                }
        }

        /// <summary>
        /// Gets all the child nodes contained in the specified parent node.
        /// This method includes the parent node in the output.
        /// </summary>
        /// <param name="Start"></param>
        /// <returns></returns>
        static InstancedNode.InstanceNode[] TraceNodesInclusive(Collada_Node Start)
        {
            List<InstancedNode.InstanceNode> Nodes = new List<InstancedNode.InstanceNode>();
            var SNode = new InstancedNode.InstanceNode();
            SNode.Matrix = Matrix.Identity;
            SNode.Node = Start;
            Nodes.Add(SNode);
            InternalTraceNodes(Start, Nodes, Matrix.Identity);

            return Nodes.ToArray();
        }
        /// <summary>
        /// Gets all the child nodes contained in the specified parent node.
        /// This method does not include the parent node in the output.
        /// </summary>
        /// <param name="Start"></param>
        /// <returns></returns>
        private InstancedNode.InstanceNode[] TraceNodes(Collada_Node Start)
        {
            List<InstancedNode.InstanceNode> Nodes = new List<InstancedNode.InstanceNode>();
            InternalTraceNodes(Start, Nodes, Matrix);

            return Nodes.ToArray();
        }
        #endregion

        #region Create Geometry Instances
        public GeometryInstance[] CreateInstance(Collada ColladaFile, Matrix IMatrix, Dictionary<String, ColladaGeometry> IGeometries, MaterialList ResolvedMaterials, TextureMap Textures)
        {
            List<GeometryInstance> CompiledInstances = new List<GeometryInstance>();
            foreach (InstanceGeometry geo in Geometries)
            {
                CompiledInstances.Add(new GeometryInstance(geo.Geometry, Matrix * geo.Matrix * IMatrix, ColladaFile, IGeometries, ResolvedMaterials, Textures));
            }

            return CompiledInstances.ToArray();
        }

        public GeometryInstance[] CompileNode(Collada ColladaFile, Dictionary<String, ColladaGeometry> Geometries, MaterialList ResolvedMaterials, TextureMap Textures)
        {
            return CreateInstance(ColladaFile, Matrix.Identity, Geometries, ResolvedMaterials, Textures);
        }
        #endregion
    }


}
