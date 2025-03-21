using AutoMapper;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Domain.Mappers;
using S0WISRXX.PurchaseOrder.Domain.Models;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Domain.BusinessObjects
{


    public class PurchaseOrderBO : IPurchaseOrderBO
    {
        private readonly IUtilityLogger _logger;
        private readonly IPurchaseOrderRepository _repo;
        private readonly IMapper _mapper;

        public PurchaseOrderBO(IUtilityLogger logger, IPurchaseOrderRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderMappingProfile>()).CreateMapper();
        }


        public async Task<PurchaseOrderDM> GetById(int id)
        {
            try
            {
                var result = await _repo.GetById(id);
                return _mapper.Map<PurchaseOrderDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<PurchaseOrderDM> GetByPoNum(int poNum)
        {
            try
            {
                var result = await _repo.GetByPoNum(poNum);
                return _mapper.Map<PurchaseOrderDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<PurchaseOrderDM>> GetAllUnprocessed()
        {
            try
            {
                var result = await _repo.GetAllUnprocessed();
                return _mapper.Map<List<PurchaseOrderDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<PurchaseOrderDM> Insert(PurchaseOrderDM inc)
        {
            try
            {
                var entity = _mapper.Map<PurchaseOrder3>(inc);
                var result = await _repo.Insert(entity);
                return _mapper.Map<PurchaseOrderDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<PurchaseOrderDM>> BatchInsert(List<PurchaseOrderDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PurchaseOrder3>>(inc);
                var result = await _repo.BatchInsert(entities);
                return _mapper.Map<List<PurchaseOrderDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<PurchaseOrderDM> Update(PurchaseOrderDM inc)
        {
            try
            {
                var entity = _mapper.Map<PurchaseOrder3>(inc);
                var result = await _repo.Update(entity);
                return _mapper.Map<PurchaseOrderDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<PurchaseOrderDM>> BatchUpdate(List<PurchaseOrderDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PurchaseOrder3>>(inc);
                var result = await _repo.BatchUpdate(entities);
                return _mapper.Map<List<PurchaseOrderDM>>(result);
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
