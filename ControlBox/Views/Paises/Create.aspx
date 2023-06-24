<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create.aspx.cs" Inherits="ControlBox.Views.Paises.Create" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load" UpdateMode="Conditional">
        <ContentTemplate>            
            <div class="form-group">
                <label for="txtName">Nombre Pais</label>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control" ></asp:TextBox>
            </div>
            <asp:Button ID="btnSave" runat="server" Text="Guardar"  CssClass="btn btn-primary" OnClick="btnSave_Click"/>
            <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secundary"  OnClick="btnCancel_Click"/>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
