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
            line = new System.Text.RegularExpressions.Regex(@"\b(IF)\b").Replace(line, "if");
            line = new System.Text.RegularExpressions.Regex(@"\b(THEN)\b").Replace(line, "then");
            line = new System.Text.RegularExpressions.Regex(@"\b(ELSE)\b").Replace(line, "else");
            line = new System.Text.RegularExpressions.Regex(@"\b(BEGIN)\b").Replace(line, "begin");
            line = new System.Text.RegularExpressions.Regex(@"\b(END)\b").Replace(line, "end");
            line = new System.Text.RegularExpressions.Regex(@"\b(DATE2DMY)\b").Replace(line, "Date2DMY");
            line = new System.Text.RegularExpressions.Regex(@"\b(ERROR)\b").Replace(line, "Error");
            line = new System.Text.RegularExpressions.Regex(@"\b(CALCFIELDS)\b").Replace(line, "CalcFields");
            line = new System.Text.RegularExpressions.Regex(@"\b(CASE)\b").Replace(line, "case");
            line = new System.Text.RegularExpressions.Regex(@"\b(OF)\b").Replace(line, "of");
            line = new System.Text.RegularExpressions.Regex(@"\b(EXIT)\b").Replace(line, "exit");
            line = new System.Text.RegularExpressions.Regex(@"\b(STRPOS)\b").Replace(line, "StrPos");
            line = new System.Text.RegularExpressions.Regex(@"\b(COPYSTR)\b").Replace(line, "CopyStr");
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
            return line;
        }
        
    }
}
