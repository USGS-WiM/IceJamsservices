//------------------------------------------------------------------------------
//----- Resource ---------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2017 WiM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Simple Plain Old Class Object (POCO) 
//
//discussion:   POCO's arn't derived from special base classed nor do they return any special types for their properties.
//              
//
//     

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO.Converters;
using Newtonsoft.Json;

namespace IceJamsDB.Resources
{
    public partial class Site
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [JsonConverter(typeof(GeometryConverter))]
        public Point Location { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string RiverName { get; set; }
        public string HUC { get; set; }
        public string USGSID { get; set; }
        public string AHPSID { get; set; }
        public string Comments { get; set; }
        public string Landmarks { get; set; }
    }
}
