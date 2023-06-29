<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentacionTPN3.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Ingresá a tu cuenta <strong style="color:blue">Smart</strong><strong style="color:#00ff21">!</strong></h2>
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
            transition:0.2s;
        }
        .bton:hover{
            background-color:#17c40a;
            color:black;
        }
    </style>
        <div class="col-md-6">
            <div class="mb-3">
                <label class="form-label lbl">User</label>
                <asp:TextBox runat="server" ID="txtEmail" placeholder="user name..." CssClass="form-control txt"/>
            </div>
            <div class="mb-3">
                <label class="form-label lbl">Password</label>
                <asp:TextBox runat="server" ID="txtPass" TextMode="Password" placeholder="password..." CssClass="form-control txt" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Ingresar" runat="server" ID="btnIngresar" CssClass="btn bton" OnClick="btnIngresar_Click" />
            </div>
        </div>
   
</asp:Content>
