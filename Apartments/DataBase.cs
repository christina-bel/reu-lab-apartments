using System;
using System.Collections.Generic;

namespace Apartments.DataLogic
{
    [Serializable] // доступ к сериализации
    public class DataBase // База данных (список записей БД).
    {
        // свойство класса для чтения и записи списка экземпляров класса Appart (квартир)
        public List<Appart> List { get; set;}

        //конструктор 
        public DataBase()
        {
            List = new List<Appart>();
        }

        // индексатор (служит первичным ключом)
        public Appart this[int index]
        {
            get { return List[index]; }
            set { List[index] = value; }
        }
       
        // перегрузка метода ToString для строкового представления списка квартир
        public override string ToString()
        {
              string s = "";
              int index = 1;
              foreach (var app in List)
              {
                s += index.ToString() + ". " + app.ToString() + "\n";
                index++;
              }
              return s;
        }

    }


    [Serializable] // доступ к сериализации
    public class Appart //класс квартир
    {
        // доступ к закрытым полям через свойства
        public string District { get; set; } // район квартиры
        public double Square { get; set; } // площадь квартиры
        public int Rooms { get; set; }// число комнат в квартире
        public int Floor { get; set; } // этаж квартиры
        public bool Phone { get; set; } // наличие телефона в квартире
        public int Price { get; set; } // цена квартиры

        //конструктор для создания квартиры 
        public Appart(string dist, double sq, int rm, int fl, bool ph, int pr)
        {
            District = dist;
            Square = sq;
            Rooms = rm;
            Floor = fl;
            Phone = ph;
            Price = pr;
        }
        // конструктор по умолчанию (необходим для сериализации)
        public Appart() { }

        // перегрузка метода ToString для строкового представления квартиры
        public override string ToString()
        {
            return $"Квартира: район - {District}, площадь - {Square} м^2, число комнат - {Rooms}, этаж - {Floor},\nналичие телефона - {Phone}, цена - {Price} руб.";
        }
    }
}