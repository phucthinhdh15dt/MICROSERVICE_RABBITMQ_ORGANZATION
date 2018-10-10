using Newtonsoft.Json;
using PlusTechPlusSystem.Data.ModelRabitmq;
using PlusTechPlusSystem.ProfileReponsitory;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusTechPlusSystem.Communication
{
    public class ReponseIdentityServer
    {
        ConnectionFactory factory { get; set; }
        IConnection connection { get; set; }
        IModel channel { get; set; }
        public void Register()
        {
            channel.QueueDeclare(queue: "profile", durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.BasicQos(0, 1, false);
            var consumer = new EventingBasicConsumer(channel);
            channel.BasicConsume(queue: "profile", consumer: consumer);
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
                    ProfileIdentityServer profileIdentityServer = JsonConvert.DeserializeObject<ProfileIdentityServer>(message);
                    ProfileCommunicationReponsitory.CreateCatalogOgranzition(profileIdentityServer);
                    Console.WriteLine(profileIdentityServer.Email+"zzzzzzzz");
                    response = "true";

                    //int n = int.Parse(message);
                    //if (OgranzitionCommunicationReponsitory.CreateCatalogOgranzition(ogranzition))
                    //{
                    //    response = "true";
                    //}
                    //else
                    //{
                    //    response = "false";
                    //}
                    //response = ogranzition;
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

        public ReponseIdentityServer()
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
