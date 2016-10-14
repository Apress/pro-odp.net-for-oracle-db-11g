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
        Me.button12 = New System.Windows.Forms.Button
        Me.button11 = New System.Windows.Forms.Button
        Me.button10 = New System.Windows.Forms.Button
        Me.button9 = New System.Windows.Forms.Button
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
        'button12
        '
        Me.button12.Location = New System.Drawing.Point(372, 91)
        Me.button12.Name = "button12"
        Me.button12.Size = New System.Drawing.Size(173, 37)
        Me.button12.TabIndex = 30
        Me.button12.Text = "Using XQuery to retrieve data"
        Me.button12.UseVisualStyleBackColor = True
        '
        'button11
        '
        Me.button11.Location = New System.Drawing.Point(372, 48)
        Me.button11.Name = "button11"
        Me.button11.Size = New System.Drawing.Size(173, 39)
        Me.button11.TabIndex = 29
        Me.button11.Text = "Deleting relational data using XML"
        Me.button11.UseVisualStyleBackColor = True
        '
        'button10
        '
        Me.button10.Location = New System.Drawing.Point(194, 178)
        Me.button10.Name = "button10"
        Me.button10.Size = New System.Drawing.Size(173, 39)
        Me.button10.TabIndex = 28
        Me.button10.Text = "Updating relational data using XML"
        Me.button10.UseVisualStyleBackColor = True
        '
        'button9
        '
        Me.button9.Location = New System.Drawing.Point(194, 134)
        Me.button9.Name = "button9"
        Me.button9.Size = New System.Drawing.Size(173, 38)
        Me.button9.TabIndex = 27
        Me.button9.Text = "Inserting relational data using XML"
        Me.button9.UseVisualStyleBackColor = True
        '
        'button7
        '
        Me.button7.Location = New System.Drawing.Point(193, 91)
        Me.button7.Name = "button7"
        Me.button7.Size = New System.Drawing.Size(174, 37)
        Me.button7.TabIndex = 25
        Me.button7.Text = "Retrieving relational data as XML using XMLCommandType"
        Me.button7.UseVisualStyleBackColor = True
        '
        'button6
        '
        Me.button6.Location = New System.Drawing.Point(192, 48)
        Me.button6.Name = "button6"
        Me.button6.Size = New System.Drawing.Size(174, 37)
        Me.button6.TabIndex = 24
        Me.button6.Text = "Translate XML using XSLT"
        Me.button6.UseVisualStyleBackColor = True
        '
        'button5
        '
        Me.button5.Location = New System.Drawing.Point(12, 220)
        Me.button5.Name = "button5"
        Me.button5.Size = New System.Drawing.Size(174, 39)
        Me.button5.TabIndex = 23
        Me.button5.Text = "Validate against an XSD schema"
        Me.button5.UseVisualStyleBackColor = True
        '
        'button4
        '
        Me.button4.Location = New System.Drawing.Point(12, 178)
        Me.button4.Name = "button4"
        Me.button4.Size = New System.Drawing.Size(174, 36)
        Me.button4.TabIndex = 22
        Me.button4.Text = "Passing XML data to PL/SQL stored proc"
        Me.button4.UseVisualStyleBackColor = True
        '
        'button3
        '
        Me.button3.Location = New System.Drawing.Point(12, 134)
        Me.button3.Name = "button3"
        Me.button3.Size = New System.Drawing.Size(174, 38)
        Me.button3.TabIndex = 21
        Me.button3.Text = "Retrieving XML data from PL/SQL stored proc"
        Me.button3.UseVisualStyleBackColor = True
        '
        'button2
        '
        Me.button2.Location = New System.Drawing.Point(12, 91)
        Me.button2.Name = "button2"
        Me.button2.Size = New System.Drawing.Size(174, 37)
        Me.button2.TabIndex = 20
        Me.button2.Text = "Receiving XMLTYPE data with OracleXMLType"
        Me.button2.UseVisualStyleBackColor = True
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(12, 48)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(174, 37)
        Me.button1.TabIndex = 19
        Me.button1.Text = "Receiving XMLTYPE data with XMLReader"
        Me.button1.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(493, 36)
        Me.label1.TabIndex = 18
        Me.label1.Text = "Please run the SQL statements in the SQLScript.txt file first (using SQL*Plus), b" & _
            "efore running any of the samples below"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 286)
        Me.Controls.Add(Me.button12)
        Me.Controls.Add(Me.button11)
        Me.Controls.Add(Me.button10)
        Me.Controls.Add(Me.button9)
        Me.Controls.Add(Me.button7)
        Me.Controls.Add(Me.button6)
        Me.Controls.Add(Me.button5)
        Me.Controls.Add(Me.button4)
        Me.Controls.Add(Me.button3)
        Me.Controls.Add(Me.button2)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.label1)
        Me.Name = "Main"
        Me.Text = "Chapter 10"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents button12 As System.Windows.Forms.Button
    Private WithEvents button11 As System.Windows.Forms.Button
    Private WithEvents button10 As System.Windows.Forms.Button
    Private WithEvents button9 As System.Windows.Forms.Button
    Private WithEvents button7 As System.Windows.Forms.Button
    Private WithEvents button6 As System.Windows.Forms.Button
    Private WithEvents button5 As System.Windows.Forms.Button
    Private WithEvents button4 As System.Windows.Forms.Button
    Private WithEvents button3 As System.Windows.Forms.Button
    Private WithEvents button2 As System.Windows.Forms.Button
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
