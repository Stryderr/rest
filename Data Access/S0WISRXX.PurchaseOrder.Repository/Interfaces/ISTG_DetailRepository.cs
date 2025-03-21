using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface ISTG_DetailRepository
    {
        Task<PodetailStg?> GetById(int id);
        Task<List<PodetailStg>?> GetByPoNum(int poNum);
        Task<List<PodetailStg>> GetAllUnprocessed();
        Task<PodetailStg> Insert(PodetailStg inc);
        Task<List<PodetailStg>> BatchInsert(List<PodetailStg> inc);
        Task<PodetailStg> Update(PodetailStg inc);
        Task<List<PodetailStg>> BatchUpdate(List<PodetailStg> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }

}