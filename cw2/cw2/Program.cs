using cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

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
            try
            {
                var fi = new FileInfo(path);
                 using (var stream = new StreamReader(fi.OpenRead()))
                 {
                     string line = null;
                     while ((line = stream.ReadLine()) != null)
                     {
                        string[] kolumny = line.Split(',');
                        if(kolumny.Length == 9)
                        {
                            bool puste = false;
                            for(int i = 0; i < 9; i++)
                            {
                                if(kolumny[i].Equals("") || kolumny[i].Equals(" "))
                                {
                                    //dodac studenta do log.txt
                                    puste = true;
                                }
                            }
                            if (!puste)
                            {
                                //Student stud = new Student(kolumny[4],kolumny[0],kolumny[1],kolumny[5],kolumny[6],kolumny[7],kolumny[8],kolumny[2],kolumny[3]);
                                Studia studia = new Studia
                                {
                                    Kierunek = kolumny[2],
                                    Typ = kolumny[3]
                                };
                                Student stud = new Student
                                {
                                    Indeks = kolumny[4],
                                    Imie = kolumny[0],
                                    Nazwisko = kolumny[1],
                                    DataUrodzenia = kolumny[5],
                                    Email = kolumny[6],
                                    ImieMatki = kolumny[7],
                                    ImieOjca = kolumny[8],
                                    //KierunekStudiow = kolumny[2],
                                    //TypStudiow = kolumny[3]
                                    Studia = studia
                                };
                                if (!list.Contains(stud))
                                    list.Add(stud);
                            }  
                        }
                        else
                        {
                            //zapisac blad do log.txt
                        }
                     }
                 }

                var jsonString = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText("data.json", jsonString);

                FileStream writer = new FileStream(@"data.xml", FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));

                serializer.Serialize(writer, list);
            }catch(ArgumentException e)
            {
                //zapisac blad do log.txt
                throw new ArgumentException("Podana sciezka jest niepoprawna");
            }catch(FileNotFoundException e)
            {
                //zapisac blad do log.txt
                throw new FileNotFoundException("Plik nazwa nie istnieje");
            }
            
        }

    }
}
