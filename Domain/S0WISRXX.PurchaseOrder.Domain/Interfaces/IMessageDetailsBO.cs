using S0WISRXX.PurchaseOrder.Domain.Models;

namespace S0WISRXX.PurchaseOrder.Domain.Interfaces
{
    public interface IMessageDetailBO
    {
        Task<MessageDetailDM> GetById(int id);
        Task<MessageDetailDM> GetByPoNum(int poNum);
        Task<List<MessageDetailDM>> GetAllUnprocessed();
        Task<MessageDetailDM> Insert(MessageDetailDM inc);
        Task<List<MessageDetailDM>> BatchInsert(List<MessageDetailDM> inc);
        Task<MessageDetailDM> Update(MessageDetailDM inc);
        Task<List<MessageDetailDM>> BatchUpdate(List<MessageDetailDM> inc);
        Task<bool> Delete(int id);
        Task<bool> BatchDelete(List<int> ids);
        Task<bool> BatchSoftDelete(List<int> ids);
        Task<bool> DeleteAllProcessed();


    }
}
