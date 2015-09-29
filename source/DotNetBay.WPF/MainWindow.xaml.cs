using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Auction> auctions;

        public ObservableCollection<Auction> Auctions
        {
            get { return auctions; }
            private set { }
        }


        public MainWindow()
        {
            this.DataContext = this;
            var memberService = new SimpleMemberService(App.MainRepository);
            var service = new AuctionService(App.MainRepository, memberService);
            this.auctions = new ObservableCollection<Auction>(service.GetAll());
            this.InitializeComponent();


        }

        private void SellButtonClick(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView {Owner = this};
            sellView.ShowDialog(); // Blocking }
        }

        private void BuyButtonClick(object sender, RoutedEventArgs e)
        {
            var bidView = new BidView(this.dataGrid.SelectedItem as Auction) {Owner = this};
            bidView.ShowDialog();
        }
    }
}