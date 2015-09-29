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
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
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
            if (double.TryParse(BidValue.Text, out newBid) && newBid > this.auction.CurrentPrice && !this.auction.IsClosed)
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
