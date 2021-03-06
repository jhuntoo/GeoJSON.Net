﻿using GeoJSON.Net.Converters;
using GeoJSON.Net.Feature;
using GeoJSON.Net.Geometry;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace GeoJSON.Net.Tests
{
    [TestClass]
    public class MiscTest
    {
        /// <summary>
        /// Test that the last coordinate must be the same as the first to complete the polygon
        /// </summary>
        [TestMethod]
        public void LineStringIsClosed() 
        {
            var coordinates = new List<GeographicPosition> 
            { 
                new GeographicPosition(52.370725881211314, 4.889259338378906), 
                new GeographicPosition(52.3711451105601, 4.895267486572266), 
                new GeographicPosition(52.36931095278263, 4.892091751098633), 
                new GeographicPosition(52.370725881211314, 4.889259338378906) 
            }.ToList<IPosition>();

            var lineString = new LineString(coordinates);
        }


        [TestMethod]
        public void ComparePolygons() 
        {
            var coordinates = new List<GeographicPosition> 
                { 
                    new GeographicPosition(52.370725881211314, 4.889259338378906), 
                    new GeographicPosition(52.3711451105601, 4.895267486572266), 
                    new GeographicPosition(52.36931095278263, 4.892091751098633), 
                    new GeographicPosition(52.370725881211314, 4.889259338378906) 
                }.ToList<IPosition>();

            var coordinates2 = new List<GeographicPosition> 
                { 
                    new GeographicPosition(52.370725881211314, 4.889259338378906), 
                    new GeographicPosition(52.3711451105601, 4.895267486572266), 
                    new GeographicPosition(52.36931095278263, 4.892091751098633), 
                    new GeographicPosition(52.370725881211314, 4.889259338378906) 
                }.ToList<IPosition>();

            var polygon = new Polygon(new List<LineString> { new LineString(coordinates) });
            var polygon2 = new Polygon(new List<LineString> { new LineString(coordinates2) });

            Assert.IsTrue(polygon == polygon2);

            var coordinates3 = new List<GeographicPosition> 
                { 
                    new GeographicPosition(52.3707258811314, 4.889259338378906), 
                    new GeographicPosition(52.3711451105601, 4.895267486572266), 
                    new GeographicPosition(52.362095278263, 4.892091751098633), 
                    new GeographicPosition(52.3707258811314, 4.889259338378906) 
                }.ToList<IPosition>();
            var polygon3 = new Polygon(new List<LineString> { new LineString(coordinates3) });
            Assert.IsFalse(polygon == polygon3);


            polygon.Coordinates[0].Coordinates.Add(new GeographicPosition(52.370725881211314, 4.889259338378906));
            Assert.IsFalse(polygon == polygon2);

        }
    }
}
