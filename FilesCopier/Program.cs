using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FilesCopier
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<string> copiedfiles = BackupFiles(@"D:\source dir\", @"d:\destination dir\");
            Console.WriteLine("{0} files copied : ",copiedfiles.Count);
            foreach (string copiedfile in copiedfiles)
            {
                Console.WriteLine(copiedfile);
            }
            Console.Read();
        }
        static List<string> GetFiles(string rootdirectory,string searchpattern)
        {
            string[] files = Directory.GetFiles(rootdirectory,searchpattern,SearchOption.AllDirectories);

            return files.ToList();
        }
        static List<string> BackupFiles(string srcpath, string dstpath)
        {
            
            List<string> sourcefileslist = GetFiles(srcpath, "*");
            List<string> copiedfileslist = new List<string>();
            foreach (string file in sourcefileslist)
            {

                string destfile = Path.Combine(new string[] { dstpath, Path.GetDirectoryName(file).Substring(srcpath.Length), Path.GetFileName(file) });

                if (!File.Exists(destfile))
                {
                    try
                    {
                        Directory.CreateDirectory(Path.GetDirectoryName(destfile));
                        File.Copy(file, destfile, true);
                        copiedfileslist.Add(destfile);
                    }
                    catch (Exception ex )
                    {
                        Console.WriteLine(ex.Message);
                    }
                   
                }

            }
            return copiedfileslist;
        }
    }
}
