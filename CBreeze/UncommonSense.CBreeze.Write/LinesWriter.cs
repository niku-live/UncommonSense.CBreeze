using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Core;
using UncommonSense.CBreeze.Core.Code;

namespace UncommonSense.CBreeze.Write
{
    public static class LinesWriter
    {
        public static void Write(this CodeLines codeLines, CSideWriter writer)
        {
            foreach (var codeLine in codeLines)
            {
                if (string.IsNullOrEmpty(codeLine))
                    writer.InnerWriter.WriteLine();
                else
                    writer.WriteLine(FormatCodeLine(codeLine, writer));
            }
        }

        private static string FormatCodeLine(string line, CSideWriter writer)
        {
            string comment = "";
            int commentLocation = line.IndexOf("//");
            if (commentLocation >= 0)
            {
                comment = line.Substring(commentLocation);
                line = line.Substring(0, commentLocation);
            }
            line = new System.Text.RegularExpressions.Regex(@"\b(IF)\b").Replace(line, "if");
            line = new System.Text.RegularExpressions.Regex(@"\b(THEN)\b").Replace(line, "then");
            line = new System.Text.RegularExpressions.Regex(@"\b(ELSE)\b").Replace(line, "else");
            line = new System.Text.RegularExpressions.Regex(@"\b(BEGIN)\b").Replace(line, "begin");
            line = new System.Text.RegularExpressions.Regex(@"\b(END)\b").Replace(line, "end");
            line = new System.Text.RegularExpressions.Regex(@"\b(DATE2DMY)\b").Replace(line, "Date2DMY");
            line = new System.Text.RegularExpressions.Regex(@"\b(ERROR)\b").Replace(line, "Error");
            line = new System.Text.RegularExpressions.Regex(@"\b(CALCFIELDS)\b").Replace(line, "CalcFields");
            line = new System.Text.RegularExpressions.Regex(@"\b(CALCFIELD)\b").Replace(line, "CalcField");
            line = new System.Text.RegularExpressions.Regex(@"\b(CALCSUMS)\b").Replace(line, "CalcSums");
            line = new System.Text.RegularExpressions.Regex(@"\b(CASE)\b").Replace(line, "case");
            line = new System.Text.RegularExpressions.Regex(@"\b(OF)\b").Replace(line, "of");
            line = new System.Text.RegularExpressions.Regex(@"\b(EXIT)\b").Replace(line, "exit");
            line = new System.Text.RegularExpressions.Regex(@"\b(STRPOS)\b").Replace(line, "StrPos");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPYSTR)\b").Replace(line, "CopyStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPY)\b").Replace(line, "Copy");
            line = new System.Text.RegularExpressions.Regex(@"\b(TESTFIELD)\b").Replace(line, "TestField");
            line = new System.Text.RegularExpressions.Regex(@"\b(FALSE)\b").Replace(line, "false");
            line = new System.Text.RegularExpressions.Regex(@"\b(TRUE)\b").Replace(line, "true");
            line = new System.Text.RegularExpressions.Regex(@"\b(GET)\b").Replace(line, "Get");
            line = new System.Text.RegularExpressions.Regex(@"\b(USERID)\b").Replace(line, "UserId");
            line = new System.Text.RegularExpressions.Regex(@"\b(TODAY)\b").Replace(line, "Today");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISTEMPORARY)\b").Replace(line, "IsTemporary");
            line = new System.Text.RegularExpressions.Regex(@"\b(INIT)\b").Replace(line, "Init");
            line = new System.Text.RegularExpressions.Regex(@"\b(INSERT)\b").Replace(line, "Insert");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETTABLE)\b").Replace(line, "GetTable");
            line = new System.Text.RegularExpressions.Regex(@"\b(AND)\b").Replace(line, "and");
            line = new System.Text.RegularExpressions.Regex(@"\b(OR)\b").Replace(line, "or");
            line = new System.Text.RegularExpressions.Regex(@"\b(NOT)\b").Replace(line, "not");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETFILTERS)\b").Replace(line, "GetFilters");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETFILTER)\b").Replace(line, "GetFilter");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETFILTER)\b").Replace(line, "SetFilter");
            line = new System.Text.RegularExpressions.Regex(@"\b(WORKDATE)\b").Replace(line, "WorkDate");
            line = new System.Text.RegularExpressions.Regex(@"\b(READPERMISSION)\b").Replace(line, "ReadPermission");
            line = new System.Text.RegularExpressions.Regex(@"\b(WRITEPERMISSION)\b").Replace(line, "WritePermission");
            line = new System.Text.RegularExpressions.Regex(@"\b(RESET)\b").Replace(line, "Reset");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETRANGE)\b").Replace(line, "SetRange");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETFILTER)\b").Replace(line, "SetFilter");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETCURRENTKEY)\b").Replace(line, "SetCurrentKey");
            line = new System.Text.RegularExpressions.Regex(@"\b(MODIFY)\b").Replace(line, "Modify");
            line = new System.Text.RegularExpressions.Regex(@"\b(MODIFYALL)\b").Replace(line, "ModifyAll");
            line = new System.Text.RegularExpressions.Regex(@"\b(DELETE)\b").Replace(line, "Delete");
            line = new System.Text.RegularExpressions.Regex(@"\b(DELETEALL)\b").Replace(line, "DeleteAll");
            line = new System.Text.RegularExpressions.Regex(@"\b(RENAME)\b").Replace(line, "Rename");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISEMPTY)\b").Replace(line, "IsEmpty");
            line = new System.Text.RegularExpressions.Regex(@"\b(CONFIRM)\b").Replace(line, "Confirm");
            line = new System.Text.RegularExpressions.Regex(@"\b(MESSAGE)\b").Replace(line, "Message");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIND)\b").Replace(line, "Find");
            line = new System.Text.RegularExpressions.Regex(@"\b(FINDSET)\b").Replace(line, "FindSet");
            line = new System.Text.RegularExpressions.Regex(@"\b(FINDFIRST)\b").Replace(line, "FindFirst");
            line = new System.Text.RegularExpressions.Regex(@"\b(FINDLAST)\b").Replace(line, "FindLast");
            line = new System.Text.RegularExpressions.Regex(@"\b(NEXT)\b").Replace(line, "Next");
            line = new System.Text.RegularExpressions.Regex(@"\b(COUNT)\b").Replace(line, "Count");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIELDCAPTION)\b").Replace(line, "FieldCaption");
            line = new System.Text.RegularExpressions.Regex(@"\b(DO)\b").Replace(line, "do");
            line = new System.Text.RegularExpressions.Regex(@"\b(WITH)\b").Replace(line, "with");
            line = new System.Text.RegularExpressions.Regex(@"\b(FOR)\b").Replace(line, "for");
            line = new System.Text.RegularExpressions.Regex(@"\b(TO)\b").Replace(line, "to");
            line = new System.Text.RegularExpressions.Regex(@"\b(DOWNTO)\b").Replace(line, "downto");
            line = new System.Text.RegularExpressions.Regex(@"\b(REPEAT)\b").Replace(line, "repeat");
            line = new System.Text.RegularExpressions.Regex(@"\b(UNTIL)\b").Replace(line, "until");
            line = new System.Text.RegularExpressions.Regex(@"\b(MAXSTRLEN)\b").Replace(line, "MaxStrLen");
            line = new System.Text.RegularExpressions.Regex(@"\b(STRLEN)\b").Replace(line, "StrLen");
            line = new System.Text.RegularExpressions.Regex(@"\b(ARRAYLEN)\b").Replace(line, "ArrayLen");
            line = new System.Text.RegularExpressions.Regex(@"\b(MARK)\b").Replace(line, "Mark");
            line = new System.Text.RegularExpressions.Regex(@"\b(CLEARMARKS)\b").Replace(line, "ClearMarks");
            line = new System.Text.RegularExpressions.Regex(@"\b(MARKEDONLY)\b").Replace(line, "MarkedOnly");
            line = new System.Text.RegularExpressions.Regex(@"\b(RUN)\b").Replace(line, "Run");
            line = new System.Text.RegularExpressions.Regex(@"\b(RUNMODAL)\b").Replace(line, "RunModal");
            line = new System.Text.RegularExpressions.Regex(@"\b(WHILE)\b").Replace(line, "while");
            line = new System.Text.RegularExpressions.Regex(@"\b(IN)\b").Replace(line, "in");
            line = new System.Text.RegularExpressions.Regex(@"\b(CLEAR)\b").Replace(line, "Clear");
            line = new System.Text.RegularExpressions.Regex(@"\b(ASCENDING)\b").Replace(line, "Ascending");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIELDNO)\b").Replace(line, "FieldNo");
            line = new System.Text.RegularExpressions.Regex(@"\b(VALIDATE)\b").Replace(line, "Validate");
            line = new System.Text.RegularExpressions.Regex(@"\b(FILTERGROUP)\b").Replace(line, "FilterGroup");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETRECFILTER)\b").Replace(line, "SetRecFilter");
            line = new System.Text.RegularExpressions.Regex(@"\b(TIME)\b").Replace(line, "Time");
            line = new System.Text.RegularExpressions.Regex(@"\b(TABLECAPTION)\b").Replace(line, "TableCaption");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIELDERROR)\b").Replace(line, "FieldError");
            line = new System.Text.RegularExpressions.Regex(@"\b(STRSUBSTNO)\b").Replace(line, "StrSubstNo");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETTABLEVIEW)\b").Replace(line, "SetTableView");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETRECORD)\b").Replace(line, "SetRecord");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETRECORD)\b").Replace(line, "GetRecord");
            line = new System.Text.RegularExpressions.Regex(@"\b(LOOKUPMODE)\b").Replace(line, "LookupMode");
            line = new System.Text.RegularExpressions.Regex(@"\b(CALCDATE)\b").Replace(line, "CalcDate");
            line = new System.Text.RegularExpressions.Regex(@"\b(LOCKTABLE)\b").Replace(line, "LockTable");
            line = new System.Text.RegularExpressions.Regex(@"\b(INCSTR)\b").Replace(line, "IncStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(ROUND)\b").Replace(line, "Round");
            line = new System.Text.RegularExpressions.Regex(@"\b(FORMAT)\b").Replace(line, "Format");
            line = new System.Text.RegularExpressions.Regex(@"\b(CURRENTDATETIME)\b").Replace(line, "CurrentDateTime");
            line = new System.Text.RegularExpressions.Regex(@"\b(CREATEDATETIME)\b").Replace(line, "CreateDateTime");
            line = new System.Text.RegularExpressions.Regex(@"\b(COMMIT)\b").Replace(line, "Commit");
            line = new System.Text.RegularExpressions.Regex(@"\b(DT2DATE)\b").Replace(line, "DT2Date");
            line = new System.Text.RegularExpressions.Regex(@"\b(DT2TIME)\b").Replace(line, "DT2Time");
            line = new System.Text.RegularExpressions.Regex(@"\b(CONVERTSTR)\b").Replace(line, "ConvertStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(ERASE)\b").Replace(line, "Erase");
            line = new System.Text.RegularExpressions.Regex(@"\b(DMY2DATE)\b").Replace(line, "DMY2Date");
            line = new System.Text.RegularExpressions.Regex(@"\b(DWY2DATE)\b").Replace(line, "DWY2Date");
            line = new System.Text.RegularExpressions.Regex(@"\b(DATE2DMY)\b").Replace(line, "Date2DMY");
            line = new System.Text.RegularExpressions.Regex(@"\b(DATE2DWY)\b").Replace(line, "Date2DWY");
            line = new System.Text.RegularExpressions.Regex(@"\b(UPPERCASE)\b").Replace(line, "UpperCase");
            line = new System.Text.RegularExpressions.Regex(@"\b(LOWERCASE)\b").Replace(line, "LowerCase");
            line = new System.Text.RegularExpressions.Regex(@"\b(EVALUATE)\b").Replace(line, "Evaluate");
            line = new System.Text.RegularExpressions.Regex(@"\b(USEREQUESTPAGE)\b").Replace(line, "UseRequestPage");
            line = new System.Text.RegularExpressions.Regex(@"\b(CREATEINSTREAM)\b").Replace(line, "CreateInStream");
            line = new System.Text.RegularExpressions.Regex(@"\b(CREATEOUTSTREAM)\b").Replace(line, "CreateOutStream");
            line = new System.Text.RegularExpressions.Regex(@"\b(OPEN)\b").Replace(line, "Open");
            line = new System.Text.RegularExpressions.Regex(@"\b(CLOSE)\b").Replace(line, "Close");
            line = new System.Text.RegularExpressions.Regex(@"\b(READTEXT)\b").Replace(line, "ReadText");
            line = new System.Text.RegularExpressions.Regex(@"\b(EXISTS)\b").Replace(line, "Exists");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETTABLE)\b").Replace(line, "SetTable");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPYFILTERS)\b").Replace(line, "CopyFilters");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPYFILTER)\b").Replace(line, "CopyFilter");
            line = new System.Text.RegularExpressions.Regex(@"\b(UPDATE)\b").Replace(line, "Update");
            line = new System.Text.RegularExpressions.Regex(@"\b(TRANSFERFIELDS)\b").Replace(line, "TransferFields");
            line = new System.Text.RegularExpressions.Regex(@"\b(ABS)\b").Replace(line, "Abs");
            line = new System.Text.RegularExpressions.Regex(@"\b(MOD)\b").Replace(line, "mod");
            line = new System.Text.RegularExpressions.Regex(@"\b(DIV)\b").Replace(line, "div");
            line = new System.Text.RegularExpressions.Regex(@"\b(HASVALUE)\b").Replace(line, "HasValue");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETRANGEMAX)\b").Replace(line, "GetRangeMax");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETRANGEMIN)\b").Replace(line, "GetRangeMin");
            line = new System.Text.RegularExpressions.Regex(@"\b(GUIALLOWED)\b").Replace(line, "GuiAllowed");
            line = new System.Text.RegularExpressions.Regex(@"\b(SELECTSTR)\b").Replace(line, "SelectStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(OPTIONSTRING)\b").Replace(line, "OptionString");
            line = new System.Text.RegularExpressions.Regex(@"\b(DELCHR)\b").Replace(line, "DelChr");
            line = new System.Text.RegularExpressions.Regex(@"\b(DELSTR)\b").Replace(line, "DelStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(PADSTR)\b").Replace(line, "PadStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPYSTREAM)\b").Replace(line, "CopyStream");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETAUTOCALCFIELDS)\b").Replace(line, "SetAutoCalcFields");
            line = new System.Text.RegularExpressions.Regex(@"\b(WRITETEXT)\b").Replace(line, "WriteText");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETVIEW)\b").Replace(line, "GetView");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETVIEW)\b").Replace(line, "SetView");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETPOSITION)\b").Replace(line, "GetPosition");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETPOSITION)\b").Replace(line, "SetPosition");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISNULLGUID)\b").Replace(line, "IsNullGuid");
            line = new System.Text.RegularExpressions.Regex(@"\b(SKIP)\b").Replace(line, "Skip");
            line = new System.Text.RegularExpressions.Regex(@"\b(COMPRESSARRAY)\b").Replace(line, "CompressArray");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIELDINDEX)\b").Replace(line, "FieldIndex");
            line = new System.Text.RegularExpressions.Regex(@"\b(VALUE)\b").Replace(line, "Value");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIELD)\b").Replace(line, "Field");
            line = new System.Text.RegularExpressions.Regex(@"\b(FIELDCOUNT)\b").Replace(line, "FieldCount");
            line = new System.Text.RegularExpressions.Regex(@"\b(KEYINDEX)\b").Replace(line, "KeyIndex");
            line = new System.Text.RegularExpressions.Regex(@"\b(KEYCOUNT)\b").Replace(line, "KeyCount");
            line = new System.Text.RegularExpressions.Regex(@"\b(GLOBALLANGUAGE)\b").Replace(line, "GlobalLanguage");
            line = new System.Text.RegularExpressions.Regex(@"\b(INSSTR)\b").Replace(line, "InsStr");
            line = new System.Text.RegularExpressions.Regex(@"\b(RECORD)\b").Replace(line, "Record");
            line = new System.Text.RegularExpressions.Regex(@"\b(IMPORT)\b").Replace(line, "Import");
            line = new System.Text.RegularExpressions.Regex(@"\b(EXPORT)\b").Replace(line, "Export");
            line = new System.Text.RegularExpressions.Regex(@"\b(DOWNLOAD)\b").Replace(line, "Download");
            line = new System.Text.RegularExpressions.Regex(@"\b(DOWNLOADFROMSTREAM)\b").Replace(line, "DownloadFromStream");
            line = new System.Text.RegularExpressions.Regex(@"\b(UPLOAD)\b").Replace(line, "Upload");
            line = new System.Text.RegularExpressions.Regex(@"\b(UPLOADTOSTREAM)\b").Replace(line, "UploadToStream");
            line = new System.Text.RegularExpressions.Regex(@"\b(BREAK)\b").Replace(line, "Break");
            line = new System.Text.RegularExpressions.Regex(@"\b(USERSECURITYID)\b").Replace(line, "UserSecurityId");
            line = new System.Text.RegularExpressions.Regex(@"\b(CURRENTCLIENTTYPE)\b").Replace(line, "CurrentClientType");
            line = new System.Text.RegularExpressions.Regex(@"\b(HYPERLINK)\b").Replace(line, "HyperLink");
            line = new System.Text.RegularExpressions.Regex(@"\b(COMPANYNAME)\b").Replace(line, "CompanyName");
            line = new System.Text.RegularExpressions.Regex(@"\b(SERVICEINSTANCEID)\b").Replace(line, "ServiceInstanceId");
            line = new System.Text.RegularExpressions.Regex(@"\b(SESSIONID)\b").Replace(line, "SessionId");
            line = new System.Text.RegularExpressions.Regex(@"\b(CREATETEMPFILE)\b").Replace(line, "CreateTempFile");
            line = new System.Text.RegularExpressions.Regex(@"\b(NAME)\b").Replace(line, "Name");
            line = new System.Text.RegularExpressions.Regex(@"\b(LENGTH)\b").Replace(line, "Length");
            line = new System.Text.RegularExpressions.Regex(@"\b(NUMBER)\b").Replace(line, "Number");
            line = new System.Text.RegularExpressions.Regex(@"\b(EDITABLE)\b").Replace(line, "Editable");
            line = new System.Text.RegularExpressions.Regex(@"\b(STRMENU)\b").Replace(line, "StrMenu");
            line = new System.Text.RegularExpressions.Regex(@"\b(OPTIONCAPTION)\b").Replace(line, "OptionCaption");
            line = new System.Text.RegularExpressions.Regex(@"\b(ADDTEXT)\b").Replace(line, "AddText");
            line = new System.Text.RegularExpressions.Regex(@"\b(POWER)\b").Replace(line, "Power");
            line = new System.Text.RegularExpressions.Regex(@"\b(RECORDLEVELLOCKING)\b").Replace(line, "RecordLevelLocking");
            line = new System.Text.RegularExpressions.Regex(@"\b(CHANGECOMPANY)\b").Replace(line, "ChangeCompany");
            line = new System.Text.RegularExpressions.Regex(@"\b(READ)\b").Replace(line, "Read");
            line = new System.Text.RegularExpressions.Regex(@"\b(ADDRECORD)\b").Replace(line, "AddRecord");
            line = new System.Text.RegularExpressions.Regex(@"\b(ADDFIELD)\b").Replace(line, "AddField");
            line = new System.Text.RegularExpressions.Regex(@"\b(CAPTION)\b").Replace(line, "Caption");
            line = new System.Text.RegularExpressions.Regex(@"\b(CLEARALL)\b").Replace(line, "ClearAll");
            line = new System.Text.RegularExpressions.Regex(@"\b(SETASCENDING)\b").Replace(line, "SetAscending");
            line = new System.Text.RegularExpressions.Regex(@"\b(TABLENAME)\b").Replace(line, "TableName");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPYARRAY)\b").Replace(line, "CopyArray");
            line = new System.Text.RegularExpressions.Regex(@"\b(GETLASTERRORTEXT)\b").Replace(line, "GetLastErrorText");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISBOOLEAN)\b").Replace(line, "IsBoolean");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISCODE)\b").Replace(line, "IsCode");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISTEXT)\b").Replace(line, "IsText");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISDATE)\b").Replace(line, "IsDate");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISDATETIME)\b").Replace(line, "IsDateTime");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISDECIMAL)\b").Replace(line, "IsDecimal");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISINTEGER)\b").Replace(line, "IsInteger");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISCODEUNIT)\b").Replace(line, "IsCodeunit");
            line = new System.Text.RegularExpressions.Regex(@"\b(ISDOTNET)\b").Replace(line, "IsDotNet");
            line = new System.Text.RegularExpressions.Regex(@"\b(BINDSUBSCRIPTION)\b").Replace(line, "BindSubscription");
            line = new System.Text.RegularExpressions.Regex(@"\b(UNBINDSUBSCRIPTION)\b").Replace(line, "UnbindSubscription");
            line = new System.Text.RegularExpressions.Regex(@"\b(CREATEGUID)\b").Replace(line, "CreateGuid");
            line = new System.Text.RegularExpressions.Regex(@"\b(SAVEASPDF)\b").Replace(line, "SaveAsPdf");
            return $"{line}{comment}";
        }
        
    }
}
