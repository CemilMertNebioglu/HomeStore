﻿using Store.DTO;
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
    public class SupplierClient : ISupplierClient
    {
        public HttpClient _httpClient { get; }
        public SupplierClient(HttpClient client)
        {

            _httpClient = client;
        }
        public async Task<SupplierDTO> AddSupplier(SupplierDTO dto)
        {
        
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("http://localhost:52134/api/Suppliers/Add"),
                Method = HttpMethod.Post,
                Content = HttpRequestExtensions.ContentAsByteJson(dto)
            };
            var response = await _httpClient.SendAsync(request);
            return HttpResponseExtensions.ContentAsType<SupplierDTO>(response);
        }

        public async Task<string> Delete(string Id)
        {
           
            var response = await _httpClient.DeleteAsync("http://localhost:52134/api/Suppliers/Delete?Id"+Id);

            if (response.StatusCode == HttpStatusCode.OK)
                return await Task.FromResult("İşlem  Başarılı");
            else
            {
                return await Task.FromResult("İşlem Yapılamadı");

            }
        }

        public async Task<SupplierDTO> Get(int Id)
        {
            
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Suppliers/Get?Id" + Id);
            return HttpResponseExtensions.ContentAsType<SupplierDTO>(response);
        }

        public async Task<List<SupplierDTO>> GetAll()
        {
           
            var response = await _httpClient.GetAsync("http://localhost:52134/api/Suppliers/GetAll");
            return HttpResponseExtensions.ContentAsType<List<SupplierDTO>>(response);
        }

        public async Task<SupplierDTO> UpdateSupplier(SupplierDTO dto)
        {
           
            var Content = HttpRequestExtensions.ContentAsByteJson(dto);
            var response = await _httpClient.PutAsync("http://localhost:52134/api/Suppliers/Update?Id" + dto.Id, Content);
            return HttpResponseExtensions.ContentAsType<SupplierDTO>(response);
        }
    }
}
