using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpSchool.Domain.Utilities
{
    public class LocalDB : ILocalDB
    {
        public List<string> IPs { get ; set ; }


        public LocalDB()
        {
            IPs= new List<string>();
        }
    }
}
