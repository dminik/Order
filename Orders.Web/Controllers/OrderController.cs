namespace Orders.Web.Controllers
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.Entity.Infrastructure;
	using System.Linq;
	using System.Net;
	using System.Net.Http;
	using System.Web.Http;

	using Orders.Web.Models;

	public class OrderController : ApiController
	{        
		private OrderItemContext db = new OrderItemContext();
		
		// GET api/Order
		public IEnumerable<OrderItemDto> GetOrders()
		{
			return db.OrderItems                
				.OrderByDescending(u => u.Id)
				.AsEnumerable()
				.Select(orderList => new OrderItemDto(orderList));
		}

		// GET api/Order/5
		public OrderItemDto GetOrder(int id)
		{
			var orderItem = db.OrderItems.Find(id);
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

			OrderItem orderItem = orderItemDto.ToEntity();
			db.OrderItems.Add(orderItem);
			db.SaveChanges();
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

			OrderItem orderItem = orderItemDto.ToEntity();
			
			db.Entry(orderItem).State = EntityState.Modified;

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}

			return Request.CreateResponse(HttpStatusCode.OK);
		}
		
		// DELETE api/OrderItem/5        
		public HttpResponseMessage DeleteOrder(int id)
		{
			OrderItem orderItem = db.OrderItems.Find(id);
			if (orderItem == null)
			{
				return Request.CreateResponse(HttpStatusCode.NotFound);
			}

			var orderItemDto = new OrderItemDto(orderItem);
			db.OrderItems.Remove(orderItem);

			try
			{
				db.SaveChanges();
			}
			catch (DbUpdateConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError);
			}

			return Request.CreateResponse(HttpStatusCode.OK, orderItemDto);
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}
	}
}