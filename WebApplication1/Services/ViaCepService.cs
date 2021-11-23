using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Entity;

namespace WebApplication1.Services
{
    public interface IViaCepApi<T>
    {
        Task<ViaCepEntity> BuscarCep(string cep);
        Task<List<ViaCepEntity>> ListarPorNome(string uf,string cidade, string logradouro);
    }


    public class ViaCepService: IViaCepApi<ViaCepEntity>
    {
        private string urlBuscaPorCep = "https://viacep.com.br/ws/{0}/json/";
        private string urlBuscarPorNome = "https://viacep.com.br/ws/{0}/{1}/{2}/json/";

        public ViaCepService()
        {
            
        }

        public async Task<ViaCepEntity> BuscarCep(string cep)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string str = string.Format(urlBuscaPorCep,cep);

                    using (var ret = await client.GetAsync(str))
                    {

                        string result = ret.Content.ReadAsStringAsync().Result;

                        ViaCepEntity o = JsonConvert.DeserializeObject<ViaCepEntity>(result);

                        return await Task.FromResult<ViaCepEntity>(o);

                    }

                }
            }
            catch(Exception e)
            {
                return await Task.FromResult<ViaCepEntity>(null);
            }
        }


        public async Task<List<ViaCepEntity>> ListarPorNome(string uf, string cidade, string logradouro)
        {

            try
            {
                using (HttpClient client = new HttpClient())
                {

                    string str = string.Format(urlBuscarPorNome, uf,cidade,logradouro);

                    using (var ret = await client.GetAsync(str))
                    {

                        string result = ret.Content.ReadAsStringAsync().Result;

                        List<ViaCepEntity> l = JsonConvert.DeserializeObject<List<ViaCepEntity>>(result);

                        return await Task.FromResult<List<ViaCepEntity>>(l);

                    }

                }
            }
            catch (Exception e)
            {
                return await Task.FromResult<List<ViaCepEntity>>(null);
            }
        }
    }

   
}