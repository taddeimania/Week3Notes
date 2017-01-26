using Day4EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4EF
{
    class Program
    {
        static string Read(string input)
        {
            Console.Write(input);
            return Console.ReadLine();
        }

        static void Main(string[] args)
        {
            using (var db = new OrderContext())
            {
                while (true)
                {
                    Console.WriteLine("1) Create a Customer");
                    Console.WriteLine("2) Create an Item");
                    Console.WriteLine("3) Start an Order");
                    Console.WriteLine("4) Add an Item to an Order");
                    int choice = int.Parse(Read("> "));

                    switch (choice)
                    {
                        case 1:
                            CreateCustomer(db);
                            break;
                        case 2:
                            CreateInventory(db);
                            break;
                        case 3:
                            CreateOrder(db);
                            break;
                        case 4:
                            CreateOrderItem(db);
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        private static void CreateOrderItem(OrderContext db)
        {
            int allOrderItems = db.OrderItems.Count();
            Console.WriteLine($"{allOrderItems} order items in DB");

            foreach (var order in db.Orders)
            {
                Console.WriteLine($"{order.Id} - {order.Customer.Name}");
                foreach (var oItem in order.Items)
                {
                    Console.WriteLine($"-- {oItem.Inventory.Name}");
                }
            }
            int orderId = int.Parse(Read("Order ID? "));
            var orderInstance = db.Orders.Where(o => o.Id == orderId).First();

            foreach (var item in db.Inventories)
            {
                Console.WriteLine($"{item.Id} - {item.Name}");
            }
            int itemId = int.Parse(Read("Item ID? "));
            var itemInstance = db.Inventories.Where(i => i.Id == itemId).First();

            var orderItem = new OrderItem
            {
                Order = orderInstance,
                Inventory = itemInstance,
            };
            db.OrderItems.Add(orderItem);
            db.SaveChanges();
        }

        private static void CreateOrder(OrderContext db)
        {
            int allOrders = db.Orders.Count();
            Console.WriteLine($"{allOrders} orders in DB");

            foreach (var customer in db.Customers)
            {
                Console.WriteLine($"{customer.Id} - {customer.Name}");
            }
            int customerId = int.Parse(Read("Customer ID? "));
            var customerInstance = db.Customers.Where(c => c.Id == customerId).First();

            var discount = double.Parse(Read("Discount (not %)"));
            var myOrder = new Order
            {
                Customer = customerInstance,
                Discount = discount,
                OrderDate = DateTime.Now
            };

            db.Orders.Add(myOrder);
            db.SaveChanges();
        }

        private static void CreateInventory(OrderContext db)
        {
            var allInventory = db.Inventories.Count();
            Console.WriteLine($"{allInventory} items in DB");

            var name = Read("Name? ");
            var price = double.Parse(Read("Price? "));
            int qty = int.Parse(Read("QTY? "));

            var newInventory = new Inventory
            {
                Name = name,
                Price = price,
                Quantity = qty
            };

            db.Inventories.Add(newInventory);
            db.SaveChanges();
        }

        private static void CreateCustomer(OrderContext db)
        {
            var allCustomers = db.Customers.Count();
            Console.WriteLine($"{allCustomers} customers in DB");

            var name = Read("Name? ");
            var phone = Read("Phone? ");
            var address = Read("Address? ");
            var joinDate = DateTime.Now;

            Customer myCustomer = new Customer
            {
                Name = name,
                Phone = phone,
                Address = address,
                JoinDate = joinDate
            };

            db.Customers.Add(myCustomer);
            db.SaveChanges();
        }
    }
}
