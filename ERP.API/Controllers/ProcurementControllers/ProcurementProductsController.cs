namespace ERP.API.Controllers.ProcurementControllers
{
    [Route("api/procurementProduct")]
    [ApiController]
    [Authorize]
    public class ProcurementProductsController : ControllerBase
    {
        private readonly IServiceAggregator _serviceAggregator;
        private readonly IMapper _mapper;
        public ProcurementProductsController(IServiceAggregator serviceAggregator, IMapper mapper)
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
                var ProcurementProductss = await _serviceAggregator.ProcurementProductsService.GetAllAsync(tenantId, userId);
                response.StatusCode = HttpStatusCode.OK;
                response.Result = ProcurementProductss;
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
                var ProcurementProducts = await _serviceAggregator.ProcurementProductsService.GetByIdAsync(id, tenantId, userId);
                if (ProcurementProducts == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "ProcurementProducts not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = ProcurementProducts;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateProcurementProductsDTO ProcurementProducts)
        {
            var response = new APIResponseDTO();
            if (ProcurementProducts == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "ProcurementProducts cannot be null" };
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
                var mappedProcurementProducts = _mapper.Map<ProcurementProduct>(ProcurementProducts);
                mappedProcurementProducts.UserId = userId; // assuming ProcurementProducts has a UserId property
                mappedProcurementProducts.TenantID = tenantId; // assuming ProcurementProducts has a TenantId property

                await _serviceAggregator.ProcurementProductsService.Save(mappedProcurementProducts);

                response.StatusCode = HttpStatusCode.Created;
                response.Result = ProcurementProducts;
                return CreatedAtAction(nameof(GET), new { id = mappedProcurementProducts.ProcurementProductID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateProcurementProductsDTO ProcurementProducts)
        {
            var response = new APIResponseDTO();
            if (ProcurementProducts == null || id <= 0 || !(id == _mapper.Map<ProcurementProduct>(ProcurementProducts).ProcurementProductID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid ProcurementProducts or ID" };
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
                ProcurementProduct mappedProcurementProducts = _mapper.Map<ProcurementProduct>(ProcurementProducts);
                mappedProcurementProducts.ProcurementProductID = id;
                mappedProcurementProducts.UserId = userId;
                mappedProcurementProducts.TenantID = tenantId;

                await _serviceAggregator.ProcurementProductsService.Save(mappedProcurementProducts, id);

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
                await _serviceAggregator.ProcurementProductsService.DeleteAsync(id, tenantId, userId);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH(int id, [FromBody] JsonPatchDocument<UpdateProcurementProductsDTO> patchDoc)
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
                var ProcurementProductsFromDb = await _serviceAggregator.ProcurementProductsService.GetByIdAsync(id, tenantId, userId);
                if (ProcurementProductsFromDb == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "ProcurementProducts not found" };
                    return NotFound(response);
                }

                var ProcurementProductsToPatch = _mapper.Map<UpdateProcurementProductsDTO>(ProcurementProductsFromDb);
                patchDoc.ApplyTo(ProcurementProductsToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(response);
                }

                var updatedProcurementProducts = _mapper.Map<ProcurementProduct>(ProcurementProductsToPatch);
                updatedProcurementProducts.ProcurementProductID = id;
                updatedProcurementProducts.UserId = userId;
                updatedProcurementProducts.TenantID = tenantId;

                await _serviceAggregator.ProcurementProductsService.Save(updatedProcurementProducts, id);

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
