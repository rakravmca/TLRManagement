using SampleWebsite.Data;
using SampleWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebsite.Business
{
    public class StitchingStatusComponent
    {
        /// <summary>
        /// Gets the stitching statuses.
        /// </summary>
        /// <returns></returns>
        public List<StitchingStatusModel> GetStitchingStatuses()
        {
            using (var db = new SampleEntities())
            {
                return db.StitchingStatus.Select(s => new StitchingStatusModel
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();
            }
        }
    }
}
