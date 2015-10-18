using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetBay.Interfaces;
using DotNetBay.Data.EF;

namespace DotNetBay.Test.Storage
{
    class EFMainRepositoryTest : MainRepositoryTestBase
    {
        protected override IRepositoryFactory CreateFactory()
        {
            throw new NotImplementedException();
        }
    }

    public class EFMainRepositoryFactory : IRepositoryFactory
    {
        private List<EFMainRepository> efMainRepositories;

        public void Dispose()
        {
            foreach (var repository in efMainRepositories)
            {
                repository.Database.Delete();
            }
        }

        public IMainRepository CreateMainRepository()
        {
            var repository = new EFMainRepository();
            efMainRepositories.Add(repository);
            return repository;
        }
    }
}
