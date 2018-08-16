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
using System.Windows.Shapes;


namespace Program_3
{

    /// <summary>
    /// Interaction logic for FilterDialogue.xaml
    /// </summary>
    public partial class FilterDialogue : Window
    {
        public System.Windows.Forms.DialogResult result;
        public Func<object, bool> choosen;
        public FilterDialogue()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CbxFilter.SelectedIndex != -1)
            {
                result = System.Windows.Forms.DialogResult.OK;
                Close();
            }
            else MessageBox.Show("Please choose an example filter first.\n");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            result = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CbxFilter.SelectedIndex)
            {
                case 0:
                    choosen = (object str) => { return str.ToString().Any(char.IsDigit); };
                    break;
                case 1:
                    choosen = (object str) => { return str.ToString().Contains('s'); };
                    break;
                default:
                    break;
            }
        }
    }
}
