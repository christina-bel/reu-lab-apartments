using System;
using System.Text;
using Apartments.DataLogic;

namespace Apartments.BussinessLogic
{
    class Business_logic // Слой бизнес-логики
    {
        Data_logic dt = new Data_logic(new DataBase());
        public void Add(Appart a) // добавление новой записи
        {
            dt.Create(a);
        }
        public void Delete(int id) // удаление записи
        {
            dt.Delete(id);
        }
        public void Update(int id, Appart a) // обновление записи
        {
            dt.Update(id, a);

        }
        public Appart ShowRecord(int id) // просмотр записи
        {
           return dt.Read(id);
        }

        public DataBase ShowAllRecords() // просмотр записей
        {
            return dt.Read();
        }

        public int CountRecords() // число элементов в базе данных
        {
            return dt.CountRecords();
        }

        public bool Save(string filename, ref string e) // сохранить базу данных
        {
            return dt.Save(filename, ref e);
        }

        public bool Load(string filename, ref string e) // загрузка базы данных
        {
            return dt.Load(filename, ref e);
        }

        public string Select(string dist, double s, int rm, int fl, bool ph,int pr) // выборка квартиры с указанными параметрами
        {
            StringBuilder str = new StringBuilder(); //класс StringBuilder - динамическая строка, позволяет увеличить производительность при повторяющихся изменениях строки (избавляет от значительных издержек, связанных с созданием объекта String)             
            for (int i = 0; i < dt.CountRecords(); i++)
            {
                if (dt.Read(i).District == dist && dt.Read(i).Square == s && dt.Read(i).Rooms == rm
                    && dt.Read(i).Floor == fl && dt.Read(i).Phone == ph && dt.Read(i).Price <= pr)
                {
                    str.Append($"{i+1}." + dt.Read(i)+"\n"); //добавляет сведения в конец текущего объекта StringBuilder.
                }
            }
            return str.ToString();
        }
    }
}
 