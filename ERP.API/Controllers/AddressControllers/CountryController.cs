namespace ERP.API.Controllers.AddressControllers
{
    [Route("api/Country")]
    [ApiController]
    [Authorize]
    public class CountryController : ControllerBase
    {
        #if DEBUG

        private readonly ICountryService _CountryService;
        private readonly IMapper _mapper;
        public CountryController(ICountryService CountryService, IMapper mapper)
        {
            _CountryService = CountryService;
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
                var Countrys = await _CountryService.GetAllAsync();
                response.StatusCode = HttpStatusCode.OK;
                response.Result = Countrys;
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
                var Country = await _CountryService.GetByIdAsync(id);
                if (Country == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Country not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = Country;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateCountryDTO Country)
        {
            var response = new APIResponseDTO();
            if (Country == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Country cannot be null" };
                return BadRequest(response);
            }

            try
            {
                await _CountryService.Save(_mapper.Map<Country>(Country));
                response.StatusCode = HttpStatusCode.Created;
                response.Result = Country;
                return CreatedAtAction(nameof(GET), new { id = _mapper.Map<Country>(Country).CountryID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateCountryDTO Country)
        {


            var response = new APIResponseDTO();
            if (Country == null || id <= 0 || !(id == _mapper.Map<Country>(Country).CountryID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid Country or ID" };
                return BadRequest(response);
            }

            try
            {
                _mapper.Map<Country>(Country).CountryID = id; // assuming Country has an Id property

                await _CountryService.Save(_mapper.Map<Country>(Country), id);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH([FromBody] List<Country> Countrys)
        {
            var response = new APIResponseDTO();
            if (Countrys == null || Countrys.Count == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Countrys cannot be null or empty" };
                return BadRequest(response);
            }

            try
            {
                foreach (var Country in Countrys)
                {
                    if (Country.CountryID <= 0) // Assuming we need to add a new Country
                    {
                        await _CountryService.Save(_mapper.Map<Country>(Country));
                    }
                    else // Update existing Country
                    {
                        await _CountryService.Save(_mapper.Map<Country>(Country), Country.CountryID);
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
                await _CountryService.DeleteAsync(id);
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
