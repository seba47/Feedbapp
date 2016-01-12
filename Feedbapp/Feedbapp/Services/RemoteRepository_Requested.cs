using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Feedbapp.Entities;

namespace Feedbapp.Services
{
    public class RemoteRepository_Requested: RemoteRepository<Requested>
    {
        public RemoteRepository_Requested() : base("Requesteds")
        {

        }
    }
}
