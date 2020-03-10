using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2.Models
{  
    [XmlTypeAttribute(typeName: "student")]
    public class Student
    {
        //[XmlAttribute(attributeName:"email")]
        // public string Email { get; set; }
        [JsonPropertyName("indexNumber")]
        [XmlAttribute(attributeName: "indexNumber")]
        public string Indeks { get; set; }
        [JsonPropertyName("fname")]
        [XmlElement(elementName: "fname")]
        public string Imie { get; set; }
        [JsonPropertyName("lname")]
        [XmlElement(elementName: "lname")]
        public string Nazwisko { get; set; }
        [JsonPropertyName("birthdate")]
        [XmlElement(elementName: "birthdate")]
        public string DataUrodzenia { get; set; }
        [JsonPropertyName("email")]
        [XmlElement(elementName: "email")]
        public string Email { get; set; }
        [JsonPropertyName("mothersName")]
        [XmlElement(elementName: "mothersName")]
        public string ImieMatki { get; set; }
        [JsonPropertyName("fathersName")]
        [XmlElement(elementName: "fathersName")]
        public string ImieOjca { get; set; }
        [JsonPropertyName("studies")]
        [XmlElement(elementName: "studies")]
        public Studia Studia { get; set; }
        //[XmlAttribute(attributeName: "studies")]
        /* [XmlElement(elementName: "name")]
         public string KierunekStudiow { get; set; }
         [XmlElement(elementName: "mode")]
         public string TypStudiow { get; set; }*/

        /*public Student(string Indeks, string Imie, string Nazwisko, string DataUrodzenia, string Email, string ImieMatki, string ImieOjca, string KierunekStudiow, string TypStudiow)
        {
            this.Indeks = Indeks;
            this.Imie = Imie;
            this.Nazwisko = Nazwisko;
            this.DataUrodzenia = DataUrodzenia;
            this.Email = Email;
            this.ImieMatki = ImieMatki;
            this.ImieOjca = ImieOjca;
            this.KierunekStudiow = KierunekStudiow;
            this.TypStudiow = TypStudiow;
        }*/
        public override bool Equals(Object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;
            Student s = (Student)obj;
            if (this.Imie != s.Imie)
                return false;
            if (this.Nazwisko != s.Nazwisko)
                return false;
            if (this.Indeks != s.Indeks)
                return false;
            return true;
        }
    }
}
