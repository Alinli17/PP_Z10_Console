using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_Z10_
{
    class Program
    {
        static void info(DirectoryInfo directory, FileInfo K1_file1, FileInfo K1_file2, FileInfo K2_file1)
        {
            Console.WriteLine("4.(8.) Директория '{0}'", directory.Name);
            Console.WriteLine($"       Полный путь к файлу/каталогу: {directory.FullName}\n" +
                                $"       Имя файла/каталога: {directory.Name}\n" +
                                $"       Корневой каталог: {directory.Root}\n" +
                                $"       Время создания файла/каталога: {directory.CreationTime}\n" +
                                $"       Ассоциативный атрибут: {directory.Attributes}" +"\n");
            Console.WriteLine("       Файл 't1.txt'");
            Console.WriteLine($"       Полный путь к файлу/каталогу: {K1_file1.FullName}\n" +
                                $"       Имя файла/каталога: {K1_file1.Name}\n" +
                                $"       Расширение файла:{K1_file1.Extension}\n" +
                                $"       Время создания файла/каталога: {K1_file1.CreationTime}\n" +
                                $"       Ассоциативный атрибут: {K1_file1.Attributes}"+ "\n");
            Console.WriteLine("       Файл 't2.txt'");
            Console.WriteLine($"       Полный путь к файлу/каталогу: {K1_file2.FullName}\n" +
                                $"       Имя файла/каталога: {K1_file2.Name}\n" +
                                $"       Расширение файла:{K1_file2.Extension}\n" +
                                $"       Время создания файла/каталога: {K1_file2.CreationTime}\n" +
                                $"       Ассоциативный атрибут: {K1_file2.Attributes}"+"\n");
            Console.WriteLine("       Файл 't3.txt'");
            Console.WriteLine($"       Полный путь к файлу/каталогу: {K2_file1.FullName}\n" +
                                $"       Имя файла/каталога: {K2_file1.Name}\n" +
                                $"       Расширение файла:{K2_file1.Extension}\n" +
                                $"       Время создания файла/каталога: {K2_file1.CreationTime}\n" +
                                $"       Ассоциативный атрибут: {K2_file1.Attributes}"+"\n");
        }
        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo(@"C:\temp");
            directory.Create();
            Console.WriteLine("       Папка 'temp' создана"+"\n");
            directory.CreateSubdirectory("K1");
            Console.WriteLine("  1.   Папка 'K1' создана");
            directory.CreateSubdirectory("K2");
            Console.WriteLine("       Папка 'K2' создана"+"\n");
            FileInfo K1_file1 = new FileInfo(@"C:\temp\K1\t1.txt");
            Console.WriteLine("  2.a) Файл 't1.txt' создан");
            using (StreamWriter sw = K1_file1.CreateText())
            {
                sw.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            }
            Console.WriteLine("       Строка записала в файл 't1.txt'"+ "\n");
            FileInfo K1_file2 = new FileInfo(@"C:\temp\K1\t2.txt");
            Console.WriteLine("  2.b) Файл 't2.txt' создан");
            using (StreamWriter sw = K1_file2.CreateText())
            {
                sw.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г.Энгельс");
            }
            Console.WriteLine("       Строка записана в файл 't2.txt'"+"\n");
            FileInfo K2_file1 = new FileInfo(@"C:\temp\K2\t3.txt");
            Console.WriteLine("  3.   Файл 't3.txt' создан");
            string str = "", str2 = "";
            using (StreamReader sr = K1_file1.OpenText())
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    str += s;
                }
            }
            using (StreamReader sr = K1_file2.OpenText())
            {
                var s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    str2 += s;
                }
            }
            using (StreamWriter sw = K2_file1.CreateText())
            {
                sw.WriteLine(str + "\n" + str2);
            }
            Console.WriteLine("       Строки записаны в файл 't3.txt'"+ "\n");
            info(directory, K1_file1, K1_file2, K2_file1);
            try
            {
                File.Move(@"C:\temp\K1\t2.txt", @"C:\temp\K2\t2.txt");
                Console.WriteLine("  5.   Файл 't2.txt' перенесён в папку 'K2'"+"\n");
                K1_file1.CopyTo(@"C:\temp\K2\t1.txt");
                Console.WriteLine("  6.   Файл 't1.txt' скопирован в папку 'K2'"+"\n");
                Directory.Move(@"C:\temp\K2", @"C:\temp\All");
                Console.WriteLine("  7.   Папка 'K2' переименована в 'All'");
                Directory.Delete(@"C:\temp\K1", true);
                Console.WriteLine("       Папка 'K1' удалена"+"\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            DirectoryInfo AllDirectory = new DirectoryInfo(@"C:\temp\All");
            info(AllDirectory, K1_file1, K1_file2, K2_file1);
            Console.ReadLine();
        }
    }
}
