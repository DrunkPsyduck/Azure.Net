using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace mvcStorage.Services
{
    public class ServiceQueueBus
    {
        private ServiceBusClient client;
        public ServiceQueueBus(String keys)
        {
            this.client = new ServiceBusClient(keys);
        }

        public async Task SendMessage(String data)
        {
            //Necesitamos un sender asociado a la queue
            ServiceBusSender sender = this.client.CreateSender("programadores");
            //Mensaje
            ServiceBusMessage message = new ServiceBusMessage(data);

            //El mensaje se envia mediante el sender
            await sender.SendMessageAsync(message);
        }

        private Queue<ServiceBusMessage> CreateMessages()
        {
            Queue<ServiceBusMessage> mensajes = new Queue<ServiceBusMessage>();
            
            mensajes.Enqueue(new ServiceBusMessage("Primer mensaje: Hola mundo"));
            mensajes.Enqueue(new ServiceBusMessage("Segundo mensaje"));
            mensajes.Enqueue(new ServiceBusMessage("Tercer mensaje"));

            return mensajes;
        }

        public async Task SendBatchMenssages()
        {
            //Recuperamos los mensajes en el batch

            Queue<ServiceBusMessage> colamensajes = this.CreateMessages();
            ServiceBusSender sender = this.client.CreateSender("programadores");
            //los mensajes estan en mode enqueue, a medida que se vayan procesando se iran quitando de la cola y pasando a proceso dequeue
            //No se sabe cuanto tardara
            //El proceso de batch debe hacerse en un bucle mientras los mensajes esten en la cola
            while (colamensajes.Count > 0)
            {
                //todos los mensajes de la cola se procesan con batch
                ServiceBusMessageBatch batch = await sender.CreateMessageBatchAsync();

                //los mensajes se agregan al batch y se van procesando
                if (batch.TryAddMessage(colamensajes.Peek()))
                {
                    colamensajes.Dequeue();
                }

                //se van enviando los batch
                await sender.SendMessagesAsync(batch);
            }
        }

        List<string> mensajes = new List<string>();
        //Los mensajes de descargan y son procesados por Azure. No se puede buscar un mensaje en una cola

        public async Task<List<String>> RecibirMensajes()
        {
            //Procesador de mensajes
            ServiceBusProcessor processor = this.client.CreateProcessor("programadores");
            processor.ProcessMessageAsync += MessageHandler;
            processor.ProcessErrorAsync += Processor_ProcessErrorAsync;
            //inicia el proceso de recuperacion
            await processor.StartProcessingAsync();
            Thread.Sleep(30000);
            

            //finalizar el proceso
            //await processor.StopProcessingAsync();
            return this.mensajes;
        }

        private Task Processor_ProcessErrorAsync(ProcessErrorEventArgs arg)
        {
            //throw new NotImplementedException();
            return Task.CompletedTask;
        }

        private async Task MessageHandler(ProcessMessageEventArgs e)
        {
            String data = e.Message.Body.ToString();
            mensajes.Add(data);
            //Debemos ir eliminando los mensajes de la cola como procesados
            await e.CompleteMessageAsync(e.Message);
        }
    }
}
