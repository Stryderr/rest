using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface IPurchaseOrderRepository
    {
        Task<PurchaseOrder3> GetById(int id);
        Task<PurchaseOrder3> GetByPoNum(int poNum);
        Task<List<PurchaseOrder3>> GetAllUnprocessed();
        Task<PurchaseOrder3> Insert(PurchaseOrder3 inc);
        Task<List<PurchaseOrder3>> BatchInsert(List<PurchaseOrder3> inc);
        Task<PurchaseOrder3> Update(PurchaseOrder3 inc);
        Task<List<PurchaseOrder3>> BatchUpdate(List<PurchaseOrder3> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }
}