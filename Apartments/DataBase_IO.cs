using System;
using System.IO;
using System.Xml.Serialization;

namespace Apartments.DataLogic
{
    //Манипуляция с файлом-хранилищем БД
    static class DataBase_IO
    {

        public static bool Save(string filename, DataBase database, ref string ex)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataBase)); //сериализатор объектов бд в xml документы
                using (var fStream = new FileStream(filename + ".xml", FileMode.Create, FileAccess.Write)) // файловый поток, создается файл на диске с присвоенным именем и доступом к записи (using автоматически закрывает поток даже при возникновении исключения)
                {
                    serializer.Serialize(fStream, database); //сериализация базы данных в файловый поток, используется метод Serialize, в качестве параметров принимает поток, куда помещает сериализованные данные и объект, который надо сериализовать.
                }
            }
            catch(Exception e) // при возникновении исключения передаем аргументу сообщение, которое описывает это исключение, и возвращается false
            {
                ex = e.Message; 
                return false;
            }
            return true;
        }

        public static bool Load(string filename, out DataBase database, ref string ex) //десериализация
        {
            database = null; 
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(DataBase)); //сериализатор объектов бд в xml документы
                using (var fStream = new FileStream(filename + ".xml", FileMode.Open, FileAccess.Read)) // файловый поток, открывается файл на диске с присвоенным именем и доступом к чтению (using автоматически закрывает поток даже при возникновении исключения)
                {
                    database = (DataBase)serializer.Deserialize(fStream); //десериализация файла в базы данных (явно привеедение типов, так как после десериализации получаем объект типа object). Испольузуется метод Deserialize, в качестве параметра принимает поток с сериализованными данными.
                }
            }
            catch (Exception e) // при возникновении исключения передаем аргументу сообщение, которое описывает это исключение, и возвращается false
            {
                ex = e.Message;
                return false;
            }
            return true;
        }
    }
}
