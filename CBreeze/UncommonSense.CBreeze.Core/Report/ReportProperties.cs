using UncommonSense.CBreeze.Core.Code.Variable;
using UncommonSense.CBreeze.Core.Contracts;
using UncommonSense.CBreeze.Core.MenuSuite;
using UncommonSense.CBreeze.Core.Property;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;
using UncommonSense.CBreeze.Core.Property.Type;

namespace UncommonSense.CBreeze.Core.Report
{
    public class ReportProperties : Properties
    {
#if NAVBC || NAV2019
        private AccessByPermissionProperty accessByPermission = new AccessByPermissionProperty("AccessByPermission");
        private TagListProperty applicationArea = new TagListProperty("ApplicationArea");
#endif    
        private MultiLanguageProperty captionML = new MultiLanguageProperty("CaptionML");
#if NAV2015
        private DefaultLayoutProperty defaultLayout = new DefaultLayoutProperty("DefaultLayout");
#endif
        private StringProperty description = new StringProperty("Description");
        private NullableBooleanProperty enableExternalAssemblies = new NullableBooleanProperty("EnableExternalAssemblies");
        private NullableBooleanProperty enableExternalImages = new NullableBooleanProperty("EnableExternalImages");
        private NullableBooleanProperty enableHyperlinks = new NullableBooleanProperty("EnableHyperlinks");
        private TriggerProperty onInitReport = new TriggerProperty("OnInitReport");
        private TriggerProperty onPostReport = new TriggerProperty("OnPostReport");
        private TriggerProperty onPreReport = new TriggerProperty("OnPreReport");
        private PaperSourceProperty paperSourceDefaultPage = new PaperSourceProperty("PaperSourceDefaultPage");
        private PaperSourceProperty paperSourceFirstPage = new PaperSourceProperty("PaperSourceFirstPage");
        private PaperSourceProperty paperSourceLastPage = new PaperSourceProperty("PaperSourceLastPage");
        private NullableBooleanProperty pdfFontEmbedding = new NullableBooleanProperty("PDFFontEmbedding");
        private PermissionsProperty permissions = new PermissionsProperty("Permissions");
#if NAV2015
        private PreviewModeProperty previewMode = new PreviewModeProperty("PreviewMode");
#endif
        private NullableBooleanProperty processingOnly = new NullableBooleanProperty("ProcessingOnly");
        private NullableBooleanProperty showPrintStatus = new NullableBooleanProperty("ShowPrintStatus");
        private TransactionTypeProperty transactionType = new TransactionTypeProperty("TransactionType");
#if NAVBC || NAV2019
        private UsageCategoryProperty usageCategory = new UsageCategoryProperty("UsageCategory");
#endif
        private NullableBooleanProperty useRequestPage = new NullableBooleanProperty("UseRequestPage");
        private NullableBooleanProperty useSystemPrinter = new NullableBooleanProperty("UseSystemPrinter");
#if NAV2015
        private StringProperty wordMergeDataItem = new StringProperty("WordMergeDataItem");
#endif
#if NAV2009
        private ClassicReportOrientationProperty orientation = new ClassicReportOrientationProperty("Orientation");
        private NullableIntegerProperty topMargin = new NullableIntegerProperty("TopMargin");
        private NullableIntegerProperty bottomMargin = new NullableIntegerProperty("BottomMargin");
        private NullableIntegerProperty leftMargin = new NullableIntegerProperty("LeftMargin");
        private NullableIntegerProperty rightMargin = new NullableIntegerProperty("RightMargin");
        private NullableIntegerProperty horzGrid = new NullableIntegerProperty("HorzGrid");
        private NullableIntegerProperty vertGrid = new NullableIntegerProperty("VertGrid");
        private StringProperty paperSize = new StringProperty("PaperSize");
        private NullableBooleanProperty useReqForm = new NullableBooleanProperty("UseReqForm");
#endif

        internal ReportProperties(Report report)
        {
            Report = report;

            innerList.Add(permissions);
            innerList.Add(transactionType);
#if NAVBC || NAV2019
            innerList.Add(accessByPermission);
#endif
            innerList.Add(captionML);
#if NAVBC || NAV2019
            innerList.Add(applicationArea);
#endif
            innerList.Add(description);
            innerList.Add(showPrintStatus);
            innerList.Add(useSystemPrinter);
#if NAV2009
            innerList.Add(useReqForm);
            innerList.Add(topMargin);
            innerList.Add(bottomMargin);
            innerList.Add(leftMargin);
            innerList.Add(rightMargin);
#endif
            innerList.Add(processingOnly);
            innerList.Add(enableExternalImages);
            innerList.Add(enableHyperlinks);
            innerList.Add(enableExternalAssemblies);
            innerList.Add(onInitReport);
            innerList.Add(onPreReport);
            innerList.Add(onPostReport);
            innerList.Add(paperSourceDefaultPage);
            innerList.Add(paperSourceFirstPage);
            innerList.Add(paperSourceLastPage);
#if NAV2015
            innerList.Add(previewMode);
            innerList.Add(defaultLayout);
#endif
            innerList.Add(useRequestPage);
#if NAV2015
            innerList.Add(wordMergeDataItem);
#endif
#if NAVBC || NAV2019
            innerList.Add(pdfFontEmbedding);
            innerList.Add(usageCategory);
#endif
#if NAV2009
            innerList.Add(orientation);
            innerList.Add(paperSize);
            innerList.Add(horzGrid);
            innerList.Add(vertGrid);
#endif
        }

