using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class MatrixBoxProperties : TableBoxProperties, IMatrixBox
    {
        public MatrixBoxProperties(FormControl formMatrixBoxControl) : base(formMatrixBoxControl)
        {
        }

        public int? MatrixColumnWidth
        {
            get => InternalMatrixColumnWidth;
            set => InternalMatrixColumnWidth = value;
        }

        public string MatrixSourceTable
        {
            get => InternalMatrixSourceTable;
            set => InternalMatrixSourceTable = value;
        }
    }
}