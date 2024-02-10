using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    public class Beer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   
        public int IdBeer { get; set; }

        [Column(TypeName ="Decimal(18,2)")]
        public decimal Alcohol { get; set; }
        public string NameBeer { get; set; }

        public int BrandId { get; set; }    

        [ForeignKey("BrandId")] //nombre del campo que se relaciona
        public virtual Brand Brand { get; set; }
        //tiene una marca! relacionada con el id de marca!
    }
}
