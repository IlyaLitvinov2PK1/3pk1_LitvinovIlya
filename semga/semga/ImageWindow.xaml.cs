using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace semga
{
    /// <summary>
    /// Логика взаимодействия для ImageWindow.xaml
    /// </summary>
    public partial class ImageWindow : Window
    {
        private string filePath;
        private bool isTextChanged;
        public ImageWindow()
        {
            InitializeComponent();
        }

        private void Back_Bt_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Bt_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "savedimage"; // Default file name
            dlg.DefaultExt = ".jpg"; // Default file extension
            dlg.Filter = "Image (.jpg)|*.jpg"; // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                //get the dimensions of the ink control
                int margin = (int)this.IK1.Margin.Left;
                int width = (int)this.IK1.ActualWidth - margin;
                int height = (int)this.IK1.ActualHeight - margin;
                //render ink to bitmap
                RenderTargetBitmap rtb =
                new RenderTargetBitmap(width, height, 94d, 92d, PixelFormats.Default);
                rtb.Render(IK1);

                using (FileStream fs = new FileStream(filename, FileMode.Create))
                {
                    BmpBitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(rtb));
                    encoder.Save(fs);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (IK1.EditingMode == InkCanvasEditingMode.Ink) IK1.EditingMode = InkCanvasEditingMode.EraseByPoint;
            else IK1.EditingMode = InkCanvasEditingMode.Ink;
        }
    }
    
    
}
