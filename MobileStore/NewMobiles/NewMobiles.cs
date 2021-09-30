using System;
using System.ComponentModel.DataAnnotations;

namespace MobileStore.NewPhones
{
    public class NewMobiles
    {
        public int ID { get; set; }
        public string Model { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Proccesor { get; set; }
        public decimal Price { get; set; }
    }
}
