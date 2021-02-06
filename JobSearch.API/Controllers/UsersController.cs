using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSearch.API.Database;
using JobSearch.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JobSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private JobSearchContext _data;
        public UsersController(JobSearchContext data)
        {
            _data = data;


        }
        /*
         * htttp://localhost:porta/api/Users?email=teste@gmail.com&password=12345
         * 
         */
        [HttpGet]
        public IActionResult GetUser(string email,string password) {

            User userDB = _data.Users.FirstOrDefault(a => a.Email == email && a.Password == password);
             
            if(userDB == null)
            {
                return NotFound();//HTTP 404 - não encontrado

            }

            return new JsonResult(userDB);
            
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            //TODO - Validacao

            _data.Users.Add(user);
            _data.SaveChanges(); //unit

            //retornos 200 - OK | 201 - Created Object

            return CreatedAtAction(nameof(GetUser), new { email = user.Email, password = user.Password }, user);
        }

    }
}
