using System;
using System.Windows;
using Microsoft.Win32;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        public SellView()
        {
            this.InitializeComponent();
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClickSelectImage(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (dialog.ShowDialog() == true)
            {
                this.ImagePath.Text = dialog.FileName;
            }
        }

        private void AddAuctionClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
