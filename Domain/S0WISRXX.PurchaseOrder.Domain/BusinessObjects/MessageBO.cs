using AutoMapper;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Domain.Mappers;
using S0WISRXX.PurchaseOrder.Domain.Models;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Domain.BusinessObjects
{

    public class MessageBO : IMessageBO
    {
        private readonly IUtilityLogger _logger;
        private readonly IMessageRepository _repo;
        private readonly IMapper _mapper;

        public MessageBO(IUtilityLogger logger, IMessageRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderMappingProfile>()).CreateMapper();
        }


        public async Task<MessageDM> GetById(int id)
        {
            try
            {
                var result = await _repo.GetById(id);
                return _mapper.Map<MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MessageDM> GetByPoNum(int poNum)
        {
            try
            {
                var result = await _repo.GetByPoNum(poNum);
                return _mapper.Map<MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<MessageDM>> GetAllUnprocessed()
        {
            try
            {
                var result = await _repo.GetAllUnprocessed();
                return _mapper.Map<List<MessageDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MessageDM> Insert(MessageDM inc)
        {
            try
            {
                var entity = _mapper.Map<PurchaseOrderMessage>(inc);
                var result = await _repo.Insert(entity);
                return _mapper.Map<MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<MessageDM>> BatchInsert(List<MessageDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PurchaseOrderMessage>>(inc);
                var result = await _repo.BatchInsert(entities);
                return _mapper.Map<List<MessageDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<MessageDM> Update(MessageDM inc)
        {
            try
            {
                var entity = _mapper.Map<PurchaseOrderMessage>(inc);
                var result = await _repo.Update(entity);
                return _mapper.Map<MessageDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<MessageDM>> BatchUpdate(List<MessageDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PurchaseOrderMessage>>(inc);
                var result = await _repo.BatchUpdate(entities);
                return _mapper.Map<List<MessageDM>>(result);
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
