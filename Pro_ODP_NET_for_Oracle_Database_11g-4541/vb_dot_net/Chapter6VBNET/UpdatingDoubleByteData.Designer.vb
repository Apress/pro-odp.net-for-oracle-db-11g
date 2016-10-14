<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdatingDoubleByteData
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
        Me.label3 = New System.Windows.Forms.Label
        Me.button1 = New System.Windows.Forms.Button
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.txtProductID = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(20, 21)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(365, 13)
        Me.label3.TabIndex = 11
        Me.label3.Text = "To run this sample, you must have support for east asian languages installed"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(21, 119)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(75, 23)
        Me.button1.TabIndex = 10
        Me.button1.Text = "Update"
        Me.button1.UseVisualStyleBackColor = True
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(161, 84)
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(195, 20)
        Me.txtRemarks.TabIndex = 9
        Me.txtRemarks.Text = "ワイパー：この作品は2010年まで在庫切れ"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(20, 84)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(118, 13)
        Me.label2.TabIndex = 8
        Me.label2.Text = "Remarks in double byte"
        '
        'txtProductID
        '
        Me.txtProductID.Location = New System.Drawing.Point(161, 58)
        Me.txtProductID.Name = "txtProductID"
        Me.txtProductID.Size = New System.Drawing.Size(195, 20)
        Me.txtProductID.TabIndex = 7
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(20, 58)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(120, 13)
        Me.label1.TabIndex = 6
        Me.label1.Text = "ID of product to update:"
        '
        'UpdatingDoubleByteData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(405, 162)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.txtRemarks)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtProductID)
        Me.Controls.Add(Me.label1)
        Me.Name = "UpdatingDoubleByteData"
        Me.Text = "UpdatingDoubleByteData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents txtRemarks As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtProductID As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
