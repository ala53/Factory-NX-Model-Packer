using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mapper
{
    public class Sprite : ISprite
    {
        private int width;
        public int Width
        {
            get { return width; }
        }

        private int height;
        public int Height
        {
            get { return height; }
        }

        public int Area
        {
            get { return width * height; }
        }

        private List<IMappedImageInfo> Imgs = new List<IMappedImageInfo>();
        public List<IMappedImageInfo> MappedImages
        {
            get { return Imgs; }
        }

        public void AddMappedImage(IMappedImageInfo mappedImage)
        {
            Imgs.Add(mappedImage);
            int totalWidth = mappedImage.X + mappedImage.ImageInfo.Width;
            int totalHeight = mappedImage.Y + mappedImage.ImageInfo.Height;

            if (width < totalWidth)
                width = totalWidth;
            if (height < totalHeight)
                height = totalHeight;
        }
    }
}
