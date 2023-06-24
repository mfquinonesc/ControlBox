<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ciudades.aspx.cs" Inherits="ControlBox.Views.Ciudades.Ciudades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" DataKeyNames="Ciudad_id" 
                AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                OnRowDeleting="GridView1_RowDeleting" >
                <Columns>
                    <asp:CommandField ShowDeleteButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" />
                    <asp:CommandField ShowSelectButton="true" ButtonType="Button" ControlStyle-CssClass="btn btn-primary" />
                    <asp:BoundField DataField="Ciudad_id" HeaderText="ID" SortExpression="Ciudad_id" />
                    <asp:BoundField DataField="NombreCiudad" HeaderText="Nombre Ciudad" SortExpression="NombreCiudad" />
                    <asp:BoundField DataField="NombrePais" HeaderText="Nombre Pais" SortExpression="NombrePais" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnCreate" runat="server" Text="Crear" CssClass="btn btn-primary" OnClick="btnCreate_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
