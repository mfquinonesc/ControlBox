<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControlBox._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnLoad="UpdatePanel1_Load" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">               
                <div class="form-group">
                    <label for="drpBoxPais">Nombre Pais</label>
                    <asp:DropDownList ID="drpBoxPais" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpBoxPais_SelectedIndexChanged" />
                </div>
                <div class="form-group">
                    <label for="drpBoxCiudad">Nombre Ciudad</label>
                    <asp:DropDownList ID="drpBoxCiudad" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpBoxCiudad_SelectedIndexChanged" OnPreRender="drpBoxCiudad_PreRender" />
                </div>    
            </div>

            <div class="row">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" 
                    AutoGenerateColumns="false">
                    <Columns>                        
                        <asp:BoundField DataField="Giro_id" HeaderText="ID" SortExpression="Giro_id" />
                         <asp:BoundField DataField="Recibo" HeaderText="Recibo" SortExpression="Recibo" />
                        <asp:BoundField DataField="Ciudad_id" HeaderText="Nombre Ciudad" SortExpression="Ciudad_id" />
                    </Columns>
                </asp:GridView>               
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="drpBoxPais" />
            <asp:PostBackTrigger ControlID="drpBoxCiudad" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
