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
    public class ProductSupplierClient : IProductSupplierClient
    {
        public HttpClient _httpClient { get; }
        public ProductSupplierClient(HttpClient client)
        {
          _httpClient = client;
        }
        public async Task<ProductSupplierDTO> AddProductSupplier(ProductSupplierDTO dto)
        {

            
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/ProductSuppliers/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<ProductSupplierDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
            
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/ProductSuppliers/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<ProductSupplierDTO> Get(int Id)
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/ProductSuppliers/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<ProductSupplierDTO>(response);
        }

        public async Task<List<ProductSupplierDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/ProductSuppliers/GetAll");
            return HttpResponseExtensions.ContentAsType<List<ProductSupplierDTO>>(response);
        }

        public async Task<ProductSupplierDTO> UpdateProductSupplier(ProductSupplierDTO dto)
        {
           
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/ProductSuppliers/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<ProductSupplierDTO>(response);
        }
    }
}
