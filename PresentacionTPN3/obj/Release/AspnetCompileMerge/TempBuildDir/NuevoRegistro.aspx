<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="NuevoRegistro.aspx.cs" Inherits="PresentacionTPN3.NuevoRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Creá tu cuenta <strong style="color:blue">Smart</strong><strong style="color:#00ff21">!</strong></h2>
    <hr />
    <style>
        .lbl{
            background-color:blue;
            border-radius:6px;
            color:white;
            font-weight:600;
            text-align:center;
            padding: 1px 8px;
        }
        .txt{
            border-color:darkgray;
        }
        .bton{
            background-color:#17f306;
            color:black;
            width:100px;
            transition:0.2s;
            font-weight:600;
            
        }
        .bton:hover{
            background-color:#17c40a;
            color:black;
        }
        .validacion{
            color:red;
            font-size:12px;
        }
    </style>
    <div class="row">
        <div class="col-4">
            <div class="mb-3">
                <label class="form-label lbl">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" TextMode="Email" CssClass="form-control txt"/>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtEmail" runat="server" />
                <asp:RegularExpressionValidator ErrorMessage="Formato incorrecto ❌" CssClass="validacion" ControlToValidate="txtEmail" 
                    ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$" runat="server" />
            </div>
            <div class="mb-3">
                <label class="form-label lbl">Password</label>
                <asp:TextBox runat="server" ID="txtPass" TextMode="Password" CssClass="form-control txt" />
                <label class="form-label" style="font-size:12px">
                    La contraseña debe tener: De 8 a 15 caracteres, al menos un número, al menos una mayúscula y una minúscula, 
                    al menos un caracter especial.
                </label>
                <asp:RequiredFieldValidator CssClass="validacion" ErrorMessage="Campo requerido ❌ " ControlToValidate="txtPass" runat="server" />
                <asp:RegularExpressionValidator CssClass="validacion" ErrorMessage="La contraseña no cumple los requisitos ❌" ControlToValidate="txtPass" 
                    ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&#.$($)$-$_])[A-Za-z\d$@$!%*?&#.$($)$-$_]{8,15}$" runat="server" />
                
            </div>            
        </div>        
        <div class="col-2" style="margin-top:90px">
            <div class="mb-3">
                <asp:Button Text="Crear" runat="server" ID="btnCrearPerfil" CssClass="btn bton" OnClick="btnCrearPerfil_Click" />
            </div>
        </div>
    </div>    
       
        
    
</asp:Content>
