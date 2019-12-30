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
            var sourceFolderName = folderFromArgs ?? Path.Combine(desktopFolderName, "objects");
            string outputFile = (args != null) && (args.Length > 1) ? args[1] : null;
            var codeStyle = Localization.Localizations.GetLocalizedCodeStyle("NAV2013", "lt-LT", true);
            codeStyle.Localization.DateFormat = "yy-MM-dd";
            codeStyle.Localization.DateTimeFormat = "yy-MM-dd HH:mm";
            codeStyle.Localization.ActiveCultureInfo = System.Globalization.CultureInfo.GetCultureInfo("lt-LT");
            Console.WriteLine(codeStyle);
            if (String.IsNullOrEmpty(outputFile))
            {
                var parser = new Parser();
                parser.Listener = myListener;
                parser.CodeStyle = codeStyle;
                parser.ParseFiles(Directory.GetFiles(sourceFolderName, "*.txt", SearchOption.AllDirectories));
            }
            else
            {                
                var application = ApplicationBuilder.ReadFromFolder(sourceFolderName, codeStyle);
                application.CodeStyle.PrintObjectReferenceAsName = true;
                application.CodeStyle.ExportToNewSyntax = true;
                application.CodeStyle.Localization.DateFormat = "yyyyMMdd\\D";
                application.CodeStyle.Localization.TimeFormat = "HHmmss\\T";
                application.CodeStyle.Localization.LocalizedYes = "true";
                application.CodeStyle.Localization.LocalizedNo = "false";
                application.CodeStyle.Localization.FieldNameExceptions = new char[0];
                application.CodeStyle.Localization.TableNameExceptions = new char[0];
                application.CodeStyle.UseQuitesInFieldList = true;
                ObjectNameCollection nameCollection = new ObjectNameCollection();
                application.CodeStyle.ObjectNameResolvers.Add(nameCollection);
                
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 396, "NoSeriesManagement");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 5200, "Employee");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024401, "PAFinUtilsABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024505, "PAGroupingManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024579, "PAIntegrationSetupABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 156, "Resource");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024400, "PASetupABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024434, "PAEmplTranslationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024404, "PAAppointmentABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024546, "PAPaymentPlaceABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024593, "PAPersonMedicalExaminationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024601, "PASecondaryPositionABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024716, "PAWorkRelationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Page, 17024798, "PAPersonListSimpleABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024808, "PAUserManagementABS");

                ApplicationWriter.WriteToFile(application, outputFile);
            }
        }
    }
}
