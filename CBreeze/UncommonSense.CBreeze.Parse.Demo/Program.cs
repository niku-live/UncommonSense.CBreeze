using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Read;
using UncommonSense.CBreeze.Write;

namespace UncommonSense.CBreeze.Parse.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var myListener = new MyListener();
            var desktopFolderName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderFromArgs = (args != null) && (args.Length > 0) ? args[0] : null;
            var sourceFolderName = folderFromArgs ?? Path.Combine(desktopFolderName, "be");
            string outputFile = (args != null) && (args.Length > 1) ? args[1] : null;

            if (String.IsNullOrEmpty(outputFile))
            {
                var parser = new Parser();
                parser.Listener = myListener;
                parser.FileEncoding = Encoding.GetEncoding(775);
                parser.ParseFiles(Directory.GetFiles(sourceFolderName, "*.txt", SearchOption.AllDirectories));
            }
            else
            {
                var encoding = Encoding.GetEncoding(775);
                var application = ApplicationBuilder.ReadFromFolder(sourceFolderName, encoding);
                ApplicationWriter.WriteToFile(application, outputFile, encoding);
            }
        }
    }
}
