﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace Mapper
{
    public abstract class MapperOptimalEfficiency_Base<S> : IMapperReturningStats<S> where S : class, ISprite, new()
    {
        private ICanvas _canvas = null;

        protected ICanvas Canvas { get { return _canvas; } }

        protected float CutoffEfficiency { get; private set; }
        protected int MaxNbrCandidateSprites { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="canvas">Canvas object to use to map the images</param>
        /// <param name="cutoffEfficiency">
        /// When the object's Mapping method produces a candidate sprite with this efficiency or higher, it stops
        /// trying to get a better one and returns the sprite.
        /// 
        /// Set this to for example 0.9 if that efficiency is good enough for you. 
        /// Set to 1.0 or higher if you want the most efficient sprite.
        /// </param>
        /// <param name="maxNbrCandidateSprites">
        /// The maximum number of candidate sprites that will be generated by the Mapping method.
        /// Set this to 1 if you want it to return the very first sprite that it manages to generate.
        /// If you want it to try to generate no more than 2 sprites before returning the best one, set this to 2, etc.
        /// Set to Int32.MaxValue if you don't want any restrictions on the number of candidate sprites generated.
        /// 
        /// If you set cutoff Efficiency to less than 1, and maxNbrCandidateSprites to less than Int32.MaxValue,
        /// the Mapper method will stop trying to get a better sprite the moment it hits one of these limitations.
        /// </param>
        public MapperOptimalEfficiency_Base(ICanvas canvas, float cutoffEfficiency, int maxNbrCandidateSprites)
        {
            _canvas = canvas;
            CutoffEfficiency = cutoffEfficiency;
            MaxNbrCandidateSprites = maxNbrCandidateSprites;
        }

        public MapperOptimalEfficiency_Base(ICanvas canvas) : this(canvas, 1.0f, Int32.MaxValue)
        {
        }

        /// <summary>
        /// See IMapping
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public S Mapping(IEnumerable<IImageInfo> images)
        {
            return Mapping(images, null);
        }

        /// <summary>
        /// See IMapping
        /// </summary>
        /// <param name="images"></param>
        /// <returns></returns>
        public abstract S Mapping(IEnumerable<IImageInfo> images, IMapperStats mapperStats);

        /// <summary>
        /// Produces a mapping to a sprite that has given maximum dimensions.
        /// If the mapping can not be done inside those dimensions, returns null.
        /// </summary>
        /// <param name="images">
        /// List of image infos. 
        /// 
        /// This method will not sort this list. 
        /// All images in this collection will be used, regardless of size.
        /// </param>
        /// <param name="maxWidth">
        /// The sprite won't be wider than this.
        /// </param>
        /// <param name="maxHeight">
        /// The generated sprite won't be higher than this.
        /// </param>
        /// <param name="canvasStats">
        /// The statistics produced by the canvas. These numbers are since the last call to its SetCanvasDimensions method.
        /// </param>
        /// <param name="lowestFreeHeightDeficitTallestRightFlushedImage">
        /// The lowest free height deficit for the images up to and including the tallest rectangle whose right hand border sits furthest to the right
        /// of all images.
        /// 
        /// This is the minimum amount by which the height of the canvas needs to be increased to accommodate that rectangle.
        /// if the width of the canvas is decreased to one less than the width now taken by images.
        /// 
        /// Note that providing the additional height might get some other (not right flushed) image to be placed higher, thereby
        /// making room for the flushed right image.
        /// 
        /// This will be set to Int32.MaxValue if there was never any free height deficit.
        /// </param>
        /// <returns>
        /// The generated sprite.
        /// 
        /// null if not all the images could be placed within the size limitations.
        /// </returns>
        protected virtual S MappingRestrictedBox(
            IOrderedEnumerable<IImageInfo> images, 
            int maxWidth, int maxHeight, ICanvasStats canvasStats,
            out int lowestFreeHeightDeficitTallestRightFlushedImage)
        {
            lowestFreeHeightDeficitTallestRightFlushedImage = 0;
            _canvas.SetCanvasDimensions(maxWidth, maxHeight);

            S spriteInfo = new S();
            int heightHighestRightFlushedImage = 0;
            int furthestRightEdge = 0;

            foreach (IImageInfo image in images)
            {
                int xOffset;
                int yOffset;
                int lowestFreeHeightDeficit;
                if (!_canvas.AddRectangle(
                    image.Width, image.Height, 
                    out xOffset, out yOffset, 
                    out lowestFreeHeightDeficit))
                {
                    // Not enough room on the canvas to place the rectangle
                    spriteInfo = null;
                    break;
                }

                MappedImageInfo imageLocation = new MappedImageInfo(xOffset, yOffset, image);
                spriteInfo.AddMappedImage(imageLocation);

                // Update the lowestFreeHeightDeficitTallestRightFlushedImage
                int rightEdge = image.Width + xOffset;
                if ((rightEdge > furthestRightEdge) ||
                    ((rightEdge == furthestRightEdge) && (image.Height > heightHighestRightFlushedImage)))
                {
                    // The image is flushed the furthest right of all images, or it is flushed equally far to the right
                    // as the furthest flushed image but it is taller. 

                    lowestFreeHeightDeficitTallestRightFlushedImage = lowestFreeHeightDeficit;
                    heightHighestRightFlushedImage = image.Height;
                    furthestRightEdge = rightEdge;
                }
            }

            _canvas.GetStatistics(canvasStats);

            return spriteInfo;
        }

    }
}
