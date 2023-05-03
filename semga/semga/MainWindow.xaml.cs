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

namespace semga
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Bt_Click(object sender, RoutedEventArgs e)
        {
          
            Add_Bt.Visibility = Visibility.Hidden;
            AddImage_Bt.Visibility = Visibility.Visible;
            AddText_Bt.Visibility = Visibility.Visible;
        }

        private void AddText_Bt_Click(object sender, RoutedEventArgs e)
        {
            TextWindow text = new TextWindow();
            text.Show();
        }

        private void AddImage_Bt_Click(object sender, RoutedEventArgs e)
        {
            ImageWindow image = new ImageWindow();
            image.Show();
        }
    }
}
