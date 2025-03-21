
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface IDetailRepository
    {
        Task<PurchaseOrderDetail?> GetById(int id);
        Task<List<PurchaseOrderDetail>?> GetByPoNum(int poNum);
        Task<List<PurchaseOrderDetail>> GetAllUnprocessed();
        Task<PurchaseOrderDetail> Insert(PurchaseOrderDetail inc);
        Task<List<PurchaseOrderDetail>> BatchInsert(List<PurchaseOrderDetail> inc);
        Task<PurchaseOrderDetail> Update(PurchaseOrderDetail inc);
        Task<List<PurchaseOrderDetail>> BatchUpdate(List<PurchaseOrderDetail> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }

}