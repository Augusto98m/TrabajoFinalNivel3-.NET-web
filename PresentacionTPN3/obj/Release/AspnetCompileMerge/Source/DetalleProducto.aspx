<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="PresentacionTPN3.DetalleProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .negra{
            font-size: 25px;
            font-weight:600;
        }
        .negrita{
            font-size: 20px;
            font-weight: 400;
        }
        .negta{
            font-size: 22px;
            font-weight: 500;
        }
        .imag{
            width:350px;
            height:350px;
            transition:0.6s;
        }
        .imag:hover{
            width:355px;
            height:355px;            
        }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager5"/>
    <div class="row">
        <div class="col 2">
            <asp:UpdatePanel runat="server" ID="updatePanel1">
                <ContentTemplate>                    
                    <asp:Image ImageUrl="https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"
                        runat="server" ID="imgArticulo" CssClass="imag" />
                </ContentTemplate>
            </asp:UpdatePanel>
         </div>
         <div class="col-8" style="margin-top:60px">            
            <div class="mb-3">
                <label id="lblNombre" class="form-label negra" runat="server"></label>
            </div>   
            <div class="mb-3">
                <asp:Label ID="lblCategoria" runat="server" CssClass="form-label negrita" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblMarca" runat="server" CssClass="form-label negrita" />
            </div>                 
             <div class="mb-3">
                 <asp:Label ID="lblPrecio" runat="server" CssClass="form-label negra" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="mb-3">
                <label class="form-label negta">Descripción</label>
            <hr />
            <asp:Label ID="lblDescripcion" runat="server"/>                
        </div>
    </div>
</asp:Content>
