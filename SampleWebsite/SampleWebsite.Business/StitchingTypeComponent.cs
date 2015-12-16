using SampleWebsite.Data;
using SampleWebsite.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebsite.Business
{
    public class StitchingTypeComponent
    {
        /// <summary>
        /// Gets the stitching types.
        /// </summary>
        /// <returns></returns>
        public List<StitchingTypeModel> GetStitchingTypes()
        {
            using (var db = new SampleEntities())
            {
                return db.StitchingTypes.Select(s => new StitchingTypeModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Cost = s.Cost,
                    Code = s.Code
                }).ToList();
            }
        }
    }
}
