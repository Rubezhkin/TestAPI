using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using Dadata;
using Dadata.Model;
namespace TestAPI.Controllers;

[ApiController]
[Route("address")]
public class AddressesContorller : ControllerBase
{
	[HttpGet(Name ="{address}")]
	public async Task<Dadata.Model.Address> Get(String address){
		string token = "enter token here";
		string secret = "enter secret token here";
		CleanClientAsync api = new CleanClientAsync(token, secret);
		var result = await api.Clean<Dadata.Model.Address>(address);
		return result;
	}
}