using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Lab1_NET;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        // Test sprawdzający przypadek, gdy ładnowść plecaka jest dużo większa niż waga wszystkich przedmiotów 
        [TestMethod]
        public void TestMethod1()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                Problem problem = new Problem(10000, knapsack);
                Assert.AreEqual(problem.weight, problem.wOpt); //jeśli ładowność plecaka jest bardzo duża, to wszystkie przedmioty znajdą się w plecaku
                Assert.AreEqual(problem.value, problem.vOpt);  // wartość plecaka jest sumą wartości wszystkich przedmiotów 
            }
        }

        // Test sprawdzajacy przypadek, gdy ladownosc plecaka wynosi 0
        [TestMethod]
        public void TestMethod2()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                Problem problem = new Problem(0, knapsack);
                Assert.AreEqual(-1, problem.wOpt); // jesli ladownosc plecaka wynosi 0, to wartosci przyjmują wartości -1
                Assert.AreEqual(-1, problem.vOpt);
            }
        }

        // Test sprawdzajacy przypadek, gdy wszystkie przedmioty ważą 0 kg
        // Przedmioty mają dowolne wartości. 
        // Ladowność plecaka wynosi przykładowo 20 kg.
        [TestMethod]
        public void TestMethod3()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                for (int i = 0; i < n_items; i++)
                {
                    knapsack.itemList[i].weight = 0;
                }
                Problem problem = new Problem(20, knapsack);
                Assert.AreEqual(0, problem.wOpt);              // jeśli przedmioty nic nie waża to waga przedmiotow w plecaku wynosi 0 kg
                Assert.AreEqual(problem.value, problem.vOpt);   // Wartosc przedmiotow w plecaku jest rowna sumie wartosci wszystkich przedmiotów 
            }

        }

        // Test sprawdzajacy przypadek, gdy wszystkie przedmioty mają wartość 0 zł
        // Przedmioty mają dowolną wagę
        // Ladowność plecaka wynosi przykładowo 20 kg.
        [TestMethod]
        public void TestMethod4()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                for (int i = 0; i < n_items; i++)
                {
                    knapsack.itemList[i].value = 0;
                }
                Problem problem = new Problem(20, knapsack);
                Assert.AreEqual(0, problem.vOpt);  //jeśli wszystkie przedmioty mają zerową wartość to optymalna wartość przedmiotow w plecaku wynosi 0 zł
            }

        }

        // Test sprawdzający przypadek, gdy wszystkie przedmioty są za ciężkie aby je załadować do plecaka 
        // Wartości przedmiotów są dowolne 
        // Przykładowa ładowność plecaka wynosi 20 kg
        [TestMethod]
        public void TestMethod5()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                for (int i = 0; i < n_items; i++)
                {
                    knapsack.itemList[i].weight = 50;
                }
                Problem problem = new Problem(20, knapsack);
                Assert.AreEqual(0, problem.vOpt);  // Wartość plecaka bez przedmiotów wynosi 0 zł  
                Assert.AreEqual(0, problem.wOpt);  // jeżeli przedmioty ważą za dużo to żaden przedmiot się nie zmieści do plecaka
            }

        }

        // Test sprawdzający przypadek, gdy mamy tylko 5 przedmioty, każdy waży po 4 kg, wartości przedmitów dowolne 
        // Przykładowa ładowność plecaka wynosi 20 kg
        [TestMethod]
        public void TestMethod6()
        {
            Knapsack knapsack = new Knapsack(5);
            for (int i = 0; i < 5; i++)
            {
                knapsack.itemList[i].weight = 4;
            }
            Problem problem = new Problem(20, knapsack);
            Assert.AreEqual(20, problem.wOpt);            // Przedmioty wszystkie są w plecaku i zajmują jego całą ładowność 
            Assert.AreEqual(problem.value, problem.vOpt); // Wartość przedmiotów w plecaku jest sumą wartości wszystkich przedmiotów 

        }

        // Test sprawdzający przypadek, gdy mamy pierwszy przedmiot, który waży 2 kg i każdy następny przedmiot waży o 2 kg więcej od poprzedniego 
        // Wartości tych przedmiotów wynoszą po 5 zł każdy 
        // Przykładowa ładowność plecaka wynosi 20 kg
        [TestMethod]
        public void TestMethod7()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                int pom = 2;
                for (int i = 0; i < n_items; i++)
                {
                    knapsack.itemList[i].weight = pom;
                    knapsack.itemList[i].value = 5;
                    pom = pom + 2;
                }
                Problem problem = new Problem(20, knapsack);
                if (n_items < 4)
                {
                    Assert.AreEqual(problem.weight, problem.wOpt);
                    Assert.AreEqual(problem.value, problem.vOpt);
                }
                if (n_items >= 4)
                {
                    Assert.AreEqual(20, problem.wOpt); // Waga plecaka powinna wynosić: 2 + 4 + 6 + 8 = 20 kg. W plecaku zmieszczą się tylko pierwsze 4 przedmioty
                    Assert.AreEqual(20, problem.vOpt); // Wartość przedmiotów w plecaku jest sumą wartości 4 pierwszych przedmiotów: 5*4 = 20 zł
                }
            }
        }

        // Test sprawdzający przypadek, gdy mamy pierwszy przedmiot, który ma wartośc 2 zł i każdy następny przedmiot jest wart o 2 zł więcej od poprzedniego 
        // Wagi tych przedmiotów wynoszą po 1 kg każdy  
        // Przykładowa ładowność plecaka wynosi 20 kg
        [TestMethod]
        public void TestMethod8()
        {
            for (int n_items = 1; n_items <= 50; n_items++)
            {
                Knapsack knapsack = new Knapsack(n_items);
                int pom = 2;
                for (int i = 0; i < n_items; i++)
                {
                    knapsack.itemList[i].weight = 1;
                    knapsack.itemList[i].value = pom;
                    pom = pom + 2;
                }
                Problem problem = new Problem(20, knapsack);
                if (n_items < 20)
                {
                    Assert.AreEqual(problem.weight, problem.wOpt);
                    Assert.AreEqual(problem.value, problem.vOpt);
                }
                if (n_items >= 20)
                {
                    Assert.AreEqual(20, problem.wOpt); // Waga plecaka powinna wynosić: 20*1kg = 20kg. W plecaku zmieszczą się tylko pierwsze 20 przedmiotow w kolejce
                    Assert.AreEqual(420, problem.vOpt); // Wartość przedmiotów w plecaku jest sumą wartości 20 pierwszych przedmiotów: (2+40)/2*20 = 420 zł 
                }
            }
        }

        // Test sprawdzający przypadek, gdy mamy tylko 10 przedmiotów. Pierwszy przedmiot waży 5 kg. Każdy kolejny o 3 kg więcej.
        // Każdy przedmiot wart jest po 15 zł.
        // Przykładowa ładowność plecaka wynosi 50 kg
        [TestMethod]
        public void TestMethod9()
        {
            Knapsack knapsack = new Knapsack(10);
            int pom = 5;
            for (int i = 0; i < 10; i++)
            {
                knapsack.itemList[i].weight = pom;
                knapsack.itemList[i].value = 15;
                pom = pom + 3;
            }
            Problem problem = new Problem(50, knapsack);
            Assert.AreEqual(38, problem.wOpt);   //Waga przedmiotów w plecaku: 5 + 8 + 11 + 14 = 38 kg. Plecak jest niezapełniony całkowicie.
            Assert.AreEqual(60, problem.vOpt);   // Wartość przedmiotów w plecaku jest sumą wartości pierwszych czterech przedmiotów: 4 * 15 = 60 zł
        }

        // Test sprawdzający przypadek, gdy mamy tylko 10 przedmiotów. Pierwszy przedmiot jest wart 3 zł. Każdy kolejny o 5 zł więcej.
        // Każdy przedmiot waży po 8 kg.
        // Przykładowa ładowność plecaka wynosi 50 kg
        [TestMethod]
        public void TestMethod10()
        {
            Knapsack knapsack = new Knapsack(10);
            int pom = 3;
            for (int i = 0; i < 10; i++)
            {
                knapsack.itemList[i].weight = 8;
                knapsack.itemList[i].value = pom;
                pom = pom + 5;
            }
            Problem problem = new Problem(50, knapsack);
            Assert.AreEqual(48, problem.wOpt);   //Waga przedmiotów w plecaku: 8*6 = 48 kg. Plecak jest niezapełniony całkowicie.
            Assert.AreEqual(93, problem.vOpt);   // Wartość przedmiotów w plecaku jest sumą wartości pierwszych 6 przedmiotów: 3 + 8 + 13 + 18 + 23 + 28 = 93 zł
        }
    }
}
