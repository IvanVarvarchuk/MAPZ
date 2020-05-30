using Interpreter24.LexicalAnalize;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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

namespace Interpreter24
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ObservableCollection<int> Lines;

        private void SynchroScroll(object sender, ScrollChangedEventArgs e) 
        {
            if (sender == CodeEditor)
                LineNumbers.ScrollIntoView(e.VerticalChange);
            else
                CodeEditor.ScrollToVerticalOffset(e.VerticalOffset);
        }

        private void CodeEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            var linesCount = CodeEditor.Text.Split('\n').Count();
            Lines = new ObservableCollection<int>(Enumerable.Range(1, linesCount));
            LineNumbers.ItemsSource = Lines;
            LineNumbers.ScrollIntoView(linesCount);
        }

        private void Run_Click(object sender, RoutedEventArgs e)
        {
            var lexer = new Lexer(CodeEditor.Text);
            var tokensStr = new StringBuilder();
            var tokens = lexer.Tokenize();
           
            foreach (var token in tokens)
            {
                tokensStr.Append(token.ToString());
            }

            Result.Text = tokensStr.ToString();
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                CodeEditor.Text = String.Empty;
                CodeEditor.Text = File.ReadAllText(filename);
            }
        }
    }
}
