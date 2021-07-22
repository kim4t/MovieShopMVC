﻿using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterMovie([FromBody] MovieCreateRequestModel model)
        {
            var createdMovie = await _adminService.CreateMovie(model);

            return Ok(createdMovie);
           
        }
        [HttpPut]
        public async Task<IActionResult> PutMovie([FromBody] MovieCreateRequestModel model)
        {
            var createdMovie = await _adminService.CreateMovie(model);

            return Ok(createdMovie);

        }
        [HttpGet]
        [Route("purchases")]
        public async Task<IActionResult> GetAllPurchases()
        {
            var purchases = await _adminService.GetAllPurchases();
            return Ok(purchases);
        }
    }
}
