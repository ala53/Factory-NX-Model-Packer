
//Use the unfinished, prototype features
#define ALLOW_PROTOTYPE_CODE
//Use the old, buggy Library_Nodes tracer
//#define USE_LEGACY_LIB_NODES_TRACER


using ColladaDotNet;
using PackageModel.Collada_Reader;
using PackageModel.Duplicated_Classes;
using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PackageModel
{
    class Program
    {
        static string InFile = "Test2.dae";
        static string OutFile = "TestOut.cgmdl";
        static bool PreserveHierarchies = false;
        static bool CustomLines = false;
        static string CustomLinesFile = "";
        static bool DisableLines = false;
        static void Main(string[] args)
        {
            ProcessArguments(args);

            var ColladaFile = Collada.Load_File(InFile);

            Collada CustomLinesData = null;
            if (CustomLines)
                CustomLinesData = Collada.Load_File(CustomLinesFile);
            /* 
             * Unfinished code - Designed to be more modular in processing models
             */
#if ALLOW_PROTOTYPE_CODE
            ProcessGeometryComponented(ColladaFile, CustomLinesData);
#else
            CompiledGeometry CompiledGeometry = null;
            CompiledGeometry CustomLinesGeometry = null;
            if (ColladaFile.Library_Nodes == null)
            {
                CompiledGeometry = ProcessGeometry(ColladaFile);
                //If lines are from a different file
                if (CustomLines)
                    CustomLinesGeometry = ProcessGeometry(CustomLinesData);
            }
            else
            {
                Console.WriteLine("Please do not use Preserve Component Hierarchies in SketchUp.");
                Console.Read();
                Environment.Exit(1);
            }

            //Postprocessing the custom lines
            if (CustomLines)
            {
                CompiledGeometry.IndicesLines = CustomLinesGeometry.IndicesLines;
                CompiledGeometry.VerticesLines = CustomLinesGeometry.VerticesLines;
            }
            if (DisableLines)
            {
                //Just create an empty line
                CompiledGeometry.IndicesLines = new int[] { 0, 1 };
                CompiledGeometry.VerticesLines = new Vector3[] { Vector3.Zero, Vector3.Zero };
            }

            SerializableGeometry Geometry = CompiledGeometry.ToSerializableGeometry();
            Geometry.Name = Name;
            Geometry.Description = Description;
            Geometry.LineColor = new float[] { LinesColor.R, LinesColor.G, LinesColor.B, LinesColor.A };
            Geometry.Serialize(OutFile);
#endif
            //Write that it completed
            Console.WriteLine();
            var AppRunningTime = DateTime.Now - System.Diagnostics.Process.GetCurrentProcess().StartTime;
            Console.WriteLine("Asset compiliation completed in " + TimespanToString(AppRunningTime) + ".");
            Console.WriteLine("Press <Enter> to exit.");
            Console.Read();
        }



        static void ProcessGeometryComponented(Collada ColladaFile, Collada CustomLinesData)
        {
            #region Declararions
            TextureMap Textures;
            MaterialList ResolvedMaterials;
            SerializableGeometry Geometry = new SerializableGeometry();
            Dictionary<string, ColladaGeometry> Geometries = new Dictionary<string, ColladaGeometry>();
            List<GeometryInstance> InstancesOfGeometries = new List<GeometryInstance>();
            #endregion
            #region Build Materials List / Map Textures
            //first, we build the list of materials
            ResolvedMaterials = new MaterialList(ColladaFile);
            //first we need to collect all the textures and build the texture map
            List<string> materials = new List<string>();

            foreach (KeyValuePair<string, string> value in ResolvedMaterials.Materials)
            {
                materials.Add(value.Value);
            }
            Textures = new TextureMap(materials.ToArray());
            #endregion
            #region Parse Geometry from Library_Geometries
            //Texture map now built.
            //Now to resolve the geometry

            //DEBUG LOGGING
            Console.WriteLine("Parsing geometry...");
            int CompletedInstances = 1;
            //Draw the progress bar
            ConsoleTools.drawTextProgressBar(0, ColladaFile.Library_Geometries.Geometry.Count());

            foreach (Collada_Geometry geom in ColladaFile.Library_Geometries.Geometry)
            {
                var Id = geom.ID;
                var Geom = new ColladaGeometry(geom);
                Geometries.Add(Id, Geom);
                ConsoleTools.drawTextProgressBar(CompletedInstances++, ColladaFile.Library_Geometries.Geometry.Count());
            }
            //DEBUG LOGGING
            //Make a new line
            Console.WriteLine();
            Console.WriteLine();
            #endregion
            #region Build Instance Trees for geometry
            //DEBUG LOGGING
            Console.WriteLine("Instancing geometry...");

            //And instance it
            Dictionary<string, ModularNode> LibraryNodes = null;
            NodePointer[] InstanceNodes = null;
            //In this case, it must be a componented node
            if (ColladaFile.Library_Nodes != null)
                LibraryNodes = ProcessBaseLevelNodes(ColladaFile);
            //Gen the instance nodes
            InstanceNodes = ProcessVisualSceneNodes(ColladaFile, LibraryNodes);
            #endregion
            //If the user wants the components to be split into separate files
            if (PreserveHierarchies)
            {
                #region Declarations
                //The parts of the model
                List<ModelPart> Parts = new List<ModelPart>();
                //And the instances of those parts
                List<ModelPartInstance> Instances = new List<ModelPartInstance>();
                //Here, we have to make several different files...
                //one for each Node from Library_Nodes
                #endregion
                #region Save each component to a different file
                //Save componentless
                foreach (NodePointer node in InstanceNodes)
                {
                    if (node.Name == "ComponentlessGeometry")
                    {
                        var CompiledGeo = GeometryCollection.MergeGeometries(
                        node.Node.CompileNode
                        (
                        ColladaFile, Geometries, ResolvedMaterials, Textures
                        ));
                        if (DisableLines)
                        {
                            //Just create an empty line
                            CompiledGeo.IndicesLines = new int[] { 0, 1 };
                            CompiledGeo.VerticesLines = new Vector3[] { Vector3.Zero, Vector3.Zero };
                        }
                        //Give it a copy of the textures, each component gets the full texture map
                        CompiledGeo.Texture = Textures.TextureDDS;
                        CompiledGeo.TextureId = Textures.TextureId;

                        //Make sure to create the output directory, so the next line doesn't crash
                        System.IO.Directory.CreateDirectory(OutFile);

                        //And save this component to a file
                        SaveGeometry(OutFile + "/" + node.Name + ".cgmdl", CompiledGeo);

                        break;
                    }
                }

                foreach (ModularNode node in LibraryNodes.Values)
                {
                    //Compile the node and merge all it's geometry instances
                    var CompiledGeo = GeometryCollection.MergeGeometries(
                        node.CompileNode
                        (
                        ColladaFile, Geometries, ResolvedMaterials, Textures
                        ));

                    if (DisableLines)
                    {
                        //Just create an empty line
                        CompiledGeo.IndicesLines = new int[] { 0, 1 };
                        CompiledGeo.VerticesLines = new Vector3[] { Vector3.Zero, Vector3.Zero };
                    }
                    //Give it a copy of the textures, each component gets the full texture map
                    CompiledGeo.Texture = Textures.TextureDDS;
                    CompiledGeo.TextureId = Textures.TextureId;

                    //Make sure to create the output directory, so the next line doesn't crash
                    System.IO.Directory.CreateDirectory(OutFile);

                    //And save this component to a file
                    SaveGeometry(OutFile + "/" + node.Name + ".cgmdl", CompiledGeo);

                    //And build it's Model part data for the metadata
                    ModelPart p = new ModelPart();
                    p.File = OutFile + "/" + node.Name + ".cgmdl";
                    p.Name = node.Name + "_" + node.Id;

                    //And add it to the parts list for the metadata
                    Parts.Add(p);
                }

                //Add componentless
                Parts.Add(new ModelPart()
                {
                    Name = "ComponentlessGeometry",
                    File = OutFile + "/MergedGeometry.cgmdl"
                });
                #endregion
                #region Write nodes to metadata file
                //Then build the XML Model Data for the instances
                //So we know where to place each instance
                foreach (NodePointer ptr in InstanceNodes)
                {
                    //Build the instance for the metadata
                    ModelPartInstance p = new ModelPartInstance();
                    p.Matrix = ptr.Matrix;
                    p.ModelPart = ptr.Node.Name + "_" + ptr.Node.Id;
                    p.Name = ptr.Name;

                    Instances.Add(p);
                }
                #endregion
                #region Build Metadata File

                //And build the geometry data
                GameModel MData = new GameModel();
                MData.ModelParts = Parts.ToArray();
                MData.Instances = Instances.ToArray();

                //And save it to a file
                MData.Serialize(OutFile + ".json");
                #endregion
            }
            else
            {
                #region Convert Node Pointers to geometry data
                //Get ALL the geometry instances that are in the model file
                List<GeometryInstance> InstanceGeometry = new List<GeometryInstance>();
                //Trace the nodes to resolve their geometry instances
                foreach (NodePointer ptr in InstanceNodes)
                {
                    //Get the list of instances from the actual node
                    GeometryInstance[] geoNew = ptr.Node.CreateInstance(ColladaFile, ptr.Matrix, Geometries, ResolvedMaterials, Textures);
                    //and add it to the geometry collection
                    InstanceGeometry.AddRange(geoNew);
                }
                #endregion
                #region Compile geometry to a single instance
                //Compile it to one file
                var merged = GeometryCollection.MergeGeometries(InstanceGeometry.ToArray());
                merged.Texture = Textures.TextureDDS;
                merged.TextureId = Textures.TextureId;
                #region Handle Optional Arguments

                //Postprocessing the custom lines
                if (CustomLines)
                {
                    var CustomLinesGeometry = ProcessGeometry(CustomLinesData);
                    merged.IndicesLines = CustomLinesGeometry.IndicesLines;
                    merged.VerticesLines = CustomLinesGeometry.VerticesLines;
                }
                if (DisableLines)
                {
                    //Just create an empty line
                    merged.IndicesLines = new int[] { 0, 1 };
                    merged.VerticesLines = new Vector3[] { Vector3.Zero, Vector3.Zero };
                }
                #endregion
                //Make the directory to save to
                System.IO.Directory.CreateDirectory(OutFile);
                //And save it to the output geometry
                SaveGeometry(OutFile + "/MergedGeometry.cgmdl", merged);
                #endregion
                #region Build Model Metadata
                //Build the XML Model Metadata
                var ModelData = new GameModel();
                ModelData.Instances = new ModelPartInstance[]  //Initialize the model instances with a default
                {
                    new ModelPartInstance 
                    {
                        Name = "DefaultGeometry",
                        ModelPart = "ComponentlessGeometry",
                        Matrix = Matrix.Identity
                    }
                };
                ModelData.ModelParts = new ModelPart[] //And the actual model parts
                { 
                    new ModelPart() { 
                        Name = "ComponentlessGeometry", 
                        File = OutFile + "/MergedGeometry.cgmdl" 
                    } 
                };

                //and save it
                ModelData.Serialize(OutFile + ".mdata");
                #endregion
            }




            Console.WriteLine();

        }

        static void SaveGeometry(string file, CompiledGeometry geom)
        {

            SerializableGeometry Geometry = geom.ToSerializableGeometry();
            Geometry.Serialize(file);
        }

        #region Build instanced nodes


        static void TraceNodes(Collada_Node Parent, List<InstancedNode.InstanceNode> Nodes, Matrix ParentMatrix)
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
                    TraceNodes(child, Nodes, mMatrix);
                }
        }

        static InstancedNode.InstanceNode[] TraceNodes(Collada_Node Start)
        {
            List<InstancedNode.InstanceNode> Nodes = new List<InstancedNode.InstanceNode>();
            var SNode = new InstancedNode.InstanceNode();
            SNode.Matrix = Matrix.Identity;
            SNode.Node = Start;
            Nodes.Add(SNode);
            TraceNodes(Start, Nodes, Matrix.Identity);

            return Nodes.ToArray();
        }

        /// <summary>
        /// Process all the nodes in Library_Nodes, splitting them into SketchUp components.
        /// Designed to allow for preserving the components.
        /// </summary>
        /// <param name="ColladaFile"></param>
        /// <returns></returns>
        static Dictionary<string, ModularNode> ProcessBaseLevelNodes(Collada ColladaFile)
        {
            //start by getting nodes
            Dictionary<string, ModularNode> Nodes = new Dictionary<string, ModularNode>();

            foreach (Collada_Node node in ColladaFile.Library_Nodes.Node)
            {
                //Build the first level nodes
                var Node = new ModularNode(node);
                Nodes.Add(Node.Id, Node);
            }

            //then process all the nodes until their geometry has been fully resolved

            while (!AllNodesFinishedProcessing(Nodes))
            {
                foreach (ModularNode node in Nodes.Values)
                {
                    node.TracePointers(Nodes);
                }
            }

            return Nodes;
        }
        static bool AllNodesFinishedProcessing(Dictionary<string, ModularNode> Nodes)
        {
            foreach (ModularNode node in Nodes.Values)
                if (!node.IsNodeTracingCompleted()) return false;

            return true;
        }


        static NodePointer[] ProcessVisualSceneNodes(Collada ColladaFile, Dictionary<string, ModularNode> LibraryNodes)
        {
            List<NodePointer> Nodes = new List<NodePointer>();
            ModularNode GeometryNode = new ModularNode();
            GeometryNode.Name = "ComponentlessGeometry";
            GeometryNode.Id = "ID999999999999999999";

            var TracedNodes = TraceNodes(ColladaFile.Library_Visual_Scene.Visual_Scene[0].Node[0]);
            //Trace the nodes
            foreach (InstancedNode.InstanceNode mNode in TracedNodes)
            {
                var mMatrix = mNode.Matrix;
                var node = mNode.Node;
                //resolve it's pointer
                if (node.Instance_Node != null)
                {
                    var pointer = new NodePointer();
                    pointer.Matrix = mMatrix;
                    pointer.Name = node.Name;

                    pointer.Node = LibraryNodes[node.Instance_Node[0].URL.Substring(1)];

                    Nodes.Add(pointer);
                }

                if (node.Instance_Geometry != null)
                    foreach (Collada_Instance_Geometry geometry in node.Instance_Geometry)
                    {

                        var m = new ModularNode.InstanceGeometry();
                        m.Matrix = mMatrix;
                        m.Geometry = geometry;
                        GeometryNode.Geometries.Add(m);
                    }
            }

            if (ColladaFile.Library_Visual_Scene.Visual_Scene[0].Node[0].Instance_Geometry != null)
                foreach (Collada_Instance_Geometry geom in ColladaFile.Library_Visual_Scene.Visual_Scene[0].Node[0].Instance_Geometry)
                {
                    var m = new ModularNode.InstanceGeometry();
                    m.Matrix = Matrix.Identity;
                    m.Geometry = geom;
                    GeometryNode.Geometries.Add(m);
                }
            if (GeometryNode.Geometries.Count > 0)
            {
                var pointer = new NodePointer();
                pointer.Name = GeometryNode.Name;
                pointer.Matrix = Matrix.Identity;
                pointer.Node = GeometryNode;

                Nodes.Add(pointer);
            }

            return Nodes.ToArray();
        }

        private class NodePointer
        {
            public Matrix Matrix;
            public string Name;
            public ModularNode Node;
        }

        #endregion


        static CompiledGeometry ProcessGeometry(Collada ColladaFile)
        {
            //Declarations
            TextureMap Textures;
            MaterialList ResolvedMaterials;
            SerializableGeometry Geometry = new SerializableGeometry();
            Dictionary<string, ColladaGeometry> Geometries = new Dictionary<string, ColladaGeometry>();
            CompiledGeometry MergedGeometries;
            List<GeometryInstance> InstancesOfGeometries = new List<GeometryInstance>();


            //first, we build the list of materials
            ResolvedMaterials = new MaterialList(ColladaFile);
            //first we need to collect all the textures and build the texture map
            List<string> materials = new List<string>();

            foreach (KeyValuePair<string, string> value in ResolvedMaterials.Materials)
            {
                materials.Add(value.Value);
            }
            Textures = new TextureMap(materials.ToArray());

            //Texture map now built.
            //Now to resolve the geometry

            //DEBUG LOGGING
            Console.WriteLine("Parsing geometry...");
            int CompletedInstances = 1;
            //Draw the progress bar
            ConsoleTools.drawTextProgressBar(0, ColladaFile.Library_Geometries.Geometry.Count());

            foreach (Collada_Geometry geom in ColladaFile.Library_Geometries.Geometry)
            {
                var Id = geom.ID;
                var Geom = new ColladaGeometry(geom);
                Geometries.Add(Id, Geom);
                ConsoleTools.drawTextProgressBar(CompletedInstances++, ColladaFile.Library_Geometries.Geometry.Count());
            }
            //DEBUG LOGGING
            //Make a new line
            Console.WriteLine();
            Console.WriteLine();

            //DEBUG LOGGING
            Console.WriteLine("Instancing geometry...");

            //And instance it
            foreach (Collada_Node node in ColladaFile.Library_Visual_Scene.Visual_Scene[0].Node)
            {
                RecursiveNodeProcessor(Matrix.Identity, node, ColladaFile, Geometries, ResolvedMaterials, Textures, InstancesOfGeometries);
            }
            Console.WriteLine();

            //Merge the geometries
            MergedGeometries = GeometryCollection.MergeGeometries(InstancesOfGeometries.ToArray());
            MergedGeometries.Texture = Textures.TextureDDS;
            MergedGeometries.TextureId = Textures.TextureId;

            return MergedGeometries;
        }

        static void RecursiveNodeProcessor(
            Matrix Parent,
            Collada_Node node,
            Collada ColladaFile,
            Dictionary<string, ColladaGeometry> Geometries,
            MaterialList ResolvedMaterials,
            TextureMap Textures,
            List<GeometryInstance> InstancesOfGeometries)
        {
            Matrix me = Matrix.Identity * Parent;
            if (node.Matrix != null)
            {
                var mC = node.Matrix[0].Value();
                var myMatrix = new Matrix(
                            mC[0], mC[4], mC[8], mC[12],
                            mC[1], mC[5], mC[9], mC[13],
                            mC[2], mC[6], mC[10], mC[14],
                            mC[3], mC[7], mC[11], mC[15]);
                me = Parent * myMatrix;
            }

            if (node.Instance_Geometry != null)
            {
                foreach (Collada_Instance_Geometry geom in node.Instance_Geometry)
                {
                    var Instance = new GeometryInstance(geom, me, ColladaFile, Geometries, ResolvedMaterials, Textures);
                    InstancesOfGeometries.Add(Instance);
                }
            }

            if (node.node != null)
                foreach (Collada_Node n in node.node)
                {
                    RecursiveNodeProcessor(me, n, ColladaFile, Geometries, ResolvedMaterials, Textures, InstancesOfGeometries);
                }
        }

        static void ProcessArguments(string[] args)
        {

            Console.Title = "MPTanks 2D Model Packer";
            if (args.Count() > 2)
            {
                InFile = args[0]; //Set the required args - input
                OutFile = args[1]; // - output

                //Process command line arguments arguments
                for (int index = 2; index < args.Count(); index++)
                    switch (args[index]) //Argument switch table
                    {
                        case "-splitcomponents":
                            Console.WriteLine("-splitcomponents is disabled until further notice." +
                                "Press any key to continue.");
                            Console.Read();
                            PreserveHierarchies = true; //Set the flag to preserve component hierarchies
                            break;
                        case "-customlines":
                            CustomLines = true; //Set the flags for custom lines
                            index++; //Increment the arg index so we get the file, which is the next argument
                            CustomLinesFile = args[index]; //and the filename
                            break;
                        case "-nolines":
                            DisableLines = true; //Set the flag to disable lines
                            break;
                        default:
                            Console.WriteLine("ERROR: Unknown argument" + args[index]);
                            break;
                    } //End switch table


            } //End -there-are-enough-arguments section-
            else
            {
                //Arguments missing, throw error and let the user know
                Console.WriteLine();
                Console.WriteLine();
                Console.Write(
                    "Invalid arguments. Required arguments are: \n" +
                    "\t\tArgument 1: Input file \n" +
                    "\t\tArgument 2: Output file \n" +
                    "\tOptional arguments: \n" +
                    "\t\t<DISABLED>-splitcomponents: Save each component\n\t\tto a different file. \n" +
                    "\t\t-customlines [file]: Load lines from a different DAE file \n\t\t(not usable with -splitcomponents) \n" +
                    "\t\t-nolines: Disable lines for the model \n" +
                    "\t E.g. PackageModel.exe \"In.dae\" \"Out.cgmdl\" -arg1 -arg2...\n"
                    );
                Console.WriteLine();
                Console.Write("Enter arguments: "); //Give them a chance to enter the args now
                var mArgs = CommandLineToArgs(Console.ReadLine());
                ProcessArguments(mArgs);
            }
        }

        #region Shell32 Command line arguments from string hooks
        [DllImport("shell32.dll", SetLastError = true)]
        static extern IntPtr CommandLineToArgvW(
            [MarshalAs(UnmanagedType.LPWStr)] string lpCmdLine, out int pNumArgs);

        public static string[] CommandLineToArgs(string commandLine)
        {
            int argc;
            var argv = CommandLineToArgvW(commandLine, out argc);
            if (argv == IntPtr.Zero)
                throw new System.ComponentModel.Win32Exception();
            try
            {
                var args = new string[argc];
                for (var i = 0; i < args.Length; i++)
                {
                    var p = Marshal.ReadIntPtr(argv, i * IntPtr.Size);
                    args[i] = Marshal.PtrToStringUni(p);
                }

                return args;
            }
            finally
            {
                Marshal.FreeHGlobal(argv);
            }
        }
        #endregion
        #region Timespans to string
        public static string TimespanToString(TimeSpan span)
        {
            string formatted = string.Format("{0}{1}{2}{3}",
                span.Duration().Days > 0 ? string.Format("{0:0} day{1}, ", span.Days, span.Days == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Hours > 0 ? string.Format("{0:0} hour{1}, ", span.Hours, span.Hours == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Minutes > 0 ? string.Format("{0:0} minute{1}, ", span.Minutes, span.Minutes == 1 ? String.Empty : "s") : string.Empty,
                span.Duration().Seconds > 0 ? string.Format("{0:0} second{1}", span.Seconds, span.Seconds == 1 ? String.Empty : "s") : string.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (string.IsNullOrEmpty(formatted)) formatted = "0 seconds";

            return formatted;
        }
        #endregion
    }
}
