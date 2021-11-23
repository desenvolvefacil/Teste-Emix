<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Consultar CEP</h1>
        <p class="lead">Digite o CEP que deseja consultar</p>
        <p class="lead">
            <asp:TextBox ID="CepTextBox" runat="server" placeholder="15043-140"></asp:TextBox>
            &nbsp;<asp:Button ID="PesquisarPorCepButton" CssClass="btn btn-primary btn-lg" runat="server" Text="Pesquisar" OnClick="PesquisarPorCepButton_Click" />
        </p>
        <p>
            

            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="MsgLabel" runat="server"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="PesquisarPorCepButton" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </p>
    </div>

    <div class="jumbotron">
        <h1>Consultar por Endereço</h1>
        <p class="lead">
            <asp:DropDownList ID="UfDropDownList" runat="server">
                <asp:ListItem>AC</asp:ListItem>
                <asp:ListItem>AL</asp:ListItem>
                <asp:ListItem>AP</asp:ListItem>
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>BA</asp:ListItem>
                <asp:ListItem>CE</asp:ListItem>
                <asp:ListItem>DF</asp:ListItem>
                <asp:ListItem>ES</asp:ListItem>
                <asp:ListItem>GO</asp:ListItem>
                <asp:ListItem>MA</asp:ListItem>
                <asp:ListItem>MT</asp:ListItem>
                <asp:ListItem>MS</asp:ListItem>
                <asp:ListItem>MG</asp:ListItem>
                <asp:ListItem>PA</asp:ListItem>
                <asp:ListItem>PB</asp:ListItem>
                <asp:ListItem>PR</asp:ListItem>
                <asp:ListItem>PE</asp:ListItem>
                <asp:ListItem>PI</asp:ListItem>
                <asp:ListItem>RJ</asp:ListItem>
                <asp:ListItem>RN</asp:ListItem>
                <asp:ListItem>RS</asp:ListItem>
                <asp:ListItem>RO</asp:ListItem>
                <asp:ListItem>RR</asp:ListItem>
                <asp:ListItem>SC</asp:ListItem>
                <asp:ListItem>SP</asp:ListItem>
                <asp:ListItem>SE</asp:ListItem>
                <asp:ListItem>TO</asp:ListItem>
            </asp:DropDownList>
        </p>
        <p class="lead">
            <asp:TextBox ID="CidadeTextBox" runat="server" placeholder="Cidade"></asp:TextBox>
        </p>
        <p class="lead">
            <asp:TextBox ID="LogradouroTextBox" runat="server" placeholder="Endereço"></asp:TextBox>
            &nbsp;<asp:Button ID="PesquisarPorNomeButton" CssClass="btn btn-primary btn-lg" runat="server" Text="Pesquisar" OnClick="PesquisarPorNomeButton_Click" />
        </p>
        <p class="lead">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="ResultadosGridView" runat="server">
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="PesquisarPorNomeButton" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </p>
    </div>

    <div class="jumbotron">
        <h1>Listar Cadastrados por Estado</h1>
        <p class="lead">
            <asp:DropDownList ID="Uf2DropDownList" runat="server">
                <asp:ListItem>AC</asp:ListItem>
                <asp:ListItem>AL</asp:ListItem>
                <asp:ListItem>AP</asp:ListItem>
                <asp:ListItem>AM</asp:ListItem>
                <asp:ListItem>BA</asp:ListItem>
                <asp:ListItem>CE</asp:ListItem>
                <asp:ListItem>DF</asp:ListItem>
                <asp:ListItem>ES</asp:ListItem>
                <asp:ListItem>GO</asp:ListItem>
                <asp:ListItem>MA</asp:ListItem>
                <asp:ListItem>MT</asp:ListItem>
                <asp:ListItem>MS</asp:ListItem>
                <asp:ListItem>MG</asp:ListItem>
                <asp:ListItem>PA</asp:ListItem>
                <asp:ListItem>PB</asp:ListItem>
                <asp:ListItem>PR</asp:ListItem>
                <asp:ListItem>PE</asp:ListItem>
                <asp:ListItem>PI</asp:ListItem>
                <asp:ListItem>RJ</asp:ListItem>
                <asp:ListItem>RN</asp:ListItem>
                <asp:ListItem>RS</asp:ListItem>
                <asp:ListItem>RO</asp:ListItem>
                <asp:ListItem>RR</asp:ListItem>
                <asp:ListItem>SC</asp:ListItem>
                <asp:ListItem>SP</asp:ListItem>
                <asp:ListItem>SE</asp:ListItem>
                <asp:ListItem>TO</asp:ListItem>
            </asp:DropDownList>
            &nbsp;<asp:Button ID="PesquisaPorEstadoButton" CssClass="btn btn-primary btn-lg" runat="server" Text="Pesquisar" OnClick="PesquisaPorEstadoButton_Click" />
        </p>

        <p class="lead">
            <asp:UpdatePanel ID="ResUfUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="ResultadosUFGridView" runat="server">
                    </asp:GridView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="PesquisaPorEstadoButton" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </p>

    </div>

</asp:Content>
