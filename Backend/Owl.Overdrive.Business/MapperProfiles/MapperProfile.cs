using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Business.MapperProfiles
{
    public partial class MapperProfile: Profile
    {
        public MapperProfile()
        {
            MapCompany();
            MapLookups();
            MapPlatforms();
            MapGame();
        }
    }
}
