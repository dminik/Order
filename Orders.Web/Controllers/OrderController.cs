using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;

using AutoMapper;

using Orders.Web.Domain.Models;
using Orders.Web.Models;

using Orders.Web.Services;

namespace Orders.Web.Controllers
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Web.Http;

	public class OrderController : ApiController
	{        		
		private readonly IOrderService _orderService;

		public OrderController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		// GET api/Order
		public IEnumerable<OrderItemDto> GetOrders()
		{			
			var orders = _orderService.GetOrders().ToList();

			Mapper.CreateMap<OrderItem, OrderItemDto>();
			var orderDtoList = Mapper.Map<List<OrderItem>, IEnumerable<OrderItemDto>>(orders);

			return orderDtoList;
		}


		[HttpGet]
		public string Ping(string str)
		{
			return _orderService.Ping(str);
		}

		 // GET api/Order/5
		public OrderItemDto GetOrder(int id)
		{
			var orderItem = _orderService.GetByKey(id);
			if (orderItem == null)
			{
				throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
			}

			return new OrderItemDto(orderItem);
		}

		// POST api/Order      
		public HttpResponseMessage PostOrder(OrderItemDto orderItemDto)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			var orderItem = _orderService.Add(orderItemDto.ToEntity());

			orderItemDto.Id = orderItem.Id;

			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, orderItemDto);
			response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = orderItemDto.Id }));
			return response;
		}

		// PUT api/Order/5        
		public HttpResponseMessage PutOrder(int id, OrderItemDto orderItemDto)
		{
			if (!ModelState.IsValid)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
			}

			if (id != orderItemDto.Id)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest);
			}

			_orderService.Update(orderItemDto.ToEntity());

			return Request.CreateResponse(HttpStatusCode.OK);
		}
		
		// DELETE api/OrderItem/5        
		public HttpResponseMessage DeleteOrder(int id)
		{
			_orderService.GetByKey(id);
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		
	}
}