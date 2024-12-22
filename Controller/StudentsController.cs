using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolWebApi.Data;
using SchoolWebApi.Model;

namespace SchoolWebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {

            var dataStudentList = await _context.Students.ToListAsync();
            var responseSuccess = new
            {
                status = "success",
                code = 200,
                data = dataStudentList
            };
            return Ok(responseSuccess);

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
            {
                var response = new
                {
                    status = "error",
                    code = 404,
                    message = "Student not found"
                };

                return NotFound(response);
            }

            var responseSuccess = new
            {
                status = "success",
                code = 200,
                data = student
            };
            return Ok(responseSuccess);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> CreateNewStudent(Student newStudent)
        {
            if (newStudent is null)
                return BadRequest();
            _context.Students.Add(newStudent);
            await _context.SaveChangesAsync();
            var responseSuccess = new
            {
                status = "success",
                code = 201,
                message = "Student created successfully",
                data = newStudent
            };

            return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.StudentId }, responseSuccess);

        }
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(Guid id, Student newDataStudent)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
            {
                var response = new
                {
                    status = "error",
                    code = 404,
                    message = "Student not found"
                };

                return NotFound(response);
            }
            student.FirstName = newDataStudent.FirstName;
            student.LastName = newDataStudent.LastName;
            student.IsActive = newDataStudent.IsActive;
            student.PhoneNumber = newDataStudent.PhoneNumber;
            student.Address = newDataStudent.Address;
            student.Country = newDataStudent.Country;
            student.Email = newDataStudent.Email;
            student.Gender = newDataStudent.Gender;
            student.DateOfBirth = newDataStudent.DateOfBirth;

            await _context.SaveChangesAsync();
            var responseSuccess = new
            {
                status = "success",
                code = 201,
                message = "Berhasil Diupdate",
                data = student
            };
            return Ok(responseSuccess);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student is null)
            {
                var response = new
                {
                    status = "error",
                    code = 404,
                    message = "Student not found"
                };

                return NotFound(response);
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            {
                var response = new
                {
                    status = "success",
                    code = 200,
                    message = "Berhasil Dihapus",
                    data = student
                };

                return Ok(response);
            }
        }







    };


}