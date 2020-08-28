using Store.DTO;
using Store.WebUI.Clients.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Store.WebUI.Clients.Services
{
    public class CustomerClient : ICustomerClient
    {
        public HttpClient _httpClient { get; }
        public CustomerClient(HttpClient client)
        {
   
            _httpClient = client;

        }

        public async Task<CustomerDTO> AddCustomer(CustomerDTO dto)
        {
           
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Customers/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<CustomerDTO>(response);

        }

        public async Task<string> Delete(string Id)
        {

            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Customers/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("Silme Başarılı");
            else
            {
                return await Task.FromResult("Silme Yapılamadı");

            }
        }

        public async Task<CustomerDTO> Get(int Id)
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Customers/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<CustomerDTO>(response);
        }

        public async Task<List<CustomerDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Customers/GetAll");
            return HttpResponseExtensions.ContentAsType<List<CustomerDTO>>(response);

        }

        public async Task<CustomerDTO> UpdateCustomer(CustomerDTO dto)
        {
          
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Customers/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<CustomerDTO>(response);


        }
    }
}

