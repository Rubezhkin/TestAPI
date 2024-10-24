
public class APIData
{
	public string Token {get;set;}
	public string Secret {get;set;}

	public APIData(string token, string secret)
	{
		Token = token;
		Secret = secret;
	}

	public APIData() { }
}