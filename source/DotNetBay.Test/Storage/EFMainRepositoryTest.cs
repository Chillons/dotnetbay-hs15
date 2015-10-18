using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.SqlServer;
using DotNetBay.Interfaces;
using DotNetBay.Data.EF;
using DotNetBay.Data.EF.Migrations;
using NUnit.Framework;

namespace DotNetBay.Test.Storage
{
    [Category("Database")]
    public class EFMainRepositoryTest : MainRepositoryTestBase
    {
        public EFMainRepositoryTest()
        {
            // ROLA - This is a hack to ensure that Entity Framework SQL Provider is copied across to the output folder.
            // As it is installed in the GAC, Copy Local does not work. It is required for probing.
            // Fixed "Provider not loaded" error
            var ensureDLLIsCopied = SqlProviderServices.Instance;

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainDbContext, Configuration>());
        }

        protected override IRepositoryFactory CreateFactory()
        {
            return new EFMainRepositoryFactory();
        }
    }

    public class EFMainRepositoryFactory : IRepositoryFactory
    {
        private readonly List<EFMainRepository> efMainRepositories = new List<EFMainRepository>();

        public void Dispose()
        {
            foreach (var repository in this.efMainRepositories)
            {
                repository.Database.Delete();
            }
        }

        public IMainRepository CreateMainRepository()
        {
            var repository = new EFMainRepository();
            this.efMainRepositories.Add(repository);
            return repository;
        }
    }
}
