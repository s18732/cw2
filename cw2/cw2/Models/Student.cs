using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace cw2.Models
{
    public class Student
    {
        //[XmlAttribute(attributeName:"email")]
       // public string Email { get; set; }
        [XmlElement(elementName: "fname")]
        public string Imie { get; set; }
        [XmlElement(elementName: "lname")]
        public string Nazwisko { get; set; }
        [XmlElement(elementName: "birthdate")]
        public string DataUrodzenia { get; set; }
        [XmlElement(elementName: "email")]
        public string Email { get; set; }
        [XmlElement(elementName: "mothersName")]
        public string ImieMatki { get; set; }
        [XmlElement(elementName: "fathersName")]
        public string ImieOjca { get; set; }
        //[XmlAttribute(attributeName: "studies")]
        [XmlElement(elementName: "name")]
        public string KierunekStudiow { get; set; }
        [XmlElement(elementName: "mode")]
        public string TypStudiow { get; set; }


    }
}
