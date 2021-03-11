using Entities;
using System.Data.Entity;
using MvcKurumsalSite.DataAccess.Migrations;

namespace MvcKurumsalSite.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
            /*Database.SetInitializer(new DatabaseInitializer());
             * Veritabanını silip yeniden oluşturma işlemi yerine sadece model class larımızda yapılan değişiklikleri veritabanına yansıtmak için yukardaki kod satırını yorum satırı haline getiriyoruz
             * Vs üst menüden View > other windows > package manager console yolunu takip ederek ilgili pencereyi açıyoruz.
             * açılan pencerede database context in olduğu projeyi seçiyoruz(Bizde dataaccess) böylece yazacağımız kodlar bu projeye uygulanacak, eğer EF nin olmadığı projeye kod yazarsak hata alırız!
             * Sonra pm> yazan satıra enable-migrations yazıp enter a basarak migrations u aktif hale getiriyoruz
             * tekrar pm> satırı geldiğinde eğer önceki işlemde hata yoksa buraya update-database komutunu yazıp enter a basıyoruz, bir hata çıkmazsa model class larımızdaki değişiklikler veritabanına yansıyacaktır
             */
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Slide> Slides { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
