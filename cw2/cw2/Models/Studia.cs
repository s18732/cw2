using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2.Models
{
    [XmlTypeAttribute(typeName: "studies")]
    public class Studia
    {
        [JsonPropertyName("name")]
        [XmlElement(elementName: "name")]
        public string Kierunek { get; set; }
        [JsonPropertyName("mode")]
        [XmlElement(elementName: "mode")]
        public string Typ { get; set; }
    }
}
