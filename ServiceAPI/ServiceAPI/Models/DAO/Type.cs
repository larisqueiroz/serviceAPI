using System.Text.Json.Serialization;

namespace ServiceAPI.Models.DAO;

public class Type: Base
{
    public string Name { get; set; }
    public double Price { get; set; }
    [JsonIgnore]
    public List<Product> Products { get; set; } = new List<Product>();
}