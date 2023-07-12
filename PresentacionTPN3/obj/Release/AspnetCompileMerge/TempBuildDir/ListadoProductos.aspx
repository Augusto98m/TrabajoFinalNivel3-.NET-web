<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListadoProductos.aspx.cs" Inherits="PresentacionTPN3.ListadoProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <asp:ScriptManager runat="server" ID="scriptManager3"/>
    <style>
        .col-2{
            width:122px;
        }
        .borde{
            border-color:black;
        }
        .boton{            
            background-color:blue;
            color:white;
            transition:0.2s;
        }
        .boton:hover{
            background-color:#080697; 
            color:white;
        }
        .bton{
            background-color:#17f306;
            color:black;
            transition:0.2s;
        }
        .bton:hover{
            background-color:#17c40a;
            color:black;
        }
    </style>        
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <h2>Lista de Productos 📃 </h2>
            <hr />
            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" ID="lblCampo" runat="server" />
                        <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCampo" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Categoría" />
                            <asp:ListItem Text="Marca" />
                            <asp:ListItem Text="Precio" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCriterio" CssClass="form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox runat="server" ID="txtFiltroAvanzado" CssClass="form-control" />  
                    </div>
                </div>                
            </div>    
            <div class="row">   
                <div class="col-3">   
                    <div class="mb-3">   
                        <asp:Button Text="Búsqueda Avanzada" ID="btnBusqueadAvanzada" runat="server" CssClass="btn boton" OnClick="btnBusqueadAvanzada_Click" />
                    </div>
                </div>
            </div>
                
    
    <br />
    <asp:GridView runat="server" ID="gvArticulos" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" 
        OnSelectedIndexChanged="gvArticulos_SelectedIndexChanged" OnPageIndexChanging="gvArticulos_PageIndexChanging" 
        AllowPaging="True" PageSize="6">
        <Columns>            
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Código" DataField="Codigo" />
            <asp:BoundField HeaderText="Precio $" DataField="Precio" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoría" DataField="Categoria.Descripcion" />
            <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="true" SelectText="🖋️ " HeaderStyle-Width="20px" ItemStyle-HorizontalAlign="Center"/> 
        </Columns>
    </asp:GridView>
    <asp:Button Text="Agregar" runat="server" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn bton" />
   </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
