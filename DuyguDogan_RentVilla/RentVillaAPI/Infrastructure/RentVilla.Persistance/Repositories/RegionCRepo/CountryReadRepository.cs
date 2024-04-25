﻿using RentVilla.Application.Repositories.RegionRepo;
using RentVilla.Domain.Entities.Concrete.Region;
using RentVilla.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentVilla.Persistence.Repositories.RegionCRepo
{
    public class CountryReadRepository : ReadRepository<Country>, ICountryReadRepository
    {
        public CountryReadRepository(RentVillaDbContext context) : base(context)
        {
        }
    }
}
