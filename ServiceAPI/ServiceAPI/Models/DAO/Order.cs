using System.ComponentModel.DataAnnotations.Schema;

namespace ServiceAPI.Models.DAO;

public class Order: Base
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Code { get; set; }
    public List<Product> Itens { get; set; }
    public Client Client { get; set; }
    public int ClientCode { get; set; }
}