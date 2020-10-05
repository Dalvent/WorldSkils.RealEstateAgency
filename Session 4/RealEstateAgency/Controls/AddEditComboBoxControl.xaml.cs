using System;
using System.Collections;
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
    /// Interaction logic for AddEditComboBoxControl.xaml
    /// </summary>
    public partial class AddEditComboBoxControl : UserControl
    {
        public static readonly DependencyProperty TitlePrperty =
            DependencyProperty.Register("Title", typeof(string), typeof(AddEditComboBoxControl));
        public static readonly DependencyProperty SelectedValuePrperty =
            DependencyProperty.Register("SelectedValue", typeof(object), typeof(AddEditComboBoxControl));
        public AddEditComboBoxControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Title
        {
            get => (string)GetValue(TitlePrperty);
            set => SetValue(TitlePrperty, value);
        }
        public object SelectedValue
        {
            get => GetValue(SelectedValuePrperty);
            set => SetValue(SelectedValuePrperty, value);
        }

        public IEnumerable ItemsSource
        {
            get => inputComboBox.ItemsSource;
            set => inputComboBox.ItemsSource = value;
        }
    }
}
