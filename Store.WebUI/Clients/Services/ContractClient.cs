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
    public class ContractClient : IContractClient
    {
        public HttpClient _httpClient;
        public ContractClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ContractDTO> AddContract(ContractDTO dto)
        {
            
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Contracts/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            var contract = HttpResponseExtensions.ContentAsType<ContractDTO>(response);
            return contract;
        }

        public async Task<ContractDTO> Get(int Id)
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Contracts/Get?Id"+Id);
            var contract = HttpResponseExtensions.ContentAsType<ContractDTO>(response);
            return contract;
        }

        public async Task<List<ContractDTO>> GetAll()
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Contracts/GetAll");
            var contracts = HttpResponseExtensions.ContentAsType<List<ContractDTO>>(response);
            return contracts;
        }

        public async Task<ContractDTO> UpdateContract(ContractDTO dto)
        {
           
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Contracts/Update", Content);
            var update = HttpResponseExtensions.ContentAsType<ContractDTO>(response);
            return update;
        }
        public async Task<string> Delete(string Id)
        {
           
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Contracts/Delete");

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("Silme Başarılı");
            else
            {
                return await Task.FromResult("Silme Yapılamadı");

            }
        }
    }
}
