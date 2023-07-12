<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioArtículo.aspx.cs" Inherits="PresentacionTPN3.FormularioArtículo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .validacion{
            color:red;
            font-size:12px;
        }
    </style>
    <asp:ScriptManager runat="server" ID="scriptManager1"/>
    <h2>Formulario Artículos 🗂️  </h2>
    <hr />
    <div class="row">
        <div class="col-5">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtNombre" runat="server" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Código</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtCodigo" runat="server" />
            </div>   
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtPrecio" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Enteros y decimales con punto" ControlToValidate="txtPrecio" CssClass="validacion" 
                    ValidationExpression="^[0-9]+([,])?([0-9]+)?$" runat="server" />
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoría</label>
                <asp:DropDownList runat="server" ID="ddlCategoria" CssClass="btn btn-secondary dropdown-toggle"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca</label>
                <asp:DropDownList runat="server" ID="ddlMarca" CssClass="btn btn-secondary dropdown-toggle"></asp:DropDownList>
            </div>

            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" />
                <asp:Button Text="Cancelar" ID="btnCancelar" runat="server" CssClass="btn btn-outline-danger" OnClick="btnCancelar_Click" />
            </div>          
        </div>

        <div class="col 5">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" />
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtDescripcion" runat="server" />
            </div>
            <asp:UpdatePanel runat="server" ID="updatePanel1">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtUrlImagen" class="form-label">UrlImagen</label>
                        <asp:TextBox runat="server" ID="txtUrlImagen" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtUrlImagen_TextChanged"/>
                    </div>
                    <asp:Image ImageUrl="https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png"
                        runat="server" ID="imgArticulo" Width="300px" Height="300px" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-5">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <%if (Request.QueryString["id"] != null)
                        { %>
                    <div class="mb-3">
                        <asp:Button Text="Eliminar" ID="btnEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnEliminar_Click" />
                    </div>
                    <%} %>
                    <%if (ConfirmaEliminacion)
                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirmar Eliminación" ID="chkEliminacion" runat="server" />
                        <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" CssClass="btn btn-danger" runat="server" OnClick="btnConfirmaEliminar_Click" />
                    </div>
                    <%} %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
