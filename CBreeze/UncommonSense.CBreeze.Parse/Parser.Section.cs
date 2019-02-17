using System;
using System.Linq;
using UncommonSense.CBreeze.Common;

namespace UncommonSense.CBreeze.Parse
{
    public partial class Parser
    {
        internal void ParseSection(Lines lines, ObjectType objectType, bool forceNewFormat = false)
        {
            var match = lines.FirstLineMustMatch(Patterns.SectionSignature);
            var sectionType = match.Groups[1].Value.ToSectionType();

            Listener.OnBeginSection(sectionType);

            lines.FirstLineMustMatch(Patterns.BeginSection);
            lines.LastLineMustMatch(Patterns.EndSection);
            lines.Unindent(2);

            switch (sectionType)
            {
                case SectionType.ObjectProperties:
                    ParseObjectPropertiesSection(lines);
                    break;

                case SectionType.Properties:
                    ParsePropertiesSection(lines);
                    break;

                case SectionType.Fields:
                    switch (objectType)
                    {
                        case ObjectType.Table:
                            ParseTableFieldsSection(lines);
                            break;
                        case ObjectType.Dataport:
                            ParseDataPortFieldsSection(lines);
                            break;
                    }
                    break;

                case SectionType.Keys:
                    ParseKeysSection(lines);
                    break;

                case SectionType.FieldGroups:
                    ParseFieldGroupsSection(lines);
                    break;

                case SectionType.Controls:
                    switch (objectType)
                    {
                        case ObjectType.Page:
                            ParsePageControlsSection(lines);
                            break;
                        case ObjectType.Form:
                            ParseFormControlsSection(lines);
                            break;
                        case ObjectType.Report:
                            if (forceNewFormat)
                            {
                                ParsePageControlsSection(lines);
                            }
                            else
                            {
                                ParseReportControlsSection(lines);
                            }
                            break;
                    }
                    break;


                case SectionType.Elements:
                    switch (objectType)
                    {
                        case ObjectType.Query:
                            ParseQueryElementsSection(lines);
                            break;
                        case ObjectType.XmlPort:
                            ParseXmlPortElementsSection(lines);
                            break;
                    }
                    break;

                case SectionType.Events:
                    break;

                case SectionType.Dataset:
                    ParseDatasetSection(lines);
                    break;

                case SectionType.Labels:
                    ParseLabelsSection(lines);
                    break;

                case SectionType.RdlData:
                    break;

                case SectionType.WordLayout:
                    ParseWordLayoutSection(lines);
                    break;

                case SectionType.Code:
                    ParseCodeSection(lines);
                    break;

                case SectionType.RequestPage:
                    ParseRequestPageSection(lines, objectType);
                    break;

                case SectionType.MenuNodes:
                    ParseMenuNodesSection(lines);
                    break;

                case SectionType.RequestForm:
                    ParseRequestFormSection(lines, objectType);
                    break;

                case SectionType.DataItems:
                    ParseDataItemsSection(lines, objectType);
                    break;

                case SectionType.Sections:
                    ParseSectionsSection(lines, objectType);
                    break;

                default:
                    Exceptions.ThrowException(Exceptions.UnknownSectionType, sectionType);
                    break;
            }

            Listener.OnEndSection();
        }
    }
}

