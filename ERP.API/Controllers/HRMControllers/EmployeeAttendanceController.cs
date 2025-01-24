namespace ERP.API.Controllers.HRMControllers
{
    [Route("api/employeeAttendance")]
    [ApiController]
    [Authorize]
    public class EmployeeAttendanceController : ControllerBase
    {
        private readonly IServiceAggregator _serviceAggregator;
        private readonly IMapper _mapper;
        public EmployeeAttendanceController(IServiceAggregator serviceAggregator, IMapper mapper)
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
                var EmployeeAttendances = await _serviceAggregator.EmployeeAttendanceService.GetAllAsync(tenantId, userId);
                response.StatusCode = HttpStatusCode.OK;
                response.Result = EmployeeAttendances;
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
                var EmployeeAttendance = await _serviceAggregator.EmployeeAttendanceService.GetByIdAsync(id, tenantId, userId);
                if (EmployeeAttendance == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "EmployeeAttendance not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = EmployeeAttendance;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateEmployeeAttendanceDTO EmployeeAttendance)
        {
            var response = new APIResponseDTO();
            if (EmployeeAttendance == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "EmployeeAttendance cannot be null" };
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
                var mappedEmployeeAttendance = _mapper.Map<EmployeeAttendance>(EmployeeAttendance);
                mappedEmployeeAttendance.UserId = userId; // assuming EmployeeAttendance has a UserId property
                mappedEmployeeAttendance.TenantID = tenantId; // assuming EmployeeAttendance has a TenantId property

                await _serviceAggregator.EmployeeAttendanceService.Save(mappedEmployeeAttendance);

                response.StatusCode = HttpStatusCode.Created;
                response.Result = EmployeeAttendance;
                return CreatedAtAction(nameof(GET), new { id = mappedEmployeeAttendance.EmployeeAttendanceID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateEmployeeAttendanceDTO EmployeeAttendance)
        {
            var response = new APIResponseDTO();
            if (EmployeeAttendance == null || id <= 0 || !(id == _mapper.Map<EmployeeAttendance>(EmployeeAttendance).EmployeeAttendanceID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid EmployeeAttendance or ID" };
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
                EmployeeAttendance mappedEmployeeAttendance = _mapper.Map<EmployeeAttendance>(EmployeeAttendance);
                mappedEmployeeAttendance.EmployeeAttendanceID = id;
                mappedEmployeeAttendance.UserId = userId;
                mappedEmployeeAttendance.TenantID = tenantId;

                await _serviceAggregator.EmployeeAttendanceService.Save(mappedEmployeeAttendance, id);

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
                await _serviceAggregator.EmployeeAttendanceService.DeleteAsync(id, tenantId, userId);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH(int id, [FromBody] JsonPatchDocument<UpdateEmployeeAttendanceDTO> patchDoc)
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
                var EmployeeAttendanceFromDb = await _serviceAggregator.EmployeeAttendanceService.GetByIdAsync(id, tenantId, userId);
                if (EmployeeAttendanceFromDb == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "EmployeeAttendance not found" };
                    return NotFound(response);
                }

                var EmployeeAttendanceToPatch = _mapper.Map<UpdateEmployeeAttendanceDTO>(EmployeeAttendanceFromDb);
                patchDoc.ApplyTo(EmployeeAttendanceToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(response);
                }

                var updatedEmployeeAttendance = _mapper.Map<EmployeeAttendance>(EmployeeAttendanceToPatch);
                updatedEmployeeAttendance.EmployeeAttendanceID = id;
                updatedEmployeeAttendance.UserId = userId;
                updatedEmployeeAttendance.TenantID = tenantId;

                await _serviceAggregator.EmployeeAttendanceService.Save(updatedEmployeeAttendance, id);

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
