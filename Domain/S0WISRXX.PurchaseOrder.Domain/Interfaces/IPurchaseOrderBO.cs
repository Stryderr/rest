using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface IPurchaseOrderBO
    {
        Task<PurchaseOrderDM> GetById(int id);
        Task<PurchaseOrderDM> GetByPoNum(int poNum);
        Task<List<PurchaseOrderDM>> GetAllUnprocessed();
        Task<PurchaseOrderDM> Insert(PurchaseOrderDM inc);
        Task<List<PurchaseOrderDM>> BatchInsert(List<PurchaseOrderDM> inc);
        Task<PurchaseOrderDM> Update(PurchaseOrderDM inc);
        Task<List<PurchaseOrderDM>> BatchUpdate(List<PurchaseOrderDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();

    }

}
