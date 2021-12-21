using System.Collections.Generic;
using System.Linq;
using ASPNET.Models;
using ASPNET.Repositories;
using ASPNET.dto;
using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace ASPNET.Controllers
{
    [ApiController]
    [Route("api/biList")]
    public class BiListController : ControllerBase
    {
        private readonly IRepo _repo;
        private readonly IMapper _map;


        public BiListController(IRepo repo, IMapper map)
        {
            _repo = repo;
            _map = map;

        }

        [HttpGet]
        public ActionResult GetAllBiList()
        {
            return Ok(_map.Map<IEnumerable<BiListReadDto>>(_repo.GetAllBiList()));
        }

        [HttpGet("{id}", Name = "GetBiListById")]
        public ActionResult GetBiListById(int id)
        {

            return Ok(_map.Map<BiListReadDto>(_repo.GetBiListById(id)));
        }


        [HttpPost]
        public ActionResult AddBiList(BiListWriteDto t)
        {
            var bilist = _map.Map<BiList>(t);

            _repo.AddBiList(bilist);
            _repo.SaveChanges();

            return CreatedAtRoute(nameof(GetBiListById), new { Id = bilist.Id }, bilist);


        }


        [HttpPut("{id}")]
        public ActionResult UpdateBiList(int id, BiListUpdateDto t)
        {
            var existingBiList = _repo.GetBiListById(id);

            if (existingBiList == null)
            {
                return NotFound();
            }

            _map.Map(t, existingBiList);

            _repo.UpdateBiList(existingBiList);

            _repo.SaveChanges();

            return Ok();

        }


        [HttpDelete("{id}")]
        public ActionResult DeleteBiList(int id)
        {
            var existingBiList = _repo.GetBiListById(id);

            if (existingBiList == null)
            {
                return NotFound();
            }

            _repo.DeleteBiList(existingBiList);
            _repo.SaveChanges();
            return Ok();
        }
    }
}