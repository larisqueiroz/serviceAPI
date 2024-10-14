using System.Text.Json.Serialization;

namespace ServiceAPI.Models.DTO;

public class TypeDto: BaseDto
{
    public string Name { get; set; }
    public double Price { get; set; }
}