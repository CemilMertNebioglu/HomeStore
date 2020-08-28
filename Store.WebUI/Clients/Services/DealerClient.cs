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
    public class DealerClient : IDealerClient
    {
        public HttpClient _httpClient { get; }
        public DealerClient(HttpClient client)
        {

            _httpClient = client;
        }

        public async Task<DealerDTO> AddDealer(DealerDTO dto)
        {
           
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Dealers/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<DealerDTO>(response);

        }

        public async Task<string> Delete(string Id)
        {
           
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Dealers/Delete?Id" + Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<DealerDTO> Get(int Id)
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Dealers/Get?Id" + Id);
            return HttpResponseExtensions.ContentAsType<DealerDTO>(response);
        }

        public async Task<List<DealerDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Dealers/GetAll");
            return HttpResponseExtensions.ContentAsType<List<DealerDTO>>(response);

        }

        public async Task<DealerDTO> UpdateDealer(DealerDTO dto)
        {
            
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Dealers/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<DealerDTO>(response);

        }
    }
}
