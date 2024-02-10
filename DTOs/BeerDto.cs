using Api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.DTOs
{
    public class BeerDto
    {
        public int Id { get; set; }
        public decimal Alcohol { get; set; }
        public string Name{ get; set; }
        public int BrandId { get; set; }
    }
}
