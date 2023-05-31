using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;

namespace Lab1_NET
{
    internal class Problem
    {
        public List<Item> itemList;  //Lista przedmiotów w plecaku  
        public int capacity;         //dopuszczalna ladownosc plecaka
        public int weight;           //waga bieżącego zestawu
        public int value;            //wartość bieżąecego zestawu
        public int wOpt;             //waga przedmiotów w plecaku 
        public int vOpt;             //wartość przedmiotów w plecaku 

        public Problem(int cap, Knapsack knapsack)
        {
            itemList = new List<Item>();
            itemList = knapsack.itemList;
            capacity = cap;
            weight = 0;
            value = 0;
            vOpt = 0;
            wOpt = 0;
            Solution();
        }

        //Metoda zachłanna (nieoptymalna)
        public void Solution()
        {
            if (capacity == 0)
            {
                wOpt = -1;
                vOpt = -1;
            }
            for (int k = 0; k < itemList.Count; k++)
            {
                weight += itemList[k].weight;
                if (weight <= capacity)
                {
                    value += itemList[k].value;
                    itemList[k].flag = true;
                    if (value > vOpt)
                    {
                        vOpt = value;
                        wOpt = weight;
                        foreach (Item i in itemList)
                        {
                            i.flagOpt = i.flag;
                        }
                    }
                }
                if (weight > capacity) break;
            }
        }

        public override string ToString()
        {
            String s = "";
            s += "\nLista przedmiotów w plecaku\n";
            s += "-------------------------------------------------- \n";
            s += "Przedmiot -------- Waga [kg] -------- Wartosc [zł] \n";
            foreach (Item i in itemList)
            {
                if (i.flagOpt)
                    s += "    " + i + "\n";
            }
            s += "-------------------------------------------------- \n";
            s += "Waga przedmiotów w plecaku: " + wOpt + "\n";
            s += "Wartość przedmiotów w plecaku: " + vOpt + "\n";
            return s;
        }
    }
}
