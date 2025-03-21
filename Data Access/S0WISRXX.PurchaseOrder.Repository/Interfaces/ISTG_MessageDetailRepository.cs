using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface ISTG_MessageDetailRepository
    {
        Task<PoextendedMessageDetailStg?> GetById(int id);
        Task<List<PoextendedMessageDetailStg>?> GetByPoNum(int poNum);
        Task<List<PoextendedMessageDetailStg>> GetAllUnprocessed();
        Task<PoextendedMessageDetailStg> Insert(PoextendedMessageDetailStg inc);
        Task<List<PoextendedMessageDetailStg>> BatchInsert(List<PoextendedMessageDetailStg> inc);
        Task<PoextendedMessageDetailStg> Update(PoextendedMessageDetailStg inc);
        Task<List<PoextendedMessageDetailStg>> BatchUpdate(List<PoextendedMessageDetailStg> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }
}