using Microsoft.Xna.Framework;
using PackageModel.Duplicated_Classes;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    [Serializable]
    public class CompiledGeometry
    {
        [ProtoMember(1)]
        public VertexDeferredLighting[] Vertices;
        [ProtoMember(2)]
        public int[] Indices;
        [ProtoMember(3)]
        public Vector3[] VerticesLines;
        [ProtoMember(4)]
        public int[] IndicesLines;

        [ProtoMember(5)]
        public byte[] Texture;
        [ProtoMember(6)]
        public byte[] Normals;
        [ProtoMember(7)]
        public byte[] Specular;
        [ProtoMember(8)]
        public int TextureId;
        [ProtoMember(9)]
        public int NormalId;
        [ProtoMember(10)]
        public int SpecularId;

        public SerializableGeometry ToSerializableGeometry()
        {
            var SInstance = new SerializableGeometry();

            SInstance.TextureAtlas = Texture;
            SInstance.NormalAtlas = Normals;
            SInstance.SpecularAtlas = Specular;

            SInstance.TextureId = TextureId;
            SInstance.NormalId = NormalId;
            SInstance.SpecularId = SpecularId;

            List<float> SerializableVertices = new List<float>();
            foreach (VertexDeferredLighting vertex in Vertices)
                SerializableVertices.AddRange(SerializableVertex.ConvertFromGPUVertex(vertex));

            SInstance.Vertices = SerializableVertices.ToArray();
            SInstance.Indices = Indices;

            List<float> SerializableVerticesLines = new List<float>();
            foreach (Vector3 vertex in VerticesLines)
                SerializableVerticesLines.AddRange(new float[] { vertex.X, vertex.Y, vertex.Z });

            SInstance.VerticesLines = SerializableVerticesLines.ToArray();
            SInstance.IndicesLines = IndicesLines;

            return SInstance;
        }
    }
}
