<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="PresentacionTPN3.MiPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .boton{            
            background-color:blue;
            color:white;
            transition:0.2s;
        }
        .boton:hover{
            background-color:#080697; 
            color:white;
        }
        .validacion{
            color:red;
            font-size:12px;
        }
    </style>
    <h2>Mi Perfil 😃</h2>
    <hr />
    <div class="row">   
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" disabled CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtNombre" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese solo letras" ControlToValidate="txtNombre" CssClass="validacion" 
                    ValidationExpression="^[a-zA-Z]+$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label">Apellido</label>
                <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtApellido" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Ingrese solo letras" ControlToValidate="txtApellido" CssClass="validacion" 
                    ValidationExpression="^[a-zA-Z]+$" runat="server" />
            </div>            
        </div>
        <div class="col-md-4">
            <div class="mb-3">
                <label class="form-label">Imagen de Perfil</label>
                <input type="file" id="txtImagen" class="form-control" runat="server" />
            </div>
            <asp:Image ID="imgNuevoPerfil" ImageUrl="https://upload.wikimedia.org/wikipedia/commons/thumb/3/3f/Placeholder_view_vector.svg/1200px-Placeholder_view_vector.svg.png" 
                runat="server" Width="280px" Height="245px"  />
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" runat="server" CssClass="btn boton" ID="btnGuardarPerfil" OnClick="btnGuardarPerfil_Click"  />
            <a href="Inicio.aspx">Regresar</a>
        </div>
    </div>
</asp:Content>
