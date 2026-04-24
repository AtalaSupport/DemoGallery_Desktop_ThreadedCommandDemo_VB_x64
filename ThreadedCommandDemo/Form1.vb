Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Reflection
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.ImageProcessing
Imports Atalasoft.Imaging.Codec
Imports WinDemoHelperMethods.WinDemoHelperMethods

Namespace ThreadedCommandDemo
    ''' <summary>
    ''' Applies threaded image commands and displays the timing results.
    ''' </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private _originalImage As Atalasoft.Imaging.AtalaImage
        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private menuItem3 As System.Windows.Forms.MenuItem
        Private statusBar1 As System.Windows.Forms.StatusBar
        Private statusTime As System.Windows.Forms.StatusBarPanel
        Private statusFile As System.Windows.Forms.StatusBarPanel
        Private panel1 As System.Windows.Forms.Panel
        Private splitter1 As System.Windows.Forms.Splitter
        Private label1 As System.Windows.Forms.Label
        Private panel2 As System.Windows.Forms.Panel
        Private WithEvents cboCommand As System.Windows.Forms.ComboBox
        Private propertyGrid1 As System.Windows.Forms.PropertyGrid
        Private WithEvents btnApply As System.Windows.Forms.Button
        Private workspaceViewer1 As Atalasoft.Imaging.WinControls.WorkspaceViewer
        Private menuFile As System.Windows.Forms.MenuItem
        Private WithEvents menuOpen As System.Windows.Forms.MenuItem
        Private WithEvents menuExit As System.Windows.Forms.MenuItem
        Private statusNoThread As System.Windows.Forms.StatusBarPanel
        Private groupBox1 As System.Windows.Forms.GroupBox
        Private numSectionHeight As System.Windows.Forms.NumericUpDown
        Private label3 As System.Windows.Forms.Label
        Private numThreads As System.Windows.Forms.NumericUpDown
        Private label2 As System.Windows.Forms.Label
        Private label4 As System.Windows.Forms.Label
        Private numIterations As System.Windows.Forms.NumericUpDown
        Private statusCpus As System.Windows.Forms.StatusBarPanel
        Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
        Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
        Private components As System.ComponentModel.IContainer
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>

        Shared Sub New()
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)
        End Sub

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
            Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
            Me.menuFile = New System.Windows.Forms.MenuItem
            Me.menuOpen = New System.Windows.Forms.MenuItem
            Me.menuItem3 = New System.Windows.Forms.MenuItem
            Me.menuExit = New System.Windows.Forms.MenuItem
            Me.MenuItem1 = New System.Windows.Forms.MenuItem
            Me.MenuItem2 = New System.Windows.Forms.MenuItem
            Me.statusBar1 = New System.Windows.Forms.StatusBar
            Me.statusFile = New System.Windows.Forms.StatusBarPanel
            Me.statusCpus = New System.Windows.Forms.StatusBarPanel
            Me.statusNoThread = New System.Windows.Forms.StatusBarPanel
            Me.statusTime = New System.Windows.Forms.StatusBarPanel
            Me.panel1 = New System.Windows.Forms.Panel
            Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid
            Me.panel2 = New System.Windows.Forms.Panel
            Me.groupBox1 = New System.Windows.Forms.GroupBox
            Me.numIterations = New System.Windows.Forms.NumericUpDown
            Me.label4 = New System.Windows.Forms.Label
            Me.numSectionHeight = New System.Windows.Forms.NumericUpDown
            Me.label3 = New System.Windows.Forms.Label
            Me.numThreads = New System.Windows.Forms.NumericUpDown
            Me.label2 = New System.Windows.Forms.Label
            Me.btnApply = New System.Windows.Forms.Button
            Me.cboCommand = New System.Windows.Forms.ComboBox
            Me.label1 = New System.Windows.Forms.Label
            Me.splitter1 = New System.Windows.Forms.Splitter
            Me.workspaceViewer1 = New Atalasoft.Imaging.WinControls.WorkspaceViewer
            CType(Me.statusFile, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusCpus, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusNoThread, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.statusTime, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panel1.SuspendLayout()
            Me.panel2.SuspendLayout()
            Me.groupBox1.SuspendLayout()
            CType(Me.numIterations, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numSectionHeight, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.numThreads, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'mainMenu1
            '
            Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.MenuItem1})
            '
            'menuFile
            '
            Me.menuFile.Index = 0
            Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuOpen, Me.menuItem3, Me.menuExit})
            Me.menuFile.Text = "&File"
            '
            'menuOpen
            '
            Me.menuOpen.Index = 0
            Me.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
            Me.menuOpen.Text = "&Open"
            '
            'menuItem3
            '
            Me.menuItem3.Index = 1
            Me.menuItem3.Text = "-"
            '
            'menuExit
            '
            Me.menuExit.Index = 2
            Me.menuExit.Text = "E&xit"
            '
            'MenuItem1
            '
            Me.MenuItem1.Index = 1
            Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2})
            Me.MenuItem1.Text = "&Help"
            '
            'MenuItem2
            '
            Me.MenuItem2.Index = 0
            Me.MenuItem2.Text = "&About ..."
            '
            'statusBar1
            '
            Me.statusBar1.Location = New System.Drawing.Point(0, 467)
            Me.statusBar1.Name = "statusBar1"
            Me.statusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.statusFile, Me.statusCpus, Me.statusNoThread, Me.statusTime})
            Me.statusBar1.ShowPanels = True
            Me.statusBar1.Size = New System.Drawing.Size(808, 22)
            Me.statusBar1.TabIndex = 0
            Me.statusBar1.Text = "statusBar1"
            '
            'statusFile
            '
            Me.statusFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
            Me.statusFile.Name = "statusFile"
            Me.statusFile.Width = 428
            '
            'statusCpus
            '
            Me.statusCpus.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusCpus.Name = "statusCpus"
            Me.statusCpus.Text = "CPU Count:"
            Me.statusCpus.Width = 84
            '
            'statusNoThread
            '
            Me.statusNoThread.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusNoThread.Name = "statusNoThread"
            Me.statusNoThread.ToolTipText = "Previous Processing Time"
            Me.statusNoThread.Width = 140
            '
            'statusTime
            '
            Me.statusTime.Alignment = System.Windows.Forms.HorizontalAlignment.Center
            Me.statusTime.Name = "statusTime"
            Me.statusTime.ToolTipText = "Processing Time"
            Me.statusTime.Width = 140
            '
            'panel1
            '
            Me.panel1.Controls.Add(Me.propertyGrid1)
            Me.panel1.Controls.Add(Me.panel2)
            Me.panel1.Dock = System.Windows.Forms.DockStyle.Right
            Me.panel1.Location = New System.Drawing.Point(592, 0)
            Me.panel1.Name = "panel1"
            Me.panel1.Size = New System.Drawing.Size(216, 467)
            Me.panel1.TabIndex = 1
            Me.panel1.Text = "panel1"
            '
            'propertyGrid1
            '
            Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
            Me.propertyGrid1.Location = New System.Drawing.Point(0, 224)
            Me.propertyGrid1.Name = "propertyGrid1"
            Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
            Me.propertyGrid1.Size = New System.Drawing.Size(216, 243)
            Me.propertyGrid1.TabIndex = 0
            Me.propertyGrid1.ToolbarVisible = False
            '
            'panel2
            '
            Me.panel2.Controls.Add(Me.groupBox1)
            Me.panel2.Controls.Add(Me.btnApply)
            Me.panel2.Controls.Add(Me.cboCommand)
            Me.panel2.Controls.Add(Me.label1)
            Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.panel2.Location = New System.Drawing.Point(0, 0)
            Me.panel2.Name = "panel2"
            Me.panel2.Size = New System.Drawing.Size(216, 224)
            Me.panel2.TabIndex = 1
            '
            'groupBox1
            '
            Me.groupBox1.Controls.Add(Me.numIterations)
            Me.groupBox1.Controls.Add(Me.label4)
            Me.groupBox1.Controls.Add(Me.numSectionHeight)
            Me.groupBox1.Controls.Add(Me.label3)
            Me.groupBox1.Controls.Add(Me.numThreads)
            Me.groupBox1.Controls.Add(Me.label2)
            Me.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.groupBox1.Location = New System.Drawing.Point(16, 60)
            Me.groupBox1.Name = "groupBox1"
            Me.groupBox1.Size = New System.Drawing.Size(184, 115)
            Me.groupBox1.TabIndex = 2
            Me.groupBox1.TabStop = False
            '
            'numIterations
            '
            Me.numIterations.Location = New System.Drawing.Point(96, 80)
            Me.numIterations.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numIterations.Name = "numIterations"
            Me.numIterations.Size = New System.Drawing.Size(72, 20)
            Me.numIterations.TabIndex = 5
            Me.numIterations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.numIterations.Value = New Decimal(New Integer() {1, 0, 0, 0})
            '
            'label4
            '
            Me.label4.Location = New System.Drawing.Point(8, 82)
            Me.label4.Name = "label4"
            Me.label4.Size = New System.Drawing.Size(63, 17)
            Me.label4.TabIndex = 4
            Me.label4.Text = "Iterations:"
            '
            'numSectionHeight
            '
            Me.numSectionHeight.Increment = New Decimal(New Integer() {10, 0, 0, 0})
            Me.numSectionHeight.Location = New System.Drawing.Point(96, 50)
            Me.numSectionHeight.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
            Me.numSectionHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
            Me.numSectionHeight.Name = "numSectionHeight"
            Me.numSectionHeight.Size = New System.Drawing.Size(72, 20)
            Me.numSectionHeight.TabIndex = 3
            Me.numSectionHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.numSectionHeight.Value = New Decimal(New Integer() {200, 0, 0, 0})
            '
            'label3
            '
            Me.label3.Location = New System.Drawing.Point(8, 52)
            Me.label3.Name = "label3"
            Me.label3.Size = New System.Drawing.Size(88, 16)
            Me.label3.TabIndex = 2
            Me.label3.Text = "Section Height:"
            '
            'numThreads
            '
            Me.numThreads.Increment = New Decimal(New Integer() {2, 0, 0, 0})
            Me.numThreads.Location = New System.Drawing.Point(96, 20)
            Me.numThreads.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
            Me.numThreads.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
            Me.numThreads.Name = "numThreads"
            Me.numThreads.Size = New System.Drawing.Size(72, 20)
            Me.numThreads.TabIndex = 1
            Me.numThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
            Me.numThreads.Value = New Decimal(New Integer() {4, 0, 0, 0})
            '
            'label2
            '
            Me.label2.Location = New System.Drawing.Point(8, 22)
            Me.label2.Name = "label2"
            Me.label2.Size = New System.Drawing.Size(56, 16)
            Me.label2.TabIndex = 0
            Me.label2.Text = "Threads:"
            '
            'btnApply
            '
            Me.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnApply.Location = New System.Drawing.Point(16, 186)
            Me.btnApply.Name = "btnApply"
            Me.btnApply.Size = New System.Drawing.Size(184, 24)
            Me.btnApply.TabIndex = 3
            Me.btnApply.Text = "Apply Command"
            '
            'cboCommand
            '
            Me.cboCommand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cboCommand.Location = New System.Drawing.Point(16, 32)
            Me.cboCommand.Name = "cboCommand"
            Me.cboCommand.Size = New System.Drawing.Size(184, 21)
            Me.cboCommand.TabIndex = 1
            '
            'label1
            '
            Me.label1.Location = New System.Drawing.Point(16, 16)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(64, 16)
            Me.label1.TabIndex = 0
            Me.label1.Text = "Command:"
            '
            'splitter1
            '
            Me.splitter1.Dock = System.Windows.Forms.DockStyle.Right
            Me.splitter1.Location = New System.Drawing.Point(586, 0)
            Me.splitter1.Name = "splitter1"
            Me.splitter1.Size = New System.Drawing.Size(6, 467)
            Me.splitter1.TabIndex = 2
            Me.splitter1.TabStop = False
            '
            'workspaceViewer1
            '
            Me.workspaceViewer1.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ScaleToGray
            Me.workspaceViewer1.AutoDispose = False
            Me.workspaceViewer1.Centered = True
            Me.workspaceViewer1.DisplayProfile = Nothing
            Me.workspaceViewer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.workspaceViewer1.Location = New System.Drawing.Point(0, 0)
            Me.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White
            Me.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.workspaceViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.workspaceViewer1.Name = "workspaceViewer1"
            Me.workspaceViewer1.OutputProfile = Nothing
            Me.workspaceViewer1.Selection = Nothing
            Me.workspaceViewer1.Size = New System.Drawing.Size(586, 467)
            Me.workspaceViewer1.TabIndex = 0
            Me.workspaceViewer1.Text = "workspaceViewer1"
            '
            'Form1
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(808, 489)
            Me.Controls.Add(Me.workspaceViewer1)
            Me.Controls.Add(Me.splitter1)
            Me.Controls.Add(Me.panel1)
            Me.Controls.Add(Me.statusBar1)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Menu = Me.mainMenu1
            Me.MinimumSize = New System.Drawing.Size(632, 477)
            Me.Name = "Form1"
            Me.Text = "Atalasoft ThreadedCommand Demo"
            CType(Me.statusFile, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusCpus, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusNoThread, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.statusTime, System.ComponentModel.ISupportInitialize).EndInit()
            Me.panel1.ResumeLayout(False)
            Me.panel2.ResumeLayout(False)
            Me.groupBox1.ResumeLayout(False)
            CType(Me.numIterations, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numSectionHeight, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.numThreads, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Shared Sub Main()
            Application.EnableVisualStyles()
            Application.DoEvents()
            Application.Run(New Form1())
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Load all treaded commands into the combo box.
            Dim asm As System.Reflection.Assembly = System.Reflection.Assembly.LoadWithPartialName("Atalasoft.dotImage")
            If asm Is Nothing Then
                Return
            End If

            Dim types As Type() = asm.GetTypes()
            For Each t As Type In types
                If Not t.GetInterface("IThreadableCommand", False) Is Nothing Then
                    Me.cboCommand.Items.Add(New ThreadedCommandHolder(CType(asm.CreateInstance(t.FullName), ImageCommand)))
                End If
            Next t

            If Me.cboCommand.Items.Count > 0 Then
                Me.cboCommand.SelectedIndex = 0
            End If

            Dim cpuCount As String = System.Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS")
            Me.statusCpus.Text = "CPU Count: " & cpuCount

            ' For best results use twice the number of threads as CPUs.
            Me.numThreads.Value = Int32.Parse(cpuCount) * 2
        End Sub

        Private Sub cboCommand_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCommand.SelectedIndexChanged
            Me.propertyGrid1.SelectedObject = (CType(Me.cboCommand.SelectedItem, ThreadedCommandHolder)).Command
        End Sub

        Private Sub btnApply_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApply.Click
            If Me.workspaceViewer1.Image Is Nothing Then
                MessageBox.Show(Me, "An image must be loaded before applying a command.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            Dim holder As ThreadedCommandHolder = CType(IIf(TypeOf Me.cboCommand.SelectedItem Is ThreadedCommandHolder, Me.cboCommand.SelectedItem, Nothing), ThreadedCommandHolder)
            If holder Is Nothing Then
                Return
            End If

            Me.btnApply.Enabled = False
            Me.cboCommand.Enabled = False
            Me.propertyGrid1.Enabled = False
            Me.menuFile.Enabled = False
            Me.statusTime.Text = ""
            Me.statusNoThread.Text = ""
            Me.Cursor = Cursors.WaitCursor

            Try
                ' Process without threading.
                Dim time As Integer = TestCommand(holder.Command)
                Me.statusNoThread.Text = "Non-Threaded: " & time.ToString() & "ms"

                ' Process threaded.

                Dim subThread As New Global.System.Threading.Thread(AddressOf RunThreadedTest)

                subThread.Start(holder)

            Catch ex As System.Exception
                MessageBox.Show(Me, ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
                Me.btnApply.Enabled = True
                Me.cboCommand.Enabled = True
                Me.propertyGrid1.Enabled = True
                Me.menuFile.Enabled = True
            End Try
        End Sub

        Private Sub RunThreadedTest(ByVal holder As ThreadedCommandHolder)
            Dim tc As ThreadedCommand = New ThreadedCommand(holder.Command, Convert.ToInt32(Me.numThreads.Value))
            tc.StripSize = Convert.ToInt32(Me.numSectionHeight.Value)

            Dim time As Integer = TestCommand(tc)
            Me.BeginInvoke(New UpdateThreadedTimeDelegate(AddressOf UpdateThreadedTime), time)
        End Sub

        Delegate Sub UpdateThreadedTimeDelegate(ByVal time As Integer)
        Delegate Sub PopErrorMessageDelegate(ByRef message As String)

        Private Sub UpdateThreadedTime(ByVal time As Integer)
            Me.statusTime.Text = "Threaded: " & time.ToString() & "ms"
        End Sub

        Private Sub PopErrorMessage(ByVal message As String)
            MessageBox.Show(Me, message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Sub

        Private Function TestCommand(ByVal command As ImageCommand) As Integer
            Try
                If Me._originalImage Is Nothing Then
                    Return 0
                End If

                ' We don't want to modify the original image.
                Dim image As AtalaImage = Me._originalImage
                If command.InPlaceProcessing Then
                    image = CType(Me._originalImage.Clone(), AtalaImage)
                End If

                Dim iterations As Integer = Convert.ToInt32(Me.numIterations.Value)

                Dim t1 As Integer = System.Environment.TickCount
                Dim results As ImageResults = Nothing
                For i As Integer = 0 To iterations - 1
                    If Not results Is Nothing AndAlso (Not results.IsImageSourceImage) AndAlso Not results.Image Is Nothing Then
                        results.Image.Dispose()
                    End If
                    results = command.Apply(image)
                Next i
                Dim t2 As Integer = System.Environment.TickCount

                ' Dispose the image being viewed if it's not the original.
                If Not Me.workspaceViewer1.Image Is Me._originalImage Then
                    Me.workspaceViewer1.Image.Dispose()
                End If

                Me.workspaceViewer1.Image = results.Image

                Return (t2 - t1) / iterations
            Catch ex As System.Exception
                Me.BeginInvoke(New UpdateThreadedTimeDelegate(AddressOf PopErrorMessage), ex.Message)
            End Try

            Return 0
        End Function

#Region "File Menu"

        Private Sub menuOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuOpen.Click
            'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
            '			using (OpenFileDialog dlg = New OpenFileDialog())
            Dim dlg As OpenFileDialog = New OpenFileDialog()
            Try
                ' try to locate images folder
                Dim imagesFolder As String = Application.ExecutablePath
                ' we assume we are running under the DotImage install folder
                Dim pos As Integer = imagesFolder.IndexOf("DotImage ")
                If pos <> -1 Then
                    imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf("\", pos)) & "\Images\Documents"
                End If

                'use this folder as starting point			
                dlg.InitialDirectory = imagesFolder

                dlg.Filter = HelperMethods.CreateDialogFilter(True)

                If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                    Me.Cursor = Cursors.WaitCursor
                    Me.btnApply.Enabled = False
                    Try
                        If Not Me._originalImage Is Nothing Then
                            Me._originalImage.Dispose()
                        End If
                        Me._originalImage = New AtalaImage(dlg.FileName, 0, Nothing)

                        Me.workspaceViewer1.Image = Me._originalImage

                        Me.statusFile.Text = dlg.FileName
                        Me.statusFile.ToolTipText = dlg.FileName
                        Me.statusNoThread.Text = ""
                        Me.statusTime.Text = ""
                    Catch ex As System.Exception
                        MessageBox.Show(Me, ex.Message, "Load Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Finally
                        Me.Cursor = Cursors.Default
                        Me.btnApply.Enabled = True
                    End Try
                End If
            Finally
                CType(dlg, IDisposable).Dispose()
            End Try
            'INSTANT VB NOTE: End of the original C# 'using' block
        End Sub

        Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExit.Click
            Me.Close()
        End Sub

#End Region

        Private Sub MenuAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
            Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About Atalasoft Threaded Command Demo", "Threaded Command Demo")
            aboutBox.Description = "Some of our most CPU-Intensive image processing commands implement an IThreadableCommand interface to allow them to be run multi-threaded." & vbCrLf & vbCrLf & _
                                   "This demo allows the user to test our various IThreadableCommand Image processing commands and alter the number of threads and certain other parameters. It can be used to test for optimal performance for a given command/document combination, or the source code can be examined to provide an excellent example of how to properly implement one of our threadable commands."
            aboutBox.ShowDialog()
        End Sub
    End Class

    Public Class ThreadedCommandHolder
        Private _command As ImageCommand
        Private _name As String = ""

        Public Sub New(ByVal command As ImageCommand)
            _command = command
            _name = command.GetType().Name
        End Sub

        Public ReadOnly Property Command() As ImageCommand
            Get
                Return Me._command
            End Get
        End Property

        Public Overrides Function ToString() As String
            Return Me._name
        End Function

    End Class
End Namespace
