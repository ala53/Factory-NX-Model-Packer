using Mapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;

namespace PackageModel
{
    public class TextureMap
    {
        public int Width;
        public int Height;
        public Sprite sprite;

        public byte[] TextureDDS;
        public byte[] NormalDDS;
        public byte[] SpecularDDS;
        public int TextureId;
        public int NormalId;
        public int SpecularId;

        public TextureMap(string[] images)
        {
            //And start the working...
            Console.WriteLine("Mapping images into texture atlas...");
            //Cull images that end in _normal or _specular

            List<string> ImagesCulled = new List<string>();

            foreach (string image in images)
            {
                string NameWOExtension = Path.GetFileNameWithoutExtension(image);
                if (NameWOExtension.ToLower().EndsWith("_normal") ||
                    NameWOExtension.ToLower().EndsWith("_specular"))
                {
                    //Dont add it to the new list because it's a property of a material

                }
                else
                {
                    ImagesCulled.Add(image);
                }
            }

            Console.WriteLine("\tPlacing images for efficiency...");
            List<ImageInfo> Images = new List<ImageInfo>();
            foreach (string image in ImagesCulled)
            {
                //if its a color...
                if (image.StartsWith("@COLORPOLYGON"))
                {
                    ImageInfo IInfo = new ImageInfo();
                    //Start at char 14 which is the color
                    IInfo.Name = image;
                    IInfo.File = "@COLORPOLYGON";
                    IInfo.Height = 16;
                    IInfo.Width = 16;

                    Images.Add(IInfo);
                }
                else
                {
                    Bitmap Image = new Bitmap(image);
                    ImageInfo IInfo = new ImageInfo();

                    IInfo.Name = image;
                    IInfo.File = image;
                    IInfo.Width = Image.Width + 8;
                    IInfo.Height = Image.Height + 8;

                    Images.Add(IInfo);

                    Image.Dispose();
                }
            }

            MapperOptimalEfficiency<Sprite> mapper = new MapperOptimalEfficiency<Sprite>(new Canvas());
            Sprite sprite = mapper.Mapping(Images);

            //
            Console.WriteLine("\tStarting to build atlas...");

            //Texture Atlas
            Bitmap Textures = new Bitmap(sprite.Width, sprite.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics TextureGr = Graphics.FromImage(Textures);
            //And the Normal+Specularity Atlas
            Bitmap Normals = new Bitmap(sprite.Width, sprite.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics NormalGr = Graphics.FromImage(Normals);

            Bitmap Specular = new Bitmap(sprite.Width, sprite.Height,
                System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics SpecularGr = Graphics.FromImage(Specular);

            //and draw the textures into the atlas
            ProcessImages(sprite, TextureGr, NormalGr, SpecularGr);

            Console.WriteLine("\tConverting texture atlas to DDS/DXT1.");
            TextureDDS = ResampleToDDS(Textures);
            Console.WriteLine("\tConverting normals atlas to DDS/DXT1.");
            NormalDDS = ResampleToDDS(Normals);
            Console.WriteLine("\tConverting specular atlas to DDS/DXT1.");
            SpecularDDS = ResampleToDDS(Specular);

            SetInfo(sprite);
        }

        private void SetInfo(Sprite Sprite)
        {
            sprite = Sprite;
            Width = sprite.Width;
            Height = sprite.Height;
        }
        private void InitializeImages(Graphics TextureGr, Graphics NormalGr, Graphics SpecularGr)
        {
            //TextureGr.SmoothingMode = SmoothingMode.None;
            //TextureGr.CompositingMode = CompositingMode.SourceCopy;
            //TextureGr.PixelOffsetMode = PixelOffsetMode.None;
            TextureGr.InterpolationMode = InterpolationMode.NearestNeighbor;

            //Initialize it to default
            NormalGr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            NormalGr.FillRectangle(new SolidBrush(Color.FromArgb(127, 127, 127, 255)),
                new Rectangle(0, 0, 99999, 99999));
            //127,127,127 for normals...255 for specularity

            SpecularGr.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
            SpecularGr.FillRectangle(new SolidBrush(Color.FromArgb(255, 127, 0, 255)),
                new Rectangle(0, 0, 99999, 99999)); //R is power, G is intensity, B is useless
        }

        private void ProcessImages(Sprite sprite, Graphics TextureGr, Graphics NormalGr, Graphics SpecularGr)
        {

            foreach (IMappedImageInfo img in sprite.MappedImages)
            {
                //Draw the texture
                ImageInfo Image = (ImageInfo)img.ImageInfo;
                if (Image.File == "@COLORPOLYGON")
                {
                    Microsoft.Xna.Framework.Color c_xna = new Microsoft.Xna.Framework.Color();
                    c_xna.PackedValue = uint.Parse(Image.Name.Substring(13));
                    //Just write a 4x4 pixel area
                    Color c = Color.FromArgb(
                        c_xna.A,
                        c_xna.R,
                        c_xna.G,
                        c_xna.B);
                    TextureGr.FillRectangle(new SolidBrush(c), img.X - 2, img.Y - 2, 12, 12);
                }
                else
                {
                    //It's an actual texture
                    Bitmap Texture = new Bitmap(Image.File);
                    TextureGr.DrawImage(Texture, img.X, img.Y, Texture.Width, Texture.Height);
                    Texture.Dispose();

                    //Draw the normal map if there is one
                    FileInfo fi = new FileInfo(Image.File);
                    string NormalFile = Image.File.Replace(fi.Extension, "_normal" + fi.Extension);
                    if (File.Exists(NormalFile))
                    {
                        Console.WriteLine("\t\tFound normal map for " + fi.Name);
                        Bitmap Normal = new Bitmap(NormalFile);
                        //If it does exist, we can just copy over...
                        NormalGr.DrawImage(Normal, new Rectangle(img.X, img.Y, Normal.Width, Normal.Height));
                        //Dispose of course
                        Normal.Dispose();
                        //And if it doesn't exist, we'll just leave it as the stock map
                    }
                    //Draw the specular map if there is one
                    string SpecFile = Image.File.Replace(fi.Extension, "_specular" + fi.Extension);
                    if (File.Exists(NormalFile))
                    {
                        Console.WriteLine("\t\tFound specular map for " + fi.Name);
                        Bitmap SpecularImg = new Bitmap(SpecFile);
                        //If it does exist, we can just copy over...
                        SpecularGr.DrawImage(SpecularImg, new Rectangle(img.X, img.Y, SpecularImg.Width, SpecularImg.Height));
                        //Again, dispose
                        SpecularImg.Dispose();
                        //And if it doesn't exist, we'll just leave it as the stock map
                    }
                }
            }
        }

        private byte[] ResampleToDDS(Bitmap bm)
        {
            if (bm.Width > 4096 || bm.Height > 4096)
            {
                //Resample
                float Scale = Math.Min(4096f / bm.Width, 4096f / bm.Height);
                Bitmap New = new Bitmap((int)(bm.Width * Scale), (int)(bm.Height * Scale));

                using (Graphics gr = Graphics.FromImage(New))
                {
                    gr.SmoothingMode = SmoothingMode.HighQuality;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(bm, new Rectangle(0, 0, New.Width, New.Height));
                }

                New.Save("TEMP_FILE_jndfs.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                New.Dispose();
            }
            else
            {
                //Just save
                bm.Save("TEMP_FILE_jndfs.bmp", System.Drawing.Imaging.ImageFormat.Bmp);
            }


            Console.WriteLine("\t\tInitializing the converter...");
            Console.WriteLine("========================================================");
            //Call the converter
            ProcessStartInfo prStart = new ProcessStartInfo("crunch", "/DXT1 -file TEMP_FILE_jndfs.bmp /out TMP_NEW.dds");
            prStart.UseShellExecute = false;
            Process pr = Process.Start(prStart);
            pr.WaitForExit();

            Console.WriteLine("========================================================");

            //Delete the temp file

            try
            {
                System.IO.File.Delete("TEMP_FILE_jndfs.bmp");
            }
            catch (Exception)
            {

            }

            if (pr.ExitCode == 0)
            {
                Console.WriteLine("\t\tSucessfully converted.");

                byte[] DXT1 = File.ReadAllBytes("TMP_NEW.dds");
                //And delete the dds file

                try
                {
                    System.IO.File.Delete("TMP_NEW.dds");
                }
                catch (Exception)
                {

                }
                return DXT1;
            }
            else
            {
                Console.WriteLine("\t\tAn unknown error occurred...");
                throw new FormatException("\t\tConverter exited with code 1");
            }
        }
        /// <summary>
        /// Returns the UV Offset and UV Scale of a texture.
        /// </summary>
        /// <param name="TextureName"></param>
        /// <returns></returns>
        public RectangleF TextureLocation(string TextureName)
        {
            foreach (MappedImageInfo img in sprite.MappedImages)
            {
                ImageInfo ImgInfo = (ImageInfo)img.ImageInfo;
                if (ImgInfo.Name == TextureName)
                {
                    if (ImgInfo.Name.StartsWith("@COLORPOLYGON"))
                    {
                        RectangleF Normalized = new RectangleF();
                        Normalized.X = (float)(img.X + 2f) / Width;
                        Normalized.Y = (float)(img.Y + 2f) / Height;

                        Normalized.Width = 8f / Width;
                        Normalized.Height = 8f / Height;

                        return Normalized;
                    }
                    else
                    {
                        RectangleF Normalized = new RectangleF();
                        Normalized.X = (float)img.X / Width;
                        Normalized.Y = (float)img.Y / Height;

                        Normalized.Width = (float)ImgInfo.Width / Width;
                        Normalized.Height = (float)ImgInfo.Height / Height;

                        return Normalized;
                    }

                }
            }
            throw new KeyNotFoundException("Could not find texture with name " + TextureName + ".");
        }
    }

}
