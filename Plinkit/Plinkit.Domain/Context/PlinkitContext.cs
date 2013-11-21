using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Plinkit.Domain.Models;
using Plinkit.Domain.Enums;
using Plinkit.Domain.Models.Links;

namespace Plinkit.Domain.Context
{
    public interface IPlinkitContext : IDisposable
    {
        IDbSet<DailyLinksContainer> DailyLinksContainers { get; set; }
        IDbSet<DailyLink> DailyLinks { get; set; }
    }

    public class PlinkitContext : DbContext, IPlinkitContext
    {
        public IDbSet<DailyLinksContainer> DailyLinksContainers { get; set; }
        public IDbSet<DailyLink> DailyLinks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<DailyLink>()
                .Map<WebDevelopmentLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.WebDevelopment))
                .Map<EntityFrameworkLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.EntityFramework))
                .Map<VisualStudioLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.VisualStudio))
                .Map<JavascriptLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.Javascript))
                .Map<CleanCodeLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.CleanCode))
                .Map<ProductivityLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.Productivity))
                .Map<UnitTestingLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.UnitTesting))
                .Map<ComputerScienceLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.ComputerScience))
                .Map<FunctionalProgrammingAndFSharpLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.FunctionalProgrammingAndFSharp))
                .Map<ComputingTechnologyLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.ComputingTechnology))
                .Map<UncleBobLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.UncleBob))
                .Map<UndefinedLink>(l => l.Requires("CategoryId").HasValue((int)LinkCategories.Undefined));
        }
    }
}
