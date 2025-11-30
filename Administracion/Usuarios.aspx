<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.vb" Inherits="ControlVehiculos.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-bg d-flex align-items-center justify-content-center">
        <div class="container py-5">
            <div class="justify-content-center">
                <div class="col-12 col-sm-10 col-md-8 col-lg-6">
                    <div class="card login-card shadow-sm">
                        <div class="row g-5">
                            <div class="col-md-5 d-0 d-md-flex brand-panel">
                                <svg width="72" height="72" viewBox="0 0 24 24" fill="blue" class="mb-3" xmlns="http://www.w3.org/2000/svg" aria-hidden="true">
                                    <rect width="24" height="24" rx="6" fill="white" fill-opacity="0.08"/>
                                    <path d="M12 7v6l4 2" stroke="white" stroke-width="1.4" stroke-linecap="round" stroke-linejoin="round"/>
                                </svg>
                                <h3>Acceso de Usuario</h3>
                                <p> </p>
                            </div>

                            <div class="col-md-7">
                                <div class="card-body p-4 p-sm-5">
                                    <h5 class="mb-3">Iniciar sesión</h5>

                                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="d-block mb-2" Visible="false"></asp:Label>

                                    <div class="mb-3">
                                        <label for="txtUsuario" class="form-label small">Usuario</label>
                                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control form-control-lg" Placeholder="Nombre de usuario" />
                                    </div>

                                    <div class="mb-3">
                                        <label for="txtPassword" class="form-label small">Contraseña</label>
                                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control form-control-lg" TextMode="Password" Placeholder="Contraseña" />
                                    </div>

                                    <div class="d-grid mb-3">
                                        <asp:Button ID="btnIniciarSesion" runat="server" Text="Iniciar sesión" OnClick="btnIniciarSesion_Click" CssClass="btn btn-pink btn-lg" />
                                    </div>

                                    <div class="d-flex justify-content-between align-items-center">
                                        <a href="Registro.aspx" class="small small-muted text-decoration-none">¿No tienes cuenta?</a>
                                        <a href="#" class="small text-muted text-decoration-none">¿Olvidaste la contraseña?</a>
                                    </div>

                                  <%-- Lables --%>
                                    <asp:Label ID="lblUsuario" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblEmail" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div> 
                </div>
            </div>
        </div>
    </div>
</asp:Content>