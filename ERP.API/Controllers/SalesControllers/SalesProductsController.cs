namespace ERP.API.Controllers.SalesControllers
{
    [Route("api/salesProduct")]
    [ApiController]
    [Authorize]
    public class SalesProductsController : ControllerBase
    {

        private readonly IServiceAggregator _serviceAggregator;
        private readonly IMapper _mapper;
        public SalesProductsController(IServiceAggregator serviceAggregator, IMapper mapper)
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
                var SalesProductss = await _serviceAggregator.SalesProductsService.GetAllAsync(tenantId, userId);
                response.StatusCode = HttpStatusCode.OK;
                response.Result = SalesProductss;
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
                var SalesProducts = await _serviceAggregator.SalesProductsService.GetByIdAsync(id, tenantId, userId);
                if (SalesProducts == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "SalesProducts not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = SalesProducts;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateSalesProductsDTO SalesProducts)
        {
            var response = new APIResponseDTO();
            if (SalesProducts == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "SalesProducts cannot be null" };
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
                var mappedSalesProducts = _mapper.Map<SalesProduct>(SalesProducts);
                mappedSalesProducts.UserId = userId; // assuming SalesProducts has a UserId property
                mappedSalesProducts.TenantID = tenantId; // assuming SalesProducts has a TenantId property

                await _serviceAggregator.SalesProductsService.Save(mappedSalesProducts);

                response.StatusCode = HttpStatusCode.Created;
                response.Result = SalesProducts;
                return CreatedAtAction(nameof(GET), new { id = mappedSalesProducts.SaleProductID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateSalesProductsDTO SalesProducts)
        {
            var response = new APIResponseDTO();
            if (SalesProducts == null || id <= 0 || !(id == _mapper.Map<SalesProduct>(SalesProducts).SaleProductID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid SalesProducts or ID" };
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
                SalesProduct mappedSalesProducts = _mapper.Map<SalesProduct>(SalesProducts);
                mappedSalesProducts.SaleProductID = id;
                mappedSalesProducts.UserId = userId;
                mappedSalesProducts.TenantID = tenantId;

                await _serviceAggregator.SalesProductsService.Save(mappedSalesProducts, id);

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
                await _serviceAggregator.SalesProductsService.DeleteAsync(id, tenantId, userId);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH(int id, [FromBody] JsonPatchDocument<UpdateSalesProductsDTO> patchDoc)
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
                var SalesProductsFromDb = await _serviceAggregator.SalesProductsService.GetByIdAsync(id, tenantId, userId);
                if (SalesProductsFromDb == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "SalesProducts not found" };
                    return NotFound(response);
                }

                var SalesProductsToPatch = _mapper.Map<UpdateSalesProductsDTO>(SalesProductsFromDb);
                patchDoc.ApplyTo(SalesProductsToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(response);
                }

                var updatedSalesProducts = _mapper.Map<SalesProduct>(SalesProductsToPatch);
                updatedSalesProducts.SaleProductID = id;
                updatedSalesProducts.UserId = userId;
                updatedSalesProducts.TenantID = tenantId;

                await _serviceAggregator.SalesProductsService.Save(updatedSalesProducts, id);

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
