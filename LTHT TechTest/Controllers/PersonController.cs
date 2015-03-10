using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using LTHTTechTest.Core.Concrete;
using LTHTTechTest.Core.Contracts;
using LTHTTechTest.Models;

namespace LTHTTechTest.Controllers
{
    public class PersonController : ApiController
    {
        private IDataService _dataService = null;

        public PersonController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            // TODO could do with some error handling
            var people = _dataService.People.ToArray();

            var data = people.Select(x => new PeopleViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                IsAuthorised = x.IsAuthorised,
                IsEnabled = x.IsEnabled,
                Colours = string.Join(", ", x.Colours.Select(colour => colour.Name))
            }).ToArray();

            return Ok(data);
        }

        public IHttpActionResult Get(int id)
        {
            var person = _dataService.People.SingleOrDefault(x => x.PersonId == id);
            if (person == null)
                return NotFound();

            var colours = new List<ColourViewModel>();
            foreach (var colour in _dataService.Colours)
            {
                var cvm = new ColourViewModel
                {
                    ColourId = colour.ColourId,
                    Name = colour.Name,
                    IsFavourite = person.Colours.Contains(colour)
                };

                colours.Add(cvm);
            }

            return Ok(new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                IsAuthorised = person.IsAuthorised,
                IsEnabled = person.IsEnabled,
                Colours = colours
            });
        }

        public IHttpActionResult Put(int id, [FromBody] PersonViewModel data)
        {
            var person = _dataService.People.SingleOrDefault(x => x.PersonId == id);
            if (person == null)
                return NotFound();

            person.IsAuthorised = data.IsAuthorised;
            person.IsEnabled = data.IsEnabled;
            foreach (var item in data.Colours)
            {
                var colour = _dataService.Colours.SingleOrDefault(x => x.ColourId == item.ColourId);
                if (colour != null)
                {
                    if (item.IsFavourite)
                    {
                        if (person.Colours.Contains(colour) == false)
                        {
                            person.Colours.Add(colour);
                        }
                    }
                    else
                    {
                        if (person.Colours.Contains(colour))
                        {
                            person.Colours.Remove(colour);
                        }
                    }
                }
            }

            _dataService.SaveChanges();
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (_dataService != null)
            {
                _dataService.Dispose();
                _dataService = null;
            }
        }
    }
}