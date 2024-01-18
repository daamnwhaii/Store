﻿using Microsoft.AspNetCore.Mvc;
using Store.Messages;
using Store.Web.Models;
using System.Net;
using System.Text.RegularExpressions;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IOrderRepository orderRepository;
        private readonly INotificationService notificationService;

        public OrderController(IProductRepository productRepository,
                               IOrderRepository orderRepository,
                               INotificationService notificationService)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                var order = orderRepository.GetById(cart.OrderId);
                OrderModel model = Map(order);

                return View(model);
            }
            return View("Empty");
        }

        private OrderModel Map(Order order)
        {
            var productIds = order.Items.Select(item => item.ProductId);
            var products = productRepository.GetAllByIds(productIds);
            var itemModels = from item in order.Items
                             join product in products on item.ProductId equals product.Id
                             select new OrderItemModel
                             {
                                 ProductId = product.Id,
                                 Title = product.Title,
                                 Brand = product.Brand,
                                 Price = item.Price,
                                 Count = item.Count,
                             };
            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        [HttpPost]
        public IActionResult AddItem(int productId, int count = 1)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            var product = productRepository.GetById(productId);

            order.AddOrUpdateItem(product, count);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Product", new { id = productId });
        }

        [HttpPost]
        public IActionResult UpdateItem(int productId, int count)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.GetItem(productId).Count = count;

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Order");
        }

        private (Order order, Cart cart) GetOrCreateOrderAndCart()
        {
            Order order;

            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }
            return (order, cart);
        }
        private void SaveOrderAndCart(Order order, Cart cart)
        {
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
        }

        [HttpPost]
        public IActionResult RemoveItem(int productId)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.RemoveItem(productId);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Order");
        }



        [HttpPost]
        public IActionResult SendConfirmationCode(int id, string cellPhone)
        {
            var order = orderRepository.GetById(id);
            var model = Map(order);
            if (!IsValidCellPhone(cellPhone))
            {
                model.Errors["cellPhone"] = "Номер телефона не соответствует формату +79XXXXXXXXX";
                return View("Index", model);
            }

            int code = 1111; // random.Next(1000, 10000)
            HttpContext.Session.SetInt32(cellPhone, code);
            notificationService.SendConfirmationCode(cellPhone, code);

            return View("Confirmation",
                        new ConfirmationModel
                        {
                            OrderId = id,
                            CellPhone = cellPhone
                        });
        }

        private bool IsValidCellPhone(string cellPhone)
        {
            if (cellPhone == null)
                return false;

            cellPhone = cellPhone.Replace(" ", "")
                                 .Replace("-", "");

            return Regex.IsMatch(cellPhone, @"^\+?\d{11}$");
        }

        [HttpPost]
        public IActionResult StartDelivery(int id, string cellPhone, int code)
        {
            int? storedCode = HttpContext.Session.GetInt32(cellPhone);
            if (storedCode == null)
            {
                return View("Confirmation",
                            new ConfirmationModel
                            {
                                OrderId = id,
                                CellPhone = cellPhone,
                                Errors = new Dictionary<string, string>
                                {
                                    { "code", "Пустой код, повторите отправку" }
                                },
                            }); ;
            }

            if (storedCode != code)
            {
                return View("Confirmation",
                            new ConfirmationModel
                            {
                                OrderId = id,
                                CellPhone = cellPhone,
                                Errors = new Dictionary<string, string>
                                {
                                    { "code", "Неверный код" }
                                },
                            }); ;
            }

            //

            return View();
        }
    }
}
