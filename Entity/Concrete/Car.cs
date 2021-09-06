using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Core.Entities;

namespace Entity.Concrete
{
    public class Car : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string CarName { get; set; }
        public int Kilometer { get; set; }
        public decimal Price { get; set; }
        public decimal Deposite { get; set; }
        public int Point { get; set; }
        public int SegmentId { get; set; }
        public int CompanyId { get; set; }
        public decimal? CompanyCount { get; set; }
        public int? TotalAlgorithm { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        [ForeignKey(nameof(SegmentId))]
        public Segment Segment { get; set; }
    }
}
