namespace ERP.API.Controllers.Auth
{
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthController> _logger;
        protected APIResponseDTO _response;
        public AuthController(IAuthService authService, IConfiguration configuration, ILogger<AuthController> logger)
        {
            _authService = authService;
            _configuration = configuration;
            _logger = logger;
            _response = new APIResponseDTO();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO model)
        {

            try
            {
                var errorMessage = await _authService.Register(model);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add(errorMessage);
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during user registration");
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("An error occurred while registering the user.");
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model)
        {
            try
            {

                var loginResponse = await _authService.Login(model);
                if (loginResponse.User == null)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Invalid username or password.");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                _response.Result = loginResponse;
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during login");
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("An error occurred while logging in.");
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegisterRequestDTO model)
        {
            try
            {
                var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToLower());
                if (!assignRoleSuccessful)
                {
                    _response.IsSuccess = false;
                    _response.ErrorMessages.Add("Failed to assign role.");
                    _response.StatusCode = HttpStatusCode.BadRequest;
                    return BadRequest(_response);
                }
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during role assignment");
                _response.IsSuccess = false;
                _response.ErrorMessages.Add("An error occurred while assigning the role.");
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return StatusCode((int)HttpStatusCode.InternalServerError, _response);
            }
        }
    }
}
