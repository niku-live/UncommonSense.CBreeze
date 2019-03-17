﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public class NullListener : IListener
    {
        public void OnBeginApplication()
        {
        }

        public void OnEndApplication()
        {
        }

        public void OnBeginFile(string fileName)
        {
        }

        public void OnEndFile()
        {
        }

        public void OnBeginObject(ObjectType objectType, int objectID, string objectName)
        {
        }

        public void OnEndObject()
        {
        }

        public void OnBeginSection(SectionType sectionType)
        {
        }

        public void OnEndSection()
        {
        }

        public void OnProperty(string propertyName, string propertyValue)
        {
        }


        public void OnBeginFunction(int functionID, string functionName, bool functionLocal)
        {
        }

        public void OnEndFunction()
        {
        }

        public void OnFunctionAttribute(string name, params string[] values)
        {
        }

        public void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
        }

        public void OnEndTableFieldGroup()
        {
        }

        public void OnBeginTableKey(bool? keyEnabled, string[] keyFields)
        {
        }

        public void OnEndTableKey()
        {
        }

        public void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName, TableFieldType fieldType, int fieldLength)
        {
        }

        public void OnEndTableField()
        {
        }

        public void OnCodeLine(string codeLine)
        {
        }

        public void OnBeginFormControl(int controlId, ClassicControlType controlType, int posX, int posY, int width, int height)
        {
            
        }

        public void OnEndFormControl()
        {
        }

        public void OnBeginFormMenuItem()
        {
            
        }

        public void OnEndFormMenuItem()
        {

        }

        public void OnBeginDataPortField(int? startPos, int? width, string sourceExpr)
        {
            
        }

        public void OnEndDataPortField()
        {

        }

        public void OnBeginTrigger(string triggerName)
        {
        }

        public void OnEndTrigger()
        {
        }

        public void OnObjectProperty(string propertyName, string propertyValue)
        {
        }

        public void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType, int? returnValueLength, string returnValueDimensions)
        {
        }

        public void OnParameter(bool parameterVar, int parameterID, string parameterName, ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString, bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient, string parameterSecurityFiltering, bool parameterSuppressDispose)
        {
        }

        public void OnVariable(int variableID, string variableName, VariableType variableType, string variableSubType, int? variableLength, string variableOptionString, string variableConstValue, bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents, string variableSecurityFiltering, bool variableInDataSet)
        {
        }

        public void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
        }

        public void OnEndEvent()
        {
        }


        public void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName, QueryElementType elementType)
        {
        }

        public void OnEndQueryElement()
        {
        }


        public void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType)
        {
        }

        public void OnEndPageControl()
        {
        }

        public void OnBeginPageAction(int actionID, int? actionIndentation, PageActionType actionType)
        {
        }

        public void OnEndPageAction()
        {
        }

        public void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName, XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType)
        {
        }

        public void OnEndXmlPortElement()
        {
        }


        public void OnBeginReportElement(int elementID, int? elementIndentation, string elementName, ReportElementType elementType)
        {
        }

        public void OnEndReportElement()
        {
        }


        public void OnRdlData(System.Xml.XmlDocument data)
        {
        }

        public void OnBeginRequestPage()
        {
        }

        public void OnEndRequestPage()
        {
        }

        public void OnBeginRequestForm()
        {
        }

        public void OnEndRequestForm()
        {
        }

        public void OnBeginReportLabel(int labelID, string labelName)
        {
        }

        public void OnEndReportLabel()
        {
        }

        public void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID)
        {
        }

        public void OnEndMenuSuiteNode()
        {
        }

        public void OnBeginReportControl(int controlId, ClassicControlType controlType, int posX, int posY, int width, int height)
        {
        }

        public void OnEndReportControl()
        {
        }

        public void OnBeginReportDataItem()
        {
        }

        public void OnEndReportDataItem()
        {
        }

        public void OnBeginReportSection()
        {
        }

        public void OnEndReportSection()
        {
        }

        public void OnBeginDataportDataItem()
        {
        }

        public void OnEndDataportDataItem()
        {
        }

        public void OnInvalidTrigger(string invalidTriggerValue)
        {
        }
    }
}
