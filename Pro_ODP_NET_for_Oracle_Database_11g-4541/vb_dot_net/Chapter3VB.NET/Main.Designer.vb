Namespace Chapter_3
	Partial Public Class Main
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
            Me.button1 = New System.Windows.Forms.Button
            Me.button2 = New System.Windows.Forms.Button
            Me.button3 = New System.Windows.Forms.Button
            Me.button4 = New System.Windows.Forms.Button
            Me.button5 = New System.Windows.Forms.Button
            Me.button6 = New System.Windows.Forms.Button
            Me.button7 = New System.Windows.Forms.Button
            Me.button8 = New System.Windows.Forms.Button
            Me.button9 = New System.Windows.Forms.Button
            Me.SuspendLayout()
            '
            'button1
            '
            Me.button1.Location = New System.Drawing.Point(12, 12)
            Me.button1.Name = "button1"
            Me.button1.Size = New System.Drawing.Size(153, 23)
            Me.button1.TabIndex = 0
            Me.button1.Text = "Connect via TNS"
            Me.button1.UseVisualStyleBackColor = True
            '
            'button2
            '
            Me.button2.Location = New System.Drawing.Point(12, 41)
            Me.button2.Name = "button2"
            Me.button2.Size = New System.Drawing.Size(153, 23)
            Me.button2.TabIndex = 1
            Me.button2.Text = "Connect without TNS names"
            Me.button2.UseVisualStyleBackColor = True
            '
            'button3
            '
            Me.button3.Location = New System.Drawing.Point(13, 71)
            Me.button3.Name = "button3"
            Me.button3.Size = New System.Drawing.Size(152, 23)
            Me.button3.TabIndex = 2
            Me.button3.Text = "Connect via EZConnect"
            Me.button3.UseVisualStyleBackColor = True
            '
            'button4
            '
            Me.button4.Location = New System.Drawing.Point(13, 100)
            Me.button4.Name = "button4"
            Me.button4.Size = New System.Drawing.Size(152, 38)
            Me.button4.TabIndex = 3
            Me.button4.Text = "Connect with connection pooling"
            Me.button4.UseVisualStyleBackColor = True
            '
            'button5
            '
            Me.button5.Location = New System.Drawing.Point(13, 144)
            Me.button5.Name = "button5"
            Me.button5.Size = New System.Drawing.Size(152, 38)
            Me.button5.TabIndex = 4
            Me.button5.Text = "Connect with integrated windows authentication"
            Me.button5.UseVisualStyleBackColor = True
            '
            'button6
            '
            Me.button6.Location = New System.Drawing.Point(13, 188)
            Me.button6.Name = "button6"
            Me.button6.Size = New System.Drawing.Size(152, 35)
            Me.button6.TabIndex = 5
            Me.button6.Text = "Connect with special privileges"
            Me.button6.UseVisualStyleBackColor = True
            '
            'button7
            '
            Me.button7.Location = New System.Drawing.Point(172, 12)
            Me.button7.Name = "button7"
            Me.button7.Size = New System.Drawing.Size(144, 23)
            Me.button7.TabIndex = 6
            Me.button7.Text = "Check if ODP.NET exists"
            Me.button7.UseVisualStyleBackColor = True
            '
            'button8
            '
            Me.button8.Location = New System.Drawing.Point(172, 41)
            Me.button8.Name = "button8"
            Me.button8.Size = New System.Drawing.Size(144, 23)
            Me.button8.TabIndex = 7
            Me.button8.Text = "Build connection string"
            Me.button8.UseVisualStyleBackColor = True
            '
            'button9
            '
            Me.button9.Location = New System.Drawing.Point(172, 71)
            Me.button9.Name = "button9"
            Me.button9.Size = New System.Drawing.Size(144, 23)
            Me.button9.TabIndex = 8
            Me.button9.Text = "Display list of datasources"
            Me.button9.UseVisualStyleBackColor = True
            '
            'Main
            '
            Me.ClientSize = New System.Drawing.Size(422, 264)
            Me.Controls.Add(Me.button9)
            Me.Controls.Add(Me.button8)
            Me.Controls.Add(Me.button7)
            Me.Controls.Add(Me.button6)
            Me.Controls.Add(Me.button5)
            Me.Controls.Add(Me.button4)
            Me.Controls.Add(Me.button3)
            Me.Controls.Add(Me.button2)
            Me.Controls.Add(Me.button1)
            Me.Name = "Main"
            Me.Text = "Chapter 3"
            Me.ResumeLayout(False)

        End Sub

		#End Region

		Private WithEvents button1 As Button
		Private WithEvents button2 As Button
		Private WithEvents button3 As Button
		Private WithEvents button4 As Button
		Private WithEvents button5 As Button
		Private WithEvents button6 As Button
		Private WithEvents button7 As Button
		Private WithEvents button8 As Button
		Private WithEvents button9 As Button
	End Class
End Namespace

