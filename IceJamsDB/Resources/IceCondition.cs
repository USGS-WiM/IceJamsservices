//------------------------------------------------------------------------------
//----- Resource ---------------------------------------------------------------
//------------------------------------------------------------------------------

//-------1---------2---------3---------4---------5---------6---------7---------8
//       01234567890123456789012345678901234567890123456789012345678901234567890
//-------+---------+---------+---------+---------+---------+---------+---------+

// copyright:   2019 WIM - USGS

//    authors:  Jeremy K. Newson USGS Web Informatics and Mapping
//              
//  
//   purpose:   Simple Plain Old Class Object (POCO) 
//
//discussion:   POCO's arn't derived from special base classed nor do they return any special types for their properties.
//              
//
//   

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;
namespace IceJamsDB.Resources
{
    public partial class IceCondition
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int IceJamID { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int IceConditionTypeID { get; set; }
        [Required]
        public double Measurement { get; set; }
        public bool IsEstimated { get; set; }
        public bool IsChanging { get; set; }
        public string Comments { get; set; }

        public Point UpstreamEndLocation { get; set; }
        public Point DownstreamEndLocation { get; set; }
        public int RoughnessTypeID { get; set; }

        public IceConditionType Type { get; set; }
        public RoughnessType RoughnessType { get; set; }
    }
}
