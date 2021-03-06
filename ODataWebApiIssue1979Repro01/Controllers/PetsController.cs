﻿using ODataWebApiIssue1979Repro01.DataSources;
using ODataWebApiIssue1979Repro01.Models;
using Microsoft.AspNet.OData;
using System.Linq;

namespace ODataWebApiIssue1979Repro01.Controllers
{
    public class PetsController: ODataController
    {
        private PetsDbContext _db;

        public PetsController(PetsDbContext db)
        {
            _db = db;
        }

        [EnableQuery]
        public IQueryable<Pet> Get()
        {
            return _db.Pets;
        }

        [EnableQuery]
        public SingleResult<Pet> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Pets.Where(d => d.Id.Equals(key)));
        }
    }
}
