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


namespace SimCorpProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string text1 = System.IO.File.ReadAllText("c:\\users\\pamet_000\\documents\\visual studio 2013\\Projects\\SimCorpProgram\\SimCorpProgram\\SimCorp.txt");
            TextBoxFile.Text = text1;  
        }

       
        //counting method
        private void Count(string content)
        {
                       
            //to lower
            string text1 =content.ToLower();
            
            //string to a List
            List<string> Words = text1.Split(' ').ToList();
           
            //list to a diccionary
            Dictionary<string, int> Book = new Dictionary<string, int>();

            foreach(string word in Words)
             {
              if(Book.ContainsKey(word))
                 {
                     Book[word]++;
                  }
              else
                 {
                     Book[word] = 1;
                  }
              
              }


            // to print
            var print=Book.Select(q=>q.Value.ToString()+": "+q.Key);
            TextBoxResult.Text = string.Join(Environment.NewLine, print);
            

        }

        //count button
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFile.IsReadOnly = true;
            
            //read text as string
            string text1 = System.IO.File.ReadAllText("c:\\users\\pamet_000\\documents\\visual studio 2013\\Projects\\SimCorpProgram\\SimCorpProgram\\SimCorp.txt");
           
            //use Count method
            Count(text1);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TextBoxFile.IsReadOnly = false;
            
        }

        private void TextBoxFile_TextChanged(object sender, TextChangedEventArgs e)
        {
            string newContent = TextBoxFile.Text;
            System.IO.StreamWriter obj = new System.IO.StreamWriter("c:\\users\\pamet_000\\documents\\visual studio 2013\\Projects\\SimCorpProgram\\SimCorpProgram\\SimCorp.txt");
            obj.Write(newContent);
            obj.Close();
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
