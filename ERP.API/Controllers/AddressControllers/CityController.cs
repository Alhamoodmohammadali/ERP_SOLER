namespace ERP.API.Controllers.AddressControllers
{
    [Route("api/City")]
    [ApiController]
    [Authorize]

    public class CityController : ControllerBase
    {
#if DEBUG

        private readonly ICityService _CityService;
        private readonly IMapper _mapper;

        public CityController(ICityService CityService, IMapper mapper)
        {
            _CityService = CityService;
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
                var Citys = await _CityService.GetAllAsync();
                response.StatusCode = HttpStatusCode.OK;
                response.Result = Citys;
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
                var City = await _CityService.GetByIdAsync(id);
                if (City == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "City not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = City;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateCityDTO City)
        {
            var response = new APIResponseDTO();
            if (City == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "City cannot be null" };
                return BadRequest(response);
            }

            try
            {
                await _CityService.Save(_mapper.Map<City>(City));
                response.StatusCode = HttpStatusCode.Created;
                response.Result = City;
                return CreatedAtAction(nameof(GET), new { id = _mapper.Map<City>(City).CityID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateCityDTO City)
        {


            var response = new APIResponseDTO();
            if (City == null || id <= 0 || !(id == _mapper.Map<City>(City).CityID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid City or ID" };
                return BadRequest(response);
            }

            try
            {
                _mapper.Map<City>(City).CityID = id; // assuming City has an Id property

                await _CityService.Save(_mapper.Map<City>(City), id);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH([FromBody] List<City> Citys)
        {
            var response = new APIResponseDTO();
            if (Citys == null || Citys.Count == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Citys cannot be null or empty" };
                return BadRequest(response);
            }

            try
            {
                foreach (var City in Citys)
                {
                    if (City.CityID <= 0) // Assuming we need to add a new City
                    {
                        await _CityService.Save(_mapper.Map<City>(City));
                    }
                    else // Update existing City
                    {
                        await _CityService.Save(_mapper.Map<City>(City), City.CityID);
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
                await _CityService.DeleteAsync(id);
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
