package it.gabrieletondi.telldontaskkata.useCase;

import it.gabrieletondi.telldontaskkata.domain.Order;
import it.gabrieletondi.telldontaskkata.domain.OrderStatus;
import it.gabrieletondi.telldontaskkata.repository.OrderRepository;

import static it.gabrieletondi.telldontaskkata.domain.OrderStatus.REJECTED;
import static it.gabrieletondi.telldontaskkata.domain.OrderStatus.SHIPPED;

public class OrderApprovalUseCase {
    private final OrderRepository orderRepository;

    public OrderApprovalUseCase(OrderRepository orderRepository) {
        this.orderRepository = orderRepository;
    }

    public void run(OrderApprovalRequest request) {
        final Order order = orderRepository.getById(request.getOrderId());

        if(request.isApproved()) {
            if (order.getStatus().equals(SHIPPED)) {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (order.getStatus().equals(REJECTED)) {
                throw new RejectedOrderCannotBeApprovedException();
            }

            order.setStatus(OrderStatus.APPROVED);

        } else {
            if (order.getStatus().equals(SHIPPED)) {
                throw new ShippedOrdersCannotBeChangedException();
            }

            if (order.getStatus().equals(OrderStatus.APPROVED)) {
                throw new ApprovedOrderCannotBeRejectedException();
            }

            order.setStatus(OrderStatus.REJECTED);
        }

        orderRepository.save(order);
    }
}
