using System;
using System.IO;

namespace TestProjMK0
{
    class Program
    {
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
                Console.Write("Total size - "); Console.WriteLine(disk.TotalSize);
                Console.Write("Total free space - "); Console.WriteLine(disk.TotalFreeSpace);
                Console.WriteLine("==================================");
                Console.WriteLine();
            }
        }
    }
}
