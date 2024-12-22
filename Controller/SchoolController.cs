
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Data;
using SchoolWebApi.Model;

namespace SchoolWebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class SchoolController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        [HttpGet]
        public async Task<ActionResult<List<School>>> GetSchools()
        {

            var dataSchoolList = await _context.Schools.ToListAsync();
            var responseSuccess = new
            {
                status = "success",
                code = 200,
                data = dataSchoolList
            };
            return Ok(responseSuccess);

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<School>> GetSchoolById(Guid id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school is null)
            {
                var response = new
                {
                    status = "error",
                    code = 404,
                    message = "School not found"
                };

                return NotFound(response);
            }

            var responseSuccess = new
            {
                status = "success",
                code = 200,
                data = school
            };
            return Ok(responseSuccess);
        }
        [HttpPost]
        public async Task<ActionResult<School>> CreateNewSchool(School newSchool)
        {
            if (newSchool is null)
                return BadRequest();
            _context.Schools.Add(newSchool);
            await _context.SaveChangesAsync();
            var responseSuccess = new
            {
                status = "success",
                code = 201,
                message = "School created successfully",
                data = newSchool
            };

            return CreatedAtAction(nameof(GetSchoolById), new { id = newSchool.SchoolId }, responseSuccess);

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<School>> UpdateSchool(Guid id, School newDataSchool)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school is null)
            {
                var response = new
                {
                    status = "error",
                    code = 404,
                    message = "School not found"
                };

                return NotFound(response);
            }
            school.SchoolName = newDataSchool.SchoolName;
            school.City = newDataSchool.City;
            school.IsActive = newDataSchool.IsActive;
            school.PhoneNumber = newDataSchool.PhoneNumber;
            school.Address = newDataSchool.Address;
            school.State = newDataSchool.State;
            school.Email = newDataSchool.Email;
            school.Website = newDataSchool.Website;
            school.PostalCode = newDataSchool.PostalCode;

            await _context.SaveChangesAsync();
            var responseSuccess = new
            {
                status = "success",
                code = 201,
                message = "Berhasil Diupdate",
                data = school
            };
            return Ok(responseSuccess);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSchool(Guid id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school is null)
            {
                var response = new
                {
                    status = "error",
                    code = 404,
                    message = "School not found"
                };

                return NotFound(response);
            }
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            {
                var response = new
                {
                    status = "success",
                    code = 200,
                    message = "Berhasil Dihapus",
                    data = school
                };

                return Ok(response);
            }
        }
    }



}