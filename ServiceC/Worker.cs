using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Models;

namespace ServiceC
{
    public class Worker : IConsumer<Mensagem>
    {
        private readonly ILogger<Worker> _logger;
        private readonly MensagemContext _context;
        public Worker(ILogger<Worker> logger, MensagemContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task Consume(ConsumeContext<Mensagem> context)
        {
            await _context.AddAsync(context.Message);
        }
    }
}
