using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Dao;
using WebApplication1.Entity;
using WebApplication1.Services;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        private static readonly CepDao dao = new CepDao();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void PesquisarPorCepButton_Click(object sender, EventArgs e)
        {
            //valida o formato do cep
            string cep = String.Join("", System.Text.RegularExpressions.Regex.Split(CepTextBox.Text, @"[^\d]"));

            if (cep.Length == 8)
            {


                //tenta buscar na base de dados
                CepEntity o = dao.BuscarCep(cep);

                if (o != null)
                {
                    //o.Id.ToString();

                    //MsgLabel.Text = "CEP Encontrado";
                    //MsgLabel.ForeColor = Color.Green;

                    MsgLabel.Text = o.Logradouro + " - " + o.Bairro + " - " + o.Localidade + " - " + o.Uf;
                    MsgLabel.ForeColor = Color.Blue;
                }
                else
                {
                    //tenta buscar o cep no via cep

                    BuscarViaCepApi(cep);
                }
            }
            else
            {
                MsgLabel.Text = "CEP Inválido";
                MsgLabel.ForeColor = Color.Red;
            }

        }

        private async void BuscarViaCepApi(string cep)
        {
            ViaCepEntity ret = await new ViaCepService().BuscarCep(cep);

            if (ret.cep != null)
            {
                MsgLabel.Text = "CEP Encontrado";
                MsgLabel.ForeColor = Color.Green;

                CepEntity o = new CepEntity();

                o.Cep = cep;
                o.Bairro = ret.bairro;
                o.Complemento = ret.complemento;
                o.Gia = ret.gia;
                o.Ibge = int.Parse( ret.ibge);
                o.Localidade = ret.localidade;
                o.Logradouro = ret.logradouro;
                o.Uf = ret.uf;
                o.Unidade = long.Parse(ret.siafi);

                //salva no banco de dados para uma pesquisa futura
                dao.InserirCep(o);
            }
            else
            {
                MsgLabel.Text = "CEP Não Localizado";
                MsgLabel.ForeColor = Color.Red;
            }
        }

        protected async void PesquisarPorNomeButton_Click(object sender, EventArgs e)
        {
            List<ViaCepEntity> ret = await new ViaCepService().ListarPorNome(UfDropDownList.SelectedValue,CidadeTextBox.Text,LogradouroTextBox.Text);

            List<CepEntity> lista = new List<CepEntity>();

            foreach (var item in ret)
            {
                CepEntity o = new CepEntity();

                o.Cep = String.Join("", System.Text.RegularExpressions.Regex.Split(item.cep, @"[^\d]"));
                o.Bairro = item.bairro;
                o.Complemento = item.complemento;
                o.Gia = item.gia;
                o.Ibge = int.Parse(item.ibge);
                o.Localidade = item.localidade;
                o.Logradouro = item.logradouro;
                o.Uf = item.uf;
                o.Unidade = long.Parse(item.siafi);

                //salva no banco de dados para uma pesquisa futura
                dao.InserirCep(o);

                lista.Add(o);
            }

            ResultadosGridView.DataSource = lista;
            ResultadosGridView.DataBind();

            GC.Collect();
        }

        protected void PesquisaPorEstadoButton_Click(object sender, EventArgs e)
        {
            List<CepEntity> lista = dao.ListarPorEstado(Uf2DropDownList.SelectedValue);

            ResultadosUFGridView.DataSource = lista;
            ResultadosUFGridView.DataBind();

            GC.Collect();
        }
    }

}