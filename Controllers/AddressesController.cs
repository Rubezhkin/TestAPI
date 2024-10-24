using Microsoft.AspNetCore.Mvc;
using Models;
using Dadata;
using Dadata.Model;
using AutoMapper;
using Microsoft.Extensions.Options;
namespace Controllers;

[ApiController]
[Route("address")]
public class AddressesContorller : ControllerBase
{
	private readonly IMapper _mapper;
	private readonly APIData apidata;
	
	private CleanClientAsync _api;
	public AddressesContorller(IMapper mapper, IOptions<APIData> options)
	{
		_mapper = mapper;
		apidata = options.Value;
		_api = new CleanClientAsync(apidata.Token, apidata.Secret);
	}

	[HttpGet(Name ="{address}")]
	public async Task<Models.Address> Get(String address){
		Dadata.Model.Address answer = await _api.Clean<Dadata.Model.Address>(address);
		var result = _mapper.Map<Dadata.Model.Address, Models.Address>(answer);
		return result;
	}
}