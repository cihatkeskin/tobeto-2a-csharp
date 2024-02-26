namespace Business.Requests.Brand;

public class AddBrandRequest
{ // Dto
    public string Name { get; set; }
    public string LogoUrl { get; set; }

    public AddBrandRequest(string name, string logoUrl)
    {
        Name = name;
        LogoUrl = logoUrl;
    }
}
