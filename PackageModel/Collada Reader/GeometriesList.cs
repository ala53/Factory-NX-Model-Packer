using ColladaDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PackageModel.Collada_Reader
{
    class GeometriesList
    {
        List<ColladaGeometry> Geometries = new List<ColladaGeometry>();
        public GeometriesList(Collada ColladaFile)
        {
            foreach (Collada_Geometry geometry in ColladaFile.Library_Geometries.Geometry)
            {

            }
        }
    }
}
