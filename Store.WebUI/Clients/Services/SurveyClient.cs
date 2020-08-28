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
    public class SurveyClient : ISurveysClient
    {
        public HttpClient _httpClient { get; }
        public SurveyClient(HttpClient client)
        {
            _httpClient = client;
        }
        public async Task<SurveyDTO> AddSurvey(SurveyDTO dto)
        {
          
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Surveys/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<SurveyDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
            
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Surveys/Delete?Id");

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<SurveyDTO> Get(int Id)
        {
          
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Surveys/Get?Id"+Id);
            return HttpResponseExtensions.ContentAsType<SurveyDTO>(response);
        }

        public async Task<List<SurveyDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Surveys/GetAll");
            return HttpResponseExtensions.ContentAsType<List<SurveyDTO>>(response);
        }

        public async Task<SurveyDTO> UpdateSurvey(SurveyDTO dto)
        {
           
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Surveys/Update"+dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<SurveyDTO>(response);
        }
    }
}
