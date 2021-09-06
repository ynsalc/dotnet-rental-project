using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concrete
{
    public class Segment : IEntity
    {
        public Segment()
        {
            Cars = new List<Car>();
        }

        [Key]
        public int Id { get; set; }
        public string SegmentName { get; set; }
        public List<Car> Cars { get; set; }
    }
}
