using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Repository.Interfaces
{
    public interface ISTG_MessageRepository
    {
        Task<PoextendedMessageHeaderStg?> GetById(int id);
        Task<List<PoextendedMessageHeaderStg>?> GetByPoNum(int poNum);
        Task<List<PoextendedMessageHeaderStg>> GetAllUnprocessed();
        Task<PoextendedMessageHeaderStg> Insert(PoextendedMessageHeaderStg inc);
        Task<List<PoextendedMessageHeaderStg>> BatchInsert(List<PoextendedMessageHeaderStg> inc);
        Task<PoextendedMessageHeaderStg> Update(PoextendedMessageHeaderStg inc);
        Task<List<PoextendedMessageHeaderStg>> BatchUpdate(List<PoextendedMessageHeaderStg> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();
    }

}