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
                codeStyle.ExportToNewSyntax = true;
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

                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 10, "Type Helper");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 12, "Gen. Jnl.-Post Line");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 13, "Gen. Jnl.-Post Batch");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 41, "TextManagement");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 42, "CaptionManagement");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 396, "NoSeriesManagement");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 408, "DimensionManagement");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 418, "User Management");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 419, "File Management");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 701, "Data Type Management");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 1291, "DotNet Exception Handler");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 1299, "Web Request Helper");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 5370, "Excel Buffer Dialog Management");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 9801, "Identity Management");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 4, "Currency");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 8, "Language");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 9, "Country/Region");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17, "G/L Entry");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 18, "Customer");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 15, "G/L Account");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 23, "Vendor");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 45, "G/L Register");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 79, "Company Information");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 80, "Gen. Journal Template");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 81, "Gen. Journal Line");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 91, "User Setup");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 92, "Customer Posting Group");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 93, "Vendor Posting Group");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 98, "General Ledger Setup");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 156, "Resource");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 225, "Post Code");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 232, "Gen. Journal Batch");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 270, "Bank Account");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 288, "Vendor Bank Account");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 308, "No. Series");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 309, "No. Series Line");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 348, "Dimension");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 349, "Dimension Value");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 352, "Default Dimension");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 353, "Dimension ID Buffer");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 360, "Dimension Buffer");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 365, "Format Address");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 472, "Job Queue Entry");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 480, "Dimension Set Entry");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 823, "Name/Value Buffer");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 1261, "Service Password");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 5200, "Employee");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 5600, "Fixed Asset");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 5714, "Responsibility Center");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 9182, "Generic Chart Y-Axis");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 99008535, "TempBlob");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000001, "Object");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000004, "Permission Set");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000005, "Permission");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000006, "Company");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000007, "Date");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000026, "Integer");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000038, "AllObj");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000041, "Field");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000048, "Database");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000053, "Access Control");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000058, "AllObjWithCaption");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000069, "Add-in");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000076, "Web Service");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000078, "Chart");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000110, "Active Session");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000111, "Session Event");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000120, "User");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 2000000140, "Event Subscription");
                nameCollection.RegisterObjectName(Common.ObjectType.Page, 480, "Edit Dimension Set Entries");
                nameCollection.RegisterObjectName(Common.ObjectType.Page, 537, "Dimension Values");
                nameCollection.RegisterObjectName(Common.ObjectType.Report, 9802, "Copy Permission Set");

                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024401, "PAFinUtilsABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024403, "PAUtilsABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024428, "PAUnusedHolRemManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024431, "PAGlobalFilterManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024457, "PAFormulaUtilsABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024460, "PAIntegrationManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024462, "PAColourManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024505, "PAGroupingManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024584, "PANameConstructorABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024663, "PAEmployeeStatusManagementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Codeunit, 17024808, "PAUserManagementABS");                
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024400, "PASetupABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024402, "PAPersonABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024404, "PAAppointmentABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024406, "PAPostCodeExtensionABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024409, "PAFormerEmploymentABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024411, "PAPersonRelativeABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024414, "PAEmplArmyRegistrationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024434, "PAEmplTranslationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024445, "PAPersonEducationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024446, "PAPersonForeignLanguageABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024447, "PAPersonPenaltyEcouragementABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024448, "PAEmplTrainingABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024482, "PAEmplAbsenceABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024488, "PASubstitutionABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024493, "PAPersonDocumentABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024512, "PAPersonDisabilityABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024513, "PAPersonRelAddTaxExemptABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024514, "PAEmplArmyRegistrationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024530, "PAPermanentAddDedABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024536, "PASumJournalLineABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024546, "PAPaymentPlaceABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024553, "PAEmplIndividualDataABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024579, "PAIntegrationSetupABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024593, "PAPersonMedicalExaminationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024601, "PASecondaryPositionABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024713, "PATableFieldHistoryABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024714, "PATableOptionFieldStoreABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024715, "PAPersonTradeUnionABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Table, 17024716, "PAWorkRelationABS");
                nameCollection.RegisterObjectName(Common.ObjectType.Page, 17024798, "PAPersonListSimpleABS");

                FieldTypeMappingCollection fieldTypeMappingCollection = new FieldTypeMappingCollection();
                application.CodeStyle.FieldTypeResolvers.Add(fieldTypeMappingCollection);
                fieldTypeMappingCollection.RegisterTableFields("PATableFieldHistoryABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Table ID", Common.TableFieldType.Integer },
                    { "Field ID", Common.TableFieldType.Integer }
                });
                fieldTypeMappingCollection.RegisterTableFields("PAEmailIntegrationHistoryABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Journal Code", Common.TableFieldType.Code },
                    { "Already Sent", Common.TableFieldType.Boolean },
                });
                fieldTypeMappingCollection.RegisterTableFields("PAActivityCodeABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Show", Common.TableFieldType.Boolean },
                    { "Activity Type", Common.TableFieldType.Option },
                });
                fieldTypeMappingCollection.RegisterTableFields("PAWorkScheduleNameABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Confirmed", Common.TableFieldType.Boolean },
                });
                fieldTypeMappingCollection.RegisterTableFields("PAWorkRelationABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Employee No.", Common.TableFieldType.Code },
                    { "Work Relation Type", Common.TableFieldType.Option }
                });
                fieldTypeMappingCollection.RegisterTableFields("PAAnalysisColumnSubgroupABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Type", Common.TableFieldType.Option },
                });
                fieldTypeMappingCollection.RegisterTableFields("PAIndividualDataCodeABS", new Dictionary<string, Common.TableFieldType>()
                {
                    { "Type", Common.TableFieldType.Option },
                });
                ApplicationWriter.WriteToFile(application, outputFile);
            }
        }
    }
}
