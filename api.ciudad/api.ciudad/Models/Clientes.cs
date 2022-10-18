using System.ComponentModel.DataAnnotations.Schema;

namespace api.ciudad.Models
{
    public class Clientes
    {
       

        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
       
    }
}
