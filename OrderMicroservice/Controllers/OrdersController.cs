﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderMicroservice.Models;
using OrderMicroservice.Repository.Interfaces;

namespace OrderMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderManager _orderManager;

        public OrdersController(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }
        // GET api/orders
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            return await _orderManager.GetAllOrders();
        }

        // GET api/orders/1
        [HttpGet("{id}")]
        public async Task<Order> Get(int id)
        {
            return await _orderManager.GetOrderById(id);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] Order orderVal)
        {
            await _orderManager.SaveOrder(orderVal);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] Order orderVal)
        {
            await _orderManager.UpdateOrder(id, orderVal);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            await _orderManager.DeleteOrder(id);
        }
    }
}
