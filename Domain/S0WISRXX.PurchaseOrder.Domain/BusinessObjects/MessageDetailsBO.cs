using AutoMapper;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Domain.Models;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Domain.BusinessObjects
{

    public class MessageDetailBO : IMessageDetailBO
    {
        private readonly IUtilityLogger _logger;
        private readonly IMessageDetailRepository _repo;
        private readonly IMapper _mapper;

        public MessageDetailBO(IUtilityLogger logger, IMessageDetailRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderMappingProfile>()).CreateMapper();
        }


        public async Task<MessageMessageDetailDM> GetById(int id)
        {
            try
            {
                var result = await _repo.GetById(id);
                return _mapper.Map<MessageDetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MessageDetailDM> GetByPoNum(int poNum)
        {
            try
            {
                var result = await _repo.GetByPoNum(poNum);
                return _mapper.Map<MessageDetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<MessageDetailDM>> GetAllUnprocessed()
        {
            try
            {
                var result = await _repo.GetAllUnprocessed();
                return _mapper.Map<List<MessageDetailDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MessageDetailDM> Insert(MessageDetailDM inc)
        {
            try
            {
                var entity = _mapper.Map<PurchaseOrderMessageDetail>(inc);
                var result = await _repo.Insert(entity);
                return _mapper.Map<MessageDetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<MessageDetailDM>> BatchInsert(List<MessageDetailDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PurchaseOrderMessageDetail>>(inc);
                var result = await _repo.BatchInsert(entities);
                return _mapper.Map<List<MessageDetailDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MessageDetailDM> Update(MessageDetailDM inc)
        {
            try
            {
                var entity = _mapper.Map<PurchaseOrderDetail>(inc);
                var result = await _repo.Update(entity);
                return _mapper.Map<MessageDetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<MessageDetailDM>> BatchUpdate(List<MessageDetailDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PurchaseOrderMessageDetail>>(inc);
                var result = await _repo.BatchUpdate(entities);
                return _mapper.Map<List<MessageDetailDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                return await _repo.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> BatchDelete(List<int> ids)
        {
            try
            {
                return await _repo.BatchDelete(ids);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> BatchSoftDelete(List<int> ids)
        {
            try
            {
                return await _repo.BatchSoftDelete(ids);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<bool> DeleteAllProcessed()
        {
            try
            {
                return await _repo.DeleteAllProcessed();
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}
