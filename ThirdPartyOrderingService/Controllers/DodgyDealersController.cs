﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThirdPartyOrderingService.Dtos;
using ThirdPartyOrderingService.Services;

namespace ThirdPartyOrderingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Staff"]
    public class DodgyDealersController : ControllerBase, ISupplierController
    {
        private Services.DodgyDealersService _dds;
        private readonly string SupplierName = "DodgyDealers";

        public DodgyDealersController(IDodgyDealersService Dds)
        {
            _dds = (DodgyDealersService)Dds;
        }

        [HttpPost("Order")]
        //[Authorize(Roles = "Staff"]
        public async Task<IActionResult> Order([FromBody]Order order)
        {
            order.SupplierName = SupplierName;
            return await _dds.MakeOrderAsync(order);
        }

        [HttpGet("Orders")]
        public IActionResult GetOrderById([FromBody] int OrderID)
        {
            return _dds.GetOrder(OrderID);
        }

        [HttpDelete("Orders")]
        public Task<IActionResult> DeleteOrderAsync([FromBody] int OrderID)
        {
            return _dds.DeleteOrderAsync(OrderID);
        }
    }
}