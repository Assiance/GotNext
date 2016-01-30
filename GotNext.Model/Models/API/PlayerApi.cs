using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GotNext.Model.Models.API
{
    public class PlayerApi
    {
        
        public int Id { get; set; }
        public SportTypeApi SportType { get; set; }
    }
}
