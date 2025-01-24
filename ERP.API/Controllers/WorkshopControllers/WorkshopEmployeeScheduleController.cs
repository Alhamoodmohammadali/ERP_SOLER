namespace ERP.API.Controllers.WorkshopControllers
{
    [Route("api/workshopEmployeeSchedule")]
    [ApiController]
    [Authorize]
    public class WorkshopEmployeeScheduleController : ControllerBase
    {

        private readonly IServiceAggregator _serviceAggregator;
        private readonly IMapper _mapper;
        public WorkshopEmployeeScheduleController(IServiceAggregator serviceAggregator, IMapper mapper)
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
                var WorkshopEmployeeSchedules = await _serviceAggregator.WorkshopEmployeeScheduleService.GetAllAsync(tenantId, userId);
                response.StatusCode = HttpStatusCode.OK;
                response.Result = WorkshopEmployeeSchedules;
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
                var WorkshopEmployeeSchedule = await _serviceAggregator.WorkshopEmployeeScheduleService.GetByIdAsync(id, tenantId, userId);
                if (WorkshopEmployeeSchedule == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "WorkshopEmployeeSchedule not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = WorkshopEmployeeSchedule;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateWorkshopEmployeeScheduleDTO WorkshopEmployeeSchedule)
        {
            var response = new APIResponseDTO();
            if (WorkshopEmployeeSchedule == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "WorkshopEmployeeSchedule cannot be null" };
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
                var mappedWorkshopEmployeeSchedule = _mapper.Map<WorkshopEmployeeSchedule>(WorkshopEmployeeSchedule);
                mappedWorkshopEmployeeSchedule.UserId = userId; // assuming WorkshopEmployeeSchedule has a UserId property
                mappedWorkshopEmployeeSchedule.TenantID = tenantId; // assuming WorkshopEmployeeSchedule has a TenantId property

                await _serviceAggregator.WorkshopEmployeeScheduleService.Save(mappedWorkshopEmployeeSchedule);

                response.StatusCode = HttpStatusCode.Created;
                response.Result = WorkshopEmployeeSchedule;
                return CreatedAtAction(nameof(GET), new { id = mappedWorkshopEmployeeSchedule.WorkshopEmployeeScheduleID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateWorkshopEmployeeScheduleDTO WorkshopEmployeeSchedule)
        {
            var response = new APIResponseDTO();
            if (WorkshopEmployeeSchedule == null || id <= 0 || !(id == _mapper.Map<WorkshopEmployeeSchedule>(WorkshopEmployeeSchedule).WorkshopEmployeeScheduleID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid WorkshopEmployeeSchedule or ID" };
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
                WorkshopEmployeeSchedule mappedWorkshopEmployeeSchedule = _mapper.Map<WorkshopEmployeeSchedule>(WorkshopEmployeeSchedule);
                mappedWorkshopEmployeeSchedule.WorkshopEmployeeScheduleID = id;
                mappedWorkshopEmployeeSchedule.UserId = userId;
                mappedWorkshopEmployeeSchedule.TenantID = tenantId;

                await _serviceAggregator.WorkshopEmployeeScheduleService.Save(mappedWorkshopEmployeeSchedule, id);

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
                await _serviceAggregator.WorkshopEmployeeScheduleService.DeleteAsync(id, tenantId, userId);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH(int id, [FromBody] JsonPatchDocument<UpdateWorkshopEmployeeScheduleDTO> patchDoc)
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
                var WorkshopEmployeeScheduleFromDb = await _serviceAggregator.WorkshopEmployeeScheduleService.GetByIdAsync(id, tenantId, userId);
                if (WorkshopEmployeeScheduleFromDb == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "WorkshopEmployeeSchedule not found" };
                    return NotFound(response);
                }

                var WorkshopEmployeeScheduleToPatch = _mapper.Map<UpdateWorkshopEmployeeScheduleDTO>(WorkshopEmployeeScheduleFromDb);
                patchDoc.ApplyTo(WorkshopEmployeeScheduleToPatch, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

                if (!ModelState.IsValid)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.IsSuccess = false;
                    response.ErrorMessages = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                    return BadRequest(response);
                }

                var updatedWorkshopEmployeeSchedule = _mapper.Map<WorkshopEmployeeSchedule>(WorkshopEmployeeScheduleToPatch);
                updatedWorkshopEmployeeSchedule.WorkshopEmployeeScheduleID = id;
                updatedWorkshopEmployeeSchedule.UserId = userId;
                updatedWorkshopEmployeeSchedule.TenantID = tenantId;

                await _serviceAggregator.WorkshopEmployeeScheduleService.Save(updatedWorkshopEmployeeSchedule, id);

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
