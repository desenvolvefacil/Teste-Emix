using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entity
{
    [JsonObject]
    public class ViaCepEntity
    {
        [JsonProperty]
        public string cep { get; set; }

        [JsonProperty]
        public string logradouro { get; set; }

        [JsonProperty]
        public string complemento { get; set; }

        [JsonProperty]
        public string bairro { get; set; }

        [JsonProperty]
        public string localidade { get; set; }

        [JsonProperty]
        public string uf { get; set; }

        [JsonProperty]
        public string ibge { get; set; }

        [JsonProperty]
        public string gia { get; set; }

        [JsonProperty]
        public string ddd { get; set; }

        [JsonProperty]
        public string siafi { get; set; }
    }
}