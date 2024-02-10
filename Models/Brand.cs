using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public  int IdBrand{ get; set; }

        public string Name { get; set; }

    }
}