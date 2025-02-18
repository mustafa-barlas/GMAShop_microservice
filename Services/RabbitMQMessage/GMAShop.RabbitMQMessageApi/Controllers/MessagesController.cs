using System.Text;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Threading.Tasks;

namespace GMAShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        // Mesaj Gönderme (POST)
        [HttpPost]
        public IActionResult CreateMessage()
        {
            try
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = "localhost", // RabbitMQ'nun çalıştığından emin olun
                };

                using var connection = connectionFactory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(
                    queue: "queue1",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                );

                var messageContent = "Hello World!";
                var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

                channel.BasicPublish(
                    exchange: "",
                    routingKey: "queue1",
                    basicProperties: null,
                    body: byteMessageContent
                );

                return Ok("Your message has been added to the RabbitMQ queue.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Mesaj Alma (GET)
        [HttpGet]
        public async Task<IActionResult> ReadMessage()
        {
            try
            {
                var connectionFactory = new ConnectionFactory()
                {
                    HostName = "localhost", // RabbitMQ'nun çalıştığından emin olun
                };

                using var connection = connectionFactory.CreateConnection();
                using var channel = connection.CreateModel();

                var consumer = new EventingBasicConsumer(channel);
                string receivedMessage = string.Empty;

                // Mesaj alındığında tetiklenecek olan olay
                consumer.Received += (model, body) =>
                {
                    var byteMessage = body.Body.ToArray();
                    receivedMessage = Encoding.UTF8.GetString(byteMessage);
                };

                // Kuyruğa bağlanıyoruz ve mesaj almayı başlatıyoruz
                channel.BasicConsume(queue: "queue1", autoAck: true, consumer: consumer);

                // Mesaj geldiğinde, bu işlem hemen gerçekleşmeyebilir.
                // Bu yüzden 3 saniyelik bir bekleme süresi veriyoruz
                // Mesajı almazsa zaman aşımına uğrayacak
                await Task.Delay(3000);

                if (string.IsNullOrEmpty(receivedMessage))
                {
                    return NotFound("No message found in the queue.");
                }

                return Ok($"Message received: {receivedMessage}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
