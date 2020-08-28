using Store.DTO;
using Store.WebUI.Clients.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Services
{
    public class OrderClient : IOrderClient
    {
        public HttpClient _httpClient { get; }
        public OrderClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52134");
            _httpClient = client;
        }
        public async Task<OrderDTO> AddOrder(OrderDTO dto)
        {
           
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Orders/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<OrderDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
            
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Orders/Delete");

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<OrderDTO> Get(int Id)
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Orders/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<OrderDTO>(response);
        }

        public async Task<List<OrderDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Orders/GetAll");
            return HttpResponseExtensions.ContentAsType<List<OrderDTO>>(response);

        }

        public async Task<OrderDTO> UpdateOrder(OrderDTO dto)
        {
            
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Orders/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<OrderDTO>(response);
        }
    }
}
