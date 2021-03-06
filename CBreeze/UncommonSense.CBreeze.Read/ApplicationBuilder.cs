﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UncommonSense.CBreeze.Common;
using UncommonSense.CBreeze.Core.Base;
using UncommonSense.CBreeze.Core.Code;
using UncommonSense.CBreeze.Core.Code.Function;
using UncommonSense.CBreeze.Core.Code.Parameter;
using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Codeunit;
using UncommonSense.CBreeze.Core.Common;
using UncommonSense.CBreeze.Core.Dataport;
using UncommonSense.CBreeze.Core.Form;
using UncommonSense.CBreeze.Core.Form.Control;
using UncommonSense.CBreeze.Core.Form.Control.Properties;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Page;
using UncommonSense.CBreeze.Core.Page.Action;
using UncommonSense.CBreeze.Core.Page.Control;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;
using UncommonSense.CBreeze.Core.Query;
using UncommonSense.CBreeze.Core.Report;
using UncommonSense.CBreeze.Core.Report.Classic;
using UncommonSense.CBreeze.Core.Report.Classic.Controls;
using UncommonSense.CBreeze.Core.Report.Classic.Section;
using UncommonSense.CBreeze.Core.Report.Classic.Section.Contracts;
using UncommonSense.CBreeze.Core.Table;
using UncommonSense.CBreeze.Core.Table.Field;
using UncommonSense.CBreeze.Core.Table.Key;
using UncommonSense.CBreeze.Core.XmlPort;
using UncommonSense.CBreeze.Parse;
using Object = UncommonSense.CBreeze.Core.Base.Object;
using SectionType = UncommonSense.CBreeze.Common.SectionType;

namespace UncommonSense.CBreeze.Read
{
    public class ApplicationBuilder : ListenerBase
    {
        private readonly Stack<IEnumerable<Property>> currentProperties = new Stack<IEnumerable<Property>>();
        private Code currentCode;
        private DataItem currentReportDataItem;
        private DataItems currentReportDataItems;
        private DataportDataItem currentDataportDataItem;
        private DataportField currentDataportField;
        private Event currentEvent;
        private string currentFileName;
        private FormMenuItem currentFormMenuItem;
        private FormControl currentFormControl;
        private FormControls currentFormControls;
        private Function currentFunction;
        private MenuSuiteNodes currentMenuSuiteNodes;
        private Object currentObject;
        private ActionList currentPageActionList;
        private PageControls currentPageControls;
        private QueryElements currentQueryElements;
        private RdlData currentRdlData;
        private ReportElements currentReportElements;
        private ReportLabels currentReportLabels;
        private RequestForm currentRequestForm;
        private RequestPage currentRequestPage;
        private SectionBase currentSection;
        private Sections currentReportSections;
        private SectionType? currentSectionType;
        private TableField currentTableField;
        private TableFieldGroup currentTableFieldGroup;
        private TableFieldGroups currentTableFieldGroups;
        private TableFields currentTableFields;
        private TableKey currentTableKey;
        private TableKeys currentTableKeys;
        private Trigger currentTrigger;
#if NAV2015
        private WordLayout currentWordLayout;
#endif
        private XmlPortNodes currentXmlPortNodes;
        private bool sectionBegin;

        public ApplicationBuilder(Application application)
        {
            Application = application;
        }

        public Application Application { get; }

        public static Application ReadFromFolder(string folderName, ApplicationCodeStyle codeStyle = null)
        {
            return ReadFromFiles(Directory.EnumerateFiles(folderName, "*.txt"), codeStyle: codeStyle);
        }

        public static Application ReadFromFiles(ApplicationCodeStyle codeStyle = null, params string[] fileNames)
        {
            return ReadFromFiles((IEnumerable<string>) fileNames, codeStyle: codeStyle);
        }

        public static Application ReadFromFiles(IEnumerable<string> fileNames, Action<string> reportProgress = null, ApplicationCodeStyle codeStyle = null)
        {
            codeStyle = codeStyle ?? ApplicationCodeStyle.CreateNav2013CodeStyle();
            var parser = new Parser();
            if (codeStyle != null)
            {
                parser.CodeStyle = codeStyle;
            }
            var application = new Application() { CodeStyle = parser.CodeStyle };
            application.CodeStyle.ObjectNameResolvers.Add(application);
            var applicationBuilder = new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.ParseFiles(fileNames, reportProgress);

            return application;
        }

        public static Application ReadFromLines(IEnumerable<string> lines, ApplicationCodeStyle codeStyle = null)
        {
            var parser = new Parser();
            if (codeStyle != null)
            {
                parser.CodeStyle = codeStyle;
            }
            var application = new Application() { CodeStyle = parser.CodeStyle };
            var applicationBuilder = new ApplicationBuilder(application);

            parser.Listener = applicationBuilder;
            parser.ParseLines(lines);

            return application;
        }

        public override void OnBeginFile(string fileName)
        {
            currentFileName = fileName;
        }

        public override void OnEndFile()
        {
            currentFileName = null;
        }

        public override void OnBeginObject(ObjectType objectType, int objectID, string objectName)
        {
            switch (objectType)
            {
                case ObjectType.Table:
                    var newTable = Application.Tables.Add(new Table(objectID, objectName));

                    //currentObjectLevelProperties = newTable.Properties;
                    currentProperties.Push(newTable.Properties);
                    currentTableFields = newTable.Fields;
                    currentTableKeys = newTable.Keys;
                    currentTableFieldGroups = newTable.FieldGroups;
                    currentCode = newTable.Code;

                    currentObject = newTable;
                    break;
#if NAV2009
                case ObjectType.Form:
                    var newForm = Application.Forms.Add(new Form(objectID, objectName));

                    currentProperties.Push(newForm.Properties);
                    currentFormControls = newForm.Controls;
                    currentCode = newForm.Code;
                    currentObject = newForm;
                    break;
#endif

                case ObjectType.Page:
                    var newPage = Application.Pages.Add(new Page(objectID, objectName));

                    // currentObjectLevelProperties = newPage.Properties;
                    currentProperties.Push(newPage.Properties);
                    currentPageControls = newPage.Controls;
                    currentPageActionList = newPage.Properties.ActionList;
                    currentCode = newPage.Code;
                    currentObject = newPage;
                    break;

                case ObjectType.Report:
                    var newReport = Application.Reports.Add(new Report(objectID, objectName));
                    currentProperties.Push(newReport.Properties);
                    currentReportElements = newReport.Elements;
                    currentReportLabels = newReport.Labels;
                    currentRequestPage = newReport.RequestPage;
                    currentRequestForm = newReport.RequestForm;
                    currentCode = newReport.Code;
                    currentRdlData = newReport.RdlData;
#if NAV2015
                    currentWordLayout = newReport.WordLayout;
#endif
#if NAV2009
                    currentReportDataItems = newReport.DataItems;
#endif
                    currentObject = newReport;
                    break;

                case ObjectType.Codeunit:
                    var newCodeunit = Application.Codeunits.Add(new Codeunit(objectID, objectName));
                    currentProperties.Push(newCodeunit.Properties);

                    //currentObjectLevelProperties = newCodeunit.Properties;
                    currentCode = newCodeunit.Code;
                    currentObject = newCodeunit;
                    break;
#if NAV2009
                case ObjectType.Dataport:
                    var newDataport = Application.Dataports.Add(new Dataport(objectID, objectName));
                    currentProperties.Push(newDataport.Properties);
                    currentCode = newDataport.Code;
                    currentRequestForm = newDataport.RequestForm;
                    currentObject = newDataport;
                    break;
#endif
                case ObjectType.XmlPort:
                    var newXmlPort = Application.XmlPorts.Add(new XmlPort(objectID, objectName));
                    currentProperties.Push(newXmlPort.Properties);
                    currentRequestPage = newXmlPort.RequestPage;
                    currentCode = newXmlPort.Code;
                    currentXmlPortNodes = newXmlPort.Nodes;
                    currentObject = newXmlPort;
                    break;

                case ObjectType.MenuSuite:
                    var newMenuSuite = Application.MenuSuites.Add(new MenuSuite(objectID, objectName));
                    currentProperties.Push(newMenuSuite.Properties);
                    currentMenuSuiteNodes = newMenuSuite.Nodes;
                    currentObject = newMenuSuite;
                    break;

                case ObjectType.Query:
                    var newQuery = Application.Queries.Add(new Query(objectID, objectName));

                    // currentObjectLevelProperties = newQuery.Properties;
                    currentProperties.Push(newQuery.Properties);
                    currentQueryElements = newQuery.Elements;
                    currentCode = newQuery.Code;
                    currentObject = newQuery;
                    break;
            }
        }

        public override void OnEndObject()
        {
            currentObject = null;
            currentProperties.Pop();

            //currentObjectLevelProperties = null;
            currentTableFields = null;
            currentTableKeys = null;
            currentTableFieldGroups = null;
            currentPageControls = null;
            currentPageActionList = null;
            currentQueryElements = null;
            currentXmlPortNodes = null;
            currentReportElements = null;
            currentReportLabels = null;
            currentRequestPage = null;
            currentRequestForm = null;
            currentCode = null;
            currentRdlData = null;
#if NAV2015
            currentWordLayout = null;
#endif
            currentMenuSuiteNodes = null;
            currentFormControls = null;
            currentReportDataItems = null;
        }

        public override void OnBeginSection(SectionType sectionType)
        {
            currentSectionType = sectionType;
        }

        public override void OnEndSection()
        {
            currentSectionType = null;
        }

