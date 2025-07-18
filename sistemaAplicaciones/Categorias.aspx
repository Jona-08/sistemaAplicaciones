﻿<%@ Page Title="Categorías" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="sistemaAplicaciones.Categorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container mt-5">
            <h2  class="mb-4 text-white text-center"> Gestión de Categorías</h2>

            <div class="card shadow rounded p-4 mb-4 form-container">
                <div class="row">
                    <div class="col-md-6">
                        <label for="txtNombre" class="form-label text-black">Nombre de Categoría:</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ej. Juegos, Salud..."></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server"
                            ControlToValidate="txtNombre"
                            ErrorMessage="Este campo es obligatorio"
                            CssClass="text-danger"
                            Display="Dynamic"
                            ValidationGroup="CategoriaValidacion"/>
                        <asp:Label ID="lblMensaje" runat="server" CssClass="fw-bold d-block mt-3 text-warning"></asp:Label>
                    </div>

                    <div class="mt-3">
                        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregar_Click" ValidationGroup="CategoriaValidacion" />
                        <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="btn btn-primary ms-2" OnClick="btnActualizar_Click" Visible="false" ValidationGroup="CategoriaValidacion" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" CausesValidation="false" Visible="false" />
                    </div>
                </div>
            </div>
        </div>

        <asp:GridView ID="gvCategorias" runat="server" CssClass="table table-bordered table-striped gridview-dark" AutoGenerateColumns="False" OnRowCommand="gvCategorias_RowCommand" DataKeyNames="id">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("id") %>' Text="Editar" CssClass="btn btn-warning btn-sm me-2" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm" CommandName="Eliminar" CommandArgument='<%# Eval("id") %>' OnClientClick="confirmDelete(event, this);" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
