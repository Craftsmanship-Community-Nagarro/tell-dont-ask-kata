package it.gabrieletondi.telldontaskkata.domain;

import static it.gabrieletondi.telldontaskkata.domain.OrderStatus.CREATED;
import static it.gabrieletondi.telldontaskkata.domain.OrderStatus.REJECTED;
import static it.gabrieletondi.telldontaskkata.domain.OrderStatus.SHIPPED;

import it.gabrieletondi.telldontaskkata.service.ShipmentService;
import it.gabrieletondi.telldontaskkata.useCase.*;

import java.math.BigDecimal;
import java.util.List;

public class Order {
	private BigDecimal total;
	private String currency;
	private List<OrderItem> items;
	private BigDecimal tax;
	private OrderStatus status;
	private int id;

	public BigDecimal getTotal() {
		return total;
	}

	public void setTotal(BigDecimal total) {
		this.total = total;
	}

	public String getCurrency() {
		return currency;
	}

	public void setCurrency(String currency) {
		this.currency = currency;
	}

	public List<OrderItem> getItems() {
		return items;
	}

	public void setItems(List<OrderItem> items) {
		this.items = items;
	}

	public BigDecimal getTax() {
		return tax;
	}

	public void setTax(BigDecimal tax) {
		this.tax = tax;
	}

	public OrderStatus getStatus() {
		return status;
	}

	public void setStatus(OrderStatus status) {
		this.status = status;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	private void verifyShippable() {
		if (getStatus().equals(CREATED) || getStatus().equals(REJECTED)) {
			throw new OrderCannotBeShippedException();
		}

		if (getStatus().equals(SHIPPED)) {
			throw new OrderCannotBeShippedTwiceException();
		}
	}

	public void approve() {
		verifyCanBeChanged();
		if (getStatus().equals(REJECTED)) {
			throw new RejectedOrderCannotBeApprovedException();
		}

		setStatus(OrderStatus.APPROVED);
	}

	public void reject() {
		verifyCanBeChanged();
		if (getStatus().equals(OrderStatus.APPROVED)) {
			throw new ApprovedOrderCannotBeRejectedException();
		}

		setStatus(OrderStatus.REJECTED);
	}

	private void verifyCanBeChanged() {
		if (getStatus().equals(SHIPPED)) {
			throw new ShippedOrdersCannotBeChangedException();
		}
	}

	public void ship(ShipmentService shipmentService) {
		verifyShippable();

		shipmentService.ship(this);

		setStatus(SHIPPED);
	}
}
