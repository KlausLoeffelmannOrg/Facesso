using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Facesso
{
    public class DemoProduct
    {
        public int IDPurchasedBy { get; set; }
        public string ProductName { get; set; }
        public string ProductNo { get; set; }
        public string Category { get; set; }
        public int Amount { get; set; }
        public decimal UnitPrice { get; set; }

        public override string ToString()
        {
            return this.ProductNo + ": " + this.ProductName;
        }

        public static List<DemoProduct> RandomProducts(List<DemoContact> Kontakte)
        {
            Random tmpRandom = new Random(42);
            List<DemoProduct> tmpListOfProducts = new List<DemoProduct>();
            string[] tmpProductMasterData =
            {
                "DVD|Catch me if you can|1-234",
                "DVD/Blue Ray|Being John Malkovich|2-134",
                "DVD/Blue Ray|Bodyguard|3-123",
                "DVD/Blue Ray|Castaway|9-646",
                "DVD/Blue Ray|The Maiden Heist|3-534",
                "DVD/Blue Ray|Transporter 3|4-324",
                "DVD/Blue Ray|The Social Network|9-423",
                "DVD/Blue Ray|Runaway Jury|5-554",
                "DVD/Blue Ray|24 - Season 7|2-424",
                "Books, IT|Parallel Programming with Microsoft Visual Studio 2010 Step by Step|5-506",
                "Books, IT|Visual Basic 2010 - Developer's Handbook|5-506",
                "Books, IT|Microsoft Visual C# 2010 - Developer's Handbook|3-543",
                "Books, IT|How We Test Software at Microsoft|5-401",
                "Books, IT|Microsoft SQL Server 2008 R2 - Developer's Handbook|5-513",
                "Audibooks|Harry Potter and the Deathly Hallows| 4-444",
                "Audibooks|The Jungle Book|2-321",
                "Audibooks|A tale of two cities|9-009",
                "Audibooks|Pride and prejudice|7-321",
                "Books, Novels|Eclipse (The Twilight Saga, Book 3)|9-445",
                "Books, Novels|The Cathedral of the Sea|5-436",
                "Books, Novels|The Da Vinci Code|4-444",
                "Books, Novels|Der Schwarm (German Edition)|3-333",
                "Books, Novels|The Rose Killer|6-666"
            };
            DemoProduct tmpProduct = default(DemoProduct);
            //Everybody purchased something! :-)
            foreach (var adrItem in Kontakte)
            {
                //Every customer purchased between one and 20 products.
                for (int anzahlGekaufterArtikel = 1; anzahlGekaufterArtikel <= tmpRandom.Next(1, 10); anzahlGekaufterArtikel++)
                {
                    tmpProduct = new DemoProduct();
                    var tmpStr = tmpProductMasterData[tmpRandom.Next(0, tmpProductMasterData.Count() - 1)].Split('|');
                    tmpProduct.IDPurchasedBy = adrItem.IDContact;
                    tmpProduct.ProductName = tmpStr[1];
                    tmpProduct.ProductNo = tmpStr[2];
                    tmpProduct.Amount = tmpRandom.Next(1, 4);
                    tmpProduct.UnitPrice = (tmpRandom.Next(1, 20) * 5) - 0.05m;
                    tmpProduct.Category = tmpStr[0];
                    tmpListOfProducts.Add(tmpProduct);
                }
            }

            return tmpListOfProducts;
        }
    }

    public class DemoContact
    {
        public DemoContact(int ID, string Name, string Vorname, string Straße, string Plz, string Ort)
        {
            this.IDContact = ID;
            this.LastName = Name;
            this.FirstName = Vorname;
            this.Street = Straße;
            this.ZIP = Plz;
            this.City = Ort;
        }

        public int IDContact { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Street { get; set; }
        public string ZIP { get; set; }
        public virtual string City { get; set; }

        public override string ToString()
        {
            return "\"" + LastName + ", " + FirstName + "\"";
        }

        public static List<DemoContact> RandomContacts(int Count)
        {
            List<DemoContact> tmpListOfAddresses = new List<DemoContact>();
            Random tmpRandom = new Random(42);
            string[] tmpLastNames =
            {
                "Heckhuis",
                "Löffelmann",
                "Jones",
                "Lowel",
                "Ardelean",
                "Beckham",
                "Baur",
                "Picard",
                "Trouv",
                "Feigenbaum",
                "Miller",
                "Wallace",
                "Merkel",
                "Spooner",
                "Spoonman",
                "Huffman",
                "Rode",
                "Trouw",
                "Schindler",
                "Brown",
                "Walker",
                "Cruise",
                "Meier",
                "Maier",
                "Mayer",
                "Tinoco",
                "O'Reilly",
                "O'Donnell",
                "Ó Briain",
                "Russel",
                "English",
                "Clarke",
                "Schumacher"
            };
            string[] tmpStreetNames =
            {
                "Wiedenbrückerstr.",
                "Stauffenberg Ave.",
                "Broadway",
                "Parkstr.",
                "Kurgartenweg",
                "Alter Postweg",
                "Long Turnpike",
                "Zzyzx Rd.",
                "Main Street",
                "Streetway",
                "Postplatz",
                "Beamer Place",
                "Mercedes Way",
                "Porsche Drive",
                "Weidering",
                "One Way",
                "Endof Rd.",
                "Gotlost Way",
                "Satnav Rd."
            };
            string[] tmpFirstNames =
            {
                "Jürgen",
                "Gabriele",
                "Dianne",
                "Katrin",
                "Jack",
                "Arnold",
                "Christian",
                "Frank",
                "Curt",
                "Peter",
                "Anne",
                "Anja",
                "Theo",
                "Bob",
                "Katrin",
                "Guido",
                "Barbara",
                "Bernhard",
                "Margarete",
                "Alfred",
                "Melanie",
                "Britta",
                "José",
                "Thomas",
                "Dara",
                "Klaus",
                "Axel",
                "Gabby",
                "Gareth",
                "Bob",
                "Denise",
                "Kristen"
            };
            string[] tmpCities =
            {
                "Bellevue",
                "Dortmund",
                "Lippstadt",
                "Redmond",
                "Los Angeles",
                "Las Vegas",
                "Seattle",
                "New York",
                "Berlin",
                "Bielefeld",
                "Braunschweig",
                "Munich",
                "Cologne",
                "Hamburg",
                "Bad Waldliesborn",
                "Bremen",
                "Encinitas",
                "Anaheim"
            };
            for (int i = 1; i <= Count; i++)
            {
                string tmpLastName = default(string);
                string tmpFirstName = default(string);
                tmpLastName = tmpLastNames[tmpRandom.Next(tmpLastNames.Length - 1)];
                tmpFirstName = tmpFirstNames[tmpRandom.Next(tmpLastNames.Length - 1)];
                tmpListOfAddresses.Add(new DemoContact(i, tmpLastName, tmpFirstName, tmpStreetNames[tmpRandom.Next(tmpStreetNames.Length - 1)], tmpRandom.Next(99999).ToString("00000"), tmpCities[tmpRandom.Next(tmpCities.Length - 1)]));
            }

            return tmpListOfAddresses;
        }

        public static void PrintContacts(List<DemoContact> Contacts)
        {
            //Option Infer ist 'On', deswegen wird
            //Item automatisch zum Typ 'Adresse'
            foreach (var Item in Contacts)
            {
                Console.WriteLine(Item);
            }
        }
    }
}