using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Entity;

namespace WebApplication1.Dao
{
    public class CepDao : ConnDao
    {

        public bool InserirCep(CepEntity o)
        {
            try
            {

                string sql = "INSERT INTO Cep (cep,logradouro,complemento,bairro,localidade,uf,unidade,ibge,gia) " +
                    "VALUES (@cep,@logradouro,@complemento,@bairro,@localidade,@uf,@unidade,@ibge,@gia);" +
                    "SELECT SCOPE_IDENTITY();";

                using (SqlConnection conn = new SqlConnection(StrConn))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {

                        cmd.Parameters.AddWithValue("@cep", o.Cep);
                        cmd.Parameters.AddWithValue("@logradouro", o.Logradouro);
                        cmd.Parameters.AddWithValue("@complemento", o.Complemento);
                        cmd.Parameters.AddWithValue("@bairro", o.Bairro);
                        cmd.Parameters.AddWithValue("@localidade", o.Localidade);
                        cmd.Parameters.AddWithValue("@uf", o.Uf);
                        cmd.Parameters.AddWithValue("@unidade", o.Unidade);
                        cmd.Parameters.AddWithValue("@ibge", o.Ibge);
                        cmd.Parameters.AddWithValue("@gia", o.Gia);

                        o.Id = Convert.ToInt32(cmd.ExecuteScalar());

                        if (o.Id > 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                //MessageBox.Show(e.StackTrace);
                return false;
            }
        }

        public CepEntity BuscarCep(string cep)
        {
            try
            {

                string sql = "select Id,cep,logradouro,complemento,bairro,localidade,uf,unidade,ibge,gia " +
                    " from Cep" +
                    " where cep = @cep;";

                using (SqlConnection conn = new SqlConnection(StrConn))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@cep", cep);

                        SqlDataReader r = cmd.ExecuteReader();

                        if (r.Read())
                        {
                            CepEntity o = new CepEntity();

                            o.Id = int.Parse(r["Id"].ToString());
                            o.Cep = r["cep"].ToString();
                            o.Logradouro = r["logradouro"].ToString();
                            o.Complemento = r["complemento"].ToString();
                            o.Bairro = r["bairro"].ToString();
                            o.Localidade = r["localidade"].ToString();
                            o.Uf = r["uf"].ToString();
                            o.Unidade = long.Parse(r["unidade"].ToString());
                            o.Ibge = int.Parse(r["ibge"].ToString());
                            o.Gia = r["gia"].ToString();

                            return o;
                        }

                    }
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                //MessageBox.Show(e.StackTrace);
                //return null;
            }

            return null;
        }

        public List<CepEntity> ListarPorEstado(string uf)
        {
            List<CepEntity> l = new List<CepEntity>();

            try
            {

                string sql = "select Id,cep,logradouro,complemento,bairro,localidade,uf,unidade,ibge,gia " +
                    " from Cep" +
                    " where uf = @uf;";

                using (SqlConnection conn = new SqlConnection(StrConn))
                {

                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@uf", uf);

                        SqlDataReader r = cmd.ExecuteReader();

                        while (r.Read())
                        {
                            CepEntity o = new CepEntity();

                            o.Id = int.Parse(r["Id"].ToString());
                            o.Cep = r["cep"].ToString();
                            o.Logradouro = r["logradouro"].ToString();
                            o.Complemento = r["complemento"].ToString();
                            o.Bairro = r["bairro"].ToString();
                            o.Localidade = r["localidade"].ToString();
                            o.Uf = r["uf"].ToString();
                            o.Unidade = long.Parse(r["unidade"].ToString());
                            o.Ibge = int.Parse(r["ibge"].ToString());
                            o.Gia = r["gia"].ToString();

                            l.Add(o);
                        }

                    }
                }

            }
            catch (Exception e)
            {
                //MessageBox.Show(e.Message);
                //MessageBox.Show(e.StackTrace);
                //return null;
            }

            return l;
        }
    }
}