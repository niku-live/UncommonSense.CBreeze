using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Common;
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
                var codeStyle = ApplicationCodeStyle.CreateNav5CodeStyle();
                codeStyle.Localization.DateFormat = "yy.MM.dd";
                codeStyle.Localization.TimeFormat = @"HH\:mm\:ss";
                codeStyle.UseEnclosedTimeFormat = true;
                codeStyle.CustomPropertyMappings.AddMap("Data", "Date");
                codeStyle.CustomPropertyMappings.AddMap("Laikas", "Time");
                codeStyle.CustomPropertyMappings.AddMap("Versijos", "Version List");
                codeStyle.CustomPropertyMappings.AddMap("Pakeista", "Modified");
                var blobTypeMap = codeStyle.GetEnumMapping<Core.Property.Type.BlobSubType>();
                var blobTypeTextMap = codeStyle.GetEnumMapping<Core.Property.Type.BlobSubType>(true);
                blobTypeMap.AddMap("Paveikslėlis", "Bitmap");
                blobTypeTextMap.AddMap("Paveikslėlis", "Bitmap");
                blobTypeMap.AddMap("Memolaukas", "Memo");
                blobTypeTextMap.AddMap("Memo laukas", "Memo");
                blobTypeMap.AddMap("Vartotojoapibr", "UserDefined");
                blobTypeTextMap.AddMap("Vartotojo apibr.", "User-Defined");

                codeStyle.Localization.DecimalFormat = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.Clone() as System.Globalization.NumberFormatInfo;
                codeStyle.Localization.DecimalFormat.NumberGroupSeparator = ".";                
                codeStyle.Localization.LocalizedYes = "Taip";
                codeStyle.Localization.LocalizedNo = "Ne";
                codeStyle.EmptyCaptionIsNotQuited = true;
                codeStyle.NoVariableIds = true;
                codeStyle.NonAnsiLettersAllowedInTableName = true;
                codeStyle.TableNameExceptions = new [] { '-' };
                var application = ApplicationBuilder.ReadFromFolder(sourceFolderName, encoding, codeStyle);
                ApplicationWriter.WriteToFile(application, outputFile, encoding);
            }
        }
    }
}
