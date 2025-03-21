

using AutoMapper;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Domain.Mappers;
using S0WISRXX.PurchaseOrder.Domain.Models;
using S0WISRXX.PurchaseOrder.Repository.Interfaces;
using S0WISRXX.PurchaseOrder.Repository.Models;

namespace S0WISRXX.PurchaseOrder.Domain.BusinessObjects
{

    public class STG_DetailBO : ISTG_DetailBO
    {
        private readonly IUtilityLogger _logger;
        private readonly ISTG_DetailRepository _repo;
        private readonly IMapper _mapper;

        public STG_DetailBO(IUtilityLogger logger, ISTG_DetailRepository repo)
        {
            _logger = logger;
            _repo = repo;
            _mapper = new MapperConfiguration(cfg => cfg.AddProfile<PurchaseOrderMappingProfile>()).CreateMapper();
        }


        public async Task<STG_DetailDM> GetById(int id)
        {
            try
            {
                var result = await _repo.GetById(id);
                return _mapper.Map<STG_DetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<STG_DetailDM> GetByPoNum(int poNum)
        {
            try
            {
                var result = await _repo.GetByPoNum(poNum);
                return _mapper.Map<STG_DetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<STG_DetailDM>> GetAllUnprocessed()
        {
            try
            {
                var result = await _repo.GetAllUnprocessed();
                return _mapper.Map<List<STG_DetailDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<STG_DetailDM> Insert(STG_DetailDM inc)
        {
            try
            {
                var entity = _mapper.Map<PodetailStg>(inc);
                var result = await _repo.Insert(entity);
                return _mapper.Map<STG_DetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<STG_DetailDM>> BatchInsert(List<STG_DetailDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PodetailStg>>(inc);
                var result = await _repo.BatchInsert(entities);
                return _mapper.Map<List<STG_DetailDM>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<STG_DetailDM> Update(STG_DetailDM inc)
        {
            try
            {
                var entity = _mapper.Map<PodetailStg>(inc);
                var result = await _repo.Update(entity);
                return _mapper.Map<STG_DetailDM>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }

        public async Task<List<STG_DetailDM>> BatchUpdate(List<STG_DetailDM> inc)
        {
            try
            {
                var entities = _mapper.Map<List<PodetailStg>>(inc);
                var result = await _repo.BatchUpdate(entities);
                return _mapper.Map<List<STG_DetailDM>>(result);
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
