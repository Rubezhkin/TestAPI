using Microsoft.AspNetCore.Mvc;
using Models;
using Dadata;
using Dadata.Model;
using AutoMapper;
using Microsoft.Extensions.Options;
using Serilog;
namespace Controllers;

[ApiController]
[Route("address")]
public class AddressesContorller : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly APIData apidata;
	private ILogger<AddressesContorller> _logger;
	private CleanClientAsync _api;
	public AddressesContorller(IMapper mapper, IOptions<APIData> options, ILogger<AddressesContorller> logger)
	{
		_mapper = mapper;
		apidata = options.Value;
		_api = new CleanClientAsync(apidata.Token, apidata.Secret);
		_logger = logger;
	}

	[HttpGet(Name ="{address}")]
	public async Task<IActionResult> Get(String address){
		_logger.LogInformation($"Requested information about {address}");
		Dadata.Model.Address answer = await _api.Clean<Dadata.Model.Address>(address);
		var result = _mapper.Map<Dadata.Model.Address, Models.Address>(answer);
		return Ok(result);
	}
}