        public Report Report { get; protected set; }

        public override INode ParentNode => Report;

#if NAVBC || NAV2019
        public AccessByPermission AccessByPermission => accessByPermission.Value;
        public TagList ApplicationArea => applicationArea.Value;    
#endif

        public MultiLanguageValue CaptionML
        {
            get
            {
                return captionML.Value;
            }
        }

#if NAV2015
        public DefaultLayout? DefaultLayout
        {
            get
            {
                return defaultLayout.Value;
            }
            set
            {
                defaultLayout.Value = value;
            }
        }
#endif

        public string Description
        {
            get
            {
                return description.Value;
            }
            set
            {
                description.Value = value;
            }
        }

        public bool? EnableExternalAssemblies
        {
            get
            {
                return enableExternalAssemblies.Value;
            }
            set
            {
                enableExternalAssemblies.Value = value;
            }
        }

        public bool? EnableExternalImages
        {
            get
            {
                return enableExternalImages.Value;
            }
            set
            {
                enableExternalImages.Value = value;
            }
        }

        public bool? EnableHyperlinks
        {
            get
            {
                return enableHyperlinks.Value;
            }
            set
            {
                enableHyperlinks.Value = value;
            }
        }

        public Trigger OnInitReport
        {
            get
            {
                return onInitReport.Value;
            }
        }

        public Trigger OnPostReport
        {
            get
            {
                return onPostReport.Value;
            }
        }

        public Trigger OnPreReport
        {
            get
            {
                return onPreReport.Value;
            }
        }

        public PaperSource? PaperSourceDefaultPage
        {
            get
            {
                return paperSourceDefaultPage.Value;
            }
            set
            {
                paperSourceDefaultPage.Value = value;
            }
        }

        public PaperSource? PaperSourceFirstPage
        {
            get
            {
                return paperSourceFirstPage.Value;
            }
            set
            {
                paperSourceFirstPage.Value = value;
            }
        }

        public PaperSource? PaperSourceLastPage
        {
            get
            {
                return paperSourceLastPage.Value;
            }
            set
            {
                paperSourceLastPage.Value = value;
            }
        }

        public bool? PDFFontEmbedding
        {
            get => pdfFontEmbedding.Value;
            set => pdfFontEmbedding.Value = value;
        }

        public Permissions Permissions
        {
            get
            {
                return permissions.Value;
            }
        }

#if NAV2015
        public PreviewMode? PreviewMode
        {
            get
            {
                return previewMode.Value;
            }
            set
            {
                previewMode.Value = value;
            }
        }
#endif

        public bool? ProcessingOnly
        {
            get
            {
                return processingOnly.Value;
            }
            set
            {
                processingOnly.Value = value;
            }
        }

        public bool? ShowPrintStatus
        {
            get
            {
                return showPrintStatus.Value;
            }
            set
            {
                showPrintStatus.Value = value;
            }
        }

        public TransactionType? TransactionType
        {
            get
            {
                return transactionType.Value;
            }
            set
            {
                transactionType.Value = value;
            }
        }

#if NAVBC || NAV2019
        public UsageCategory? UsageCategory
        {
            get => usageCategory.Value;
            set => usageCategory.Value = value;
        }
#endif

        public bool? UseRequestPage
        {
            get
            {
                return useRequestPage.Value;
            }
            set
            {
                useRequestPage.Value = value;
            }
        }

        public bool? UseSystemPrinter
        {
            get
            {
                return useSystemPrinter.Value;
            }
            set
            {
                useSystemPrinter.Value = value;
            }
        }

#if NAV2015
        public string WordMergeDataItem
        {
            get
            {
                return wordMergeDataItem.Value;
            }
            set
            {
                wordMergeDataItem.Value = value;
            }
        }
#endif
#if NAV2009
        public ClassicReportOrientation? Orientation
        {
            get => orientation.Value;
            set => orientation.Value = value;
        }

        public int? TopMargin
        {
            get => topMargin.Value;
            set => topMargin.Value = value;
        }

        public int? BottomMargin
        {
            get => bottomMargin.Value;
            set => bottomMargin.Value = value;
        }

        public int? LeftMargin
        {
            get => leftMargin.Value;
            set => leftMargin.Value = value;
        }

        public int? RightMargin
        {
            get => rightMargin.Value;
            set => rightMargin.Value = value;
        }

        public int? HorzGrid
        {
            get => horzGrid.Value;
            set => horzGrid.Value = value;
        }

        public int? VertGrid
        {
            get => vertGrid.Value;
            set => vertGrid.Value = value;
        }

        public string PaperSize
        {
            get => paperSize.Value;
            set => paperSize.Value = value;
        }

        public bool? UseReqForm
        {
            get => useReqForm.Value;
            set => useReqForm.Value = value;
        }
#endif
    }
}
