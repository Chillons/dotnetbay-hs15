using System.Collections.ObjectModel;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<Auction> auctions;

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
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
            var sellView = new View.SellView {Owner = this};
            sellView.ShowDialog(); // Blocking }
        }

        private void BuyButtonClick(object sender, RoutedEventArgs e)
        {
            var bidView = new View.BidView(this.dataGrid.SelectedItem as Auction) {Owner = this};
            bidView.ShowDialog();
        }
    }
}