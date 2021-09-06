using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class SegmentManager : ISegmentService
    {
        private ISegmentDal _segmentDal;
        public SegmentManager(ISegmentDal segmentDal)
        {
            _segmentDal = segmentDal;
        }
        public void Add(Segment segment)
        {
            _segmentDal.Add(segment);
        }

        public List<Segment> GetAll()
        {
            return new List<Segment>(_segmentDal.GetAll());
        }
    }
}
