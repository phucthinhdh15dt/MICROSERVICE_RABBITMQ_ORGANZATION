using CatalogOrgantication.Data.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogOrgantication.CommunicationForeignService
{
    public static class ReponsServiceCommunication
    {
        public static void  test()
        {
            Console.WriteLine("zzzzzzzzzzzzzzzzzzzz");
        }

            public static void communicationService(string hostRabit, string queue ,DbContext dbContext)
            {
                var factory = new ConnectionFactory() { HostName = hostRabit };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queue, durable: false, exclusive: false, autoDelete: false, arguments: null);
                    channel.BasicQos(0, 1, false);
                    var consumer = new EventingBasicConsumer(channel);
                    channel.BasicConsume(queue: queue, consumer: consumer);
                    Console.WriteLine(" [x] Awaiting RPC requests");
                    consumer.Received += (model, ea) =>
                    {
                        string response="";

                        var body = ea.Body;
                        var props = ea.BasicProperties;
                        var replyProps = channel.CreateBasicProperties();
                        replyProps.CorrelationId = props.CorrelationId;
                       

                        try
                        {

                            var message = Encoding.UTF8.GetString(body);
                            string IdOgrancation = JsonConvert.DeserializeObject<string>(message);
                            response = CkeckOgranHaveOrNo(IdOgrancation,dbContext);
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(" [.] " + e.Message);
                            response = "false";
                           
                        }
                        finally
                        { 
                            var responseBytes = Encoding.UTF8.GetBytes(response);
                            channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                            connection.Close();
                        }
                    };

                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                }
            }
        
        private static string CkeckOgranHaveOrNo(string IdOgrancation,DbContext dbContext)
        {
            var checkCatalog = dbContext.Find<CatalogOgranzition>(IdOgrancation);
            if (checkCatalog != null)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        
    }
}
