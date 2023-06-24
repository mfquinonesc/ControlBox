<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ControlBox.Views.Ciudades.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load" UpdateMode="Conditional">
        <ContentTemplate> 
            <h1 class="display-4">Ciudades</h1>
            <div class="form-group">
                <label for="drpBox">Nombre Pais</label>
                <asp:DropDownList ID="drpBox" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpBox_SelectedIndexChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtName">Nombre Ciudad</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnSave_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secundary"  OnClick="btnCancel_Click"/>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
