using System.Windows;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {

        private Auction auction;


        public BidView(Auction auction)
        {
            this.auction = auction;
            this.DataContext = auction;
            this.InitializeComponent();
            this.BidValue.Focus();
        }

        private void PlaceBidButtonClick(object sender, RoutedEventArgs e)
        {
            double newBid = 0;
            if (double.TryParse(this.BidValue.Text, out newBid) && newBid > this.auction.CurrentPrice && !this.auction.IsClosed)
            {
                var memberService = new SimpleMemberService(App.MainRepository);
                var service = new AuctionService(App.MainRepository, memberService);
                service.PlaceBid(this.auction, newBid);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error Placing Bid");
            }
        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
