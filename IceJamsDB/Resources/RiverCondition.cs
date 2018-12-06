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
    public partial class RiverCondition
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int IceJamID { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int RiverConditionTypeID { get; set; }
        public bool IsFlooding { get; set; }
        public int StageTypeID { get; set; }
        public double Measurement { get; set; }
        public bool IsChanging { get; set; }
        [Required]
        public string Comments { get; set; }

        public StageType StageType { get; set; }
        public RiverConditionType Type { get; set; }

    }
}
