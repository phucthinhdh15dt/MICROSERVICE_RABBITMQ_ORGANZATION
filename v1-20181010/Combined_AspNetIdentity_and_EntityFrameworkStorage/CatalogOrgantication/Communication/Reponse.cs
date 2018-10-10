using CatalogOrgantication.CommunicationReponsitory;
using CatalogOrgantication.Data.ModelRabbitJson;
using CatalogOrgantication.Data.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CatalogOrgantication.Communication
{
    public class Reponse
    {
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }
        public void Register()
        {
                channel.QueueDeclare(queue: "rpc_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                channel.BasicQos(0, 1, false);
                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: "rpc_queue", consumer: consumer);
                Console.WriteLine("Rabbitmq lang nghe ProptechPlus");
                
                consumer.Received += (model, ea) =>
                {
                    string response = null;

                    var body = ea.Body;
                    var props = ea.BasicProperties;
                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = props.CorrelationId;

                    try
                    {

                        var message = Encoding.UTF8.GetString(body);
                        Ogranzition ogranzition = JsonConvert.DeserializeObject<Ogranzition>(message);
                        Console.WriteLine(ogranzition.NameOgranzition+"000000000000");
                        //int n = int.Parse(message);
                        if (OgranzitionCommunicationReponsitory.CreateCatalogOgranzition(ogranzition))
                        {
                            response = "true";
                        }
                        else
                        {
                            response = "false";
                        }
                    }
                    catch (Exception)
                    {
                        
                        response = "false";
                    }
                    finally
                    {
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                        channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                       
                       
                    }
                };
        }

                public Reponse()
                {
                    this.factory = new ConnectionFactory() { HostName = "localhost" };
                    this.connection = factory.CreateConnection();
                    this.channel = connection.CreateModel();


                }
                public void Deregister()
                {
                    this.connection.Close();
                }



    }
}
