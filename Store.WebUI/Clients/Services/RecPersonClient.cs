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
    public class RecPersonClient : IRecPersonClient
    {
        public HttpClient _httpClient { get; }
        public RecPersonClient(HttpClient client)
        {
            
            _httpClient = client;
        }
        public async Task<RecPersonDTO> AddRecPerson(RecPersonDTO dto)
        {
           
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/RecPersons/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<RecPersonDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
         
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/RecPersons/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<RecPersonDTO> Get(int Id)
        {
            var response = await _httpClient.GetAsync("http://localhost:52134/api/RecPersons/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<RecPersonDTO>(response);
        }

        public async Task<List<RecPersonDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/RecPersons/GetAll");
            return HttpResponseExtensions.ContentAsType<List<RecPersonDTO>>(response);
        }

        public async Task<RecPersonDTO> UpdateRecPerson(RecPersonDTO dto)
        {
           
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/RecPersons/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<RecPersonDTO>(response);
        }
    }
}
