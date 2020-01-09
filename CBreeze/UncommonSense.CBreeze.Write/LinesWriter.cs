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
        public static void Write(this CodeLines codeLines, CSideWriter writer, bool asDocumentation = false)
        {
            bool inComment = false;
            foreach (var codeLine in codeLines)
            {
                if (string.IsNullOrEmpty(codeLine))
                    writer.InnerWriter.WriteLine();
                else if (asDocumentation)
                    writer.WriteLine(codeLine);
                else
                    writer.WriteLine(FormatCodeLine(codeLine, ref inComment, writer));
            }
        }

        private static string FormatCodeLine(string line, ref bool inComment, CSideWriter writer)
        {
            string prefixComment = "";
            if (inComment)
            {
                int prefixLocation = line.IndexOf("}");
                if (prefixLocation < 0)
                {                    
                    return line;
                }
                else
                {
                    prefixComment = line.Substring(0, prefixLocation + 1);
                    line = line.Substring(prefixLocation + 1);
                    inComment = false;
                }
            }

            StringBuilder builder = new StringBuilder();
            builder.Append(prefixComment);
            string linePart = "";
            while (GetNextLinePart(ref line, ref linePart))
            {
                if (linePart.StartsWith("\"") || linePart.StartsWith("'") || linePart.StartsWith("//"))
                {
                    builder.Append(linePart);
                }
                else if (linePart.StartsWith("{"))
                {
                    inComment = String.IsNullOrEmpty(line);
                    builder.Append(linePart);
                }
                else
                {
                    linePart = FormatLinePart(linePart, ref inComment, writer);
                    builder.Append(linePart);
                }
            }

            return builder.ToString();
        }
        
        private static bool GetNextLinePart(ref string line, ref string linePart)
        {
            linePart = "";
            if (String.IsNullOrEmpty(line))
            {                
                return false;
            }
            if (line.StartsWith("\""))
            {
                int end = line.IndexOf("\"", 1);
                if (end < 0)
                {
                    end = line.Length - 1;
                }
                linePart = line.Substring(0, end + 1);
                line = line.Length > end + 1 ? line.Substring(end + 1) : "";
                return true;
            }
            if (line.StartsWith("'"))
            {
                int end = line.IndexOf("'", 1);
                if (end < 0)
                {
                    end = line.Length - 1;
                }
                linePart = line.Substring(0, end + 1);
                line = line.Length > end + 1 ? line.Substring(end + 1) : "";
                return true;
            }
            if (line.StartsWith("//"))
            {
                linePart = line;
                line = "";
                return true;
            }
            if (line.StartsWith("{"))
            {
                int end = line.IndexOf("}", 1);
                if (end < 0)
                {
                    end = line.Length - 1;
                }
                linePart = line.Substring(0, end + 1);
                line = line.Length > end + 1 ? line.Substring(end + 1) : "";
                return true;
            }



            int stringStart = line.IndexOf("'");
            int varStart = line.IndexOf("\"");            
            int commentStart = line.IndexOf("//");
            int blockCommentStart = line.IndexOf("{");

            stringStart = stringStart < 0 ? line.Length : stringStart;
            varStart = varStart < 0 ? line.Length : varStart;
            commentStart = commentStart < 0 ? line.Length : commentStart;
            blockCommentStart = blockCommentStart < 0 ? line.Length : blockCommentStart;

            int nextStop = Math.Min(Math.Min(stringStart, varStart), Math.Min(commentStart, blockCommentStart));

            linePart = line.Substring(0, nextStop);
            line = line.Substring(nextStop);
            return true;
        }


        private static string FormatLinePart(string linePart, ref bool inComment, CSideWriter writer)
        {
            linePart = new System.Text.RegularExpressions.Regex(@"\b(IF)\b").Replace(linePart, "if");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(THEN)\b").Replace(linePart, "then");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ELSE)\b").Replace(linePart, "else");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(BEGIN)\b").Replace(linePart, "begin");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(END)\b").Replace(linePart, "end");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DATE2DMY)\b").Replace(linePart, "Date2DMY");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ERROR)\b").Replace(linePart, "Error");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CALCFIELDS)\b").Replace(linePart, "CalcFields");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CALCFIELD)\b").Replace(linePart, "CalcField");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CALCSUMS)\b").Replace(linePart, "CalcSums");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CASE)\b").Replace(linePart, "case");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(OF)\b").Replace(linePart, "of");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(EXIT)\b").Replace(linePart, "exit");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(STRPOS)\b").Replace(linePart, "StrPos");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COPYSTR)\b").Replace(linePart, "CopyStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COPY)\b").Replace(linePart, "Copy");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TESTFIELD)\b").Replace(linePart, "TestField");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FALSE)\b").Replace(linePart, "false");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TRUE)\b").Replace(linePart, "true");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GET)\b").Replace(linePart, "Get");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(USERID)\b").Replace(linePart, "UserId");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TODAY)\b").Replace(linePart, "Today");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISTEMPORARY)\b").Replace(linePart, "IsTemporary");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(INIT)\b").Replace(linePart, "Init");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(INSERT)\b").Replace(linePart, "Insert");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETTABLE)\b").Replace(linePart, "GetTable");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(AND)\b").Replace(linePart, "and");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(OR)\b").Replace(linePart, "or");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(NOT)\b").Replace(linePart, "not");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETFILTERS)\b").Replace(linePart, "GetFilters");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETFILTER)\b").Replace(linePart, "GetFilter");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETFILTER)\b").Replace(linePart, "SetFilter");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(WORKDATE)\b").Replace(linePart, "WorkDate");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(READPERMISSION)\b").Replace(linePart, "ReadPermission");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(WRITEPERMISSION)\b").Replace(linePart, "WritePermission");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RESET)\b").Replace(linePart, "Reset");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETRANGE)\b").Replace(linePart, "SetRange");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETFILTER)\b").Replace(linePart, "SetFilter");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETCURRENTKEY)\b").Replace(linePart, "SetCurrentKey");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MODIFY)\b").Replace(linePart, "Modify");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MODIFYALL)\b").Replace(linePart, "ModifyAll");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DELETE)\b").Replace(linePart, "Delete");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DELETEALL)\b").Replace(linePart, "DeleteAll");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RENAME)\b").Replace(linePart, "Rename");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISEMPTY)\b").Replace(linePart, "IsEmpty");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CONFIRM)\b").Replace(linePart, "Confirm");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MESSAGE)\b").Replace(linePart, "Message");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIND)\b").Replace(linePart, "Find");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FINDSET)\b").Replace(linePart, "FindSet");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FINDFIRST)\b").Replace(linePart, "FindFirst");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FINDLAST)\b").Replace(linePart, "FindLast");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(NEXT)\b").Replace(linePart, "Next");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COUNT)\b").Replace(linePart, "Count");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIELDCAPTION)\b").Replace(linePart, "FieldCaption");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DO)\b").Replace(linePart, "do");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(WITH)\b").Replace(linePart, "with");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FOR)\b").Replace(linePart, "for");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TO)\b").Replace(linePart, "to");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DOWNTO)\b").Replace(linePart, "downto");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(REPEAT)\b").Replace(linePart, "repeat");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(UNTIL)\b").Replace(linePart, "until");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MAXSTRLEN)\b").Replace(linePart, "MaxStrLen");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(STRLEN)\b").Replace(linePart, "StrLen");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ARRAYLEN)\b").Replace(linePart, "ArrayLen");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MARK)\b").Replace(linePart, "Mark");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CLEARMARKS)\b").Replace(linePart, "ClearMarks");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MARKEDONLY)\b").Replace(linePart, "MarkedOnly");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RUN)\b").Replace(linePart, "Run");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RUNMODAL)\b").Replace(linePart, "RunModal");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(WHILE)\b").Replace(linePart, "while");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(IN)\b").Replace(linePart, "in");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CLEAR)\b").Replace(linePart, "Clear");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ASCENDING)\b").Replace(linePart, "Ascending");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIELDNO)\b").Replace(linePart, "FieldNo");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(VALIDATE)\b").Replace(linePart, "Validate");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FILTERGROUP)\b").Replace(linePart, "FilterGroup");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETRECFILTER)\b").Replace(linePart, "SetRecFilter");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TIME)\b").Replace(linePart, "Time");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TABLECAPTION)\b").Replace(linePart, "TableCaption");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIELDERROR)\b").Replace(linePart, "FieldError");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(STRSUBSTNO)\b").Replace(linePart, "StrSubstNo");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETTABLEVIEW)\b").Replace(linePart, "SetTableView");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETRECORD)\b").Replace(linePart, "SetRecord");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETRECORD)\b").Replace(linePart, "GetRecord");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(LOOKUPMODE)\b").Replace(linePart, "LookupMode");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CALCDATE)\b").Replace(linePart, "CalcDate");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(LOCKTABLE)\b").Replace(linePart, "LockTable");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(INCSTR)\b").Replace(linePart, "IncStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ROUND)\b").Replace(linePart, "Round");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FORMAT)\b").Replace(linePart, "Format");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CURRENTDATETIME)\b").Replace(linePart, "CurrentDateTime");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CREATEDATETIME)\b").Replace(linePart, "CreateDateTime");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COMMIT)\b").Replace(linePart, "Commit");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DT2DATE)\b").Replace(linePart, "DT2Date");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DT2TIME)\b").Replace(linePart, "DT2Time");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CONVERTSTR)\b").Replace(linePart, "ConvertStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ERASE)\b").Replace(linePart, "Erase");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DMY2DATE)\b").Replace(linePart, "DMY2Date");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DWY2DATE)\b").Replace(linePart, "DWY2Date");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DATE2DMY)\b").Replace(linePart, "Date2DMY");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DATE2DWY)\b").Replace(linePart, "Date2DWY");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(UPPERCASE)\b").Replace(linePart, "UpperCase");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(LOWERCASE)\b").Replace(linePart, "LowerCase");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(EVALUATE)\b").Replace(linePart, "Evaluate");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(USEREQUESTPAGE)\b").Replace(linePart, "UseRequestPage");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CREATEINSTREAM)\b").Replace(linePart, "CreateInStream");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CREATEOUTSTREAM)\b").Replace(linePart, "CreateOutStream");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(OPEN)\b").Replace(linePart, "Open");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CLOSE)\b").Replace(linePart, "Close");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(READTEXT)\b").Replace(linePart, "ReadText");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(EXISTS)\b").Replace(linePart, "Exists");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETTABLE)\b").Replace(linePart, "SetTable");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COPYFILTERS)\b").Replace(linePart, "CopyFilters");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COPYFILTER)\b").Replace(linePart, "CopyFilter");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(UPDATE)\b").Replace(linePart, "Update");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TRANSFERFIELDS)\b").Replace(linePart, "TransferFields");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ABS)\b").Replace(linePart, "Abs");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(MOD)\b").Replace(linePart, "mod");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DIV)\b").Replace(linePart, "div");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(HASVALUE)\b").Replace(linePart, "HasValue");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETRANGEMAX)\b").Replace(linePart, "GetRangeMax");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETRANGEMIN)\b").Replace(linePart, "GetRangeMin");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GUIALLOWED)\b").Replace(linePart, "GuiAllowed");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SELECTSTR)\b").Replace(linePart, "SelectStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(OPTIONSTRING)\b").Replace(linePart, "OptionString");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DELCHR)\b").Replace(linePart, "DelChr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DELSTR)\b").Replace(linePart, "DelStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(PADSTR)\b").Replace(linePart, "PadStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COPYSTREAM)\b").Replace(linePart, "CopyStream");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETAUTOCALCFIELDS)\b").Replace(linePart, "SetAutoCalcFields");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(WRITETEXT)\b").Replace(linePart, "WriteText");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETVIEW)\b").Replace(linePart, "GetView");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETVIEW)\b").Replace(linePart, "SetView");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETPOSITION)\b").Replace(linePart, "GetPosition");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETPOSITION)\b").Replace(linePart, "SetPosition");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISNULLGUID)\b").Replace(linePart, "IsNullGuid");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISNULL)\b").Replace(linePart, "IsNull");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SKIP)\b").Replace(linePart, "Skip");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COMPRESSARRAY)\b").Replace(linePart, "CompressArray");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIELDINDEX)\b").Replace(linePart, "FieldIndex");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(VALUE)\b").Replace(linePart, "Value");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIELD)\b").Replace(linePart, "Field");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FIELDCOUNT)\b").Replace(linePart, "FieldCount");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(KEYINDEX)\b").Replace(linePart, "KeyIndex");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(KEYCOUNT)\b").Replace(linePart, "KeyCount");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GLOBALLANGUAGE)\b").Replace(linePart, "GlobalLanguage");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(INSSTR)\b").Replace(linePart, "InsStr");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RECORD)\b").Replace(linePart, "Record");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(IMPORT)\b").Replace(linePart, "Import");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(EXPORT)\b").Replace(linePart, "Export");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DOWNLOAD)\b").Replace(linePart, "Download");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(DOWNLOADFROMSTREAM)\b").Replace(linePart, "DownloadFromStream");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(UPLOAD)\b").Replace(linePart, "Upload");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(UPLOADINTOSTREAM)\b").Replace(linePart, "UploadIntoStream");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(BREAK)\b").Replace(linePart, "Break");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(USERSECURITYID)\b").Replace(linePart, "UserSecurityId");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CURRENTCLIENTTYPE)\b").Replace(linePart, "CurrentClientType");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(HYPERLINK)\b").Replace(linePart, "HyperLink");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COMPANYNAME)\b").Replace(linePart, "CompanyName");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SERVICEINSTANCEID)\b").Replace(linePart, "ServiceInstanceId");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SESSIONID)\b").Replace(linePart, "SessionId");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CREATETEMPFILE)\b").Replace(linePart, "CreateTempFile");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(NAME)\b").Replace(linePart, "Name");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(LENGTH)\b").Replace(linePart, "Length");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(NUMBER)\b").Replace(linePart, "Number");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(EDITABLE)\b").Replace(linePart, "Editable");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(STRMENU)\b").Replace(linePart, "StrMenu");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(OPTIONCAPTION)\b").Replace(linePart, "OptionCaption");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ADDTEXT)\b").Replace(linePart, "AddText");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(POWER)\b").Replace(linePart, "Power");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RECORDLEVELLOCKING)\b").Replace(linePart, "RecordLevelLocking");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CHANGECOMPANY)\b").Replace(linePart, "ChangeCompany");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(READ)\b").Replace(linePart, "Read");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(QUIT)\b").Replace(linePart, "Quit");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ADDRECORD)\b").Replace(linePart, "AddRecord");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ADDRECORDREF)\b").Replace(linePart, "AddRecordRef");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ADDTABLE)\b").Replace(linePart, "AddTable");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ADDFIELD)\b").Replace(linePart, "AddField");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ADDFIELDNO)\b").Replace(linePart, "AddFieldNo");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CAPTION)\b").Replace(linePart, "Caption");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CLEARALL)\b").Replace(linePart, "ClearAll");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETASCENDING)\b").Replace(linePart, "SetAscending");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(TABLENAME)\b").Replace(linePart, "TableName");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(COPYARRAY)\b").Replace(linePart, "CopyArray");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETLASTERRORTEXT)\b").Replace(linePart, "GetLastErrorText");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISBOOLEAN)\b").Replace(linePart, "IsBoolean");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISCODE)\b").Replace(linePart, "IsCode");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISTEXT)\b").Replace(linePart, "IsText");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISDATE)\b").Replace(linePart, "IsDate");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISDATETIME)\b").Replace(linePart, "IsDateTime");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISDECIMAL)\b").Replace(linePart, "IsDecimal");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISINTEGER)\b").Replace(linePart, "IsInteger");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISCODEUNIT)\b").Replace(linePart, "IsCodeunit");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISDOTNET)\b").Replace(linePart, "IsDotNet");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISRECORD)\b").Replace(linePart, "IsRecord");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(ISRECORDREF)\b").Replace(linePart, "IsRecordRef");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(BINDSUBSCRIPTION)\b").Replace(linePart, "BindSubscription");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(UNBINDSUBSCRIPTION)\b").Replace(linePart, "UnbindSubscription");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CREATEGUID)\b").Replace(linePart, "CreateGuid");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SAVEASPDF)\b").Replace(linePart, "SaveAsPdf");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SAVEAS)\b").Replace(linePart, "SaveAs");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(RUNREQUESTPAGE)\b").Replace(linePart, "RunRequestPage");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(STARTSESSION)\b").Replace(linePart, "StartSession");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(PAGECAPTION)\b").Replace(linePart, "PageCaption");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(EXECUTE)\b").Replace(linePart, "Execute");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CREATE)\b").Replace(linePart, "Create");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(GETDOTNETTYPE)\b").Replace(linePart, "GetDotNetType");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CLEARLASTERROR)\b").Replace(linePart, "ClearLastError");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETDESTINATION)\b").Replace(linePart, "SetDestination");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(SETSOURCE)\b").Replace(linePart, "SetSource");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(FOREACH)\b").Replace(linePart, "foreach");
            linePart = new System.Text.RegularExpressions.Regex(@"\b(CAPTIONCLASSTRANSLATE)\b").Replace(linePart, "CaptionClassTranslate");
            return linePart;
        }

    }
}
