<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class InventoryForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InventoryForm))
        Me.LbTitle = New System.Windows.Forms.Label()
        Me.TbLPInventory = New System.Windows.Forms.TableLayoutPanel()
        Me.LbObjName = New System.Windows.Forms.Label()
        Me.LbQuantityTitle = New System.Windows.Forms.Label()
        Me.BtBack = New System.Windows.Forms.Button()
        Me.TbLPInventory.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbTitle
        '
        Me.LbTitle.AutoSize = True
        Me.LbTitle.BackColor = System.Drawing.Color.Transparent
        Me.LbTitle.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTitle.Location = New System.Drawing.Point(12, 9)
        Me.LbTitle.Name = "LbTitle"
        Me.LbTitle.Size = New System.Drawing.Size(363, 23)
        Me.LbTitle.TabIndex = 0
        Me.LbTitle.Text = "These are the items in the inventory:"
        '
        'TbLPInventory
        '
        Me.TbLPInventory.AutoScroll = True
        Me.TbLPInventory.BackColor = System.Drawing.Color.Transparent
        Me.TbLPInventory.ColumnCount = 2
        Me.TbLPInventory.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.2479!))
        Me.TbLPInventory.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.7521!))
        Me.TbLPInventory.Controls.Add(Me.LbObjName, 1, 0)
        Me.TbLPInventory.Controls.Add(Me.LbQuantityTitle, 0, 0)
        Me.TbLPInventory.Location = New System.Drawing.Point(16, 44)
        Me.TbLPInventory.Name = "TbLPInventory"
        Me.TbLPInventory.RowCount = 13
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.692307!))
        Me.TbLPInventory.Size = New System.Drawing.Size(359, 362)
        Me.TbLPInventory.TabIndex = 1
        '
        'LbObjName
        '
        Me.LbObjName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LbObjName.AutoSize = True
        Me.LbObjName.BackColor = System.Drawing.Color.Transparent
        Me.LbObjName.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbObjName.Location = New System.Drawing.Point(93, 4)
        Me.LbObjName.Name = "LbObjName"
        Me.LbObjName.Size = New System.Drawing.Size(114, 19)
        Me.LbObjName.TabIndex = 1
        Me.LbObjName.Text = "Object Name"
        Me.LbObjName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LbQuantityTitle
        '
        Me.LbQuantityTitle.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.LbQuantityTitle.AutoSize = True
        Me.LbQuantityTitle.BackColor = System.Drawing.Color.Transparent
        Me.LbQuantityTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbQuantityTitle.Location = New System.Drawing.Point(3, 4)
        Me.LbQuantityTitle.Name = "LbQuantityTitle"
        Me.LbQuantityTitle.Size = New System.Drawing.Size(79, 19)
        Me.LbQuantityTitle.TabIndex = 0
        Me.LbQuantityTitle.Text = "Quantity"
        Me.LbQuantityTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtBack
        '
        Me.BtBack.BackColor = System.Drawing.Color.Transparent
        Me.BtBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.BtBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtBack.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtBack.Location = New System.Drawing.Point(152, 412)
        Me.BtBack.Name = "BtBack"
        Me.BtBack.Size = New System.Drawing.Size(98, 37)
        Me.BtBack.TabIndex = 2
        Me.BtBack.Text = "Back"
        Me.BtBack.UseVisualStyleBackColor = False
        '
        'InventoryForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.ZooProject_4._0.My.Resources.Resources.frontpage_info_background
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(384, 461)
        Me.Controls.Add(Me.BtBack)
        Me.Controls.Add(Me.TbLPInventory)
        Me.Controls.Add(Me.LbTitle)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "InventoryForm"
        Me.Text = "InventoryForm"
        Me.TbLPInventory.ResumeLayout(False)
        Me.TbLPInventory.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LbTitle As Label
    Friend WithEvents LbObjName As Label
    Friend WithEvents LbQuantityTitle As Label
    Friend WithEvents BtBack As Button
    Public WithEvents TbLPInventory As TableLayoutPanel
End Class
