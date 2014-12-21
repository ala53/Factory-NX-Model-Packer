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

        public static float[] ConvertFromGPUVertex(Vertex vertex)
        {
            float[] Values;
            Values = new float[18];
            Values[0] = vertex.Position.X;
            Values[1] = vertex.Position.Y;
            Values[2] = vertex.Position.Z;

            Values[3] = vertex.Normal.X;
            Values[4] = vertex.Normal.Y;
            Values[5] = vertex.Normal.Z;

            Values[6] = vertex.TexCoord.X;
            Values[7] = vertex.TexCoord.Y;

            Values[8] = vertex.TexRect.X;
            Values[9] = vertex.TexRect.Y;
            Values[10] = vertex.TexRect.Z;
            Values[11] = vertex.TexRect.W;

            return Values;
        }

        public static Vertex ConvertToGPUVertex(float[] Values)
        {
            Vertex vertex = new Vertex(
                new Vector3(Values[0], Values[1], Values[2]),
                new Vector3(Values[3], Values[4], Values[5]),
                new Vector2(Values[6], Values[7]),
                new Vector4(Values[8], Values[9], Values[10], Values[11])
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
