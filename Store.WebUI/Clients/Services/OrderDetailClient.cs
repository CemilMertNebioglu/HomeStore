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
    public class OrderDetailClient : IOrderDetailClient
    {
        public HttpClient _httpClient { get; }
        public OrderDetailClient(HttpClient client)
        {

          
            _httpClient = client;
        }
        public async Task<OrderDetailDTO> AddOrderDetail(OrderDetailDTO dto)
        {
          
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/OrderDetails/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<OrderDetailDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
           
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/OrderDetails/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<OrderDetailDTO> Get(int Id)
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/OrderDetails/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<OrderDetailDTO>(response);
        }

        public async Task<List<OrderDetailDTO>> GetAll()
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/OrderDetails/GetAll");
            return HttpResponseExtensions.ContentAsType<List<OrderDetailDTO>>(response);
        }

        public async Task<OrderDetailDTO> UpdateOrderDetail(OrderDetailDTO dto)
        {
        
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/OrderDetails/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<OrderDetailDTO>(response);
        }
    }
}
