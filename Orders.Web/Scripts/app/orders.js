﻿"use strict";

define(["jquery", "ko"],
	function ($, ko) {        
					  
		function OrderViewModel(resource) {
			//Make the self as 'this' reference
			var self = this;
			//Declare observable which will be bind with UI
			self.Id = ko.observable("");
			self.Text = ko.observable("");
			self.Status = ko.observable("New");
			self.Email = ko.observable("");

			var Order = {
				Id: self.Id,
				Text: self.Text,
				Status: self.Status,
				Email: self.Email
			};

			self.Order = ko.observable();
			self.Orders = ko.observableArray(); // Contains the list of orders

			// Initialize the view-model
			$.ajax({
				url: '/api/Order/',
				cache: false,
				type: 'GET',
				contentType: 'application/json; charset=utf-8',
				data: {},
				beforeSend: function() {
					$('#loader').show();
				},
				complete: function() {
					$('#loader').hide();
				},
				success: function(data) {
					self.Orders(data); //Put the response in ObservableArray
				}
			}).fail(
						function (xhr, textStatus, err) {
							alert(xhr.responseText); 
						});;

			//Add New Item
			self.create = function() {
				Order.Id = '0';

				if (Order.Text() != "" && Order.Status() != "" && Order.Email() != "") {
					$.ajax({
						url: '/api/Order/0',
						cache: false,
						type: 'POST',
						contentType: 'application/json; charset=utf-8',
						data: ko.toJSON(Order),
						beforeSend: function() {
							$('#loader').show();
						},
						complete: function() {
							$('#loader').hide();
						},
						success: function(data) {
							// alert('added');
							self.Orders.push(data);
							self.Text("");
							self.Status("New");
							self.Email("");

						}
					}).fail(
						function(xhr, textStatus, err) {
							alert(xhr.responseText);
						});

				} else {
					alert(resource.EnterAllFields);
				}

			}

			// Update order details
			self.update = function () {
				var order = self.Order();

				$.ajax({
					url: '/api/Order/' + order.Id,
					cache: false,
					type: 'PUT',
					contentType: 'application/json; charset=utf-8',
					data: ko.toJSON(order),
					beforeSend: function () {
						$('#loader').show();
					},
					complete: function () {
						$('#loader').hide();
					},
					success: function (data) {
						self.Orders.remove(order);
						self.Orders.push(order);
						self.Order(null);
						alert(resource.Updated);
					}
				})
					.fail(
						function (xhr, textStatus, err) {
							alert(err);
						});
			}

			// Delete order details
			self.delete = function(order) {
				if (confirm(resource.SureToDelete.replace('{0}', order.Text))) {
					var id = order.Id;

					$.ajax({
						url: '/api/Order/' + id,
						cache: false,
						type: 'DELETE',
						contentType: 'application/json; charset=utf-8',
						beforeSend: function() {
							$('#loader').show();
						},
						complete: function() {
							$('#loader').hide();
						},
						success: function(data) {
							self.Orders.remove(order);
						}
					}).fail(
						function(xhr, textStatus, err) {
							alert(err);
						});
				}
			}

			// Edit order details
			self.edit = function(order) {
				self.Order(order);

			}

			self.ping = function () {				
				$.ajax({
					url: '/api/Order/Ping',
					cache: false,
					type: 'GET',									
					beforeSend: function () {
						$('#loader').show();
					},
					complete: function () {
						$('#loader').hide();
					},
					success: function (data) {
						alert(data + " ok");
					}
				})
					.fail(
						function (xhr, textStatus, err) {
							alert("Error: " + xhr.responseText);
						});
			}
			
			// Reset order details
			self.reset = function() {
				self.Text("");
				self.Status("New");
				self.Email("");
			}

			// Cancel order details
			self.cancel = function() {
				self.Order(null);
			}
		}
				
		var init = function (require, lang) {

			require(['/Scripts/Localization/ordersLocalization_' + lang + '.js'], function (requireorderLocalization) { 
				var viewModel = new OrderViewModel(requireorderLocalization);
				ko.applyBindings(viewModel);
			});            
		};

		return {
			init: init
		};
	}   
);