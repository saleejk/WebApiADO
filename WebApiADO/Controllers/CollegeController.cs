using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiADO.Model;

namespace WebApiADO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollegeController : ControllerBase
    {
        private readonly ICollegeRep _collegeRep;
        public CollegeController(ICollegeRep collegeRep)
        {
            _collegeRep= collegeRep;
        }
        [HttpGet]
        public ActionResult GetColleges()
        {
            return Ok(_collegeRep.GetColleges());
        }
        [HttpGet("{id}")]
        public ActionResult GetCollegeById(int id)
        {
            return Ok(_collegeRep.GetCollegeById(id));
        }
        [HttpPost]
        public ActionResult AddCollege([FromBody]College college)
        {
            college.Id = _collegeRep.GetColleges().LastOrDefault().Id + 1;
            _collegeRep.AddCollege(college);
            return Ok();
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCollege(int id,College college)
        {
            _collegeRep.UpdateCollege(id, college);
            return Ok("Spdated Successfully");
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCollege(int id)
        {
            _collegeRep.DeleteCollege(id);
            return Ok("Delete Successfully");
        }
    }
}
