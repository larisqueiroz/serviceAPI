using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceAPI.Models.DAO;

public class Client: Base
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Code { get; set; }
    public string Name { get; set; }
}