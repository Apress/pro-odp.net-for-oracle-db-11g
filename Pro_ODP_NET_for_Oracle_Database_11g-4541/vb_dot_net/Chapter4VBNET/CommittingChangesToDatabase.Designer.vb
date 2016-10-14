<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CommittingChangesToDatabase
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
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
        Me.button1 = New System.Windows.Forms.Button
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(20, 267)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(155, 35)
        Me.button2.TabIndex = 7
        Me.button2.Text = "Commit changes to database"
        Me.button2.UseVisualStyleBackColor = True
        '
        'dataGridView1
        '
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(20, 42)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.Size = New System.Drawing.Size(517, 219)
        Me.dataGridView1.TabIndex = 6
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(20, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(109, 23)
        Me.button1.TabIndex = 5
        Me.button1.Text = "Retrieve Data"
        Me.button1.UseVisualStyleBackColor = True
        '
        'CommittingChangesToDatabase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(556, 315)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.dataGridView1)
        Me.Controls.Add(Me.button1)
        Me.Name = "CommittingChangesToDatabase"
        Me.Text = "CommittingChangesToDatabase"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents button1 As System.Windows.Forms.Button
End Class
