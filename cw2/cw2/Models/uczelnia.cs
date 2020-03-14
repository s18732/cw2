using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace cw2.Models
{
	public class studies
	{
		public string name { get; set; }
		public string mode { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string _name { get; set; }
		[XmlAttribute(AttributeName = "numberOfStudents")]
		public string numberOfStudents { get; set; }
		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
				return false;
			studies s = (studies)obj;
			if (this._name != s._name || this.name != s.name)
				return false;
			return true;
		}

	}

	public class studenci
	{
		public List<student> student { get; set; }
	}
	public class student
	{
		[XmlAttribute(AttributeName = "indexNumber")]
		public string indexNumber { get; set; }
		public string fname { get; set; }
		public string lname { get; set; }
		public string birthdate { get; set; }
		public string email { get; set; }
		public string mothersName { get; set; }
		public string fathersName { get; set; }
		public studies studies { get; set; }

		public override bool Equals(Object obj)
		{
			if ((obj == null) || !this.GetType().Equals(obj.GetType()))
				return false;
			student s = (student)obj;
			if (this.fname != s.fname)
				return false;
			if (this.lname != s.lname)
				return false;
			if (this.indexNumber != s.indexNumber)
				return false;
			return true;
		}
	}

	public class uczelnia
	{
		[XmlAttribute(AttributeName = "createdAt")]
		public string createdAt { get; set; }
		[XmlAttribute(AttributeName = "author")]
		public string author { get; set; }
		public studenci studenci { get; set; }
		public List<studies> activeStudies { get; set; }
	}
}