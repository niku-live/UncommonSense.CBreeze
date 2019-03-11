using UncommonSense.CBreeze.Core.Form.Contracts;
using UncommonSense.CBreeze.Core.Property.Implementation;

namespace UncommonSense.CBreeze.Core.Form.Control.Properties
{
    public class MatrixBoxProperties : TableBoxProperties, IMatrixBox
    {
        private readonly NullableIntegerProperty _matrixColumnWidth = new NullableIntegerProperty("MatrixColumnWidth");
        private readonly StringProperty _matrixSourceTable = new StringProperty("MatrixSourceTable");

        public MatrixBoxProperties(FormControl formMatrixBoxControl) : base(formMatrixBoxControl)
        {
            innerList.Add(_matrixColumnWidth);
            innerList.Add(_matrixSourceTable);
        }

        public int? MatrixColumnWidth
        {
            get => _matrixColumnWidth.Value;
            set => _matrixColumnWidth.Value = value;
        }

        public string MatrixSourceTable
        {
            get => _matrixSourceTable.Value;
            set => _matrixSourceTable.Value = value;
        }
    }
}