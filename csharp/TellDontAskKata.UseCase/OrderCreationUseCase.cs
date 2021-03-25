using System;
using System.Collections.Generic;
using TellDontAsk.Repository;
using TellDontAskKata.Domain;
using TellDontAskKata.Repository;

namespace TellDontAskKata.UseCase
{
    public class OrderCreationUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductCatalog productCatalog;

        public OrderCreationUseCase(IOrderRepository orderRepository, IProductCatalog productCatalog)
        {
            this.orderRepository = orderRepository;
            this.productCatalog = productCatalog;
        }

        public void Run(SellItemsRequest request)
        {
            Order order = new Order();

            foreach (SellItemRequest itemRequest in request.GetRequests())
            {
                Product product = productCatalog.GetByName(itemRequest.GetProductName());

                if (product == null)
                {
                    throw new UnknownProductException();
                }

                OrderItem orderItem = new OrderItem(product, itemRequest.GetQuantity());
                order.AddItem(orderItem);
            }

            orderRepository.Save(order);
        }
    }
}
