using cw2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace cw2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inFile = "data.csv";
            string outFile = "result.xml";
            string dataType = "xml";
            Log log = new Log();

            // sprawdzenie i popbrane argumentów
            if (args.Length > 3)
            {
                Console.WriteLine("Za duzo argumentow");
                Environment.Exit(-1);
            }
            else if (args.Length == 3)
            {
                inFile = args[0];
                outFile = args[1];
                dataType = args[2];
            }

            // obiekt główny
            uczelnia Uczelnia = new uczelnia
            {
                createdAt = DateTime.Now.ToString("dd.MM.yyyy"),
                author = "Adam Bajszczak",
                studenci = new studenci { student = new List<student> { } },
                activeStudies = new List<studies> { }
            };

            //wczytywanie danych
            try
            {
                var fi = new FileInfo(inFile);
                using (var stream = new StreamReader(fi.OpenRead()))
                {
                    string line = null;
                    while ((line = stream.ReadLine()) != null)
                    {
                        string[] kolumny = line.Split(',');
                        if (kolumny.Length == 9)
                        {
                            bool puste = false;
                            for (int i = 0; i < 9; i++)
                            {
                                if (kolumny[i].Equals("") || kolumny[i].Equals(" "))
                                {
                                    log.Dodaj(line);
                                    puste = true;
                                }
                            }
                            if (!puste)
                            {
                                studies studia = new studies
                                {
                                    name = kolumny[2],
                                    mode = kolumny[3]
                                };
                                student stud = new student
                                {
                                    indexNumber = kolumny[4],
                                    fname = kolumny[0],
                                    lname = kolumny[1],
                                    birthdate = kolumny[5],
                                    email = kolumny[6],
                                    mothersName = kolumny[7],
                                    fathersName = kolumny[8],
                                    studies = studia
                                };
                                if (!Uczelnia.studenci.student.Contains(stud))
                                    Uczelnia.studenci.student.Add(stud);

                                studies studia2 = new studies { };
                                if (String.Equals(dataType, "json"))
                                {
                                    studia2.name = kolumny[2];
                                    studia2.numberOfStudents = "1";
                                }
                                else
                                {
                                    studia2._name = kolumny[2];
                                    studia2.numberOfStudents = "1";
                                };
                                if (!Uczelnia.activeStudies.Contains(studia2))
                                    Uczelnia.activeStudies.Add(studia2);
                                else
                                    Uczelnia.activeStudies[Uczelnia.activeStudies.IndexOf(studia2)].numberOfStudents = (1 + int.Parse(Uczelnia.activeStudies[Uczelnia.activeStudies.IndexOf(studia2)].numberOfStudents)).ToString();
                            }
                        }
                        else
                        {
                            log.Dodaj(line);
                        }
                    }
                }
                if (String.Equals(dataType, "json"))
                {

                    // plik json
                    var tmp = new { uczelnia = Uczelnia };
                    string jsonString = JsonSerializer.Serialize(tmp, new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = true });
                    File.WriteAllText(outFile, jsonString);
                }
                else
                {
                    // plik xml
                    XmlWriter writer = XmlWriter.Create(outFile, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true, ConformanceLevel = ConformanceLevel.Auto });
                    XmlSerializer serializer = new XmlSerializer(typeof(uczelnia));
                    XmlSerializerNamespaces emptyns = new XmlSerializerNamespaces();
                    emptyns.Add("", "");
                    serializer.Serialize(writer, Uczelnia, emptyns);
                }

            }
            catch (ArgumentException)
            {
                log.Dodaj("Podana scieżka jest niepoprawna");
                throw new ArgumentException("Podana scieżka jest niepoprawna");
            }
            catch (FileNotFoundException)
            {
                log.Dodaj("Plik z danymi nie został znaleziony");
                throw new FileNotFoundException("Plik z danymi nie został znaleziony");
            }
        }
    }

    // logowanie błędów
    public class Log
    {
        public void Dodaj(string logMessage)
        {
            try
            {
                using (StreamWriter plik = File.AppendText("log.txt"))
                {
                    plik.WriteLine(logMessage);
                }
            }
            catch (Exception)
            {
                throw new FileNotFoundException("Błąd zapisu do pliku log.txt");
            }
        }
    }
}
