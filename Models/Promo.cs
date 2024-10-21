namespace MateoPugaProyectoII.Models
{
    public class Promo
    {
        public int PromoID { get; set; }
        public string Description { get; set; }
        public DateTime FechaPromo { get; set; }
        

        public int BurgerID { get; set; }
        public Burger? Burger { get; set; }
    }
}
