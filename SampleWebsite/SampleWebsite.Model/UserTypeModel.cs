using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebsite.Model
{
    public class UserTypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserModel[] Users { get; set; }
    }
}
