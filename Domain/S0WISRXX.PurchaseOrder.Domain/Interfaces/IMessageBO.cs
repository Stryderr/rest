using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface IMessageBO
    {
        Task<MessageDM> GetById(int id);
        Task<MessageDM> GetByPoNum(int poNum);
        Task<List<MessageDM>> GetAllUnprocessed();
        Task<MessageDM> Insert(MessageDM inc);
        Task<List<MessageDM>> BatchInsert(List<MessageDM> inc);
        Task<MessageDM> Update(MessageDM inc);
        Task<List<MessageDM>> BatchUpdate(List<MessageDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();

    }

}
