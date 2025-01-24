namespace ERP.API.Controllers.AddressControllers
{
    [Route("api/Address")]
    [ApiController]
    [Authorize]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _AddressService;
        private readonly IServiceAggregator _serviceAggregator;
        private readonly IMapper _mapper;
        public AddressController(IServiceAggregator serviceAggregator, IMapper mapper)
        {
            _mapper = mapper;
            _serviceAggregator =  serviceAggregator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(APIResponseDTO), (int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult<APIResponseDTO>> GET()
        {
            var response = new APIResponseDTO();
            try
            {
                var Addresss = await _AddressService.GetAllAsync();
                response.StatusCode = HttpStatusCode.OK;
                response.Result = Addresss;
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
                var Address = await _AddressService.GetByIdAsync(id);
                if (Address == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.IsSuccess = false;
                    response.ErrorMessages = new List<string> { "Address not found" };
                    return NotFound(response);
                }

                response.StatusCode = HttpStatusCode.OK;
                response.Result = Address;
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
        public async Task<ActionResult<APIResponseDTO>> POST([FromBody] CreateAddressDTO Address)
        {
            var response = new APIResponseDTO();
            if (Address == null)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Address cannot be null" };
                return BadRequest(response);
            }

            try
            {
                await _AddressService.Save(_mapper.Map<Address>(Address));
                response.StatusCode = HttpStatusCode.Created;
                response.Result = Address;
                return CreatedAtAction(nameof(GET), new { id = _mapper.Map<Address>(Address).AddressID }, response);
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
        public async Task<ActionResult<APIResponseDTO>> PUT(int id, [FromBody] UpdateAddressDTO Address)
        {


            var response = new APIResponseDTO();
            if (Address == null || id <= 0 || !(id == _mapper.Map<Address>(Address).AddressID))
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Invalid Address or ID" };
                return BadRequest(response);
            }

            try
            {
                _mapper.Map<Address>(Address).AddressID = id; // assuming Address has an Id property

                await _AddressService.Save(_mapper.Map<Address>(Address), id);

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
        public async Task<ActionResult<APIResponseDTO>> PATCH([FromBody] List<Address> Addresss)
        {
            var response = new APIResponseDTO();
            if (Addresss == null || Addresss.Count == 0)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.IsSuccess = false;
                response.ErrorMessages = new List<string> { "Addresss cannot be null or empty" };
                return BadRequest(response);
            }

            try
            {
                foreach (var Address in Addresss)
                {
                    if (Address.AddressID <= 0) // Assuming we need to add a new Address
                    {
                        await _AddressService.Save(_mapper.Map<Address>(Address));
                    }
                    else // Update existing Address
                    {
                        await _AddressService.Save(_mapper.Map<Address>(Address), Address.AddressID);
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
                await _AddressService.DeleteAsync(id);
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