        public override void OnObjectProperty(string propertyName, string propertyValue)
        {
            switch (propertyName)
            {
                case "Date":
                    currentObject.ObjectProperties.Date = propertyValue.ToFormattedDate(Application.CodeStyle.Localization);
                    currentObject.ObjectProperties.HasDateComponent = !String.IsNullOrEmpty(propertyValue);
                    break;

                case "Time":
                    currentObject.ObjectProperties.Time = propertyValue.ToFormattedTimeSpan(Application.CodeStyle.Localization);
                    currentObject.ObjectProperties.HasTimeComponent = !String.IsNullOrEmpty(propertyValue);
                    break;

                case "Modified":
                    currentObject.ObjectProperties.Modified = propertyValue.ToBoolean(Application.CodeStyle.Localization);
                    break;

                case "Version List":
                    currentObject.ObjectProperties.VersionList = propertyValue;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(propertyName));
            }
        }

        public override void OnProperty(string propertyName, string propertyValue)
        {
            if (String.IsNullOrEmpty(propertyName))
            {
                throw new ArgumentNullException(nameof(propertyName));
            }
            // Unfortunately, this block is necessary because the type of the section in the text files does not depend on the object section,
            // but on the "Properties" subordinate object. This is very unpleasant, because it is not really object-oriented.
            // Maybe there's a better solution?
            if (sectionBegin && currentObject is Report &&
                propertyName.Equals("SectionType", StringComparison.InvariantCultureIgnoreCase))
            {
                var secttype = propertyValue.ToEnum<Core.Report.Classic.Section.SectionType>();
                // If possible, should be outsourced to a factory or at least one factory method.
                switch (secttype)
                {
                    case Core.Report.Classic.Section.SectionType.Header:
                        currentSection = new HeaderSection(currentReportDataItem);
                        break;
                    case Core.Report.Classic.Section.SectionType.TransHeader:
                        currentSection = new TransHeaderSection(currentReportDataItem);
                        break;
                    case Core.Report.Classic.Section.SectionType.GroupHeader:
                        currentSection = new GroupHeaderSection(currentReportDataItem);
                        break;
                    case Core.Report.Classic.Section.SectionType.Body:
                        currentSection = new BodySection(currentReportDataItem);
                        break;
                    case Core.Report.Classic.Section.SectionType.GroupFooter:
                        currentSection = new GroupFooterSection(currentReportDataItem);
                        break;
                    case Core.Report.Classic.Section.SectionType.TransFooter:
                        currentSection = new TransFooterSection(currentReportDataItem);
                        break;
                    case Core.Report.Classic.Section.SectionType.Footer:
                        currentSection = new FooterSection(currentReportDataItem);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(propertyValue));
                }
                if (currentReportDataItem.Sections == null)
                {
                    currentReportDataItem.Sections = new Sections(currentReportDataItem);
                }
                currentReportDataItem.Sections.Add(currentSection);
                currentProperties.Push(currentSection.AllProperties);
                currentFormControls = currentSection.Controls;
                sectionBegin = false;
                return;
            }

            var properties = currentProperties.Peek();

            if (propertyName == "Method")
            {
                var methodType = (properties.First(p => p.Name == "MethodType") as MethodTypeProperty).Value;

                switch (methodType)
                {
                    case MethodType.Date:
                        propertyName = "DateMethod";
                        break;

                    case MethodType.Totals:
                        propertyName = "TotalsMethod";
                        break;
                }
            }

            if (propertyName == "Format/Evaluate")
                propertyName = "FormatEvaluate";

            Parsing.TryMatch(ref propertyName, @"^Import::");
            Parsing.TryMatch(ref propertyName, @"^Export::");

            Property property;

            try
            {
                property = properties.First(p => p.Name == propertyName);
            }
            catch (InvalidOperationException e)
            {
                throw new InvalidOperationException($"Unexpected property '{propertyName}'.", e);
            }

