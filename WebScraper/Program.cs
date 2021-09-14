using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WindowsFormsApp1
{
    class Program
    {
        static void 
            Main(string[] args)
        {
            Scraper scraper = new Scraper();

            scraper.GetFuels();

            Console.ReadKey();
        }
    }


    class Scraper
    {
        private const string url = "https://www.autocentrum.pl/paliwa/ceny-paliw/";

        public void GetFuels()
        {

            var web = new HtmlWeb();
            var document = web.Load(url);
            ArrayList Fuel_List = new ArrayList();

            var table = document.QuerySelectorAll("tbody");

            if (table != null)
            {
                foreach (var cell in table)
                {
                    //Dodaj elementy do Fuel_List
                    Fuel_List.Add(cell.InnerText.ToString().Replace(" ", String.Empty));
                }
            }

            else
            {
                Console.WriteLine("Wyszukiwanie tabeli nie powiodło się");
            }

            Console.WriteLine("*********");

            //Konwertowanie i splitowanie tabeli
            List<string> stringList = Fuel_List[0].ToString().Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Where(x => !string.IsNullOrWhiteSpace(x)).ToList();


            foreach (var item in stringList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("To koniec");

            //Podlicz wszystkie elementy
            //Console.WriteLine(stringList.Count());

            //TODO Stworzyc teraz kazdy jeden array do kazdego wojewodztwa 

        }
    }
}
