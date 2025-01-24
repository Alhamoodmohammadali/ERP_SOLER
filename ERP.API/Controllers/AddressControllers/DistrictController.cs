namespace ERP.API.Controllers.AddressControllers
{
    [Route("api/District")]
    [ApiController]

    [Authorize]
    public class DistrictController : ControllerBase
    {
#if DEBUG
        private readonly IDistrictService _DistrictService;
        private readonly IMapper _mapper;

        public DistrictController(IDistrictService DistrictService, IMapper mapper)
        {
            _DistrictService = DistrictService;
            _mapper = mapper;
        }
        [HttpGet]

        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> GET()
        {
            var response = new APIResponseDTO();
            try
            {
                var Districts = await _DistrictService.GetAllAsync();
                response.StatusCode = HttpStatusCode.OK;
                response.Result = Districts;
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
        [Authorize(Roles = SD.Role_Admin)]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [Authorize(Roles = SD.Role_ManagementEmployee)]
        [Authorize(Roles = SD.Role_RegularEmployee)]
        [Authorize(Roles = SD.Role_WorkshopManager)]
        [Authorize(Roles = SD.Role_SeniorManager)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> GET(int id)
        {
            var response = new APIResponseDTO();
            try
            {
                var District = await _DistrictService.GetByIdAsync(id);
                if (District == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "District not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = District;
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
        [Authorize(Roles = SD.Role_Admin)]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [Authorize(Roles = SD.Role_ManagementEmployee)]
        [Authorize(Roles = SD.Role_RegularEmployee)]
        [Authorize(Roles = SD.Role_WorkshopManager)]
        [Authorize(Roles = SD.Role_SeniorManager)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateDistrictDTO District)
        {
            var response = new APIResponseDTO();
            if (District == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "District cannot be null" };
                return BadRequest(response);
            }

            try
            {
                await _DistrictService.Save(_mapper.Map<District>(District));
                response.StatusCode = HttpStatusCode.Created;
                response.Result = District;
                return CreatedAtAction(nameof(GET), new { id = _mapper.Map<District>(District).DistrictID }, response);
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
        [Authorize(Roles = SD.Role_Admin)]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [Authorize(Roles = SD.Role_ManagementEmployee)]
        [Authorize(Roles = SD.Role_RegularEmployee)]
        [Authorize(Roles = SD.Role_WorkshopManager)]
        [Authorize(Roles = SD.Role_SeniorManager)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.NoContent)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateDistrictDTO District)
        {


            var response = new APIResponseDTO();
            if (District == null || id <= 0 || !(id == _mapper.Map<District>(District).DistrictID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid District or ID" };
                return BadRequest(response);
            }

            try
            {
                _mapper.Map<District>(District).DistrictID = id; // assuming District has an Id property

                await _DistrictService.Save(_mapper.Map<District>(District), id);

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
        [HttpPatch("PATCH")]
        [Authorize(Roles = SD.Role_Admin)]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [Authorize(Roles = SD.Role_ManagementEmployee)]
        [Authorize(Roles = SD.Role_RegularEmployee)]
        [Authorize(Roles = SD.Role_WorkshopManager)]
        [Authorize(Roles = SD.Role_SeniorManager)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> PATCH([FromBody] List<District> Districts)
        {
            var response = new APIResponseDTO();
            if (Districts == null || Districts.Count == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Districts cannot be null or empty" };
                return BadRequest(response);
            }

            try
            {
                foreach (var District in Districts)
                {
                    if (District.DistrictID <= 0) // Assuming we need to add a new District
                    {
                        await _DistrictService.Save(_mapper.Map<District>(District));
                    }
                    else // Update existing District
                    {
                        await _DistrictService.Save(_mapper.Map<District>(District), District.DistrictID);
                    }
                }
                response.StatusCode = HttpStatusCode.OK; // Batch process success
                response.Result = "Batch processing completed successfully.";
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
        [HttpDelete("{id}")]
        [Authorize(Roles = SD.Role_Admin)]
        [Authorize(Roles = SD.Role_Company)]
        [Authorize(Roles = SD.Role_AccountingEmployee)]
        [Authorize(Roles = SD.Role_ManagementEmployee)]
        [Authorize(Roles = SD.Role_RegularEmployee)]
        [Authorize(Roles = SD.Role_WorkshopManager)]
        [Authorize(Roles = SD.Role_SeniorManager)]
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

            try
            {
                await _DistrictService.DeleteAsync(id);
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



#endif
    }
}
