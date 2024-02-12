Console.WriteLine("Starting");

var ordersQueue = new Queue<string>();

var orderPlacer = new OrderPlacer(ordersQueue);

var orderServer = new OrderServer(ordersQueue);

var placeOrdersTask = orderPlacer.PlaceOrdersAsync(new[]
{
    "Pizza",
    "Soup",
    "Chicken",
    "Ice Cream"
});

Thread.Sleep(2_000);

var serveOrdersTask = orderServer.ServeOrdersAsync();

Console.WriteLine("End of all");

while (true)
{
}

public class OrderPlacer
{
    private readonly Queue<string> _ordersQueue;
    public OrderPlacer(Queue<string> ordersQueue) => 
        _ordersQueue = ordersQueue;

    public Task PlaceOrdersAsync(string[] orders) =>
        Task.Run(() =>
        {
            Console.WriteLine("Placing Orders");
            foreach (var order in orders)
            {
                Console.WriteLine($"Placing {order}");
                Thread.Sleep(1_000);
                _ordersQueue.Enqueue(order);
            }
            Console.Write("Ending Placing Orders");
        });
}

public class OrderServer
{
    private readonly Queue<string> _ordersQueue;
    public OrderServer(Queue<string> ordersQueue) => 
        _ordersQueue = ordersQueue;

    public Task ServeOrdersAsync() =>
        Task.Run(() =>
        {
            Console.WriteLine("Serving Orders");

            while (true)
            {
                if(_ordersQueue.Count > 0)
                {
                    var order = _ordersQueue.Dequeue();
                    Console.WriteLine($"Serving {order}");
                    Thread.Sleep(2_000);
                }
            }
        });
}