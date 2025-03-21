
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface IMessageDetailRepository
    {
        Task<PurchaseOrderMessageDetail?> GetById(int id);
        Task<List<PurchaseOrderMessageDetail>?> GetByPoNum(int poNum);
        Task<List<PurchaseOrderMessageDetail>> GetAllUnprocessed();
        Task<PurchaseOrderMessageDetail> Insert(PurchaseOrderMessageDetail inc);
        Task<List<PurchaseOrderMessageDetail>> BatchInsert(List<PurchaseOrderMessageDetail> inc);
        Task<PurchaseOrderMessageDetail> Update(PurchaseOrderMessageDetail inc);
        Task<List<PurchaseOrderMessageDetail>> BatchUpdate(List<PurchaseOrderMessageDetail> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }

}