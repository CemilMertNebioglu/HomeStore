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
    public class DepartmentClient : IDepartmentClient
    {
        public HttpClient _httpClient { get; }
        public DepartmentClient(HttpClient client)
        {
           
            _httpClient = client;

        }
        public async Task<DepartmentDTO> AddDepartment(DepartmentDTO dto)
        {
           
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Departments/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<DepartmentDTO>(response);

        }

        public async Task<string> Delete(string Id)
        {
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Departments/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<DepartmentDTO> Get(int Id)
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Departments/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<DepartmentDTO>(response);

        }

        public async Task<List<DepartmentDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Departments/GetAll");
            return HttpResponseExtensions.ContentAsType<List<DepartmentDTO>>(response);

        }

        public async Task<DepartmentDTO> UpdateDepartment(DepartmentDTO dto)
        {
          
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Departments/Update?Id"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<DepartmentDTO>(response);

        }
    }
}
