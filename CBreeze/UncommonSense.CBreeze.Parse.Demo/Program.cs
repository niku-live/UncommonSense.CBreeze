using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

            var parser = new Parser();
            parser.Listener = myListener;
            parser.FileEncoding = Encoding.GetEncoding(775);
            parser.ParseFiles(Directory.GetFiles(sourceFolderName, "*.txt", SearchOption.AllDirectories));
        }
    }
}
