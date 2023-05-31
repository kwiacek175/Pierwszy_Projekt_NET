using System;
using System.Collections.Generic;

namespace Lab1_NET
{
    internal class Knapsack
    {
        public List<Item> itemList; //lista wszystkich przedmiotów 

        public Knapsack(int number)
        {
            itemList = new List<Item>();
            Random random = new Random(5);

            for (int i = 0; i < number; i++)
            {
                itemList.Add(new Item(i + 1, random.Next(1, 15), random.Next(1, 15)));
            }
        }

        public override string ToString()
        {
            string s = "";
            s += "Przedmiot -------- Waga [kg] -------- Wartosc [zł] \n";
            foreach (Item i in itemList)
                s += "    " + i + "\n";
            return s;
        }
    }
}