            TypeSwitch.Do(
                property,
#if NAV2015
                TypeSwitch.Case<AccessByPermissionProperty>(p => p.SetAccessByPermission(propertyValue)),
                TypeSwitch.Case<PreviewModeProperty>(p => p.Value = propertyValue.ToEnum<PreviewMode>()),
                TypeSwitch.Case<PageActionScopeProperty>(p => p.Value = propertyValue.ToEnum<PageActionScope>()),
                TypeSwitch.Case<UpdatePropagationProperty>(p => p.Value = propertyValue.ToEnum<UpdatePropagation>()),
                TypeSwitch.Case<DefaultLayoutProperty>(p => p.Value = propertyValue.ToEnum<DefaultLayout>()),
#endif
#if NAV2017
                TypeSwitch.Case<TagListProperty>(p =>
                    //p.Value.AddRange(propertyValue.Split(",".ToCharArray()).Where(s => !string.IsNullOrEmpty(s)))),
                    p.Value.SetFromString(propertyValue)),
#endif
#if NAV2016
                TypeSwitch.Case<TableTypeProperty>(p => p.Value = propertyValue.ToEnum<TableType>()),
#endif
                TypeSwitch.Case<PageActionContainerTypeProperty>(p =>
                    p.Value = propertyValue.ToEnum<PageActionContainerType>()),
                TypeSwitch.Case<AutoFormatTypeProperty>(p => p.Value = propertyValue.ToAutoFormatType()),
                TypeSwitch.Case<BlankNumbersProperty>(p => p.Value = propertyValue.ToEnum<BlankNumbers>()),
                TypeSwitch.Case<CalcFormulaProperty>(p => p.SetCalcFormulaProperty(propertyValue)),
                TypeSwitch.Case<CodeunitSubTypeProperty>(p => p.Value = propertyValue.ToEnum<CodeunitSubType>()),
                TypeSwitch.Case<ColumnFilterProperty>(p => p.SetColumnFilterProperty(propertyValue)),
                TypeSwitch.Case<PageControlContainerTypeProperty>(p =>
                    p.Value = propertyValue.ToEnum<PageControlContainerType>()),
                TypeSwitch.Case<ControlListProperty>(p => p.Value.AddRange(propertyValue.Split(",".ToCharArray()))),
                TypeSwitch.Case<QueryDataItemLinkProperty>(p => p.SetDataItemLinkProperty(propertyValue)),
#if NAV2018
                TypeSwitch.Case<DataClassificationProperty>(p => p.Value = propertyValue.ToEnum<DataClassification>()),
#endif
                TypeSwitch.Case<DataItemLinkTypeProperty>(p => p.Value = propertyValue.ToEnum<DataItemLinkType>()),
                TypeSwitch.Case<DataItemQueryElementTableFilterProperty>(p =>
                    p.SetDataItemQueryElementTableFilter(propertyValue)),
                TypeSwitch.Case<DateMethodProperty>(p => p.Value = propertyValue.ToEnum<DateMethod>()),
                TypeSwitch.Case<DecimalPlacesProperty>(p => p.SetDecimalPlacesProperty(propertyValue)),
                TypeSwitch.Case<MenuItemDepartmentCategoryProperty>(p =>
                    p.Value = propertyValue.ToEnum<MenuItemDepartmentCategory>()),
                TypeSwitch.Case<DirectionProperty>(p => p.Value = propertyValue.ToEnum<Direction>()),
#if NAV2016
                TypeSwitch.Case<ExternalAccessProperty>(p => p.Value = propertyValue.ToEnum<ExternalAccess>()),
                TypeSwitch.Case<EventSubscriberInstanceProperty>(p =>
                    p.Value = propertyValue.ToEnum<EventSubscriberInstance>()),
#endif
                TypeSwitch.Case<ExtendedDataTypeProperty>(p => p.Value = propertyValue.ToEnum<ExtendedDataType>()),
                TypeSwitch.Case<FieldClassProperty>(p => p.Value = propertyValue.ToEnum<FieldClass>()),
                TypeSwitch.Case<FieldListProperty>(p => p.Value.AddRange(propertyValue.Split(",".ToCharArray()))),
                TypeSwitch.Case<FormatEvaluateProperty>(p => p.Value = propertyValue.ToFormatEvaluate()),
                TypeSwitch.Case<GestureProperty>(p => p.Value = propertyValue.ToEnum<Gesture>()),
                TypeSwitch.Case<PageControlGroupTypeProperty>(p =>
                    p.Value = propertyValue.ToEnum<PageControlGroupType>()),
                TypeSwitch.Case<ImportanceProperty>(p => p.Value = propertyValue.ToEnum<Importance>()),
                TypeSwitch.Case<PageControlGroupLayoutProperty>(p =>
                    p.Value = propertyValue.ToEnum<PageControlGroupLayout>()),
                TypeSwitch.Case<LinkFieldsProperty>(p => p.SetLinkFieldsProperty(propertyValue)),
                TypeSwitch.Case<MethodTypeProperty>(p => p.Value = propertyValue.ToEnum<MethodType>()),
                TypeSwitch.Case<MaxOccursProperty>(p => p.Value = propertyValue.ToEnum<MaxOccurs>()),
                TypeSwitch.Case<MenuItemRunObjectTypeProperty>(p =>
                    p.Value = propertyValue.ToEnum<MenuItemRunObjectType>()),
                TypeSwitch.Case<MinOccursProperty>(p => p.Value = propertyValue.ToEnum<MinOccurs>()),
                TypeSwitch.Case<MultiLanguageProperty>(p => p.SetMultiLanguageProperty(propertyValue)),
#if NAV2016
                TypeSwitch.Case<XmlPortNamespacesProperty>(p => p.Value.SetNamespacesValue(propertyValue)),
#endif
                TypeSwitch.Case<ObjectProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<RunObjectProperty>(p => p.SetObjectReferenceProperty(propertyValue)),
#if NAV2018
                TypeSwitch.Case<ObsoleteStateProperty>(p => p.Value = propertyValue.ToEnum<ObsoleteState>()),
#endif
                TypeSwitch.Case<OccurrenceProperty>(p => p.Value = propertyValue.ToEnum<Occurrence>()),
                //TypeSwitch.Case<OptionStringProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<OptionStringProperty>(p => p.Value.SetFromString(propertyValue)),
                TypeSwitch.Case<PageReferenceProperty>(p => p.Value = propertyValue.ToPageReference()),
#if NAV2009
                TypeSwitch.Case<FormReferenceProperty>(p => p.Value = propertyValue.ToFormReference()),
                TypeSwitch.Case<ClassicControlBorderStyleProperty>(p => p.Value = propertyValue.ToEnum<ClassicControlBorderStyle>()),
                TypeSwitch.Case<ShapeStyleProperty>(p => p.Value = propertyValue.ToEnum<ShapeStyle>()),
                TypeSwitch.Case<SourceTablePlacementProperty>(p => p.Value = propertyValue.ToEnum<ClassicControlSourceTablePlacement>()),
                TypeSwitch.Case<OrientationProperty>(p => p.Value = propertyValue.ToEnum<Orientation>()),
                TypeSwitch.Case<ClassicReportOrientationProperty>(p => p.Value = propertyValue.ToEnum<ClassicReportOrientation>()),
                TypeSwitch.Case<ClassicDataportFileFormatProperty>(p => p.Value = propertyValue.ToEnum<ClassicDataportFileFormat>()),
#endif
                TypeSwitch.Case<PageTypeProperty>(p => p.Value = propertyValue.ToEnum<PageType>()),
                TypeSwitch.Case<PaperSourceProperty>(p => p.Value = propertyValue.ToEnum<PaperSource>()),
                TypeSwitch.Case<PageControlPartTypeProperty>(p =>
                    p.Value = propertyValue.ToEnum<PageControlPartType>()),
                TypeSwitch.Case<PermissionsProperty>(p => p.SetPermissionProperty(propertyValue)),
                TypeSwitch.Case<PromotedCategoryProperty>(p => p.Value = propertyValue.ToEnum<PromotedCategory>()),
                TypeSwitch.Case<QueryOrderByLinesProperty>(p => p.SetQueryOrderByLinesProperty(propertyValue)),
                TypeSwitch.Case<QueryTypeProperty>(p => p.Value = propertyValue.ToEnum<QueryType>()),
                TypeSwitch.Case<ReadStateProperty>(p => p.Value = propertyValue.ToEnum<ReadState>()),
                TypeSwitch.Case<ReportDataItemLinkProperty>(p => p.SetReportDataItemLinkProperty(propertyValue)),
                TypeSwitch.Case<RunObjectLinkProperty>(p => p.SetObjectLinkProperty(propertyValue)),
                TypeSwitch.Case<RunPageModeProperty>(p => p.Value = propertyValue.ToEnum<RunPageMode>()),
                TypeSwitch.Case<SemiColonSeparatedStringProperty>(p =>
                    p.SetSemiColonSeparatedStringProperty(propertyValue)),
                TypeSwitch.Case<SIFTLevelsProperty>(p => p.SetSIFTLevelsProperty(propertyValue)),
                TypeSwitch.Case<SourceFieldProperty>(p => p.SetSourceFieldProperty(propertyValue)),
                TypeSwitch.Case<SqlJoinTypeProperty>(p => p.Value = propertyValue.ToEnum<SqlJoinType>()),
                TypeSwitch.Case<StringProperty>(p => p.Value = propertyValue),
                TypeSwitch.Case<StyleProperty>(p => p.Value = propertyValue.ToEnum<Style>()),
                TypeSwitch.Case<SystemPartIDProperty>(p => p.Value = propertyValue.ToEnum<SystemPartID>()),
                TypeSwitch.Case<BlobSubTypeProperty>(p => p.Value = propertyValue.ToEnum<BlobSubType>(app: Application)),
                TypeSwitch.Case<TableFieldTypeProperty>(p => p.Value = propertyValue.ToEnum<TableFieldType>()),
                TypeSwitch.Case<TableReferenceProperty>(p => p.Value = propertyValue.ToTableReference()),
                TypeSwitch.Case<TableRelationProperty>(p => p.SetTableRelationProperty(propertyValue)),
                TypeSwitch.Case<TableViewProperty>(p => p.SetTableViewProperty(propertyValue)),
                TypeSwitch.Case<TestIsolationProperty>(p => p.Value = propertyValue.ToEnum<TestIsolation>()),
#if NAV2017
                TypeSwitch.Case<TestPermissionsProperty>(p => p.Value = propertyValue.ToEnum<TestPermissions>()),
#endif
                TypeSwitch.Case<TextEncodingProperty>(p => p.Value = propertyValue.ToEnum<TextEncoding>()),
                TypeSwitch.Case<TextTypeProperty>(p => p.Value = propertyValue.ToEnum<TextType>()),
                TypeSwitch.Case<TotalsMethodProperty>(p => p.Value = propertyValue.ToEnum<TotalsMethod>()),
                TypeSwitch.Case<TransactionTypeProperty>(p => p.Value = propertyValue.ToEnum<TransactionType>()),
#if NAVBC
                TypeSwitch.Case<UsageCategoryProperty>(p=>p.Value = propertyValue.ToEnum<UsageCategory>()),
#endif
                TypeSwitch.Case<XmlPortEncodingProperty>(p => p.Value = propertyValue.ToEnum<XmlPortEncoding>()),
                TypeSwitch.Case<XmlPortNodeDataTypeProperty>(p =>
                    p.Value = propertyValue.ToEnum<XmlPortNodeDataType>()),
                TypeSwitch.Case<XmlPortFormatProperty>(p => p.Value = propertyValue.ToEnum<XmlPortFormat>()),
                TypeSwitch.Case<NullableTimeProperty>(p => p.Value = propertyValue.ToNullableTime()),
                TypeSwitch.Case<NullableBooleanProperty>(p => p.Value = propertyValue.ToNullableBoolean(Application.CodeStyle.Localization)),
                TypeSwitch.Case<NullableDecimalProperty>(p => p.Value = propertyValue.ToNullableDecimal(Application.CodeStyle.Localization)),
                TypeSwitch.Case<NullableGuidProperty>(p => p.Value = propertyValue.ToNullableGuid()),
                TypeSwitch.Case<NullableBigIntegerProperty>(p => p.Value = propertyValue.ToNullableBigInteger()),
                TypeSwitch.Case<NullableIntegerProperty>(p => p.SetNullableIntegerProperty(propertyValue)),
                TypeSwitch.Case<NullableDateProperty>(p => p.Value = propertyValue.ToNullableDateTime()),
                TypeSwitch.Case<AutoPositionProperty>(p =>
                    p.Value = propertyValue.ToEnum<ClassicControlAutoPosition>()),
                TypeSwitch.Case<BitmapPosProperty>(p => p.Value = propertyValue.ToEnum<BitmapPos>()),
                TypeSwitch.Case<BlankNumbersProperty>(p => p.Value = propertyValue.ToEnum<BlankNumbers>()),
                TypeSwitch.Case<BorderStyleProperty>(p => p.Value = propertyValue.ToEnum<BorderStyle>()),
                TypeSwitch.Case<BorderWidthProperty>(p => p.Value = propertyValue.ToBorderWidth()),
                TypeSwitch.Case<CaptionBarProperty>(p => p.Value = propertyValue.ToEnum<ClassicControlCaptionBar>()),
                TypeSwitch.Case<ColorProperty>(p => p.Value = propertyValue.ToColor()),
                TypeSwitch.Case<HorzAlignProperty>(p => p.Value = propertyValue.ToEnum<HorzAlign>()),
                TypeSwitch.Case<VertAlignProperty>(p => p.Value = propertyValue.ToEnum<VertAlign>()),
                TypeSwitch.Case<HorzGlueProperty>(p => p.Value = propertyValue.ToEnum<HorzGlue>()),
                TypeSwitch.Case<VertGlueProperty>(p => p.Value = propertyValue.ToEnum<VertGlue>()),
                TypeSwitch.Case<InvalidActionAppearanceProperty>(p =>
                    p.Value = propertyValue.ToEnum<InvalidActionAppearance>()),
                TypeSwitch.Case<PushActionProperty>(p => p.Value = propertyValue.ToEnum<PushAction>()),
                TypeSwitch.Case<RunFormLinkTypeProperty>(p => p.Value = propertyValue.ToEnum<RunFormLinkType>()),
                TypeSwitch.Case<IntegerProperty>(p => p.Value = propertyValue.ToInteger()),
                TypeSwitch.Case<MenuItemTypeProperty>(p => p.Value = propertyValue.ToEnum<MenuItemType>()),
                TypeSwitch.Case<NullableUnsignedIntegerProperty>(p =>
                    p.Value = propertyValue.ToNullableUnsignedInteger()),
                TypeSwitch.Case<DataClassificationProperty>(p => p.Value = propertyValue.ToEnum<DataClassification>()),
                TypeSwitch.Default(() => UnknownPropertyType(property.GetType().FullName)));
        }

        private void UnknownPropertyType(string propertyType)
        {
            throw new ArgumentOutOfRangeException($"Unknown property type: {propertyType}");
        }

        public override void OnBeginTrigger(string triggerName)
        {
            Parsing.TryMatch(ref triggerName, @"^Import::");
            Parsing.TryMatch(ref triggerName, @"^Export::");

            switch (currentSectionType)
            {
                case SectionType.ObjectProperties:
                    throw new ApplicationException(GetTranslatedString("No variables expected in object properties section."));
                case SectionType.Properties:
                case SectionType.Fields:
                case SectionType.Controls:
                case SectionType.Dataset:
                    currentTrigger = (currentProperties.Peek().First(p => p.Name == triggerName) as TriggerProperty)
                        ?.Value;
                    break;

                case SectionType.Elements:
                    currentTrigger =
                        (currentProperties.Peek().First(p => p.Name == triggerName) as ScopedTriggerProperty)?.Value;
                    break;

                default:
                    throw new ArgumentException($"No triggers expected in {currentSectionType} section.");
            }
        }

        public override void OnInvalidTrigger(string invalidTriggerValue)
        {
            if (currentTrigger == null)
            {
                return;
            }
            currentTrigger.InvalidTrigger = true;
            currentTrigger.InvalidTriggerValue = invalidTriggerValue;
        }

        public override void OnEndTrigger()
        {
            currentTrigger = null;
        }

        public override void OnBeginTableField(int fieldNo, bool? fieldEnabled, string fieldName,
            TableFieldType fieldType, int fieldLength)
        {
            var fields = (currentObject as Table).Fields;

            switch (fieldType)
            {
                case TableFieldType.BigInteger:
                    var bigIntegerTableField = fields.Add(new BigIntegerTableField(fieldNo, fieldName));
                    currentProperties.Push(bigIntegerTableField.Properties);
                    currentTableField = bigIntegerTableField;
                    break;

                case TableFieldType.Binary:
                    var binaryTableField = fields.Add(new BinaryTableField(fieldNo, fieldName, fieldLength));
                    currentProperties.Push(binaryTableField.Properties);
                    currentTableField = binaryTableField;
                    break;

                case TableFieldType.BLOB:
                    var blobTableField = fields.Add(new BlobTableField(fieldNo, fieldName));
                    currentProperties.Push(blobTableField.Properties);
                    currentTableField = blobTableField;
                    break;

                case TableFieldType.Boolean:
                    var booleanTableField = fields.Add(new BooleanTableField(fieldNo, fieldName));
                    currentProperties.Push(booleanTableField.Properties);
                    currentTableField = booleanTableField;
                    break;

                case TableFieldType.Code:
                    var codeTableField = fields.Add(new CodeTableField(fieldNo, fieldName, fieldLength, Application.CodeStyle.PlatformVersion.MajorVersion, Application.CodeStyle.ExportToNewSyntax));
                    currentProperties.Push(codeTableField.Properties);
                    currentTableField = codeTableField;
                    break;

                case TableFieldType.Date:
                    var dateTableField = fields.Add(new DateTableField(fieldNo, fieldName));
                    currentProperties.Push(dateTableField.Properties);
                    currentTableField = dateTableField;
                    break;

                case TableFieldType.DateFormula:
                    var dateFormulaTableField = fields.Add(new DateFormulaTableField(fieldNo, fieldName));
                    currentProperties.Push(dateFormulaTableField.Properties);
                    currentTableField = dateFormulaTableField;
                    break;

                case TableFieldType.DateTime:
                    var dateTimeTableField = fields.Add(new DateTimeTableField(fieldNo, fieldName));
                    currentProperties.Push(dateTimeTableField.Properties);
                    currentTableField = dateTimeTableField;
                    break;

                case TableFieldType.Decimal:
                    var decimalTableField = fields.Add(new DecimalTableField(fieldNo, fieldName));
                    currentProperties.Push(decimalTableField.Properties);
                    currentTableField = decimalTableField;
                    break;

                case TableFieldType.Duration:
                    var durationTableField = fields.Add(new DurationTableField(fieldNo, fieldName));
                    currentProperties.Push(durationTableField.Properties);
                    currentTableField = durationTableField;
                    break;

                case TableFieldType.Guid:
                    var guidTableField = fields.Add(new GuidTableField(fieldNo, fieldName));
                    currentProperties.Push(guidTableField.Properties);
                    currentTableField = guidTableField;
                    break;

                case TableFieldType.Integer:
                    var integerTableField = fields.Add(new IntegerTableField(fieldNo, fieldName));
                    currentProperties.Push(integerTableField.Properties);
                    currentTableField = integerTableField;
                    break;

#if NAV2017
                case TableFieldType.Media:
                    var mediaTableField = fields.Add(new MediaTableField(fieldNo, fieldName));
                    currentProperties.Push(mediaTableField.Properties);
                    currentTableField = mediaTableField;
                    break;

                case TableFieldType.MediaSet:
                    var mediaSetTableField = fields.Add(new MediaSetTableField(fieldNo, fieldName));
                    currentProperties.Push(mediaSetTableField.Properties);
                    currentTableField = mediaSetTableField;
                    break;
#endif

                case TableFieldType.Option:
                    var optionTableField = fields.Add(new OptionTableField(fieldNo, fieldName, Application.CodeStyle.ExportToNewSyntax));
                    currentProperties.Push(optionTableField.Properties);
                    currentTableField = optionTableField;
                    break;

                case TableFieldType.RecordID:
                    var recordIDTableField = fields.Add(new RecordIDTableField(fieldNo, fieldName));
                    currentProperties.Push(recordIDTableField.Properties);
                    currentTableField = recordIDTableField;
                    break;

                case TableFieldType.TableFilter:
                    var tableFilterTableField = fields.Add(new TableFilterTableField(fieldNo, fieldName));
                    currentProperties.Push(tableFilterTableField.Properties);
                    currentTableField = tableFilterTableField;
                    break;

                case TableFieldType.Text:
                    var textTableField = fields.Add(new TextTableField(fieldNo, fieldName, fieldLength));
                    currentProperties.Push(textTableField.Properties);
                    currentTableField = textTableField;
                    break;

                case TableFieldType.Time:
                    var timeTableField = fields.Add(new TimeTableField(fieldNo, fieldName));
                    currentProperties.Push(timeTableField.Properties);
                    currentTableField = timeTableField;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(fieldType));
            }

            currentTableField.Container = currentTableFields;
            currentTableField.Enabled = fieldEnabled;
        }

        public override void OnEndTableField()
        {
            currentProperties.Pop();
            currentTableField = null;
        }

        public override void OnBeginTableKey(bool? keyEnabled, string[] keyFields)
        {
            currentTableKey = (currentObject as Table).Keys.Add(new TableKey(keyFields));
            currentTableKey.Enabled = keyEnabled;

            currentProperties.Push(currentTableKey.Properties);
        }

        public override void OnEndTableKey()
        {
            currentProperties.Pop();
            currentTableKey = null;
        }

        public override void OnBeginTableFieldGroup(int fieldGroupID, string fieldGroupName, string[] fieldGroupFields)
        {
            currentTableFieldGroup =
                (currentObject as Table).FieldGroups.Add(new TableFieldGroup(fieldGroupID, fieldGroupName));
            currentTableFieldGroup.Fields.AddRange(fieldGroupFields);
            currentProperties.Push(currentTableFieldGroup.Properties);
        }

        public override void OnEndTableFieldGroup()
        {
            currentProperties.Pop();
            currentTableFieldGroup = null;
        }

        public override void OnBeginFunction(int functionID, string functionName, bool functionLocal)
        {
            currentFunction = currentCode.Functions.Add(new Function(functionID, functionName));
            currentFunction.Local = functionLocal;
        }

        public override void OnEndFunction()
        {
            currentFunction = null;
        }

        public override void OnFunctionAttribute(string name, params string[] values)
        {
            switch (name)
            {
#if NAV2016
                case "TryFunction":
                    currentFunction.TryFunction = true;
                    break;

                case "Business":
                    currentFunction.Event = EventPublisherSubscriber.Publisher;
                    currentFunction.EventType = EventType.Business;
                    currentFunction.IncludeSender = values[0].ToNullableBoolean(Application.CodeStyle.Localization);
                    break;

                case "Integration":
                    currentFunction.Event = EventPublisherSubscriber.Publisher;
                    currentFunction.EventType = EventType.Integration;
                    currentFunction.IncludeSender = values[0].ToNullableBoolean(Application.CodeStyle.Localization);
                    currentFunction.GlobalVarAccess = values[1].ToNullableBoolean(Application.CodeStyle.Localization);
                    break;

                case "EventSubscriber":
                    currentFunction.Event = EventPublisherSubscriber.Subscriber;
                    currentFunction.EventPublisherObject.Type = values[0].ToNullableEnum<ObjectType>();
                    currentFunction.EventPublisherObject.ID = values[1].ToNullableInteger();
                    currentFunction.EventFunction = values[2];
                    currentFunction.EventPublisherElement = values[3];
                    currentFunction.OnMissingLicense = values[4].ToNullableEnum<MissingAction>();
                    currentFunction.OnMissingPermission = values[5].ToNullableEnum<MissingAction>();
                    break;
#endif
                case "TransactionModel":
                    currentFunction.TransactionModel = values[0].ToNullableEnum<TransactionModel>();
                    break;

#if NAV2018
                case "FunctionVisibility":
                    currentFunction.FunctionVisibility = values[0].ToNullableEnum<FunctionVisibility>();
                    break;

                case "ServiceEnabled":
                    currentFunction.ServiceEnabled = true;
                    break;
#endif

#if NAV2017
                case "TestPermissions":
                    currentFunction.TestPermissions = values[0].ToNullableEnum<TestPermissions>();
                    break;
#endif

                case "HandlerFunctions":
                    currentFunction.HandlerFunctions = values[0];
                    break;

                case "Normal":
                    switch ((currentObject as Codeunit).Properties.Subtype)
                    {
                        case CodeunitSubType.Test:
                            currentFunction.TestFunctionType = TestFunctionType.Normal;
                            break;
#if NAV2015
                        case CodeunitSubType.Upgrade:
                            currentFunction.UpgradeFunctionType = UpgradeFunctionType.Normal;
                            break;
#endif
                        default:
#if NAV2019 || NAVBC
                            currentFunction.NormalFunctionType = NormalFunctionType.Normal;
#endif
                            break;
                    }

                    break;

                case "Test":
                case "MessageHandler":
                case "ConfirmHandler":
                case "StrMenuHandler":
                case "PageHandler":
                case "ModalPageHandler":
                case "ReportHandler":
                case "RequestPageHandler":
                case "HyperlinkHandler":
#if NAV2017
                case "SendNotificationHandler":
                case "RecallNotificationHandler":
#endif
                    currentFunction.TestFunctionType = name.ToNullableEnum<TestFunctionType>();
                    break;
#if NAV2015
                case "Upgrade":
                case "TableSyncSetup":
                case "CheckPrecondition":
#if NAV2016
                case "UpgradePerCompany":
                case "UpgradePerDatabase":
#endif
                    currentFunction.UpgradeFunctionType = name.ToNullableEnum<UpgradeFunctionType>();
                    break;
#if NAVBC
                case "LineStart":
                    currentFunction.LineStart = values[0].ToNullableInteger();
                    break;
#endif
#endif
                default:
                    throw new ArgumentOutOfRangeException(GetFormattedTranslatedString("Unknown function type {0}.", name));
            }
        }

        public override void OnVariable(int variableID, string variableName, VariableType variableType,
            string variableSubType, int? variableLength, string variableOptionString, string variableConstValue,
            bool variableTemporary, string variableDimensions, bool variableRunOnClient, bool variableWithEvents,
            string variableSecurityFiltering, bool variableInDataSet, bool supressDispose)
        {
            Variables variables = null;

            switch (currentSectionType)
            {
                case SectionType.ObjectProperties:
                    throw new ApplicationException(GetTranslatedString("No variables expected in object properties section."));
                case SectionType.Properties: // Object-level trigger variable
                case SectionType.Fields: // Field trigger variable
                case SectionType.Controls: // Page control trigger variable
                case SectionType.Elements: // XMLport element trigger variable
                case SectionType.Dataset: // Report element trigger variable
                    variables = currentTrigger.Variables;
                    break;

                case SectionType.Code:
                    if (currentFunction != null)
                        variables = currentFunction.Variables;
                    else if (currentEvent != null)
                        variables = currentEvent.Variables;
                    else
                        variables = currentCode.Variables;

                    break;

                default:
                    throw new ArgumentException(GetFormattedTranslatedString("No variables expected for {0} section.", currentSectionType));
            }

            switch (variableType)
            {
                case VariableType.Action:
                    var actionVariable = variables.Add(new ActionVariable(variableID, variableName));
                    actionVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Automation:
                    var automationVariable =
                        variables.Add(new AutomationVariable(variableID, variableName, variableSubType));
                    automationVariable.Dimensions = variableDimensions;
                    automationVariable.WithEvents = variableWithEvents;
                    break;

                case VariableType.BigInteger:
                    var bigIntegerVariable = variables.Add(new BigIntegerVariable(variableID, variableName));
                    bigIntegerVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.BigText:
                    var bigTextVariable = variables.Add(new BigTextVariable(variableID, variableName));
                    bigTextVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Binary:
                    var binaryVariable = variables.Add(new BinaryVariable(variableID, variableName, variableLength));
                    binaryVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Boolean:
                    var booleanVariable = variables.Add(new BooleanVariable(variableID, variableName));
                    booleanVariable.Dimensions = variableDimensions;
                    booleanVariable.IncludeInDataset = variableInDataSet;
                    break;

                case VariableType.Byte:
                    var byteVariable = variables.Add(new ByteVariable(variableID, variableName));
                    byteVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Char:
                    var charVariable = variables.Add(new CharVariable(variableID, variableName));
                    charVariable.Dimensions = variableDimensions;
                    break;

#if NAV2017
                case VariableType.ClientType:
                    var clientTypeVariable = variables.Add(new ClientTypeVariable(variableID, variableName));
                    clientTypeVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.Code:
                    var codeVariable = variables.Add(new CodeVariable(variableID, variableName, variableLength));
                    codeVariable.Dimensions = variableDimensions;
                    codeVariable.IncludeInDataset = variableInDataSet;
                    break;

                case VariableType.Codeunit:
                    var codeunitVariable =
                        variables.Add(new CodeunitVariable(variableID, variableName, variableSubType.ToInteger()));
                    codeunitVariable.Dimensions = variableDimensions;
                    break;

#if NAV2009
                case VariableType.Dataport:
                    var dataportVariable =
                        variables.Add(new DataportVariable(variableID, variableName, variableSubType.ToInteger()));
                    dataportVariable.Dimensions = variableDimensions;
                    break;
#endif

#if NAV2018
                case VariableType.DataClassification:
                    var dataClassificationVariable = variables.Add(new DataClassificationVariable(variableID, variableName));
                    dataClassificationVariable.Dimensions = variableDimensions;
                    break;
#endif

#if NAVBC
                case VariableType.DataScope:
                    var dataScopeVariable = variables.Add(new DataScopeVariable(variableID, variableName));
                    dataScopeVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.Date:
                    var dateVariable = variables.Add(new DateVariable(variableID, variableName));
                    dateVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.DateFormula:
                    var dateFormulaVariable = variables.Add(new DateFormulaVariable(variableID, variableName));
                    dateFormulaVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.DateTime:
                    var dateTimeVariable = variables.Add(new DateTimeVariable(variableID, variableName));
                    dateTimeVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Decimal:
                    var decimalVariable = variables.Add(new DecimalVariable(variableID, variableName));
                    decimalVariable.Dimensions = variableDimensions;
                    break;

#if NAV2017
                case VariableType.DefaultLayout:
                    var defaultLayoutVariable = variables.Add(new DefaultLayoutVariable(variableID, variableName));
                    defaultLayoutVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.Dialog:
                    var dialogVariable = variables.Add(new DialogVariable(variableID, variableName));
                    dialogVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.DotNet:
                    var dotnetVariable = variables.Add(new DotNetVariable(variableID, variableName, variableSubType));
                    dotnetVariable.Dimensions = variableDimensions;
                    dotnetVariable.RunOnClient = variableRunOnClient;
                    dotnetVariable.WithEvents = variableWithEvents;
                    dotnetVariable.SuppressDispose = supressDispose;
                    break;

                case VariableType.Duration:
                    var durationVariable = variables.Add(new DurationVariable(variableID, variableName));
                    durationVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.ExecutionMode:
                    var executionModeVariable = variables.Add(new ExecutionModeVariable(variableID, variableName));
                    executionModeVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.FieldRef:
                    var fieldRefVariable = variables.Add(new FieldRefVariable(variableID, variableName));
                    fieldRefVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.File:
                    var fileVariable = variables.Add(new FileVariable(variableID, variableName));
                    fileVariable.Dimensions = variableDimensions;
                    break;
#if NAV2016
                case VariableType.FilterPageBuilder:
                    var filterPageBuilderVariable =
                        variables.Add(new FilterPageBuilderVariable(variableID, variableName));
                    filterPageBuilderVariable.Dimensions = variableDimensions;
                    break;
#endif
#if NAV2009
                case VariableType.Form:
                    var formVariable =
                        variables.Add(new FormVariable(variableID, variableName, variableSubType.ToInteger()));
                    formVariable.Dimensions = variableDimensions;
                    break;
#endif
                case VariableType.Guid:
                    var guidVariable = variables.Add(new GuidVariable(variableID, variableName));
                    guidVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.InStream:
                    var instreamVariable = variables.Add(new InStreamVariable(variableID, variableName));
                    instreamVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Integer:
                    var integerVariable = variables.Add(new IntegerVariable(variableID, variableName));
                    integerVariable.Dimensions = variableDimensions;
                    integerVariable.IncludeInDataset = variableInDataSet;
                    break;

                case VariableType.KeyRef:
                    var keyrefVariable = variables.Add(new KeyRefVariable(variableID, variableName));
                    keyrefVariable.Dimensions = variableDimensions;
                    break;

#if NAV2017
                case VariableType.Notification:
                    var notificationVariable = variables.Add(new NotificationVariable(variableID, variableName));
                    notificationVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.NotificationScope:
                    var notificationScopeVariable =
                        variables.Add(new NotificationScopeVariable(variableID, variableName));
                    notificationScopeVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.ObjectType:
                    var objectTypeVariable = variables.Add(new ObjectTypeVariable(variableID, variableName));
                    objectTypeVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.Ocx:
                    var ocxVariable = variables.Add(new OcxVariable(variableID, variableName, variableSubType));
                    ocxVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Option:
                    var optionVariable = variables.Add(new OptionVariable(variableID, variableName));
                    optionVariable.Dimensions = variableDimensions;
                    optionVariable.OptionString = variableOptionString;
                    break;

                case VariableType.OutStream:
                    var outstreamVariable = variables.Add(new OutStreamVariable(variableID, variableName));
                    outstreamVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Page:
                    var pageVariable =
                        variables.Add(new PageVariable(variableID, variableName, variableSubType.ToInteger()));
                    pageVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Query:
                    var queryVariable =
                        variables.Add(new QueryVariable(variableID, variableName, variableSubType.ToInteger()));
                    queryVariable.Dimensions = variableDimensions;
                    queryVariable.SecurityFiltering =
                        variableSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    break;

                case VariableType.Record:
                    var recordVariable =
                        variables.Add(new RecordVariable(variableID, variableName, variableSubType.ToInteger()));
                    recordVariable.Dimensions = variableDimensions;
                    recordVariable.SecurityFiltering =
                        variableSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    recordVariable.Temporary = variableTemporary;
                    break;

                case VariableType.RecordID:
                    var recordIDVariable = variables.Add(new RecordIDVariable(variableID, variableName));
                    recordIDVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.RecordRef:
                    var recordRefVariable = variables.Add(new RecordRefVariable(variableID, variableName));
                    recordRefVariable.Dimensions = variableDimensions;
                    recordRefVariable.SecurityFiltering =
                        variableSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    break;

                case VariableType.Report:
                    var reportVariable =
                        variables.Add(new ReportVariable(variableID, variableName, variableSubType.ToInteger()));
                    reportVariable.Dimensions = variableDimensions;
                    break;
#if NAV2016
                case VariableType.ReportFormat:
                    var reportFormatVariable = variables.Add(new ReportFormatVariable(variableID, variableName));
                    reportFormatVariable.Dimensions = variableDimensions;
                    break;

#if NAV2018
                case VariableType.SessionSettings:
                    var sessionSettingsVariable = variables.Add(new SessionSettingsVariable(variableID, variableName));
                    sessionSettingsVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.TableConnectionType:
                    var tableConnectionTypeVariable =
                        variables.Add(new TableConnectionTypeVariable(variableID, variableName));
                    tableConnectionTypeVariable.Dimensions = variableDimensions;
                    break;
#endif
                case VariableType.TestPage:
                    var testPageVariable =
                        variables.Add(new TestPageVariable(variableID, variableName, variableSubType.ToInteger()));
                    testPageVariable.Dimensions = variableDimensions;
                    break;

#if NAV2017
                case VariableType.TestPermissions:
                    var testPermissionsVariable = variables.Add(new TestPermissionsVariable(variableID, variableName));
                    testPermissionsVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.Text:
                    var textVariable = variables.Add(new TextVariable(variableID, variableName, variableLength));
                    textVariable.Dimensions = variableDimensions;
                    textVariable.IncludeInDataset = variableInDataSet;
                    break;

                case VariableType.TextConst:
                    var textConstant = variables.Add(new TextConstant(variableID, variableName));
                    textConstant.Values.SetMultiLanguageValue(variableConstValue ?? string.Empty);
                    break;
#if NAV2016
                case VariableType.TextEncoding:
                    var textEncodingVariable = variables.Add(new TextEncodingVariable(variableID, variableName));
                    textEncodingVariable.Dimensions = variableDimensions;
                    break;
#endif
                case VariableType.Time:
                    var timeVariable = variables.Add(new TimeVariable(variableID, variableName));
                    timeVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.TransactionType:
                    var transactionTypeVariable = variables.Add(new TransactionTypeVariable(variableID, variableName));
                    transactionTypeVariable.Dimensions = variableDimensions;
                    break;

                case VariableType.Variant:
                    var variantVariable = variables.Add(new VariantVariable(variableID, variableName));
                    variantVariable.Dimensions = variableDimensions;
                    break;

#if NAV2018
                case VariableType.Verbosity:
                    var verbosityVariable = variables.Add(new VerbosityVariable(variableID, variableName));
                    verbosityVariable.Dimensions = variableDimensions;
                    break;
#endif

                case VariableType.XmlPort:
                    var xmlportVariable =
                        variables.Add(new XmlPortVariable(variableID, variableName, variableSubType.ToInteger()));
                    xmlportVariable.Dimensions = variableDimensions;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(variableType));
            }
        }

        public override void OnCodeLine(string codeLine)
        {
            CodeLines codeLines = null;

            switch (currentSectionType)
            {
                case SectionType.ObjectProperties:
                    throw new ApplicationException(GetTranslatedString("No codelines expected in object properties section."));
                case SectionType.Properties:
                case SectionType.Fields:
                case SectionType.Controls:
                case SectionType.Elements:
                case SectionType.Dataset:
                    codeLines = currentTrigger.CodeLines;
                    break;

                case SectionType.Code:
                    if (currentFunction != null)
                        codeLines = currentFunction.CodeLines;
                    else if (currentEvent != null)
                        codeLines = currentEvent.CodeLines;
                    else
                        codeLines = currentCode.Documentation.CodeLines;
                    break;

                case SectionType.RdlData:
                    codeLines = currentRdlData.CodeLines;
                    break;
#if NAV2015
                case SectionType.WordLayout:
                    codeLines = currentWordLayout.CodeLines;
                    break;
#endif
                default:
                    throw new ArgumentException(GetFormattedTranslatedString("No code lines expected for section {0}.", currentSectionType));
            }

            codeLines.Add(codeLine);
        }

        public override void OnParameter(bool parameterVar, int parameterID, string parameterName,
            ParameterType parameterType, string parameterSubType, int? parameterLength, string parameterOptionString,
            bool parameterTemporary, string parameterDimensions, bool parameterRunOnClient,
            string parameterSecurityFiltering, bool parameterSuppressDispose, bool parameterInDataSet = false)
        {
            Parameters parameters = null;

            if (currentFunction != null)
                parameters = currentFunction.Parameters;
            else
                parameters = currentEvent.Parameters;

            Parameter parameter;
            switch (parameterType)
            {
                case ParameterType.Action:
                    parameter = parameters.Add(new ActionParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Automation:
                    parameter = parameters.Add(new AutomationParameter(parameterName, parameterSubType, parameterVar, parameterID));
                    break;

                case ParameterType.BigInteger:
                    parameter = parameters.Add(new BigIntegerParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.BigText:
                    parameter = parameters.Add(new BigTextParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Binary:
                    parameter = parameters.Add(new BinaryParameter(parameterName, parameterVar, parameterID, parameterLength.Value));
                    break;

                case ParameterType.Boolean:
                    parameter = parameters.Add(new BooleanParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Byte:
                    parameter = parameters.Add(new ByteParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Char:
                    parameter = parameters.Add(new CharParameter(parameterName, parameterVar, parameterID));
                    break;

#if NAV2017
                case ParameterType.ClientType:
                    parameter = parameters.Add(new ClientTypeParameter(parameterName, parameterVar, parameterID));
                    break;
#endif

                case ParameterType.Code:
                    parameter = parameters.Add(new CodeParameter(parameterName, parameterVar, parameterID, parameterLength));
                    break;

                case ParameterType.Codeunit:
                    parameter = parameters.Add(new CodeunitParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

                case ParameterType.Date:
                    parameter = parameters.Add(new DateParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.DateFormula:
                    parameter = parameters.Add(new DateFormulaParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.DateTime:
                    parameter = parameters.Add(new DateTimeParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Decimal:
                    parameter = parameters.Add(new DecimalParameter(parameterName, parameterVar, parameterID));
                    break;

#if NAV2017
                case ParameterType.DefaultLayout:
                    parameter = parameters.Add(new DefaultLayoutParameter(parameterName, parameterVar, parameterID));
                    break;
#endif

                case ParameterType.Dialog:
                    parameter = parameters.Add(new DialogParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.DotNet:
                    var dotnetParameter = parameters.Add(new DotNetParameter(parameterName, parameterSubType, parameterVar, parameterID));                    
                    dotnetParameter.RunOnClient = parameterRunOnClient;
                    dotnetParameter.SuppressDispose = parameterSuppressDispose;
                    parameter = dotnetParameter;
                    break;

                case ParameterType.Duration:
                    parameter = parameters.Add(new DurationParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.ExecutionMode:
                    parameter = parameters.Add(new ExecutionModeParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.FieldRef:
                    parameter = parameters.Add(new FieldRefParameter(parameterName, parameterVar, parameterID));                    
                    break;

                case ParameterType.File:
                    parameter = parameters.Add(new FileParameter(parameterName, parameterVar, parameterID));
                    break;
#if NAV2016
                case ParameterType.FilterPageBuilder:
                    parameter = parameters.Add(new FilterPageBuilderParameter(parameterName, parameterVar, parameterID));
                    break;
#endif
                case ParameterType.GUID:
                    parameter = parameters.Add(new GuidParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.InStream:
                    parameter = parameters.Add(new InStreamParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Integer:
                    parameter = parameters.Add(new IntegerParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.KeyRef:
                    parameter = parameters.Add(new KeyRefParameter(parameterName, parameterVar, parameterID));
                    break;

#if NAV2017
                case ParameterType.Notification:
                    parameter = parameters.Add(new NotificationParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.NotificationScope:
                    parameter = parameters.Add(new NotificationScopeParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.ObjectType:
                    parameter = parameters.Add(new ObjectTypeParameter(parameterName, parameterVar, parameterID));
                    break;
#endif

                case ParameterType.Ocx:
                    parameter = parameters.Add(new OcxParameter(parameterName, parameterSubType, parameterVar, parameterID));
                    break;

                case ParameterType.Option:
                    var optionParameter = parameters.Add(new OptionParameter(parameterName, parameterVar, parameterID));                    
                    optionParameter.OptionString = parameterOptionString;
                    parameter = optionParameter;
                    break;

                case ParameterType.OutStream:
                    parameter = parameters.Add(new OutStreamParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Page:
                    parameter = parameters.Add(new PageParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

                case ParameterType.Query:
                    var queryParameter = parameters.Add(new QueryParameter(parameterName, parameterSubType.ToInteger(),
                        parameterVar, parameterID));
                    queryParameter.SecurityFiltering =
                        parameterSecurityFiltering.ToNullableEnum<QuerySecurityFiltering>();
                    parameter = queryParameter;
                    break;

                case ParameterType.Record:
                    var recordParameter = parameters.Add(new RecordParameter(parameterName,
                        parameterSubType.ToInteger(), parameterVar, parameterID));
                    recordParameter.Temporary = parameterTemporary;
                    parameter = recordParameter;
                    break;

                case ParameterType.RecordID:
                    parameter = parameters.Add(new RecordIDParameter(parameterName, parameterVar, parameterID));                    
                    break;

                case ParameterType.RecordRef:
                    var recordRefParameter =
                        parameters.Add(new RecordRefParameter(parameterName, parameterVar, parameterID));
                    recordRefParameter.SecurityFiltering =
                        parameterSecurityFiltering.ToNullableEnum<RecordSecurityFiltering>();
                    parameter = recordRefParameter;
                    break;

                case ParameterType.Report:
                    parameter = parameters.Add(new ReportParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;
#if NAV2016
                case ParameterType.ReportFormat:
                    parameter = parameters.Add(new ReportFormatParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.TableConnectionType:
                    parameter = parameters.Add(new TableConnectionTypeParameter(parameterName, parameterVar, parameterID));
                    break;
#endif
                case ParameterType.TestPage:
                    parameter = parameters.Add(new TestPageParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

#if NAV2017
                case ParameterType.TestPermissions:
                    parameter = parameters.Add(new TestPermissionsParameter(parameterName, parameterVar, parameterID));                    
                    break;
#endif

                case ParameterType.TestRequestPage:
                    parameter = parameters.Add(new TestRequestPageParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

                case ParameterType.Text:
                    parameter = parameters.Add(new TextParameter(parameterName, parameterVar, parameterID, parameterLength));
                    break;
#if NAV2016
                case ParameterType.TextEncoding:
                    parameter = parameters.Add(new TextEncodingParameter(parameterName, parameterVar, parameterID));
                    break;
#endif
                case ParameterType.Time:
                    parameter = parameters.Add(new TimeParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.TransactionType:
                    parameter = parameters.Add(new TransactionTypeParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Variant:
                    parameter = parameters.Add(new VariantParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.XmlPort:
                    parameter = parameters.Add(new XmlPortParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

#if NAV2018
                case ParameterType.DataClassification:
                    parameter = parameters.Add(new DataClassificationParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.SessionSettings:
                    parameter = parameters.Add(new SessionSettingsParameter(parameterName, parameterVar, parameterID));
                    break;

                case ParameterType.Verbosity:
                    parameter = parameters.Add(new VerbosityParameter(parameterName, parameterVar, parameterID));
                    break;
#endif
                case ParameterType.Form:
                    parameter = parameters.Add(new FormParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

                case ParameterType.Dataport:
                    parameter = parameters.Add(new DataportParameter(parameterName, parameterSubType.ToInteger(), parameterVar, parameterID));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(parameterType));
            }
            parameter.Dimensions = parameterDimensions;
            parameter.InDataSet = parameterInDataSet;
        }

        public override void OnReturnValue(string returnValueName, FunctionReturnValueType? returnValueType,
            int? returnValueLength, string returnValueDimensions)
        {
            currentFunction.ReturnValue.Name = returnValueName;
            currentFunction.ReturnValue.Type = returnValueType;
            currentFunction.ReturnValue.DataLength = returnValueLength;
            currentFunction.ReturnValue.Dimensions = returnValueDimensions;
        }

        public override void OnBeginEvent(int sourceID, string sourceName, int eventID, string eventName)
        {
            currentEvent = currentCode.Events.Add(new Event(sourceID, sourceName, eventID, eventName));
        }

        public override void OnEndEvent()
        {
            currentEvent = null;
        }

        public override void OnBeginQueryElement(int elementID, int? elementIndentation, string elementName,
            QueryElementType elementType)
        {
            switch (elementType)
            {
                case QueryElementType.DataItem:
                    var newDataItemQueryElement =
                        currentQueryElements.Add(
                            new DataItemQueryElement(0, elementID, elementName, elementIndentation));
                    currentProperties.Push(newDataItemQueryElement.Properties);
                    break;

                case QueryElementType.Filter:
                    var newFilterQueryElement =
                        currentQueryElements.Add(new FilterQueryElement(null, elementID, elementName,
                            elementIndentation));
                    currentProperties.Push(newFilterQueryElement.Properties);
                    break;

                case QueryElementType.Column:
                    var newColumnQueryElement =
                        currentQueryElements.Add(new ColumnQueryElement(null, elementID, elementName,
                            elementIndentation));
                    currentProperties.Push(newColumnQueryElement.Properties);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(elementType));
            }
        }

        public override void OnEndQueryElement()
        {
            currentProperties.Pop();
        }

        public override void OnBeginPageControl(int controlID, int? controlIndentation, PageControlType controlType)
        {
            switch (controlType)
            {
                case PageControlType.Container:
                    var newContainerPageControl =
                        currentPageControls.Add(new PageControlContainer(controlID, controlIndentation));
                    currentProperties.Push(newContainerPageControl.Properties);
                    break;

                case PageControlType.Group:
                    var newGroupPageControl =
                        currentPageControls.Add(new PageControlGroup(controlID, controlIndentation));
                    currentPageActionList = newGroupPageControl.Properties.ActionList;
                    currentProperties.Push(newGroupPageControl.Properties);
                    break;

                case PageControlType.Field:
                    var newFieldPageControl =
                        currentPageControls.Add(new PageControl(null, controlID, controlIndentation));
                    currentProperties.Push(newFieldPageControl.Properties);
                    break;

                case PageControlType.Part:
                    var newPartPageControl =
                        currentPageControls.Add(new PageControlPart(controlID, controlIndentation));
                    currentProperties.Push(newPartPageControl.Properties);
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(controlType));
            }
        }

        public override void OnEndPageControl()
        {
            currentPageActionList = null;
            currentProperties.Pop();
        }

        public override void OnBeginPageAction(int actionID, int? actionIndentation, PageActionType actionType)
        {
            switch (actionType)
            {
                case PageActionType.ActionContainer:
                    var newPageActionContainer =
                        currentPageActionList.Add(new PageActionContainer(actionIndentation, actionID));
                    currentProperties.Push(newPageActionContainer.Properties);
                    break;

                case PageActionType.ActionGroup:
                    var newPageActionGroup =
                        currentPageActionList.Add(new PageActionGroup(actionID, actionIndentation));
                    currentProperties.Push(newPageActionGroup.Properties);
                    break;

                case PageActionType.Action:
                    var newPageAction = currentPageActionList.Add(new PageAction(actionID, actionIndentation));
                    currentProperties.Push(newPageAction.Properties);
                    break;

                case PageActionType.Separator:
                    var newPageActionSeparator =
                        currentPageActionList.Add(new PageActionSeparator(actionID, actionIndentation));
                    currentProperties.Push(newPageActionSeparator.Properties);
                    break;
            }
        }

        public override void OnEndPageAction()
        {
            currentProperties.Pop();
        }

        public override void OnBeginXmlPortElement(Guid elementID, int? elementIndentation, string elementName,
            XmlPortNodeType elementNodeType, XmlPortSourceType elementSourceType)
        {
            switch (elementSourceType)
            {
                case XmlPortSourceType.Text:
                    switch (elementNodeType)
                    {
                        case XmlPortNodeType.Element:
                            var newTextElementNode =
                                currentXmlPortNodes.Add(new XmlPortTextElement(elementName, elementIndentation,
                                    elementID));
                            currentProperties.Push(newTextElementNode.Properties);
                            break;

                        case XmlPortNodeType.Attribute:
                            var newTextAttributeNode =
                                currentXmlPortNodes.Add(new XmlPortTextAttribute(elementName, elementIndentation,
                                    elementID));
                            currentProperties.Push(newTextAttributeNode.Properties);
                            break;
                    }

                    break;

                case XmlPortSourceType.Table:
                    switch (elementNodeType)
                    {
                        case XmlPortNodeType.Element:
                            var newTableElementNode =
                                currentXmlPortNodes.Add(new XmlPortTableElement(elementName, elementIndentation,
                                    elementID));
                            currentProperties.Push(newTableElementNode.Properties);
                            break;

                        case XmlPortNodeType.Attribute:
                            var newTableAttributeNode =
                                currentXmlPortNodes.Add(new XmlPortTableAttribute(elementName, elementIndentation,
                                    elementID));
                            currentProperties.Push(newTableAttributeNode.Properties);
                            break;
                    }

                    break;

                case XmlPortSourceType.Field:
                    switch (elementNodeType)
                    {
                        case XmlPortNodeType.Element:
                            var newFieldElementNode =
                                currentXmlPortNodes.Add(new XmlPortFieldElement(elementName, elementIndentation,
                                    elementID));
                            currentProperties.Push(newFieldElementNode.Properties);
                            break;

                        case XmlPortNodeType.Attribute:
                            var newFieldAttributeNode =
                                currentXmlPortNodes.Add(new XmlPortFieldAttribute(elementName, elementIndentation,
                                    elementID));
                            currentProperties.Push(newFieldAttributeNode.Properties);
                            break;
                    }

                    break;
            }
        }

        public override void OnEndXmlPortElement()
        {
            currentProperties.Pop();
        }

        public override void OnBeginReportElement(int elementID, int? elementIndentation, string elementName,
            ReportElementType elementType)
        {
            switch (elementType)
            {
                case ReportElementType.DataItem:
                    var newDataItemElement = new DataItemReportElement(null, elementID, elementIndentation) {
                        Name = elementName
                    };
                    currentReportElements.Add(newDataItemElement);
                    currentProperties.Push(newDataItemElement.Properties);
                    break;

                case ReportElementType.Column:
                    var newColumnElement = new ColumnReportElement(elementName, null, elementID, elementIndentation);
                    currentReportElements.Add(newColumnElement);
                    currentProperties.Push(newColumnElement.Properties);
                    break;
            }
        }

        public override void OnEndReportElement()
        {
            currentProperties.Pop();
        }

        public override void OnBeginRequestPage()
        {
            currentProperties.Push(currentRequestPage.Properties);
            currentPageControls = currentRequestPage.Controls;
            currentPageActionList = currentRequestPage.Actions;
        }

        public override void OnEndRequestPage()
        {
            currentProperties.Pop();
            currentPageControls = null;
            currentPageActionList = null;
        }

        public override void OnBeginReportLabel(int labelID, string labelName)
        {
            var newReportLabel = currentReportLabels.Add(new ReportLabel(labelID, labelName));
            currentProperties.Push(newReportLabel.Properties);
        }

        public override void OnEndReportLabel()
        {
            currentProperties.Pop();
        }

        public override void OnBeginMenuSuiteNode(MenuSuiteNodeType nodeType, Guid nodeID)
        {
            switch (nodeType)
            {
                case MenuSuiteNodeType.Root:
                    var newRootNode = currentMenuSuiteNodes.Add(new RootNode(nodeID));
                    currentProperties.Push(newRootNode.Properties);
                    break;

                case MenuSuiteNodeType.Menu:
                    var newMenuNode = currentMenuSuiteNodes.Add(new MenuNode(nodeID));
                    currentProperties.Push(newMenuNode.Properties);
                    break;

                case MenuSuiteNodeType.MenuGroup:
                    var newGroupNode = currentMenuSuiteNodes.Add(new GroupNode(nodeID));
                    currentProperties.Push(newGroupNode.Properties);
                    break;

                case MenuSuiteNodeType.MenuItem:
                    var newItemNode = currentMenuSuiteNodes.Add(new ItemNode(nodeID));
                    currentProperties.Push(newItemNode.Properties);
                    break;

                case MenuSuiteNodeType.Delta:
                    var newDeltaNode = currentMenuSuiteNodes.Add(new DeltaNode(nodeID));
                    currentProperties.Push(newDeltaNode.Properties);
                    break;
            }
        }

        public override void OnEndMenuSuiteNode()
        {
            currentProperties.Pop();
        }

        public override void OnBeginFormControl(int controlId, ClassicControlType controlType, int posX, int posY,
            int width, int height)
        {
            switch (controlType)
            {
                case ClassicControlType.Label:
                    var item = new FormLabelControl(controlId, posX, posY, width, height);
                    currentFormControl = item;
                    var newFormLabel =
                        currentFormControls.Add(item);
                    currentProperties.Push(newFormLabel.Properties);
                    break;
                case ClassicControlType.Image:
                    var item1 = new FormImageControl(controlId, posX, posY, width, height);
                    currentFormControl = item1;
                    var newFormImage =
                        currentFormControls.Add(item1);
                    currentProperties.Push(newFormImage.Properties);
                    break;
                case ClassicControlType.Shape:
                    var item2 = new FormShapeControl(controlId, posX, posY, width, height);
                    currentFormControl = item2;
                    var newFormShape =
                        currentFormControls.Add(item2);
                    currentProperties.Push(newFormShape.Properties);
                    break;
                case ClassicControlType.CommandButton:
                    var item3 = new FormCommandButtonControl(controlId, posX, posY, width, height);
                    currentFormControl = item3;
                    var newFormCommandButton =
                        currentFormControls.Add(item3);
                    currentProperties.Push(newFormCommandButton.Properties);
                    break;
                case ClassicControlType.MenuButton:
                    var item4 = new FormMenuButtonControl(controlId, posX, posY, width, height);
                    currentFormControl = item4;
                    var newFormMenuButton =
                        currentFormControls.Add(item4);
                    currentProperties.Push(newFormMenuButton.Properties);
                    break;
                case ClassicControlType.CheckBox:
                    var item5 = new FormCheckBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item5;
                    var newFormCheckBox =
                        currentFormControls.Add(item5);
                    currentProperties.Push(newFormCheckBox.Properties);
                    break;
                case ClassicControlType.OptionButton:
                    var item6 = new FormOptionButtonControl(controlId, posX, posY, width, height);
                    currentFormControl = item6;
                    var newFormOptionButton =
                        currentFormControls.Add(item6);
                    currentProperties.Push(newFormOptionButton.Properties);
                    break;
                case ClassicControlType.TextBox:
                    var item7 = new FormTextBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item7;
                    var newFormTextBox =
                        currentFormControls.Add(item7);
                    currentProperties.Push(newFormTextBox.Properties);
                    break;
                case ClassicControlType.PictureBox:
                    var item8 = new FormPictureBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item8;
                    var newFormPictureBox =
                        currentFormControls.Add(item8);
                    currentProperties.Push(newFormPictureBox.Properties);
                    break;
                case ClassicControlType.Indicator:
                    var item9 = new FormIndicatorControl(controlId, posX, posY, width, height);
                    currentFormControl = item9;
                    var newFormIndicator =
                        currentFormControls.Add(item9);
                    currentProperties.Push(newFormIndicator.Properties);
                    break;
                case ClassicControlType.Frame:
                    var item10 = new FormFrameControl(controlId, posX, posY, width, height);
                    currentFormControl = item10;
                    var newFormFrame =
                        currentFormControls.Add(item10);
                    currentProperties.Push(newFormFrame.Properties);
                    break;
                case ClassicControlType.TabControl:
                    var item11 = new FormTabControl(controlId, posX, posY, width, height);
                    currentFormControl = item11;
                    var newFormTabControl =
                        currentFormControls.Add(item11);
                    currentProperties.Push(newFormTabControl.Properties);
                    break;
                case ClassicControlType.TableBox:
                    var item12 = new FormTableBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item12;
                    var newFormTableBox =
                        currentFormControls.Add(item12);
                    currentProperties.Push(newFormTableBox.Properties);
                    break;
                case ClassicControlType.MatrixBox:
                    var item13 = new FormMatrixBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item13;
                    var newFormMatrixBox =
                        currentFormControls.Add(item13);
                    currentProperties.Push(newFormMatrixBox.Properties);
                    break;
                case ClassicControlType.SubForm:
                    var item14 = new FormSubFormControl(controlId, posX, posY, width, height);
                    currentFormControl = item14;
                    var newFormSubform =
                        currentFormControls.Add(item14);
                    currentProperties.Push(newFormSubform.Properties);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(controlType), controlType, null);
            }
        }

        public override void OnEndFormControl()
        {
            currentProperties.Pop();
            currentFormControl = null;
        }

        public override void OnBeginFormMenuItem()
        {
            if (!(currentFormControl is FormMenuButtonControl menuControl))
                return;

            if (menuControl.MenuItems == null)
                menuControl.MenuItems = new FormMenuItems() { Form = currentObject as Form };

            currentFormMenuItem = new FormMenuItem(menuControl);
            currentProperties.Push(currentFormMenuItem.Properties);
        }

        public override void OnEndFormMenuItem()
        {
            (currentFormControl as FormMenuButtonControl)?.MenuItems.Add(currentFormMenuItem);
            currentFormMenuItem = null;
            currentProperties.Pop();
        }

        public override void OnBeginDataPortField(int? startPos, int? width, string sourceExpr)
        {
            currentDataportField = new DataportField(startPos, width, sourceExpr);
            currentDataportDataItem.Fields.Add(currentDataportField);
            currentProperties.Push(currentDataportField.Properties);
            
        }

        public override void OnEndDataPortField()
        {
            currentDataportField = null;
            currentProperties.Pop();
        }

        public override void OnBeginRequestForm()
        {
            currentProperties.Push(currentRequestForm.Properties);
            currentFormControls = currentRequestForm.Controls;
        }

        public override void OnEndRequestForm()
        {
            currentProperties.Pop();
            currentFormControls = null;
        }

        public override void OnBeginReportControl(int controlId, ClassicControlType controlType, int posX, int posY,
            int width, int height)
        {
            switch (controlType)
            {
                case ClassicControlType.Label:
                    var item = new ReportLabelControl(controlId, posX, posY, width, height);
                    currentFormControl = item;
                    var newFormLabel = currentFormControls.Add(item);
                    currentProperties.Push(newFormLabel.Properties);
                    break;
                case ClassicControlType.Image:
                    var item2 = new ReportImageControl(controlId, posX, posY, width, height);
                    currentFormControl = item2;
                    var newFormImage = currentFormControls.Add(item2);
                    currentProperties.Push(newFormImage.Properties);
                    break;
                case ClassicControlType.Shape:
                    var item3 = new ReportShapeControl(controlId, posX, posY, width, height);
                    currentFormControl = item3;
                    var newFormShape = currentFormControls.Add(item3);
                    currentProperties.Push(newFormShape.Properties);
                    break;
                case ClassicControlType.TextBox:
                    var item4 = new ReportTextBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item4;
                    var newFormTextBox = currentFormControls.Add(item4);
                    currentProperties.Push(newFormTextBox.Properties);
                    break;
                case ClassicControlType.PictureBox:
                    var item5 = new ReportPictureBoxControl(controlId, posX, posY, width, height);
                    currentFormControl = item5;
                    var newFormPictureBox = currentFormControls.Add(item5);
                    currentProperties.Push(newFormPictureBox.Properties);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(controlType), controlType, null);
            }
        }

        public override void OnEndReportControl()
        {
            currentProperties.Pop();
            currentFormControl = null;
        }

        public override void OnBeginReportDataItem()
        {
            if (!(currentObject is Report))
                return;

            var newDataItem = new DataItem();
            currentProperties.Push(newDataItem.Properties);
            currentReportDataItem = newDataItem;
            currentReportDataItems.Add(newDataItem);
            currentReportSections = newDataItem.Sections;
        }

        public override void OnBeginDataportDataItem()
        {
            if (!(currentObject is Dataport dataport))
                return;

            var newDataItem = new DataportDataItem();
            dataport.DataItems.Add(newDataItem);
            currentProperties.Push(newDataItem.Properties);
            currentDataportDataItem = newDataItem;
        }

        public override void OnEndDataportDataItem()
        {
            currentDataportDataItem = null;
            currentProperties.Pop();
        }

        public override void OnEndReportDataItem()
        {
            currentReportDataItem = null;
            currentReportSections = null;
            currentProperties.Pop();
        }

        public override void OnBeginReportSection()
        {
            if (!(currentObject is Report))
                return;

            currentSection = null;
            sectionBegin = true;
        }

        public override void OnEndReportSection()
        {
            sectionBegin = false;
            currentSection = null;
            currentFormControls = null;
            currentProperties.Pop();
        }

        private static IFormatProvider PrepareFormatProvider(IFormatProvider specifiedProvider) => GlobalFormatProvider.CurrentFormatProvider.ResolveFormatProvider(specifiedProvider);
        private static string GetTranslatedString(string originalString) => GlobalFormatProvider.CurrentFormatProvider.GetTranslatedString(originalString);
        private static string GetFormattedTranslatedString(string originalString, params object[] args) => GlobalFormatProvider.CurrentFormatProvider.GetFormattedTranslatedString(originalString, args);
    }
}