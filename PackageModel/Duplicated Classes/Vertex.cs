using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Duplicated_Classes
{
    public struct Vertex : IVertexType
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector2 TexCoord;
        public Vector4 TexRect;

        public Vertex(
            Vector3 position,
            Vector3 normal,
            Vector2 texCoord,
            Vector4 texRect)
        {
            Position = position;
            Normal = normal;
            TexCoord = texCoord;
            TexRect = texRect;
        }

        public static VertexDeclaration _VertexDeclaration = new VertexDeclaration(
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0), //Position
            new VertexElement(sizeof(float) * 3, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0), //Normal
            new VertexElement(sizeof(float) * 6, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0), //TexCoord
            new VertexElement(sizeof(float) * 8, VertexElementFormat.Vector4, VertexElementUsage.TextureCoordinate, 1) //Texture Bounds
            );

        VertexDeclaration IVertexType.VertexDeclaration
        {
            get
            {
                return _VertexDeclaration;
            }
        }

        public static VertexDeclaration VertexDeclaration
        {
            get
            {
                return _VertexDeclaration;
            }
        }

        public override int GetHashCode()
        {
            float val = Position.X + Position.Y + Position.Z +
                TexCoord.X + TexCoord.Y +
                TexRect.Z + TexRect.W;

            return val.GetHashCode();
        }
    }
}
