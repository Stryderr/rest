using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface ISTG_PurchaseOrderRepository
    {
        Task<PoheaderStg> GetById(int id);
        Task<PoheaderStg> GetByPoNum(int poNum);
        Task<List<PoheaderStg>> GetAllUnprocessed();
        Task<PoheaderStg> Insert(PoheaderStg inc);
        Task<List<PoheaderStg>> BatchInsert(List<PoheaderStg> inc);
        Task<PoheaderStg> Update(PoheaderStg inc);
        Task<List<PoheaderStg>> BatchUpdate(List<PoheaderStg> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }
}