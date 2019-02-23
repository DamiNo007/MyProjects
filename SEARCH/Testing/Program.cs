using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Testing
{
    class Program
    {  
        public static bool flag = false;
        public static string file_name;
        public static int count = 0;
        public static string user_answer;
        public static string extention;


        public static void Search_in(DirectoryInfo dir)
        {

                FileSystemInfo[] files = dir.GetFiles();
                FileSystemInfo[] directories = dir.GetDirectories();

            foreach (FileSystemInfo file in files)
            {
                if (file.Name == file_name)
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("File: ");
                    Console.ResetColor();
                    Console.WriteLine(file);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Found in: ");
                    Console.ResetColor();
                    Console.WriteLine(file.FullName);
                    Console.WriteLine();
                    flag = true;
                    count++;
                    break;
                }
            }

                foreach (DirectoryInfo d in directories)
                {
                    try
                    {
                    Search_in(d);
                    }
                    catch (UnauthorizedAccessException)
                    {
                    continue;
                    }    
                }

        }

        public static void FileExtentions(DirectoryInfo dir)
        {
            FileSystemInfo[] files = dir.GetFiles(extention);
            FileSystemInfo[] directories = dir.GetDirectories();
            Console.ResetColor();
            foreach (FileSystemInfo file in files)
            {
                    Console.WriteLine(file);
                    count++;
            }

            foreach (DirectoryInfo d in directories)
            {
                try
                {
                    FileExtentions(d);
                }
                catch (UnauthorizedAccessException)
                {
                    continue;
                }
            }
    }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("ENTER THE PATH: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string path = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("1. Find a file;");
            Console.WriteLine("2. Get file extentions;");

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write("1 or 2: ");
            DirectoryInfo d = new DirectoryInfo(path);

            Console.ForegroundColor = ConsoleColor.Blue;
            user_answer = Console.ReadLine();

            if (user_answer == "2")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("ENTER FILE EXTENTION: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                extention = Console.ReadLine();
                FileExtentions(d);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("Total: ");
                Console.ResetColor();
                Console.WriteLine(count);
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("ENTER THE NAME OF THE FILE: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                file_name = Console.ReadLine();
                Console.ResetColor();
                Search_in(d);

                if (flag == false)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("NOT FOUND!");
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(count + " FILES FOUND!!!");
                }
            }
            Console.ReadKey();
        }
    }
}
