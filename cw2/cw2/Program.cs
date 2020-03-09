using cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = "data.csv";
            string path = "Data\\dane.csv";
            string outPath = "result.xml";
            string dataType = "xml";
            if (args.Length > 3)
            {
                Console.WriteLine("Za duzo argumentow");
                Environment.Exit(-1);
            }
            else if (args.Length == 3)
            {
                path = args[0];
                outPath = args[1];
                dataType = args[2];
            }
            var list = new List<Student>();

            //Wczytywanie
            var fi = new FileInfo(path);
           /* using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] kolumny = line.Split(',');
                    list.Add(new Student
                    {

                    });
                }
            }*/

            //XML
            //var list = new List<Student>();
            var st = new Student
            {
                Imie = "Jan",
                Nazwisko = "Kowalski",
                Email = "kowalski@wp.pl"
            };
            list.Add(st);

            FileStream writer = new FileStream(@"data.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));

            serializer.Serialize(writer, list);

        }

    }
}
