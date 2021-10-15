using Gestore.Core;
using Gestore.Core.BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gestore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBusinessLayer mainBusinessLayer;
        public OrderController(IBusinessLayer mainBusinessLayer)
        {
            this.mainBusinessLayer = mainBusinessLayer;
        }

        [HttpGet]
        public IActionResult FetchOrders()
        {
            var orders = this.mainBusinessLayer.FetchAllOrders();

            return Ok(orders);

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id Ordine non valido");
            }

            var result = this.mainBusinessLayer.GetOrderById(id);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (order == null)
            {
                return BadRequest("Dati ordine non validi");
            }

            var result = this.mainBusinessLayer.CreateOrder(order);

            if (!result)
            {
                return StatusCode(500, "Impossibile creare ordine");
            }

            return CreatedAtAction(nameof(GetById), new { Id = order.Id }, order);
        }


        [HttpPut("{id}")]
        public IActionResult Put(int id, Order editedOrder)
        {
            if (id <= 0 || editedOrder == null)
            {
                return BadRequest("Dati non validi");
            }

            if (id != editedOrder.Id)
            {
                return BadRequest("Id non combaciano");
            }

            var result = this.mainBusinessLayer.UpdateOrder(editedOrder);

            if (!result)
            {
                return StatusCode(500, "Impossibile modificare ordine");
            }
            return Ok(result);
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteOrderById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Id ordine non valido.");
            }

            var result = this.mainBusinessLayer.DeleteOrderById(id);

            if (!result)
            {
                return StatusCode(500, "Impossibile eliminare l'ordine");
            }
            return Ok(result);
        }

    }
}
