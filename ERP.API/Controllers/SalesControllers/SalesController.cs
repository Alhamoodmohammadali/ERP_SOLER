namespace ERP.API.Controllers.SalesControllers
{
    [Route("api/sales")]
    [ApiController]
    [Authorize]
    public class SalesController : ControllerBase
    {


        private readonly IServiceAggregator _serviceAggregator;
        private readonly IMapper _mapper;
        public SalesController(IServiceAggregator serviceAggregator, IMapper mapper)
        {
            _serviceAggregator = serviceAggregator;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> GET()
        {
            var response = new APIResponseDTO();
            var claimHelper = new ClaimHelper(User);

            var (userId, userError) = claimHelper.GetUserId();
            if (userError != null)
            {
                return Unauthorized(userError);
            }

            var (tenantId, tenantError) = claimHelper.GetTenantId();
            if (tenantError != null)
            {
                return Unauthorized(tenantError);
            }

            try
            {
                var Saless = await _serviceAggregator.SaleService.GetAllAsync(tenantId, userId);
                response.StatusCode = HttpStatusCode.OK;
                response.Result = Saless;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode((int)response.StatusCode, response);
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> GET(int id)
        {
            var response = new APIResponseDTO();
            var claimHelper = new ClaimHelper(User);

            var (userId, userError) = claimHelper.GetUserId();
            if (userError != null)
            {
                return Unauthorized(userError);
            }

            var (tenantId, tenantError) = claimHelper.GetTenantId();
            if (tenantError != null)
            {
                return Unauthorized(tenantError);
            }

            try
            {
                var Sales = await _serviceAggregator.SaleService.GetByIdAsync(id, tenantId, userId);
                if (Sales == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Sales not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = Sales;
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode((int)response.StatusCode, response);
            }
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateSalesDTO Sales)
        {
            var response = new APIResponseDTO();
            if (Sales == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Sales cannot be null" };
                return BadRequest(response);
            }

            var claimHelper = new ClaimHelper(User);

            var (userId, userError) = claimHelper.GetUserId();
            if (userError != null)
            {
                return Unauthorized(userError);
            }

            var (tenantId, tenantError) = claimHelper.GetTenantId();
            if (tenantError != null)
            {
                return Unauthorized(tenantError);
            }

            try
            {
                var mappedSales = _mapper.Map<Sale>(Sales);
                mappedSales.UserId = userId; // assuming Sales has a UserId property
                mappedSales.TenantID = tenantId; // assuming Sales has a TenantId property

                await _serviceAggregator.SaleService.Save(mappedSales);

                response.StatusCode = HttpStatusCode.Created;
                response.Result = Sales;
                return CreatedAtAction(nameof(GET), new { id = mappedSales.SaleID }, response);
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode((int)response.StatusCode, response);
            }
        }
        [HttpPut("{id}")]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateSalesDTO Sales)
        {
            var response = new APIResponseDTO();
            if (Sales == null || id <= 0 || !(id == _mapper.Map<Sale>(Sales).SaleID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid Sales or ID" };
                return BadRequest(response);
            }

            var claimHelper = new ClaimHelper(User);

            var (userId, userError) = claimHelper.GetUserId();
            if (userError != null)
            {
                return Unauthorized(userError);
            }

            var (tenantId, tenantError) = claimHelper.GetTenantId();
            if (tenantError != null)
            {
                return Unauthorized(tenantError);
            }

            try
            {
                Sale mappedSales = _mapper.Map<Sale>(Sales);
                mappedSales.SaleID = id;
                mappedSales.UserId = userId;
                mappedSales.TenantID = tenantId;

                await _serviceAggregator.SaleService.Save(mappedSales, id);

                response.StatusCode = HttpStatusCode.NoContent; // Update success
                return NoContent();
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode((int)response.StatusCode, response);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> DELETE(int id)
        {
            var response = new APIResponseDTO();
            if (id <= 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid ID" };
                return BadRequest(response);
            }

            var claimHelper = new ClaimHelper(User);

            var (userId, userError) = claimHelper.GetUserId();
            if (userError != null)
            {
                return Unauthorized(userError);
            }

            var (tenantId, tenantError) = claimHelper.GetTenantId();
            if (tenantError != null)
            {
                return Unauthorized(tenantError);
            }

            try
            {
                await _serviceAggregator.SaleService.DeleteAsync(id, tenantId, userId);

                response.StatusCode = HttpStatusCode.NoContent; // Deletion success
                return NoContent();
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode((int)response.StatusCode, response);
            }
        }
        [HttpPatch("{id}")]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> PATCH(int id, [FromBody] JsonPatchDocument<UpdateSalesDTO> patchDoc)
        {
            var response = new APIResponseDTO();
            if (patchDoc == null || id <= 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid request or ID" };
                return BadRequest(response);
            }

            var claimHelper = new ClaimHelper(User);

            var (userId, userError) = claimHelper.GetUserId();
            if (userError != null)
            {
                return Unauthorized(userError);
            }

            var (tenantId, tenantError) = claimHelper.GetTenantId();
            if (tenantError != null)
            {
                return Unauthorized(tenantError);
            }

            try
            {
                var SalesFromDb = await _serviceAggregator.SaleService.GetByIdAsync(id, tenantId, userId);
                if (SalesFromDb == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Sales not found" };
                    return NotFound(response);
                }

                var SalesToPatch = _mapper.Map<UpdateSalesDTO>(SalesFromDb);
                patchDoc.ApplyTo(SalesToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(response);
                }

                var updatedSales = _mapper.Map<Sale>(SalesToPatch);
                updatedSales.SaleID = id;
                updatedSales.UserId = userId;
                updatedSales.TenantID = tenantId;

                await _serviceAggregator.SaleService.Save(updatedSales, id);

                response.StatusCode = HttpStatusCode.NoContent;
                return NoContent();
            }
            catch (Exception ex)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { ex.Message };
                return StatusCode((int)response.StatusCode, response);
            }
        }

    }
}
