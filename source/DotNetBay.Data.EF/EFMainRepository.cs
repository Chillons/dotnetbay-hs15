using System;
using System.Data.Entity;
using System.Linq;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    public class EFMainRepository : IMainRepository
    {
        private readonly MainDbContext context;

        public EFMainRepository()
        {
            this.context = new MainDbContext();
        }

        public Database Database
        {
            get { return this.context.Database; }
        }

        public IQueryable<Auction> GetAuctions()
        {
            return this.context.Auctions.Include(a => a.Bids).Include(a => a.Seller).Include(a => a.ActiveBid).Include(a => a.Winner);
        }

        public IQueryable<Member> GetMembers()
        {
            return this.context.Members.Include(m => m.Auctions);
        }

        public Auction Add(Auction auction)
        {
            this.context.Auctions.Add(auction);

            return auction;
        }

        public Auction Update(Auction auction)
        {
            return auction;
        }

        public Bid Add(Bid bid)
        {
            this.context.Bids.Add(bid);

            return bid;
        }

        public Bid GetBidByTransactionId(Guid transactionId)
        {
            return this.context.Bids.FirstOrDefault(b => b.TransactionId == transactionId);
        }

        public Member Add(Member member)
        {
            this.context.Members.Add(member);

            return member;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
