using Microsoft.AspNetCore.Mvc;
using S0WISRXX.PurchaseOrder.Domain.Interfaces;
using S0WISRXX.PurchaseOrder.Domain.Models;

namespace WISR_PurchaseOrder_API.Controllers
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    [ApiController]
    public class STG_MessageDetailController : ControllerBase
    {
        private readonly IUtilityLogger _logger;
        private readonly ISTG_MessageDetailBO _bo;

        public STG_MessageDetailController(IUtilityLogger logger, ISTG_MessageDetailBO bo)
        {
            _logger = logger;
            _bo = bo;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var results = await _bo.GetById(id);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("{poNum}")]
        public async Task<ActionResult> GetByPoNum(int poNum)
        {
            try
            {
                var results = await _bo.GetByPoNum(poNum);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpGet]
        [Route("/unprocessed")]
        public async Task<ActionResult> GetAllUnprocessed()
        {
            try
            {
                var results = await _bo.GetAllUnprocessed();
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(STG_MessageDetailDM inc)
        {
            try
            {
                var result = await _bo.Insert(inc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPost]
        [Route("/batch")]
        public async Task<ActionResult> BatchInsert([FromBody] List<STG_MessageDetailDM> inc)
        {
            try
            {
                var results = await _bo.BatchInsert(inc);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult> Update(STG_MessageDetailDM inc)
        {
            try
            {
                var result = await _bo.Update(inc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpPut]
        [Route("/batch")]
        public async Task<ActionResult> BatchUpdate([FromBody] List<STG_MessageDetailDM> inc)
        {
            try
            {
                var results = await _bo.BatchUpdate(inc);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _bo.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("/batch")]
        public async Task<ActionResult> BatchDelete([FromBody] List<int> ids)
        {
            try
            {
                var results = await _bo.BatchDelete(ids);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("/soft")]
        public async Task<ActionResult> BatchSoftDelete([FromBody] List<int> ids)
        {
            try
            {
                var results = await _bo.BatchSoftDelete(ids);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

        [HttpDelete]
        [Route("/processed")]
        public async Task<ActionResult> DeleteAllProcessed()
        {
            try
            {
                var result = await _bo.DeleteAllProcessed();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"{ex.Message}");
            }
        }

    }
}
