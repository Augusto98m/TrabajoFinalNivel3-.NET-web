<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionTPN3.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="scriptManager4"/>
    <style> 
        .iniciado{
            margin:auto;
            text-align:center;  
            background-color:#5e5dee;
            border-radius:10px;
            padding:5px
        }
        .foto{          
            min-height:235px;
            max-height:235px;
            max-width:238px;
        }    
        .card{
            transition: all 0.4s;            
        }
        .card:hover{
            transform: scale(1.05);
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
        .fav{
            width:25px;
            height:25px;
            border-radius:100%;
            padding:0px;
        }
        .body{
            background-image:url("wpp.png");
        }
    </style>
    <div class="container">

    
  <asp:UpdatePanel runat="server">
   <ContentTemplate>
    <div class="container iniciado">   
        <h2 style="color:white">¡TE DAMOS LA BIENVENIDA A LA TIENDA VIRTUAL SMART TECH!</h2>
        <h5>Aquí encontrarás todo lo referido a la electrónica y los dispositivos inteligentes</h5>
    </div>
    <br />
    <br />
    <div class="container-fluid col-5">
        <div class="d-flex" role="search">
            <asp:TextBox runat="server" ID="txtFiltrar" placeholder="Buscar..." arial-label="Search" CssClass="form-control me-2" />
            <asp:Button Text="Buscar" runat="server" ID="btnBuscando" CssClass="btn boton" OnClick="btnBuscando_Click" />                      
        </div>        
    </div>
    <%--<div class="d-flex justify-content-end">
            <asp:DropDownList runat="server" CssClass="btn bton" AutoPostBack="true" ID="ddlOrdenar" OnSelectedIndexChanged="ddlOrdenar_SelectedIndexChanged">
                <asp:ListItem Text="Por defecto" />
                <asp:ListItem Text="Menor precio" />
                <asp:ListItem Text="Mayor precio" />
            </asp:DropDownList>
        </div>--%> 
    <br />
    <br />
    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repRepetidor">
            <ItemTemplate>
                <div class="col">
                    <div class="card" style="max-height:400px;max-width:280px;background-color:#d7dfe4;align-items:center">                        
                       <img src="<%#Eval("UrlImagen") %>" class="card-img-top foto" id="imgProduc">                        
                        <div class="card-body" style="max-height:184px;max-width:238px">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <h7 class="card-title"><%#Eval("Marca")%></h7>
                            <p class="card-text" style="font-size:14px">$ <%#Eval("Precio") %></p>
                            <div class="row" style="flex-wrap:nowrap">                                
                                    <a style="max-width:100px;color:black" href="DetalleProducto.aspx?id=<%#Eval("Id") %>">Ver detalle</a>
                                    <a style="max-width:110px"></a>                                                                              
                            </div>                                                        
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   </ContentTemplate>
  </asp:UpdatePanel>
 </div>
</asp:Content>
