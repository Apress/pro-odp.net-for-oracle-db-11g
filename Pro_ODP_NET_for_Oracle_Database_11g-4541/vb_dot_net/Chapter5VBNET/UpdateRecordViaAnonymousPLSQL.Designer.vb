<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateRecordViaAnonymousPLSQL
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
        Me.numPriceIncrement = New System.Windows.Forms.NumericUpDown
        Me.txtProductName = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        CType(Me.numPriceIncrement, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(12, 61)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 9
        Me.button1.Text = "Update now"
        Me.button1.UseVisualStyleBackColor = True
        '
        'numPriceIncrement
        '
        Me.numPriceIncrement.Location = New System.Drawing.Point(128, 33)
        Me.numPriceIncrement.Name = "numPriceIncrement"
        Me.numPriceIncrement.Size = New System.Drawing.Size(120, 20)
        Me.numPriceIncrement.TabIndex = 8
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(128, 9)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(183, 20)
        Me.txtProductName.TabIndex = 7
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 35)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(83, 13)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Price increment:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(95, 13)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Product to update:"
        '
        'UpdateRecordViaAnonymousPLSQL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(495, 118)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.numPriceIncrement)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "UpdateRecordViaAnonymousPLSQL"
        Me.Text = "UpdateRecordViaAnonymousPLSQL"
        CType(Me.numPriceIncrement, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents numPriceIncrement As System.Windows.Forms.NumericUpDown
    Private WithEvents txtProductName As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
