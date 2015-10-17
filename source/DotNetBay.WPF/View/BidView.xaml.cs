using System.Windows;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {
        public BidView(Auction auction)
        {
            var app = Application.Current as App;

            var memberService = new SimpleMemberService(app.MainRepository);
            var auctionService = new AuctionService(app.MainRepository, memberService);

            this.DataContext = new BidViewModel(auction, memberService, auctionService);
        }
    }
}
