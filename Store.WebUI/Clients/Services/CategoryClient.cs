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
    public class CategoryClient : ICategoryClient
    {
        public HttpClient _httpClient;

        public CategoryClient(HttpClient httpClient)
        {
            //httpClient.BaseAddress = new Uri("http://localhost:52134");
            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_client = client;
            _httpClient = httpClient;
        }
        public async Task<List<CategoryDTO>> GetAll()
        {
            //var requestUri = _client.BaseAddress + "api/Categories/GetAll"; ?id=" + dto.id + "&name" + dto.name;//
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Categories/CategoryList");
            var categories = HttpResponseExtensions.ContentAsType<List<CategoryDTO>>(response);
            return categories;
        }

        public async Task<CategoryDTO> Get(int Id)
        {

            var response = await _httpClient.GetAsync("http://localhost:52134/api/Categories/Get?Id" + Id);
            var categories = HttpResponseExtensions.ContentAsType<CategoryDTO>(response);
            return categories;
        }

        public async Task<CategoryDTO> AddCategory(CategoryDTO categoryDTO)
        {
            
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Categories/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(categoryDTO)
            };
            var response = await _httpClient.SendAsync(request);
            var category = HttpResponseExtensions.ContentAsType<CategoryDTO>(response);
            return category;
        }

        public async Task<CategoryDTO> UpdateCategory(CategoryDTO categoryDTO)
        {
            //    var requestUri = _client.BaseAddress + "api/Categories/Update" + "?id" + categoryDTO.Id;
            //    var request = new HttpRequestMessage
            //    {
            //        RequestUri = new Uri(requestUri),
            //        Method = HttpMethod.Put,
            //        Content = HttpRequestExtensions.ContentAsByteJson(categoryDTO)
            //    };
            //    var response = await _client.SendAsync(request);
            //    var upcategory = HttpResponseExtensions.ContentAsType<CategoryDTO>(response);
            //    return upcategory;
          
            var Content = HttpRequestExtensions.ContentAsByteJson(categoryDTO);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Categories/Update?Id" +categoryDTO.Id, Content);
            var update = HttpResponseExtensions.ContentAsType<CategoryDTO>(response);
            return update;
        }
        public async Task<string> Delete(string Id)
        {
           
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Categories/Delete");

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }
    }
}