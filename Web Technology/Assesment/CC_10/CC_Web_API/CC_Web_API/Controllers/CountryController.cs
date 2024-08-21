using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CC_Web_API.Models;

namespace CC_Web_API.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country{ID=1,CountryName="India",Capital="Delhi"},
        new Country{ID=2,CountryName="Japan",Capital="Tokyo"},
         new Country{ID=3,CountryName="UK",Capital="London"},
          new Country{ID=4,CountryName="France",Capital="Paris"}

        };
        [HttpGet]
        public IHttpActionResult GetCountries()
        {
            return Ok(countries);
        }

       [HttpGet]
        public IHttpActionResult GetCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }

       [HttpPost]
        public IHttpActionResult PostCountry(Country Add_new_Country)
        {
            if (Add_new_Country == null)
            {
                return BadRequest("Invalid data.");
            }
            Add_new_Country.ID = countries.Count>0? countries.Max(c => c.ID) + 1 : 1;  
            countries.Add(Add_new_Country);
            return Ok(Add_new_Country);
        }

      [HttpPut]
        public IHttpActionResult PutCountry(int id, Country New_Updated_Country)
        {
            if (New_Updated_Country == null)
            {
                return BadRequest("Wrong Input, Can not be NULL.");
            }
            var country = countries.FirstOrDefault(c => c.ID == id);
            
            country.CountryName = New_Updated_Country.CountryName;
            country.Capital = New_Updated_Country.Capital;
            return Ok(country);
        }

        [HttpDelete]
        public IHttpActionResult DeleteCountry(int id)
        {
            var country = countries.FirstOrDefault(c => c.ID == id);
            if (country == null)
            {
                return NotFound();
            }
            countries.Remove(country);
            return Ok();
        }
    }
}
