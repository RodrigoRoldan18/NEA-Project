<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2_FileName
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
        Me.LbFileName = New System.Windows.Forms.Label()
        Me.TbxFileName = New System.Windows.Forms.TextBox()
        Me.BtConfirm = New System.Windows.Forms.Button()
        Me.BtBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LbFileName
        '
        Me.LbFileName.AutoSize = True
        Me.LbFileName.BackColor = System.Drawing.Color.Transparent
        Me.LbFileName.Font = New System.Drawing.Font("Broadway", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbFileName.Location = New System.Drawing.Point(52, 58)
        Me.LbFileName.Name = "LbFileName"
        Me.LbFileName.Size = New System.Drawing.Size(390, 24)
        Me.LbFileName.TabIndex = 0
        Me.LbFileName.Text = "Please enter the name of the zoo:"
        '
        'TbxFileName
        '
        Me.TbxFileName.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbxFileName.Location = New System.Drawing.Point(87, 117)
        Me.TbxFileName.Name = "TbxFileName"
        Me.TbxFileName.Size = New System.Drawing.Size(325, 33)
        Me.TbxFileName.TabIndex = 1
        '
        'BtConfirm
        '
        Me.BtConfirm.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtConfirm.FlatAppearance.BorderSize = 3
        Me.BtConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green
        Me.BtConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtConfirm.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtConfirm.Location = New System.Drawing.Point(195, 235)
        Me.BtConfirm.Name = "BtConfirm"
        Me.BtConfirm.Size = New System.Drawing.Size(102, 37)
        Me.BtConfirm.TabIndex = 2
        Me.BtConfirm.Text = "Confirm"
        Me.BtConfirm.UseVisualStyleBackColor = True
        '
        'BtBack
        '
        Me.BtBack.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtBack.Location = New System.Drawing.Point(12, 12)
        Me.BtBack.Name = "BtBack"
        Me.BtBack.Size = New System.Drawing.Size(75, 30)
        Me.BtBack.TabIndex = 3
        Me.BtBack.Text = "Back"
        Me.BtBack.UseVisualStyleBackColor = True
        '
        'Form2_FileName
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ZooProject_4._0.My.Resources.Resources.lion_start_background
        Me.ClientSize = New System.Drawing.Size(484, 301)
        Me.Controls.Add(Me.BtBack)
        Me.Controls.Add(Me.BtConfirm)
        Me.Controls.Add(Me.TbxFileName)
        Me.Controls.Add(Me.LbFileName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form2_FileName"
        Me.ShowInTaskbar = False
        Me.Text = "Form2_FileName"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbFileName As Label
    Friend WithEvents TbxFileName As TextBox
    Friend WithEvents BtConfirm As Button
    Friend WithEvents BtBack As Button
End Class
