using System;
using System.IO;
using System.Management;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Reflection.PortableExecutable;
using Microsoft.Win32;
using System.Data;

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

//string id;
//// Создаем объект ManagementObjectSearcher с запросом к классу Win32_Processor
//ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

//// Получаем коллекцию объектов ManagementObject, соответствующих запросу
//ManagementObjectCollection collection = searcher.Get();

//var path = "C:\\Users\\User\\Downloads\\work\\txt.txt";
//// асинхронное чтение

//foreach (ManagementObject obj in collection)
//{
//    // Выводим значение свойства ProcessorId на консоль
//    Console.WriteLine("Processor ID: " + obj["ProcessorId"]);

//    id = obj["ProcessorId"].ToString();
//    using (StreamReader reader = new StreamReader(path))
//{
//    string text = await reader.ReadToEndAsync();
//    if(text == id)
//    {
//        Console.WriteLine("совпадение");
//    }
//    else
//    {
//        Console.WriteLine("Ошибка! Несовпадение идентификаторов");
//    }
//}
//}

//задание 5
//var path = "C:\\Users\\User\\Downloads\\work\\txt.txt";
//string id;
//ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
//ManagementObjectCollection collection = searcher.Get();
//foreach (ManagementObject obj in collection)
//{
//    // Выводим значение свойства ProcessorId на консоль

//    id = obj["ProcessorId"].ToString();
//    RegistryKey software = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
//    if (software != null)
//    {
//        RegistryKey proccesor_id = software.CreateSubKey("proccesor_id");
//        proccesor_id.SetValue("proc_id", id);
//        string proccesor = proccesor_id.GetValue("proc_id").ToString();

//        Console.WriteLine("proc_id = "+proccesor);
//        proccesor_id.Close();
//        software.Close();
//    }


//}
//задание 6
//string id;
//ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
//ManagementObjectCollection collection = searcher.Get();
//var path = "C:\\Users\\User\\Downloads\\work\\txt.txt";
//foreach (ManagementObject obj in collection)
//{
//    id = obj["ProcessorId"].ToString();
//    RegistryKey software = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
//    RegistryKey proccesor  = software.OpenSubKey("proccesor_id");
//    if (software != null)
//    {
//        string proc_id = proccesor.GetValue("proc_id").ToString();
//        if (proc_id==id)
//        {
//            Console.WriteLine("совпадение");
//        }
//        else
//        {
//            Console.WriteLine("Ошибка");
//            break;

//        }
//        software.Close();
//    }
//}

//Задание 7
for (int num=0; num<2;)
{
RegistryKey currentUser = Registry.CurrentUser;
RegistryKey SubKey= RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default).OpenSubKey(@"");
Console.WriteLine();
Console.WriteLine("Введите что хотите сделать");
Console.WriteLine("1. Переход по разделам");
Console.WriteLine("2. Возврат к главному разделу");
Console.WriteLine("3. Посмотреть элементы раздела");
Console.WriteLine("4. Посмотреть имена и значения в разделе");
int number_func = Convert.ToInt32(Console.ReadLine());
string pod; 

    switch (number_func)
    {
        case 1:
            for (int i = 0; i < 2;)
            {

                Console.WriteLine("Введите имя подраздела");
                string name_pr = Console.ReadLine();

                foreach (string sub in SubKey.GetSubKeyNames())
                {
                    if (name_pr == sub)
                    {
                        SubKey = SubKey.OpenSubKey("sub");
                        i = 2;
                    }
                }
            }
            break;
        case 2:
            SubKey = currentUser;
            break;
        case 3:
            foreach (string sub in SubKey.GetSubKeyNames())
            {
                Console.WriteLine(sub);
            }
            break;
        case 4:
            using (RegistryKey root = Registry.CurrentUser.OpenSubKey("Console"))
            {
                foreach (string name in root.GetValueNames().OrderBy(x => x))
                {
                    object value = root.GetValue(name);
                    RegistryValueKind kind = root.GetValueKind(name);
                    string valueString = (kind == RegistryValueKind.DWord) ? $"0x{((int)value).ToString("X2").ToLower().PadLeft(8, '0')} ({(uint)(int)value})" : value.ToString();

                    Console.WriteLine($"{name,-25} {valueString}");
                }
            }
            number_func = 0;
            break;
    }

}


public enum RegistryValueKindNative
{
    NONE = -1,
    UNKNOWN = 0,
    REG_SZ = 1,
    REG_EXPAND_SZ = 2,
    REG_BINARY = 3,
    REG_DWORD = 4,
    REG_MULTI_SZ = 7,
    REG_QWORD = 11
}