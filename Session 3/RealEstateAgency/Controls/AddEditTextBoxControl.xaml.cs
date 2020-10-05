using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealEstateAgency.Controls
{
    /// <summary>
    /// Interaction logic for AddEditTextBoxControl.xaml
    /// </summary>
    public partial class AddEditTextBoxControl : UserControl
    {
        public static readonly DependencyProperty TitlePrperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AddEditTextBoxControl));
        public static readonly DependencyProperty MaxLengthPrperty =
            DependencyProperty.Register("MaxLength", typeof(int), typeof(AddEditComboBoxControl));
        public static readonly DependencyProperty InputTextPrperty =
            DependencyProperty.Register("InputText", typeof(string), typeof(AddEditTextBoxControl));
        public AddEditTextBoxControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Title 
        {
            get => (string)GetValue(TitlePrperty);
            set => SetValue(TitlePrperty, value);
        }
        public int MaxLength
        {
            get => (int)GetValue(MaxLengthPrperty);
            set => SetValue(MaxLengthPrperty, value);
        }
        public string InputText
        {
            get => (string)GetValue(InputTextPrperty);
            set => SetValue(InputTextPrperty, value);
        }

        public string TextBoxText
        {
            get => inputTextBox.Text;
            set => inputTextBox.Text = value;
        }
    }
}
