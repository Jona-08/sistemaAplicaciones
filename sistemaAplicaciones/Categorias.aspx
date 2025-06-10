<%@ Page Title="Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="sistemaAplicaciones.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5">
        <h2 class="mb-4">Gestión de Categorías</h2>

        <div class="card shadow rounded p-4 mb-4">
            <div class="row">
                <div class="col-md-6">
                    <label for="txtNombre" class="form-label">Nombre de Categoría:</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej. Juegos, Salud..."></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                        ControlToValidate="txtNombre"
                        ErrorMessage="Este campo es obligatorio"
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
                <div class="col-md-6 d-flex align-items-end">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                </div>
            </div>
        </div>
</asp:Content>
