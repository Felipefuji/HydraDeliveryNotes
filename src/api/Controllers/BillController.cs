using core.DTO.Bill;
using core.DTO.Helpers;
using core.Helpers;
using core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillController : ControllerBase
    {
        private readonly IBillService _billService;
        private readonly ILogger<BillController> _logger;

        public BillController(IBillService billService, ILogger<BillController> logger)
        {
            _billService = billService ?? throw new ArgumentNullException(nameof(billService));
            _logger = logger;
        }

        /// <summary>
        /// Get All Bills
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PagedList<DtoBill>>> GetAll([FromQuery] DtoFilterPagedList pagedListParams)
        {
            PagedList<DtoBill> listUsers = await _billService.GetAllBills(pagedListParams);

            if (listUsers == null || !listUsers.Any())
            {
                return NotFound();
            }

            return Ok(listUsers);
        }

        /// <summary>
        /// Get Bill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            DtoBill result = await _billService.GetBillById(id);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// New Bill
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<DtoBill>> Create([FromBody] DtoBillCreate client)
        {
            int? result = await _billService.CreateBill(client);

            if (result == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(Get), new { id = result.Value }, result);
        }

        /// <summary>
        /// Update Bill
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<DtoBill>> Update([FromBody] DtoBillUpdate data)
        {
            int? result = await _billService.UpdateBill(data);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Delete Bill
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Remove(int id)
        {
            await _billService.RemoveBill(id);

            return Ok();
        }
    }
}
