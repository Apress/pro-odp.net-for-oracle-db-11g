﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ParameterizedQueries
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
        Me.txtRemarks = New System.Windows.Forms.TextBox
        Me.numPrice = New System.Windows.Forms.NumericUpDown
        Me.label4 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.txtName = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.button1 = New System.Windows.Forms.Button
        Me.txtID = New System.Windows.Forms.TextBox
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRemarks
        '
        Me.txtRemarks.Location = New System.Drawing.Point(116, 98)
        Me.txtRemarks.Multiline = True
        Me.txtRemarks.Name = "txtRemarks"
        Me.txtRemarks.Size = New System.Drawing.Size(229, 88)
        Me.txtRemarks.TabIndex = 5
        '
        'numPrice
        '
        Me.numPrice.Location = New System.Drawing.Point(116, 64)
        Me.numPrice.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.numPrice.Name = "numPrice"
        Me.numPrice.Size = New System.Drawing.Size(100, 20)
        Me.numPrice.TabIndex = 4
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(27, 98)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(49, 13)
        Me.label4.TabIndex = 2
        Me.label4.Text = "Remarks"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(13, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(18, 13)
        Me.label1.TabIndex = 4
        Me.label1.Text = "ID"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(116, 30)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(100, 20)
        Me.txtName.TabIndex = 3
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(27, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(31, 13)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Price"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.txtRemarks)
        Me.groupBox1.Controls.Add(Me.numPrice)
        Me.groupBox1.Controls.Add(Me.txtName)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Location = New System.Drawing.Point(12, 41)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(510, 211)
        Me.groupBox1.TabIndex = 7
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Data"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(27, 30)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(35, 13)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Name"
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(172, 12)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(97, 23)
        Me.button1.TabIndex = 6
        Me.button1.Text = "Retrieve Data"
        Me.button1.UseVisualStyleBackColor = True
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(66, 12)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(100, 20)
        Me.txtID.TabIndex = 5
        '
        'ParameterizedQueries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(534, 282)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.txtID)
        Me.Name = "ParameterizedQueries"
        Me.Text = "ParameterizedQueries"
        CType(Me.numPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtRemarks As System.Windows.Forms.TextBox
    Private WithEvents numPrice As System.Windows.Forms.NumericUpDown
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents txtID As System.Windows.Forms.TextBox
End Class
