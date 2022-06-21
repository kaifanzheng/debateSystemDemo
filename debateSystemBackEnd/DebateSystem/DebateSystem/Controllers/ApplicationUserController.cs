using Azure.Storage.Blobs;
using DebateSystem.Data;
using DebateSystem.Models;
using DebateSystem.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DebateSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IApplicationUserValidation _validation;
        private ApiDbContext _dbContext;
        private FileUpload fileUpload_service;
        public ApplicationUserController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _validation = new ApplicationUserValidation();
            fileUpload_service = new FileUpload();
        }

        // GET: api/<ApplicationUserController>
        [HttpGet]
        public async Task<IActionResult> GetAllApplicationUsers()
        {
            var users = await (from aUser in _dbContext.ApplicationUsers
                               select new
                               {
                                   Id = aUser.Id,
                                   UserName = aUser.UserName,
                                   ImageUrl = aUser.ImageUrl
                               }).ToListAsync();
            return Ok(users);
        }

        // GET api/<ApplicationUserController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                ApplicationUser user = await _dbContext.ApplicationUsers.FindAsync(id);
                return Ok(Argument.NotNull(user, nameof(user)));
            }
            catch
            {
                return NotFound("the user is not found");
            }
            //return Ok(service.GetApplicationUserById(id));
        }

        // POST api/<ApplicationUserController>
        /*        [HttpPost]
                public async Task<IActionResult> Post([FromBody] ApplicationUser applicationUser)
                {
                    try
                    {
                        await _dbContext.ApplicationUsers.AddAsync(_validation.userValidation(applicationUser));
                        await _dbContext.SaveChangesAsync();
                        return StatusCode(StatusCodes.Status201Created);
                    }
                    catch
                    {
                        return BadRequest("create unsuccessful");
                    }
                }*/
        // POST api/<ApplicationUserController>
        //post file, issue unsolved file upload duplicate file problem
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] ApplicationUser applicationUser)
        {
            try
            {
                applicationUser = _validation.userValidation(applicationUser);
                var imgURL = await fileUpload_service.UploadFile(applicationUser.ProfilePicture);
                applicationUser.ImageUrl = imgURL;
                await _dbContext.ApplicationUsers.AddAsync(applicationUser);
                await _dbContext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message.ToString());
            }

        }

        // PUT api/<ApplicationUserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ApplicationUser applicationUser)
        {
            try
            {
                var user = await _dbContext.ApplicationUsers.FindAsync(id);
                user = Argument.NotNull(user, nameof(user));
                applicationUser = _validation.userValidation(applicationUser);
                user.Email = applicationUser.Email;
                user.UserName = applicationUser.UserName;
                user.Password = applicationUser.Password;
                await _dbContext.SaveChangesAsync();
                return Ok("user record update successfully");
            }
            catch
            {
                return BadRequest("update unsuccessful");
            }
        }

        // DELETE api/<ApplicationUserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var user = await _dbContext.ApplicationUsers.FindAsync(id);
                user = Argument.NotNull(user, nameof(user));
                _dbContext.ApplicationUsers.Remove(user);
                await _dbContext.SaveChangesAsync();
                return Ok("user record delete successfully");
            }
            catch
            {
                return NotFound("delete unsuccessful");
            }
        }
    }
}
