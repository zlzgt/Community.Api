using EInfrastructure.Core.Config.EntitiesExtensions;
using Castle.Windsor.Diagnostics;
using EInfrastructure.Core.Configuration.Ioc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Threading;
using EInfrastructure.Core.MySql;
using System.Linq;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
namespace Community.Domain
{
    public class CommunityDbContext : DbContext, IUnitOfWork, IPerRequest
    {
        private readonly AppConfig _appConfig;

        public CommunityDbContext()
        {

        }

        public CommunityDbContext(AppConfig appconfig)
        {
            _appConfig = appconfig;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;port=3306;database=deyouyun_community_buy_dev;uid=root;pwd=root;", w => w.MaxBatchSize(30));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.AutoMap(typeof(CommunityDbContext));

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(decimal)))
            {

                // property.().ColumnType = "decimal(18, 2)";
            }
        }

        public bool Commit()
        {
            int iResult = this.SaveChanges();
            if (iResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public class AppConfig
        {
            // <summary>
            /// mySql connection string
            /// </summary>
            public string DbConn { get; set; } = "Server=localhost;port=3306;database=deyouyun_community_buy_dev;uid=root;pwd=root;";

            /// <summary>
            /// enable mysql log
            /// </summary>
            public bool EnableDebug { get; set; }

            /// <summary>
            /// 服务名称
            /// </summary>
            public string ServiceName { get; set; }

            /// <summary>
            /// 是否启用任务
            /// </summary>
            public bool RunTask { get; set; } = false;

            /// <summary>
            /// 启用服务发现
            /// </summary>
            public bool ServiceDiscovery { get; set; }

        }
    }


}
