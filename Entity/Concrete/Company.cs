using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concrete
{
    public class Company : IEntity
    {
        public Company()
        {
            Cars = new List<Car>();
        }

        [Key]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
