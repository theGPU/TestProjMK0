using System;
using System.IO;

namespace TestProjMK0
{
    class Program
    {
        static class BytesConvertet
        {
            public static float BytesToGB(long bytesCount)
            {
                return (float)bytesCount / 1073741824;
            }
            public static float BytesToMB(long bytesCount)
            {
                return (float)bytesCount / 1048576;
            }
            public static float BytesToKB(long bytesCount)
            {
                return (float)bytesCount / 1024;
            }
        }

        delegate float ConvertToSize(long x);
        static void PrintDiskSpace(string prefix, long bytes)
        {
            string postfix;
            ConvertToSize operation;
            if (bytes < 1048576)
            {
                postfix = " KB ";
                operation = BytesConvertet.BytesToKB;
            } else if (bytes < 1073741824)
            {
                postfix = " MB ";
                operation = BytesConvertet.BytesToMB;
            } else
            {
                postfix = " GB ";
                operation = BytesConvertet.BytesToGB;
            }

            Console.Write(prefix + postfix + "- "); Console.WriteLine(operation(bytes));
        }

        static void PrintArray(string prefix, string[] array)
        {
            Console.WriteLine("=================="+ prefix +"================");
            foreach (string str in array)
                Console.WriteLine(str);
        }
        static void Main(string[] args)
        {
            DriveInfo[] disks = DriveInfo.GetDrives();
            
            foreach (DriveInfo disk in disks)
            {
                Console.WriteLine("==================================");
                Console.Write("Информация о диске - "); Console.WriteLine(disk.VolumeLabel);
                Console.Write("Name - "); Console.WriteLine(disk.Name);
                Console.Write("File system - "); Console.WriteLine(disk.DriveFormat);
                Console.Write("Drive Type - "); Console.WriteLine(disk.DriveType);

                Console.WriteLine("==================================");

                PrintDiskSpace("Total size", disk.TotalSize);
                PrintDiskSpace("Total free space", disk.TotalFreeSpace);

                PrintArray("Директории", Directory.GetDirectories(disk.Name));
                PrintArray("Файлы", Directory.GetFiles(disk.Name));
                Console.WriteLine("==================================");
                Console.WriteLine();
            }
        }
    }
}
