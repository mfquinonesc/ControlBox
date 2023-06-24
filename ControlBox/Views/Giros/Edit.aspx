<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="ControlBox.Views.Giros.Edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load" UpdateMode="Conditional">
        <ContentTemplate>
            <h1 class="display-4">Giros</h1>
            <div class="form-group">
                <label for="txtId">Giro ID</label>
                <asp:TextBox ID="txtId" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="drpBoxPais">Nombre Pais</label>
                <asp:DropDownList ID="drpBoxPais" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpBoxPais_SelectedIndexChanged"/>
            </div>
            <div class="form-group">
                <label for="drpBoxCiudad">Nombre Ciudad</label>
                <asp:DropDownList ID="drpBoxCiudad" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpBoxCiudad_SelectedIndexChanged" />
            </div>
            <div class="form-group">
                <label for="txtGiro">Numero Recivo</label>
                <asp:TextBox ID="txtGiro" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnSave_Click" />
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secundary" OnClick="btnCancel_Click" />
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="drpBoxPais" />
            <asp:PostBackTrigger ControlID="drpBoxCiudad" />
        </Triggers>
    </asp:UpdatePanel>

</asp:Content>
