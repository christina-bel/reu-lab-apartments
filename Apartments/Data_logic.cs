using System;

namespace Apartments.DataLogic
{
   class Data_logic // Слой данных
    {
        private DataBase db;
        public Data_logic(DataBase db) // конструктор присваивания слоя данных с определнной баззой данных
        {
            this.db = db;
        }
        public void Create(Appart a) // добавления экземпляра квартиры в базу данных
        {
            db.List.Add(a);
        }
        public void Delete(int id) // удаление экземпляра квартиры из базы данных
        {
            db.List.RemoveAt(id);
        }
        public void Update(int id, Appart a) //обновление записи
        {
            db[id] = a; // (используя индексатор)
        }

        public int CountRecords() // возращает число элементов в базе данных
        {
            return db.List.Count;
        }
        public Appart Read(int id) // возращает элемент базы данных (используя индексатор)
        {
            return db[id];
        }

        public DataBase Read() // возращает элементы базы данных 
        {
            return db;
        }

        public bool Save(string filename, ref string e) // сохранить базу данных
        {
            return DataBase_IO.Save(filename, db, ref e);
        }

        public bool Load(string filename, ref string e) // загрузить базу данных
        {
            return DataBase_IO.Load(filename, out db, ref e);
        }
    }
}
 