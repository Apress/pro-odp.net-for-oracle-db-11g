﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.button10 = New System.Windows.Forms.Button
        Me.button9 = New System.Windows.Forms.Button
        Me.button8 = New System.Windows.Forms.Button
        Me.button7 = New System.Windows.Forms.Button
        Me.button6 = New System.Windows.Forms.Button
        Me.button5 = New System.Windows.Forms.Button
        Me.button4 = New System.Windows.Forms.Button
        Me.button3 = New System.Windows.Forms.Button
        Me.button2 = New System.Windows.Forms.Button
        Me.button1 = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'button10
        '
        Me.button10.Location = New System.Drawing.Point(231, 219)
        Me.button10.Name = "button10"
        Me.button10.Size = New System.Drawing.Size(201, 36)
        Me.button10.TabIndex = 27
        Me.button10.Text = "Using OracleBulkCopy"
        Me.button10.UseVisualStyleBackColor = True
        '
        'button9
        '
        Me.button9.Location = New System.Drawing.Point(231, 177)
        Me.button9.Name = "button9"
        Me.button9.Size = New System.Drawing.Size(201, 36)
        Me.button9.TabIndex = 26
        Me.button9.Text = "Using the client result cache"
        Me.button9.UseVisualStyleBackColor = True
        '
        'button8
        '
        Me.button8.Location = New System.Drawing.Point(231, 135)
        Me.button8.Name = "button8"
        Me.button8.Size = New System.Drawing.Size(201, 36)
        Me.button8.TabIndex = 25
        Me.button8.Text = "Changing Fetchsize property"
        Me.button8.UseVisualStyleBackColor = True
        '
        'button7
        '
        Me.button7.Location = New System.Drawing.Point(231, 93)
        Me.button7.Name = "button7"
        Me.button7.Size = New System.Drawing.Size(201, 36)
        Me.button7.TabIndex = 24
        Me.button7.Text = "Using LOB Caching"
        Me.button7.UseVisualStyleBackColor = True
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(231, 51)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(201, 36)
        Me.button6.TabIndex = 23
        Me.button6.Text = "Using PL/SQL Associative Arrays"
        Me.button6.UseVisualStyleBackColor = True
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(15, 219)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(201, 36)
        Me.button5.TabIndex = 22
        Me.button5.Text = "Using Bind Arrays"
        Me.button5.UseVisualStyleBackColor = True
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(15, 177)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(201, 36)
        Me.button4.TabIndex = 21
        Me.button4.Text = "Using Statement caching"
        Me.button4.UseVisualStyleBackColor = True
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(15, 135)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(201, 36)
        Me.button3.TabIndex = 20
        Me.button3.Text = "Batching SQL statements"
        Me.button3.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(15, 93)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(201, 36)
        Me.button2.TabIndex = 19
        Me.button2.Text = "Using BINARY FLOAT/BINARY DOUBLE"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(15, 51)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(201, 36)
        Me.button1.TabIndex = 18
        Me.button1.Text = "Using Connection pooling"
        Me.button1.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(15, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(493, 36)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Please run the SQL statements in the SQLScript.txt file first (using SQL*Plus), b" & _
            "efore running any of the samples below"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(523, 267)
        Me.Controls.Add(Me.button10)
        Me.Controls.Add(Me.button9)
        Me.Controls.Add(Me.button8)
        Me.Controls.Add(Me.button7)
        Me.Controls.Add(Me.button6)
        Me.Controls.Add(Me.button5)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Name = "Main"
        Me.Text = "Chapter 12"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button10 As System.Windows.Forms.Button
    Private WithEvents button9 As System.Windows.Forms.Button
    Private WithEvents button8 As System.Windows.Forms.Button
    Private WithEvents button7 As System.Windows.Forms.Button
    Private WithEvents button6 As System.Windows.Forms.Button
    Private WithEvents button5 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
