<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class StartMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartMenu))
        Me.BtCreateZoo = New System.Windows.Forms.Button()
        Me.BtLoadZoo = New System.Windows.Forms.Button()
        Me.WelcomeMsg = New System.Windows.Forms.Label()
        Me.BtTutorial = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtCreateZoo
        '
        Me.BtCreateZoo.BackColor = System.Drawing.SystemColors.Control
        Me.BtCreateZoo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtCreateZoo.FlatAppearance.BorderSize = 3
        Me.BtCreateZoo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtCreateZoo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtCreateZoo.Font = New System.Drawing.Font("Broadway", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtCreateZoo.Location = New System.Drawing.Point(12, 145)
        Me.BtCreateZoo.Name = "BtCreateZoo"
        Me.BtCreateZoo.Size = New System.Drawing.Size(200, 100)
        Me.BtCreateZoo.TabIndex = 1
        Me.BtCreateZoo.Text = "Create Zoo"
        Me.BtCreateZoo.UseVisualStyleBackColor = False
        '
        'BtLoadZoo
        '
        Me.BtLoadZoo.BackColor = System.Drawing.SystemColors.Control
        Me.BtLoadZoo.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtLoadZoo.FlatAppearance.BorderSize = 3
        Me.BtLoadZoo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Aqua
        Me.BtLoadZoo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtLoadZoo.Font = New System.Drawing.Font("Broadway", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtLoadZoo.Location = New System.Drawing.Point(272, 145)
        Me.BtLoadZoo.Name = "BtLoadZoo"
        Me.BtLoadZoo.Size = New System.Drawing.Size(200, 100)
        Me.BtLoadZoo.TabIndex = 1
        Me.BtLoadZoo.Text = "Load Zoo"
        Me.BtLoadZoo.UseVisualStyleBackColor = False
        '
        'WelcomeMsg
        '
        Me.WelcomeMsg.AutoSize = True
        Me.WelcomeMsg.BackColor = System.Drawing.Color.Transparent
        Me.WelcomeMsg.Font = New System.Drawing.Font("Broadway", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WelcomeMsg.Location = New System.Drawing.Point(35, 9)
        Me.WelcomeMsg.Name = "WelcomeMsg"
        Me.WelcomeMsg.Size = New System.Drawing.Size(412, 42)
        Me.WelcomeMsg.TabIndex = 2
        Me.WelcomeMsg.Text = "Welcome to the Zoo!"
        '
        'BtTutorial
        '
        Me.BtTutorial.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtTutorial.FlatAppearance.BorderSize = 3
        Me.BtTutorial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen
        Me.BtTutorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtTutorial.Font = New System.Drawing.Font("Broadway", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtTutorial.Location = New System.Drawing.Point(161, 251)
        Me.BtTutorial.Name = "BtTutorial"
        Me.BtTutorial.Size = New System.Drawing.Size(148, 38)
        Me.BtTutorial.TabIndex = 3
        Me.BtTutorial.Text = "Tutorial"
        Me.BtTutorial.UseVisualStyleBackColor = True
        '
        'StartMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ZooProject_4._0.My.Resources.Resources.lion_start_background
        Me.ClientSize = New System.Drawing.Size(484, 301)
        Me.Controls.Add(Me.BtTutorial)
        Me.Controls.Add(Me.WelcomeMsg)
        Me.Controls.Add(Me.BtLoadZoo)
        Me.Controls.Add(Me.BtCreateZoo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "StartMenu"
        Me.Text = "Start Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtCreateZoo As Button
    Friend WithEvents BtLoadZoo As Button
    Friend WithEvents WelcomeMsg As Label
    Friend WithEvents BtTutorial As Button
End Class
