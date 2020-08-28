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
    public class RoleClient : IRoleClient
    {
        public HttpClient _httpClient { get; }
        public RoleClient(HttpClient client)
        {
          
            _httpClient = client;
        }
        public async Task<RoleDTO> AddRole(RoleDTO dto)
        {
            
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Roles/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<RoleDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
            
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Roles/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<RoleDTO> Get(int Id)
        {

           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Roles/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<RoleDTO>(response);
        }

        public async Task<List<RoleDTO>> GetAll()
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Roles/GetAll");
            return HttpResponseExtensions.ContentAsType<List<RoleDTO>>(response);
        }

        public async Task<RoleDTO> UpdateRole(RoleDTO dto)
        {
         
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Roles/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<RoleDTO>(response);
        }
    }
}
