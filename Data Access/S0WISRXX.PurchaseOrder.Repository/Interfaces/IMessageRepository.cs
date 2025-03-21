using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface IMessageRepository
    {
        Task<PurchaseOrderMessage?> GetById(int id);
        Task<List<PurchaseOrderMessage>?> GetByPoNum(int poNum);
        Task<List<PurchaseOrderMessage>> GetAllUnprocessed();
        Task<PurchaseOrderMessage> Insert(PurchaseOrderMessage inc);
        Task<List<PurchaseOrderMessage>> BatchInsert(List<PurchaseOrderMessage> inc);
        Task<PurchaseOrderMessage> Update(PurchaseOrderMessage inc);
        Task<List<PurchaseOrderMessage>> BatchUpdate(List<PurchaseOrderMessage> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }

}