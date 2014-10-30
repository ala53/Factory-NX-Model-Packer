using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mapper
{
    public class ImageInfo : IImageInfo
    {
        public string Name = "";
        public string File = "";
        private int width = 0;
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                width = value;
            }
        }
        private int height = 0;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                height = value;
            }
        }
    }
}
