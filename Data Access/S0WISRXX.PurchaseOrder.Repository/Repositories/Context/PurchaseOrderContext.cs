using Microsoft.EntityFrameworkCore;
using S0WISRXX.Library.DataAccess.S0WISRXXModels;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Repositories.Context
{
    public class PurchaseOrderContext : DbContext
    {
        public PurchaseOrderContext(DbContextOptions<PurchaseOrderContext> options) : base(options) { }

        public DbSet<PurchaseOrder3> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public DbSet<PurchaseOrderMessage> PurchaseOrderMessages { get; set; }
        public DbSet<PurchaseOrderMessageDetail> PurchaseOrderMessageDetails { get; set; }
        public DbSet<PoheaderStg> STG_PurchaseOrders { get; set; }
        public DbSet<PodetailStg> STG_PurchaseOrderDetails { get; set; }
        public DbSet<PoextendedMessageHeaderStg> STG_PurchaseOrderMessages { get; set; }
        public DbSet<PoextendedMessageDetailStg> STG_PurchaseOrderMessageDetails { get; set; }
        // Add other DbSet properties as needed
    }
}
