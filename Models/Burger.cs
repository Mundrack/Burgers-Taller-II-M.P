using System.ComponentModel.DataAnnotations;

namespace MateoPugaProyectoII.Models
{
    public class Burger
    {
        public int  BurgerID { get; set; }
        [required]
        public string? Name { get; set; }
        public bool WithChees { get; set; }
        [Range(8, 15)]
        public decimal Precio { get; set; }

    }
}
