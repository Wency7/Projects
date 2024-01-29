<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Menu))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btnpos = New System.Windows.Forms.Button()
        Me.btnsalesrep = New System.Windows.Forms.Button()
        Me.btnmanage = New System.Windows.Forms.Button()
        Me.btnaboutus = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.LightGreen
        Me.PictureBox2.Location = New System.Drawing.Point(30, 30)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(275, 300)
        Me.PictureBox2.TabIndex = 3
        Me.PictureBox2.TabStop = False
        '
        'btnpos
        '
        Me.btnpos.BackColor = System.Drawing.Color.Green
        Me.btnpos.Font = New System.Drawing.Font("Rockwell", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnpos.ForeColor = System.Drawing.Color.White
        Me.btnpos.Location = New System.Drawing.Point(65, 51)
        Me.btnpos.Name = "btnpos"
        Me.btnpos.Size = New System.Drawing.Size(205, 60)
        Me.btnpos.TabIndex = 5
        Me.btnpos.Text = "Point Of Sale"
        Me.btnpos.UseVisualStyleBackColor = False
        '
        'btnsalesrep
        '
        Me.btnsalesrep.BackColor = System.Drawing.Color.Green
        Me.btnsalesrep.Font = New System.Drawing.Font("Rockwell", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnsalesrep.ForeColor = System.Drawing.Color.White
        Me.btnsalesrep.Location = New System.Drawing.Point(65, 117)
        Me.btnsalesrep.Name = "btnsalesrep"
        Me.btnsalesrep.Size = New System.Drawing.Size(205, 60)
        Me.btnsalesrep.TabIndex = 6
        Me.btnsalesrep.Text = "View Sales Report"
        Me.btnsalesrep.UseVisualStyleBackColor = False
        '
        'btnmanage
        '
        Me.btnmanage.BackColor = System.Drawing.Color.Green
        Me.btnmanage.Font = New System.Drawing.Font("Rockwell", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmanage.ForeColor = System.Drawing.Color.White
        Me.btnmanage.Location = New System.Drawing.Point(65, 183)
        Me.btnmanage.Name = "btnmanage"
        Me.btnmanage.Size = New System.Drawing.Size(205, 60)
        Me.btnmanage.TabIndex = 7
        Me.btnmanage.Text = "View  Management Reports"
        Me.btnmanage.UseVisualStyleBackColor = False
        '
        'btnaboutus
        '
        Me.btnaboutus.BackColor = System.Drawing.Color.Green
        Me.btnaboutus.Font = New System.Drawing.Font("Rockwell", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnaboutus.ForeColor = System.Drawing.Color.White
        Me.btnaboutus.Location = New System.Drawing.Point(65, 249)
        Me.btnaboutus.Name = "btnaboutus"
        Me.btnaboutus.Size = New System.Drawing.Size(205, 60)
        Me.btnaboutus.TabIndex = 8
        Me.btnaboutus.Text = "About Us"
        Me.btnaboutus.UseVisualStyleBackColor = False
        '
        'Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(334, 361)
        Me.Controls.Add(Me.btnaboutus)
        Me.Controls.Add(Me.btnmanage)
        Me.Controls.Add(Me.btnsalesrep)
        Me.Controls.Add(Me.btnpos)
        Me.Controls.Add(Me.PictureBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Menu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnpos As Button
    Friend WithEvents btnsalesrep As Button
    Friend WithEvents btnmanage As Button
    Friend WithEvents btnaboutus As Button
End Class
