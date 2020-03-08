using Microsoft.EntityFrameworkCore;
using SAS.Api.v2.Infrastructure.EntityConfigurations;

namespace SAS.Api.v2.Infrastructure
{
    public class DomainContext : DbContext
    {
        public DomainContext()
        {
        }

        public DomainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new GoodsEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
