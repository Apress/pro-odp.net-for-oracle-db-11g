<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RetrieveBLOBData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button
        Me.picProductImage = New System.Windows.Forms.PictureBox
        Me.txtProductID = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        CType(Me.picProductImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(284, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(86, 23)
        Me.button1.TabIndex = 10
        Me.button1.Text = "Get BLOB"
        Me.button1.UseVisualStyleBackColor = True
        '
        'picProductImage
        '
        Me.picProductImage.BackColor = System.Drawing.SystemColors.ControlDark
        Me.picProductImage.Location = New System.Drawing.Point(12, 47)
        Me.picProductImage.Name = "picProductImage"
        Me.picProductImage.Size = New System.Drawing.Size(358, 154)
        Me.picProductImage.TabIndex = 9
        Me.picProductImage.TabStop = False
        '
        'txtProductID
        '
        Me.txtProductID.Location = New System.Drawing.Point(118, 12)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(160, 20)
        Me.txtProductID.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 13)
        Me.label1.TabIndex = 7
        Me.label1.Text = "Product ID"
        '
        'RetrieveBLOBData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 213)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.picProductImage)
        Me.Controls.Add(Me.txtProductID)
        Me.Controls.Add(Me.label1)
        Me.Name = "RetrieveBLOBData"
        Me.Text = "RetrieveBLOBData"
        CType(Me.picProductImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents picProductImage As System.Windows.Forms.PictureBox
    Private WithEvents txtProductID As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
