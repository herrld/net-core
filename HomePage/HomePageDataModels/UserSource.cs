using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomePageDataModels
{
    public class UserSource
    { 
        public string AccessToken { get; set; } 
        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
