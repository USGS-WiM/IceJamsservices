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
namespace IceJamsDB.Resources
{
    public partial class IceJam
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime ObservationDateTime { get; set; }
        [Required]
        public int JamTypeID { get; set; }
        [Required]
        public int SiteID { get; set; }
        [Required]
        public int ObserverID { get; set; }
        [Required]
        public string Description { get; set; }
        public string Comments { get; set; }

        public Site Site { get; set; }
        public JamType Type { get; set; }
        public Observer Observer { get; set; }

        public List<IceCondition> IceConditions { get; set; }
        public List<RiverCondition> RiverConditions { get; set; }
        public List<WeatherCondition> WeatherConditions { get; set; }
        public List<Damage> Damages { get; set; }
        public List<File> Files { get; set; }

        public bool ShouldSerializeIceConditions()
        {
            return IceConditions != null && IceConditions.Count > 0;
        }
        public bool ShouldSerializeRiverConditions()
        {
            return RiverConditions != null && RiverConditions.Count > 0;
        }
        public bool ShouldSerializeWeatherConditions()
        {
            return WeatherConditions != null && WeatherConditions.Count > 0;
        }
        public bool ShouldSerializeDamages()
        {
            return Damages != null && Damages.Count > 0;
        }
        public bool ShouldSerializeFiles()
        {
            return Files != null && Files.Count > 0;
        }
    }
}
