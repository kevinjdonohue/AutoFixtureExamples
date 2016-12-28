using System;
using System.Collections.Generic;
using AutoFixtureExample;
using FluentAssertions;
using Ploeh.AutoFixture;
using Xunit;

namespace AutoFixtureExampleTests
{
    public class OrderTests
    {
        [Fact]
        public void Example_ArrangingAnOrder_ManualSetup()
        {
            //arrange
            Customer customer = new Customer()
            {
                CustomerName = "Amrit"
            };
            Order order = new Order(customer)
            {
                Id = 42,
                OrderDate = DateTime.Now,
                Items = new List<OrderItem>
                {
                    new OrderItem
                    {
                        ProductName = "Rubber Ducks",
                        Quantity = 2
                    }
                }
            };
            List<Order> orders = new List<Order> { order };

            //act

            //assert
            orders[0].ShouldBeEquivalentTo(order);
        }

        [Fact]
        public void Example_ArrangingAnOrder_AutoCreation()
        {
            //arrange
            Fixture fixture = new Fixture();
            Order order = fixture.Create<Order>();
            List<Order> orders = new List<Order> { order };

            //act

            //arrange
            orders[0].ShouldBeEquivalentTo(order);
        }
    }
}