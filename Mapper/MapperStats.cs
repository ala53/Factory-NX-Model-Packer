﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mapper
{
    /// <summary>
    /// Defines the statistics to be produced by an IMapperIterative.
    /// </summary>
    public class MapperStats : IMapperStats
    {
        /// <summary>
        /// Number of times the mapper tried to create a sprite, but failed to do so.
        /// For example, if it uses a canvas with a certain size, the canvas may have been too small
        /// to place all images.
        /// </summary>
        public int CandidateSpriteFails { get; set; }

        /// <summary>
        /// Number of candidate sprites successfully generated by the mapper.
        /// A mapper would return only the best of the candidate sprites from its Mapping method.
        /// </summary>
        public int CandidateSpritesGenerated { get; set; }

        /// <summary>
        /// Number of times an attempt was made to add an image to the canvas used by the mapper.
        /// </summary>
        public int CanvasRectangleAddAttempts { get; set; }

        /// <summary>
        /// Number of cells generated by the canvas used by the mapper.
        /// </summary>
        public int CanvasNbrCellsGenerated { get; set; }

    }
}
