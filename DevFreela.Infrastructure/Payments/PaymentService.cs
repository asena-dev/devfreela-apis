using DevFreela.Core.DTOs;
using DevFreela.Core.Services;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Payments
{
    public class PaymentService : IPaymentService
    {
        // REQUISICAO HTTP

        //private readonly string _paymentsBaseUrl;
        //private readonly IHttpClientFactory _httpClientFactory;

        //public PaymentService(IHttpClientFactory httpClientFactor, IConfiguration configuration)
        //{
        //    _httpClientFactory = httpClientFactor;
        //    _paymentsBaseUrl = configuration.GetSection("Services:Payments").Value;
        //}
        //public async Task<bool> ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        //{
        //    var url = $"{_paymentsBaseUrl}/api/payments";
        //    var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

        //    var paymentInfoContent = new StringContent(
        //        paymentInfoJson,
        //        Encoding.UTF8,
        //        "application/json"
        //        );

        //    var httpClient = _httpClientFactory.CreateClient("Payments");

        //    var response = await httpClient.PostAsync(url, paymentInfoContent);

        //    return response.IsSuccessStatusCode;
        //}

        // REQUISICAO FILAS MENSAGENS

        private readonly IMessageBusService _messageBusService;
        private const string QUEUE_NAME = "Payments";

        public PaymentService(IMessageBusService messageBusService)
        {
            _messageBusService = messageBusService;
        }
        public void ProcessPayment(PaymentInfoDTO paymentInfoDTO)
        {
            var paymentInfoJson = JsonSerializer.Serialize(paymentInfoDTO);

            var paymentInfoBytes = Encoding.UTF8.GetBytes(paymentInfoJson);

            _messageBusService.Publish(QUEUE_NAME, paymentInfoBytes);
        }
    }
}
