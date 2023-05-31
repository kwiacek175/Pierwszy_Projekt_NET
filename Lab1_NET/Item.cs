namespace Lab1_NET
{
    internal class Item
    {
        public int weight;      //waga przedmiotu
        public int value;       //wartosc przedmiotu
        public int id;          //numer przedmiotu 
        public bool flag;       //Czy przedmiot w bieżącym zestawie?
        public bool flagOpt;    //Czy przedmiot w optymalnym zestawie?

        public Item(int id, int w, int v)
        {
            this.id = id;
            weight = w;
            value = v;
            flag = false;
            flagOpt = false;
        }

        public override string ToString()
        {
            if (id >= 10)
                return id + "   --------     " + weight + "      --------     " + value;

            return id + "    --------     " + weight + "      --------     " + value;
        }
    }
}
