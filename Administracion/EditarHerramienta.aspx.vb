Private Sub CargarHerramienta(id As Integer)
    Dim dt As DataTable = herramientaDB.GetById(id)

    If dt.Rows.Count = 0 Then
        Response.Redirect("~/Administracion/GestionHerramientas.aspx")
        Return
    End If

    Dim row As DataRow = dt.Rows(0)

    txtNombre.Text = row("Nombre").ToString()
    txtCodigo.Text = row("Codigo").ToString()
    txtUbicacion.Text = row("Ubicacion").ToString()
    txtEstado.Text = row("Estado").ToString()  ' <-- ahora es TextBox
    txtDescripcion.Text = row("Descripcion").ToString()
End Sub

Protected Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

    Dim h As New Herramienta With {
        .HerramientaID = Convert.ToInt32(Request.QueryString("id")),
        .Nombre = txtNombre.Text,
        .Codigo = txtCodigo.Text,
        .Ubicacion = txtUbicacion.Text,
        .Estado = txtEstado.Text,
        .Descripcion = txtDescripcion.Text
    }

    Dim resultado As String = herramientaDB.Update(h)

    If resultado.Contains("actualizada") Then
        SwalUtils.SwalSuccess(Me, "Herramienta actualizada", "~/Administracion/GestionHerramientas.aspx")
    Else
        SwalUtils.SwalError(Me, resultado)
    End If
End Sub
