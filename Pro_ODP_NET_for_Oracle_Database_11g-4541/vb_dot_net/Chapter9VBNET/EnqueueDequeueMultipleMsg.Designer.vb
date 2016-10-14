<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EnqueueDequeueMultipleMsg
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
        Me.button2 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(193, 14)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(174, 23)
        Me.button2.TabIndex = 5
        Me.button2.Text = "Dequeue multiple messages"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(13, 14)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(174, 23)
        Me.button1.TabIndex = 4
        Me.button1.Text = "Enqueue multiple messages"
        Me.button1.UseVisualStyleBackColor = True
        '
        'EnqueueDequeueMultipleMsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(380, 51)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Name = "EnqueueDequeueMultipleMsg"
        Me.Text = "EnqueueDequeueMultipleMsg"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
End Class
