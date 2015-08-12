<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.CopyButton = New System.Windows.Forms.Button()
        Me.RadTB = New System.Windows.Forms.TextBox()
        Me.StrTB = New System.Windows.Forms.TextBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.PasteButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SmoothPanel = New System.Windows.Forms.Panel()
        Me.SmoothButton = New System.Windows.Forms.Button()
        Me.CopyPanel = New System.Windows.Forms.Panel()
        Me.CopyLabel = New System.Windows.Forms.Label()
        Me.PastePanel = New System.Windows.Forms.Panel()
        Me.PasteLabel = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SmoothPanel.SuspendLayout()
        Me.CopyPanel.SuspendLayout()
        Me.PastePanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CopyButton
        '
        Me.CopyButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.CopyButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.CopyButton.Enabled = False
        Me.CopyButton.FlatAppearance.BorderSize = 0
        Me.CopyButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.CopyButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.CopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CopyButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.CopyButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.CopyButton.Location = New System.Drawing.Point(0, 0)
        Me.CopyButton.Margin = New System.Windows.Forms.Padding(0)
        Me.CopyButton.Name = "CopyButton"
        Me.CopyButton.Size = New System.Drawing.Size(96, 30)
        Me.CopyButton.TabIndex = 1
        Me.CopyButton.Text = "Copy"
        Me.CopyButton.UseVisualStyleBackColor = False
        '
        'RadTB
        '
        Me.RadTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.RadTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RadTB.Location = New System.Drawing.Point(67, 33)
        Me.RadTB.MaxLength = 4
        Me.RadTB.Name = "RadTB"
        Me.RadTB.Size = New System.Drawing.Size(25, 13)
        Me.RadTB.TabIndex = 5
        Me.RadTB.Text = "1"
        '
        'StrTB
        '
        Me.StrTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.StrTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.StrTB.Location = New System.Drawing.Point(67, 49)
        Me.StrTB.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.StrTB.MaxLength = 4
        Me.StrTB.Name = "StrTB"
        Me.StrTB.Size = New System.Drawing.Size(25, 13)
        Me.StrTB.TabIndex = 5
        Me.StrTB.Text = "0"
        '
        'BackgroundWorker1
        '
        '
        'PasteButton
        '
        Me.PasteButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PasteButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.PasteButton.FlatAppearance.BorderSize = 0
        Me.PasteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.PasteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.PasteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PasteButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.PasteButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.PasteButton.Location = New System.Drawing.Point(0, 0)
        Me.PasteButton.Name = "PasteButton"
        Me.PasteButton.Size = New System.Drawing.Size(96, 30)
        Me.PasteButton.TabIndex = 8
        Me.PasteButton.Text = "Paste"
        Me.PasteButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Range:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Strength:"
        '
        'SmoothPanel
        '
        Me.SmoothPanel.BackColor = System.Drawing.Color.SteelBlue
        Me.SmoothPanel.Controls.Add(Me.Label1)
        Me.SmoothPanel.Controls.Add(Me.Label2)
        Me.SmoothPanel.Controls.Add(Me.RadTB)
        Me.SmoothPanel.Controls.Add(Me.StrTB)
        Me.SmoothPanel.Controls.Add(Me.SmoothButton)
        Me.SmoothPanel.Location = New System.Drawing.Point(164, 226)
        Me.SmoothPanel.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.SmoothPanel.Name = "SmoothPanel"
        Me.SmoothPanel.Size = New System.Drawing.Size(96, 66)
        Me.SmoothPanel.TabIndex = 11
        '
        'SmoothButton
        '
        Me.SmoothButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.SmoothButton.Dock = System.Windows.Forms.DockStyle.Top
        Me.SmoothButton.Enabled = False
        Me.SmoothButton.FlatAppearance.BorderSize = 0
        Me.SmoothButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(190, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.SmoothButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.SmoothButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SmoothButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.SmoothButton.ForeColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(44, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.SmoothButton.Location = New System.Drawing.Point(0, 0)
        Me.SmoothButton.Name = "SmoothButton"
        Me.SmoothButton.Size = New System.Drawing.Size(96, 30)
        Me.SmoothButton.TabIndex = 1
        Me.SmoothButton.Text = "Smooth"
        Me.SmoothButton.UseVisualStyleBackColor = False
        '
        'CopyPanel
        '
        Me.CopyPanel.BackColor = System.Drawing.Color.SteelBlue
        Me.CopyPanel.Controls.Add(Me.CopyLabel)
        Me.CopyPanel.Controls.Add(Me.CopyButton)
        Me.CopyPanel.Location = New System.Drawing.Point(268, 226)
        Me.CopyPanel.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.CopyPanel.Name = "CopyPanel"
        Me.CopyPanel.Size = New System.Drawing.Size(96, 66)
        Me.CopyPanel.TabIndex = 15
        '
        'CopyLabel
        '
        Me.CopyLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CopyLabel.Location = New System.Drawing.Point(0, 30)
        Me.CopyLabel.Margin = New System.Windows.Forms.Padding(3)
        Me.CopyLabel.Name = "CopyLabel"
        Me.CopyLabel.Padding = New System.Windows.Forms.Padding(1, 2, 1, 1)
        Me.CopyLabel.Size = New System.Drawing.Size(96, 36)
        Me.CopyLabel.TabIndex = 11
        '
        'PastePanel
        '
        Me.PastePanel.BackColor = System.Drawing.Color.SteelBlue
        Me.PastePanel.Controls.Add(Me.PasteLabel)
        Me.PastePanel.Controls.Add(Me.PasteButton)
        Me.PastePanel.Location = New System.Drawing.Point(60, 226)
        Me.PastePanel.Margin = New System.Windows.Forms.Padding(3, 0, 3, 3)
        Me.PastePanel.Name = "PastePanel"
        Me.PastePanel.Size = New System.Drawing.Size(96, 66)
        Me.PastePanel.TabIndex = 12
        '
        'PasteLabel
        '
        Me.PasteLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PasteLabel.Location = New System.Drawing.Point(0, 30)
        Me.PasteLabel.Name = "PasteLabel"
        Me.PasteLabel.Padding = New System.Windows.Forms.Padding(1, 2, 1, 1)
        Me.PasteLabel.Size = New System.Drawing.Size(96, 36)
        Me.PasteLabel.TabIndex = 10
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox2.Location = New System.Drawing.Point(220, 12)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(4, 3, 3, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox2.TabIndex = 17
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(3, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(200, 200)
        Me.PictureBox1.TabIndex = 18
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(370, 269)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(50, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AcceptButton = Me.SmoothButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(431, 304)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.CopyPanel)
        Me.Controls.Add(Me.PastePanel)
        Me.Controls.Add(Me.SmoothPanel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.Text = "Algodoo Polygon Smoothing Tool"
        Me.SmoothPanel.ResumeLayout(False)
        Me.SmoothPanel.PerformLayout()
        Me.CopyPanel.ResumeLayout(False)
        Me.PastePanel.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CopyButton As System.Windows.Forms.Button
    Friend WithEvents RadTB As System.Windows.Forms.TextBox
    Friend WithEvents StrTB As System.Windows.Forms.TextBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PasteButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents SmoothPanel As System.Windows.Forms.Panel
    Friend WithEvents CopyPanel As System.Windows.Forms.Panel
    Friend WithEvents PastePanel As System.Windows.Forms.Panel
    Friend WithEvents PasteLabel As System.Windows.Forms.Label
    Friend WithEvents CopyLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents SmoothButton As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
