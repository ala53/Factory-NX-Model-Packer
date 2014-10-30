using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Duplicated_Classes
{
    public struct VertexDeferredLighting : IVertexType
    {
        public Vector3 Position;
        public Vector3 Normal;
        public Vector3 Binormal;
        public Vector3 Tangent;
        public Vector2 TexCoord;
        public Vector4 TexRect;

        public VertexDeferredLighting(
            Vector3 _Position,
            Vector3 _Normal,
            Vector3 _Binormal,
            Vector3 _Tangent,
            Vector2 _TexCoord,
            Vector4 _TexRect)
        {
            Position = _Position;
            Normal = _Normal;
            Binormal = _Binormal;
            Tangent = _Tangent;
            TexCoord = _TexCoord;
            TexRect = _TexRect;
        }

        public static VertexDeclaration VertexDeclare = new VertexDeclaration(
            new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0), //Position
            new VertexElement(sizeof(float) * 3, VertexElementFormat.Vector3, VertexElementUsage.Normal, 0), //Normal
            new VertexElement(sizeof(float) * 6, VertexElementFormat.Vector3, VertexElementUsage.Binormal, 0), //Binormal
            new VertexElement(sizeof(float) * 9, VertexElementFormat.Vector3, VertexElementUsage.Tangent, 0), //Tangent
            new VertexElement(sizeof(float) * 12, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0), //TexCoord
            new VertexElement(sizeof(float) * 14, VertexElementFormat.Vector4, VertexElementUsage.TextureCoordinate, 1) //Texture Bounds
            );

        public VertexDeclaration VertexDeclaration
        {
            get
            {
                return VertexDeclare;
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
