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
            throw new NotImplementedException();
        }

        public IQueryable<Member> GetMembers()
        {
            throw new NotImplementedException();
        }

        public Auction Add(Auction auction)
        {
            throw new NotImplementedException();
        }

        public Auction Update(Auction auction)
        {
            throw new NotImplementedException();
        }

        public Bid Add(Bid bid)
        {
            throw new NotImplementedException();
        }

        public Bid GetBidByTransactionId(Guid transactionId)
        {
            throw new NotImplementedException();
        }

        public Member Add(Member member)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
