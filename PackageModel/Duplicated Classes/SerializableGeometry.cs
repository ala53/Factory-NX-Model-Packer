using Microsoft.Xna.Framework;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace PackageModel.Duplicated_Classes
{
    public static class SerializableVertex
    {

        public static float[] ConvertFromGPUVertex(VertexDeferredLighting vertex)
        {
            float[] Values;
            Values = new float[18];
            Values[0] = vertex.Position.X;
            Values[1] = vertex.Position.Y;
            Values[2] = vertex.Position.Z;

            Values[3] = vertex.Normal.X;
            Values[4] = vertex.Normal.Y;
            Values[5] = vertex.Normal.Z;

            Values[6] = vertex.Binormal.X;
            Values[7] = vertex.Binormal.Y;
            Values[8] = vertex.Binormal.Z;

            Values[9] = vertex.Tangent.X;
            Values[10] = vertex.Tangent.Y;
            Values[11] = vertex.Tangent.Z;

            Values[12] = vertex.TexCoord.X;
            Values[13] = vertex.TexCoord.Y;

            Values[14] = vertex.TexRect.X;
            Values[15] = vertex.TexRect.Y;
            Values[16] = vertex.TexRect.Z;
            Values[17] = vertex.TexRect.W;

            return Values;
        }

        public static VertexDeferredLighting ConvertToGPUVertex(float[] Values)
        {
            VertexDeferredLighting vertex = new VertexDeferredLighting(
                new Vector3(Values[0], Values[1], Values[2]),
                new Vector3(Values[3], Values[4], Values[5]),
                new Vector3(Values[6], Values[7], Values[8]),
                new Vector3(Values[9], Values[10], Values[11]),
                new Vector2(Values[12], Values[13]),
                new Vector4(Values[14], Values[15], Values[16], Values[17])
                );

            return vertex;
        }
    }
    [ProtoContract]
    public class SerializableGeometry
    {
        [ProtoMember(1)]
        public int[] Indices;
        [ProtoMember(2)]
        public float[] Vertices;

        [ProtoMember(3)]
        public int[] IndicesLines;
        [ProtoMember(4)]
        public float[] VerticesLines;

        [ProtoMember(5)]
        public int TextureId;
        [ProtoMember(6)]
        public byte[] TextureAtlas;
        [ProtoMember(7)]
        public int NormalId;
        [ProtoMember(8)]
        public byte[] NormalAtlas;
        [ProtoMember(9)]
        public int SpecularId;
        [ProtoMember(10)]
        public byte[] SpecularAtlas;

        //Attributes
        [ProtoMember(13)]
        public float[] LineColor;


        public void Serialize(Stream Output)
        {
            var GZ = new GZipStream(Output, CompressionMode.Compress, true);
            Serializer.Serialize(GZ, this);

            GZ.Close();
        }

        public void Serialize(string File)
        {
            FileStream fs = new FileStream(File, FileMode.Create, FileAccess.ReadWrite);
            Serialize(fs);
            fs.Close();
        }

    }
}
