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
using System.Windows.Forms;
using System.IO;

namespace Program_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IOutput output;
        private IOutput previewOutput;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenMenu_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Filter = "Dat files (*.dat)|*.dat"
            };
            if(open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    Stream source = open.OpenFile();
                    using (StreamReader writer = new StreamReader(source))
                    {
                        txtSource.Text = writer.ReadToEnd();
                       // txtPreview.Text = txtSource.Text;
                    }
                    System.Windows.MessageBox.Show("Please choose where you would like this to be output to.");
                    SaveFileDialog save = new SaveFileDialog();
                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        output = new StreamOutput(save.OpenFile());
                    }
                }
                catch
                {
                    System.Windows.MessageBox.Show("Could not open the file for some reason. Sorry.");
                }
            }
        }

        private void ExitMenu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(@"Demonstrates use of decorator pattern.
Buttons add the appropriate decorator to the current stream.
If no stream is currently open, nothing will be done.
Run will output the result of the decorators.
Choose the Open option for a source. Otherwise nothing will be printed.", "About", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnLine_Click(object sender, RoutedEventArgs e)
        {
            if(output != null)
            {
                output = new LineDecorator(output);
            }
            else
            {
                System.Windows.MessageBox.Show("You must choose an output before attempting to add decorators.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnNumber_Click(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                output = new NumberDecorator(output);
            }
            else
            {
                System.Windows.MessageBox.Show("You must choose an output before attempting to add decorators.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnFilter_Click(object sender, RoutedEventArgs e)
        {
            if (output != null)
            {
                FilterDialogue filterDialogue = new FilterDialogue();
                filterDialogue.ShowDialog();
                if (filterDialogue.result == System.Windows.Forms.DialogResult.OK)
                    output = new FilterDecorator(output, filterDialogue.choosen);
            }
            else
            {
                System.Windows.MessageBox.Show("You must choose an output before attempting to add decorators.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnTee_Click(object sender, RoutedEventArgs e)
        {
            if(output != null)
            {
                System.Windows.MessageBox.Show("Please choose where you would like the second stream to be saved to.");
                try
                {
                    SaveFileDialog save = new SaveFileDialog();
                    if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        StreamOutput second = new StreamOutput(save.OpenFile());
                        output = new TeeDecorator(output, second);
                    }
                }
                catch
                {
                    System.Windows.MessageBox.Show("Could not open the file. Sorry.");
                }
            }
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            //txtPreview.Text = "";
            txtSource.Text = "";
            output = null;
        }

        private void BtnRun_Click(object sender, RoutedEventArgs e)
        {
            ReadOperation(output);
        }
        private void ReadOperation(IOutput output)
        {
            if (output == null)
            {
                return;
            }
            StringReader reader = new StringReader(txtSource.Text);
            string result;
            while(null != (result = reader.ReadLine()))
            {
                output.WriteString(result);
            }
        }
    }
}
