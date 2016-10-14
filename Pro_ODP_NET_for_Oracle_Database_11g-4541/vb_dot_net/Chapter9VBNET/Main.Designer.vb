<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.button6 = New System.Windows.Forms.Button
        Me.button5 = New System.Windows.Forms.Button
        Me.button4 = New System.Windows.Forms.Button
        Me.button3 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(16, 197)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(236, 23)
        Me.button6.TabIndex = 20
        Me.button6.Text = "Dequeue Synchronously/Asynchronously"
        Me.button6.UseVisualStyleBackColor = True
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(16, 168)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(236, 23)
        Me.button5.TabIndex = 19
        Me.button5.Text = "Enqueuing/Dequeuing XML"
        Me.button5.UseVisualStyleBackColor = True
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(16, 139)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(236, 23)
        Me.button4.TabIndex = 18
        Me.button4.Text = "Enqueuing/Dequeuing UDT"
        Me.button4.UseVisualStyleBackColor = True
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(16, 110)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(236, 23)
        Me.button3.TabIndex = 17
        Me.button3.Text = "Enqueuing/Dequeuing MCQ"
        Me.button3.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(16, 81)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(236, 23)
        Me.button2.TabIndex = 16
        Me.button2.Text = "Enqueuing/Dequeuing multiple messages"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(16, 52)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(236, 23)
        Me.button1.TabIndex = 15
        Me.button1.Text = "Enqueuing/Dequeuing a simple message"
        Me.button1.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(493, 36)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Please run the SQL statements in the SQLScript.txt file first (using SQL*Plus), b" & _
            "efore running any of the samples below"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 232)
        Me.Controls.Add(Me.button6)
        Me.Controls.Add(Me.button5)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Name = "Main"
        Me.Text = "Chapter 9"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button6 As System.Windows.Forms.Button
    Private WithEvents button5 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
