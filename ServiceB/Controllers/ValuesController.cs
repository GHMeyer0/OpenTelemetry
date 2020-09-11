using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ServiceB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ISendEndpointProvider _sendEndpointProvider;

        public ValuesController(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }
        [HttpPost]
        public async Task<ActionResult> Post(string texto)
        {
            var endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("rabbitmq://mq.acme.com/order/order_processing"));
            await _sendEndpointProvider.Send()
                Publish<Mensagem>(new Mensagem
            {
                Texto = texto
            });
            return Ok();
        }
    }
}
