﻿using Capstone_api.Data;
using Capstone_api.Models;
using Capstone_api.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Capstone_api.Controllers
{
    [Route("2024CapstoneApi/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly GlobalDBContext _dbContext;
        public PersonController(GlobalDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("/allPersons")]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            try
            {
                var dataHandler = new DataHandler();
                var data = await dataHandler.getAllPersons(_dbContext);
            
                if(data != null)
                {
                    return Ok(data);
                }
                else
                {
                    throw new Exception();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
