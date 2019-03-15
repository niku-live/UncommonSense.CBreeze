using System.Drawing;
using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Enumeration;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class PictureBoxProperties : BaseControlBaseProperties2, IPictureBox
    {
        public PictureBoxProperties(FormControl formPictureBoxControl) : base(formPictureBoxControl)
        {
        }

        public Color? BorderColor
        {
            get => InternalBorderColor;
            set => InternalBorderColor = value;
        }

        public BorderWidth? BorderWidth
        {
            get => InternalBorderWidth;
            set => InternalBorderWidth = value;
        }

        public string SourceExpr
        {
            get => InternalSourceExpr;
            set => InternalSourceExpr = value;
        }

        public bool? AutoCalcField
        {
            get => InternalAutoCalcField;
            set => InternalAutoCalcField = value;
        }

        public string DataSetFieldName
        {
            get => InternalDataSetFieldName;
            set => InternalDataSetFieldName = value;
        }

        public string BitmapList
        {
            get => InternalBitmapList;
            set => InternalBitmapList = value;
        }

        public BitmapPos? BitmapPos
        {
            get => InternalBitmapPos;
            set => InternalBitmapPos = value;
        }
    }
}