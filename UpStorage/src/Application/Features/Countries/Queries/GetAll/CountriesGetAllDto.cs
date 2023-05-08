﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Features.Countries.Queries.GetAll
{
    public class CountriesGetAllDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountriesGetAllDto(int id, string name)
        {
            Id = id;
            Name = name;
        }

      
    }
}
