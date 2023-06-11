using Owl.Overdrive.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Domain.Entities
{
    public class CountryCode : BaseEntity
    {
        /// <summary>
        /// Country name to describe
        /// a distict part of the world
        /// </summary>
        public string? CountryName { get; set; }
        /// <summary>
        /// Centralized organization of a country
        /// </summary>
        public string? OfficialStateName { get; set; }
        /// <summary>
        /// Political entity represent by one central
        /// goverment
        /// </summary>
        public string? Sovereignty { get; set; }
        /// <summary>
        /// Two letter country codes defined
        /// in ISO 3166-1
        /// </summary>
        public string? Alpha2Code { get; set; }
        /// <summary>
        /// Three letter country codes defined
        /// in ISO 3166-1
        /// </summary>
        public string? Alpha3Code { get; set; }
        /// <summary>
        /// Three digit country codes defined
        /// in ISO 3166-1
        /// </summary>
        public long NumericCode { get; set; }
        /// <summary>
        /// Define code for identifying the
        /// proncipal subdivision
        /// </summary>
        public string? SubdivisionCodeLinks { get; set; }
        /// <summary>
        /// A country code top level domain
        /// </summary>
        public string? InternetccTLD { get; set; }
    }
}
