using System;
using SERPAutoFulfillment.Styles;
using Xamarin.Forms;

namespace SERPAutoFulfillment.Helpers
{
    public class ListViewAlternatingRowProcessor
    {
        private bool _isEvenRow;
        private readonly Color _evenRowColor;
        private readonly Color _oddRowColor;
        private readonly Color _tappedColor;

        private ViewCell _previouslyTappedCell = null;
        private Color? _previouslyTappedCellNaturalBackColor;

        public ListViewAlternatingRowProcessor() : this(AppStyles.EvenRowBackground, AppStyles.OddRowBackground, AppStyles.TappedRowBackground)
        {

        }

        public ListViewAlternatingRowProcessor(Color evenBackColor, Color oddBackColor, Color tappedColor)
        {
            _evenRowColor = evenBackColor;
            _oddRowColor = oddBackColor;
            _tappedColor = tappedColor;
        }

        public void SetBackColor(object viewCellSender)
        {
            var viewCell = (ViewCell)viewCellSender;

            Color bg = _oddRowColor;

            viewCell.Tapped += ViewCell_Tapped;

            if (_isEvenRow)
            {
                bg = _evenRowColor;
            }

            _isEvenRow = !_isEvenRow;

            if (viewCell.View != null)
            {
                viewCell.View.BackgroundColor = bg;

            }
        }

        private void ViewCell_Tapped(object sender, EventArgs e)
        {
            var viewCell = (ViewCell)sender;

            if (_previouslyTappedCellNaturalBackColor.HasValue)
            {
                _previouslyTappedCell.View.BackgroundColor = _previouslyTappedCellNaturalBackColor.Value;
            }

            if (viewCell.View != null)
            {
                _previouslyTappedCellNaturalBackColor = viewCell.View.BackgroundColor;
                viewCell.View.BackgroundColor = _tappedColor;

                _previouslyTappedCell = viewCell;
            }
        }
    }

}
