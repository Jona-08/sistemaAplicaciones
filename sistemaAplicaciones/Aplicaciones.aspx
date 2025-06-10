<%@ Page Title="Gestión de Aplicaciones" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Aplicaciones.aspx.cs" Inherits="sistemaAplicaciones.Aplicaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2 class="mb-4">Gestión de Aplicaciones</h2>

        <!-- Formulario -->
        <div class="card shadow p-4 mb-4">
            <div class="form-group">
                <label>Nombre:</label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" CssClass="text-danger" ErrorMessage="* Campo obligatorio" Display="Dynamic" />
            </div>
            <div class="form-group">
                <label>Descripción:</label>
                <asp:TextBox ID="txtDescripcion" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion" CssClass="text-danger" ErrorMessage="* Campo obligatorio" Display="Dynamic" />
            </div>
            <div class="form-group">
                <label>Categoría:</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-control" runat="server" />
                <asp:RequiredFieldValidator ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria" InitialValue="0" CssClass="text-danger" ErrorMessage="* Seleccione una categoría" Display="Dynamic" />
            </div>

            <asp:HiddenField ID="hfId" runat="server" />

            <div class="mt-3">
                <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Agregar" OnClick="btnAgregar_Click" />
                <asp:Button ID="btnActualizar" runat="server" CssClass="btn btn-primary" Text="Actualizar" OnClick="btnActualizar_Click" Visible="false" />
                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-secondary" Text="Cancelar" OnClick="btnCancelar_Click" Visible="false" />
            </div>
        </div>

        <asp:GridView ID="gvAplicaciones" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvAplicaciones_RowCommand">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="ID" />
                <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="categoria" HeaderText="Categoría" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-sm btn-warning" CommandName="EditarRegistro" CommandArgument='<%# Eval("id") %>' />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger" CommandName="EliminarRegistro" CommandArgument='<%# Eval("id") %>' OnClientClick="return confirm('¿Estás seguro de eliminar este registro?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label ID="lblMensaje" runat="server" CssClass="text-success"></asp:Label>
    </div>
</asp:Content>