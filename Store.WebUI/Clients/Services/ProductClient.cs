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
    public class ProductClient : IProductClient
    {
        public HttpClient _client { get; }
        public ProductClient(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:52134");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client = client;
        }
        public async Task<ProductDTO> AddProduct(ProductDTO dto)
        {
            var requestUri = _client.BaseAddress + "api/Products/Add";
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(requestUri),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _client.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<ProductDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
            var requestUri = _client.BaseAddress + "api/Products/Delete/Delete?Id" + Id;
            var response = await _client.DeleteAsync(requestUri);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<ProductDTO> Get(int Id)
        {
            var requestUri = _client.BaseAddress + "api/Products/Get";
            var response = await _client.GetAsync(requestUri);
            return HttpResponseExtensions.ContentAsType<ProductDTO>(response);
        }

        public async Task<List<ProductDTO>> GetAll()
        {
            var requestUri = _client.BaseAddress + "api/Products/GetAll";
            var response = await _client.GetAsync(requestUri);
            return HttpResponseExtensions.ContentAsType<List<ProductDTO>>(response);
        }

        public async Task<ProductDTO> UpdateProduct(ProductDTO dto)
        {
            var requestUri = _client.BaseAddress + "api/Products/Update" + "?id" + dto.Id;
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _client.PutAsync(requestUri, Content);
            return HttpResponseExtensions.ContentAsType<ProductDTO>(response);
        }
    }
}
