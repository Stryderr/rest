using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface ISTG_PurchaseOrderBO
    {
        Task<STG_PurchaseOrderDM> GetById(int id);
        Task<STG_PurchaseOrderDM> GetByPoNum(int poNum);
        Task<List<STG_PurchaseOrderDM>> GetAllUnprocessed();
        Task<STG_PurchaseOrderDM> Insert(STG_PurchaseOrderDM inc);
        Task<List<STG_PurchaseOrderDM>> BatchInsert(List<STG_PurchaseOrderDM> inc);
        Task<STG_PurchaseOrderDM> Update(STG_PurchaseOrderDM inc);
        Task<List<STG_PurchaseOrderDM>> BatchUpdate(List<STG_PurchaseOrderDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();

    }

}
