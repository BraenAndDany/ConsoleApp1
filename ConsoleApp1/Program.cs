using System;
using System.IO;
using System.Management;
using static System.Net.Mime.MediaTypeNames;
using System.Text;

//var path = "C:\\Users\\User\\Downloads\\work";
//int sum = 0;
//int megabite = 104857600;

//DirectoryInfo di = new DirectoryInfo(path);
//FileInfo[] fiArr = di.GetFiles();
//Console.WriteLine("The directory {0} contains the following files:", di.Name);
//foreach (FileInfo f in fiArr)
//{
//    Console.WriteLine("The size of {0} is {1} bytes.", f.Name, f.Length);
//    sum=sum + Convert.ToInt32(f.Length);
//}
//if (sum>megabite)
//{
//    foreach (FileInfo f in fiArr)
//    {
//        f.Delete();
//    }
//}
//else
//{
//    Console.WriteLine("папка весит меньше 100Мб"); 
//        }

//var path = "C:\\Users\\User\\Downloads\\work\\txt.txt";
//string id;
//// Создаем объект ManagementObjectSearcher с запросом к классу Win32_Processor
//ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

//// Получаем коллекцию объектов ManagementObject, соответствующих запросу
//ManagementObjectCollection collection = searcher.Get();

//// Перебираем все объекты в коллекции
//foreach (ManagementObject obj in collection)
//{
//    // Выводим значение свойства ProcessorId на консоль
//    Console.WriteLine("Processor ID: " + obj["ProcessorId"]);

//    id = obj["ProcessorId"].ToString();
//    if (!File.Exists(path))
//    {
//        // Create a file to write to.
//        using (StreamWriter sw = File.CreateText(path))
//        {
//            sw.WriteLine(id);
//        }
//    }
//}
//задание 4

string id;
// Создаем объект ManagementObjectSearcher с запросом к классу Win32_Processor
ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

// Получаем коллекцию объектов ManagementObject, соответствующих запросу
ManagementObjectCollection collection = searcher.Get();

var path = "C:\\Users\\User\\Downloads\\work";
int sum = 0;
int megabite = 104857600;
foreach (ManagementObject obj in collection)
{
    // Выводим значение свойства ProcessorId на консоль
    Console.WriteLine("Processor ID: " + obj["ProcessorId"]);

    id = obj["ProcessorId"].ToString();
    if (!File.Exists(path))
    {
        // Create a file to write to.
        using (StreamWriter sw = File.CreateText(path))
        {
            sw.WriteLine(id);
        }
    }
}


