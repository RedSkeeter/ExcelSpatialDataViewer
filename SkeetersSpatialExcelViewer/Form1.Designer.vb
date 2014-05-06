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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.SpatialToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.WorksheetToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.LatColumnToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.LonColumnToolStripComboBox = New System.Windows.Forms.ToolStripComboBox()
        Me.ToggleLongitudeEastWestToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.MapItToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.OpenDataSourceToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.DataGridView = New System.Windows.Forms.DataGridView()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ImportedDataTabControl = New System.Windows.Forms.TabControl()
        Me.ImportedDataTabPage = New System.Windows.Forms.TabPage()
        Me.LogTabPage = New System.Windows.Forms.TabPage()
        Me.LogTextBox = New System.Windows.Forms.TextBox()
        Me.MetadataTabPage = New System.Windows.Forms.TabPage()
        Me.ImportedDataMetadataTextBox = New System.Windows.Forms.TextBox()
        Me.SourceTextTabPage = New System.Windows.Forms.TabPage()
        Me.SourceTextBox = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Legend = New DotSpatial.Controls.Legend()
        Me.Map = New DotSpatial.Controls.Map()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.PointsFeatureSetDataGridView = New System.Windows.Forms.DataGridView()
        Me.MapToolStrip = New System.Windows.Forms.ToolStrip()
        Me.AddShapefileToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ZoominToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ZoomOutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.PanToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ZoomPreviousToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ZoomToFullExtentToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExportSnapshotToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ImportPointToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenExcelWorkbookToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreferencesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportDBFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportCSVToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.DataSourceToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.SpatialToolStrip.SuspendLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ImportedDataTabControl.SuspendLayout()
        Me.ImportedDataTabPage.SuspendLayout()
        Me.LogTabPage.SuspendLayout()
        Me.MetadataTabPage.SuspendLayout()
        Me.SourceTextTabPage.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.PointsFeatureSetDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MapToolStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SpatialToolStrip
        '
        Me.SpatialToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabel3, Me.WorksheetToolStripComboBox, Me.ToolStripLabel1, Me.LatColumnToolStripComboBox, Me.ToolStripLabel2, Me.LonColumnToolStripComboBox, Me.ToggleLongitudeEastWestToolStripButton, Me.MapItToolStripButton, Me.ToolStripSeparator1, Me.OpenDataSourceToolStripButton})
        Me.SpatialToolStrip.Location = New System.Drawing.Point(0, 24)
        Me.SpatialToolStrip.Name = "SpatialToolStrip"
        Me.SpatialToolStrip.Size = New System.Drawing.Size(1008, 25)
        Me.SpatialToolStrip.TabIndex = 0
        Me.SpatialToolStrip.Text = "ToolStrip1"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(66, 22)
        Me.ToolStripLabel3.Text = "Worksheet:"
        '
        'WorksheetToolStripComboBox
        '
        Me.WorksheetToolStripComboBox.Name = "WorksheetToolStripComboBox"
        Me.WorksheetToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(97, 22)
        Me.ToolStripLabel1.Text = "Latitude column:"
        '
        'LatColumnToolStripComboBox
        '
        Me.LatColumnToolStripComboBox.Name = "LatColumnToolStripComboBox"
        Me.LatColumnToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(108, 22)
        Me.ToolStripLabel2.Text = "Longitude column:"
        '
        'LonColumnToolStripComboBox
        '
        Me.LonColumnToolStripComboBox.Name = "LonColumnToolStripComboBox"
        Me.LonColumnToolStripComboBox.Size = New System.Drawing.Size(121, 25)
        '
        'ToggleLongitudeEastWestToolStripButton
        '
        Me.ToggleLongitudeEastWestToolStripButton.Image = CType(resources.GetObject("ToggleLongitudeEastWestToolStripButton.Image"), System.Drawing.Image)
        Me.ToggleLongitudeEastWestToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToggleLongitudeEastWestToolStripButton.Name = "ToggleLongitudeEastWestToolStripButton"
        Me.ToggleLongitudeEastWestToolStripButton.Size = New System.Drawing.Size(121, 22)
        Me.ToggleLongitudeEastWestToolStripButton.Text = "Reverse longitude"
        Me.ToggleLongitudeEastWestToolStripButton.ToolTipText = "Reverse longitude (sometimes longitudes are reported as East/West and need to be " & _
    "hemispherically reversed)"
        '
        'MapItToolStripButton
        '
        Me.MapItToolStripButton.Enabled = False
        Me.MapItToolStripButton.Image = CType(resources.GetObject("MapItToolStripButton.Image"), System.Drawing.Image)
        Me.MapItToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MapItToolStripButton.Name = "MapItToolStripButton"
        Me.MapItToolStripButton.Size = New System.Drawing.Size(61, 22)
        Me.MapItToolStripButton.Text = "Map it"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'OpenDataSourceToolStripButton
        '
        Me.OpenDataSourceToolStripButton.Enabled = False
        Me.OpenDataSourceToolStripButton.Image = CType(resources.GetObject("OpenDataSourceToolStripButton.Image"), System.Drawing.Image)
        Me.OpenDataSourceToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.OpenDataSourceToolStripButton.Name = "OpenDataSourceToolStripButton"
        Me.OpenDataSourceToolStripButton.Size = New System.Drawing.Size(120, 22)
        Me.OpenDataSourceToolStripButton.Text = "Open data source"
        '
        'DataGridView
        '
        Me.DataGridView.AllowDrop = True
        Me.DataGridView.AllowUserToAddRows = False
        Me.DataGridView.AllowUserToDeleteRows = False
        Me.DataGridView.AllowUserToOrderColumns = True
        Me.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView.Name = "DataGridView"
        Me.DataGridView.ReadOnly = True
        Me.DataGridView.Size = New System.Drawing.Size(490, 627)
        Me.DataGridView.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ImportedDataTabControl)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.MapToolStrip)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 659)
        Me.SplitContainer1.SplitterDistance = 504
        Me.SplitContainer1.TabIndex = 1
        '
        'ImportedDataTabControl
        '
        Me.ImportedDataTabControl.Controls.Add(Me.ImportedDataTabPage)
        Me.ImportedDataTabControl.Controls.Add(Me.LogTabPage)
        Me.ImportedDataTabControl.Controls.Add(Me.MetadataTabPage)
        Me.ImportedDataTabControl.Controls.Add(Me.SourceTextTabPage)
        Me.ImportedDataTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportedDataTabControl.Location = New System.Drawing.Point(0, 0)
        Me.ImportedDataTabControl.Name = "ImportedDataTabControl"
        Me.ImportedDataTabControl.SelectedIndex = 0
        Me.ImportedDataTabControl.Size = New System.Drawing.Size(504, 659)
        Me.ImportedDataTabControl.TabIndex = 3
        '
        'ImportedDataTabPage
        '
        Me.ImportedDataTabPage.Controls.Add(Me.DataGridView)
        Me.ImportedDataTabPage.Location = New System.Drawing.Point(4, 22)
        Me.ImportedDataTabPage.Name = "ImportedDataTabPage"
        Me.ImportedDataTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.ImportedDataTabPage.Size = New System.Drawing.Size(496, 633)
        Me.ImportedDataTabPage.TabIndex = 0
        Me.ImportedDataTabPage.Text = "Imported data"
        Me.ImportedDataTabPage.UseVisualStyleBackColor = True
        '
        'LogTabPage
        '
        Me.LogTabPage.Controls.Add(Me.LogTextBox)
        Me.LogTabPage.Location = New System.Drawing.Point(4, 22)
        Me.LogTabPage.Name = "LogTabPage"
        Me.LogTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.LogTabPage.Size = New System.Drawing.Size(496, 633)
        Me.LogTabPage.TabIndex = 1
        Me.LogTabPage.Text = "Log"
        Me.LogTabPage.UseVisualStyleBackColor = True
        '
        'LogTextBox
        '
        Me.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LogTextBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LogTextBox.Location = New System.Drawing.Point(3, 3)
        Me.LogTextBox.Multiline = True
        Me.LogTextBox.Name = "LogTextBox"
        Me.LogTextBox.Size = New System.Drawing.Size(490, 627)
        Me.LogTextBox.TabIndex = 0
        '
        'MetadataTabPage
        '
        Me.MetadataTabPage.Controls.Add(Me.ImportedDataMetadataTextBox)
        Me.MetadataTabPage.Location = New System.Drawing.Point(4, 22)
        Me.MetadataTabPage.Name = "MetadataTabPage"
        Me.MetadataTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.MetadataTabPage.Size = New System.Drawing.Size(496, 633)
        Me.MetadataTabPage.TabIndex = 2
        Me.MetadataTabPage.Text = "Metadata"
        Me.MetadataTabPage.UseVisualStyleBackColor = True
        '
        'ImportedDataMetadataTextBox
        '
        Me.ImportedDataMetadataTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportedDataMetadataTextBox.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportedDataMetadataTextBox.Location = New System.Drawing.Point(3, 3)
        Me.ImportedDataMetadataTextBox.Multiline = True
        Me.ImportedDataMetadataTextBox.Name = "ImportedDataMetadataTextBox"
        Me.ImportedDataMetadataTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.ImportedDataMetadataTextBox.Size = New System.Drawing.Size(490, 627)
        Me.ImportedDataMetadataTextBox.TabIndex = 0
        '
        'SourceTextTabPage
        '
        Me.SourceTextTabPage.Controls.Add(Me.SourceTextBox)
        Me.SourceTextTabPage.Location = New System.Drawing.Point(4, 22)
        Me.SourceTextTabPage.Name = "SourceTextTabPage"
        Me.SourceTextTabPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SourceTextTabPage.Size = New System.Drawing.Size(496, 633)
        Me.SourceTextTabPage.TabIndex = 3
        Me.SourceTextTabPage.Text = "Source"
        Me.SourceTextTabPage.UseVisualStyleBackColor = True
        '
        'SourceTextBox
        '
        Me.SourceTextBox.AllowDrop = True
        Me.SourceTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SourceTextBox.Location = New System.Drawing.Point(3, 3)
        Me.SourceTextBox.Multiline = True
        Me.SourceTextBox.Name = "SourceTextBox"
        Me.SourceTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.SourceTextBox.Size = New System.Drawing.Size(490, 627)
        Me.SourceTextBox.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(500, 634)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(492, 608)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Map"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Legend)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.Map)
        Me.SplitContainer2.Size = New System.Drawing.Size(486, 602)
        Me.SplitContainer2.SplitterDistance = 113
        Me.SplitContainer2.TabIndex = 3
        '
        'Legend
        '
        Me.Legend.BackColor = System.Drawing.Color.White
        Me.Legend.ControlRectangle = New System.Drawing.Rectangle(0, 0, 113, 602)
        Me.Legend.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Legend.DocumentRectangle = New System.Drawing.Rectangle(0, 0, 187, 428)
        Me.Legend.HorizontalScrollEnabled = True
        Me.Legend.Indentation = 30
        Me.Legend.IsInitialized = False
        Me.Legend.Location = New System.Drawing.Point(0, 0)
        Me.Legend.MinimumSize = New System.Drawing.Size(5, 5)
        Me.Legend.Name = "Legend"
        Me.Legend.ProgressHandler = Nothing
        Me.Legend.ResetOnResize = False
        Me.Legend.SelectionFontColor = System.Drawing.Color.Black
        Me.Legend.SelectionHighlight = System.Drawing.Color.FromArgb(CType(CType(215, Byte), Integer), CType(CType(238, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Legend.Size = New System.Drawing.Size(113, 602)
        Me.Legend.TabIndex = 2
        Me.Legend.Text = "Legend"
        Me.Legend.VerticalScrollEnabled = True
        '
        'Map
        '
        Me.Map.AllowDrop = True
        Me.Map.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Map.CollectAfterDraw = False
        Me.Map.CollisionDetection = False
        Me.Map.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Map.ExtendBuffer = False
        Me.Map.FunctionMode = DotSpatial.Controls.FunctionMode.None
        Me.Map.IsBusy = False
        Me.Map.IsZoomedToMaxExtent = False
        Me.Map.Legend = Me.Legend
        Me.Map.Location = New System.Drawing.Point(0, 0)
        Me.Map.Name = "Map"
        Me.Map.ProgressHandler = Nothing
        Me.Map.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt
        Me.Map.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt
        Me.Map.RedrawLayersWhileResizing = False
        Me.Map.SelectionEnabled = True
        Me.Map.Size = New System.Drawing.Size(369, 602)
        Me.Map.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PointsFeatureSetDataGridView)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(492, 608)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Featureset data table"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PointsFeatureSetDataGridView
        '
        Me.PointsFeatureSetDataGridView.AllowUserToAddRows = False
        Me.PointsFeatureSetDataGridView.AllowUserToDeleteRows = False
        Me.PointsFeatureSetDataGridView.AllowUserToOrderColumns = True
        Me.PointsFeatureSetDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.PointsFeatureSetDataGridView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PointsFeatureSetDataGridView.Location = New System.Drawing.Point(3, 3)
        Me.PointsFeatureSetDataGridView.Name = "PointsFeatureSetDataGridView"
        Me.PointsFeatureSetDataGridView.ReadOnly = True
        Me.PointsFeatureSetDataGridView.Size = New System.Drawing.Size(486, 602)
        Me.PointsFeatureSetDataGridView.TabIndex = 0
        '
        'MapToolStrip
        '
        Me.MapToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddShapefileToolStripButton, Me.ZoominToolStripButton, Me.ZoomOutToolStripButton, Me.PanToolStripButton, Me.ZoomPreviousToolStripButton, Me.ZoomToFullExtentToolStripButton, Me.ToolStripSeparator2, Me.ExportSnapshotToolStripButton, Me.ImportPointToolStripButton, Me.ToolStripButton1})
        Me.MapToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.MapToolStrip.Name = "MapToolStrip"
        Me.MapToolStrip.Size = New System.Drawing.Size(500, 25)
        Me.MapToolStrip.TabIndex = 2
        Me.MapToolStrip.Text = "ToolStrip1"
        '
        'AddShapefileToolStripButton
        '
        Me.AddShapefileToolStripButton.Image = CType(resources.GetObject("AddShapefileToolStripButton.Image"), System.Drawing.Image)
        Me.AddShapefileToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.AddShapefileToolStripButton.Name = "AddShapefileToolStripButton"
        Me.AddShapefileToolStripButton.Size = New System.Drawing.Size(108, 22)
        Me.AddShapefileToolStripButton.Text = "Add shapefile..."
        '
        'ZoominToolStripButton
        '
        Me.ZoominToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoominToolStripButton.Image = CType(resources.GetObject("ZoominToolStripButton.Image"), System.Drawing.Image)
        Me.ZoominToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoominToolStripButton.Name = "ZoominToolStripButton"
        Me.ZoominToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoominToolStripButton.Text = "+"
        '
        'ZoomOutToolStripButton
        '
        Me.ZoomOutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomOutToolStripButton.Image = CType(resources.GetObject("ZoomOutToolStripButton.Image"), System.Drawing.Image)
        Me.ZoomOutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomOutToolStripButton.Name = "ZoomOutToolStripButton"
        Me.ZoomOutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoomOutToolStripButton.Text = "-"
        '
        'PanToolStripButton
        '
        Me.PanToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PanToolStripButton.Image = CType(resources.GetObject("PanToolStripButton.Image"), System.Drawing.Image)
        Me.PanToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PanToolStripButton.Name = "PanToolStripButton"
        Me.PanToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PanToolStripButton.Text = "Pan"
        '
        'ZoomPreviousToolStripButton
        '
        Me.ZoomPreviousToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomPreviousToolStripButton.Image = CType(resources.GetObject("ZoomPreviousToolStripButton.Image"), System.Drawing.Image)
        Me.ZoomPreviousToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomPreviousToolStripButton.Name = "ZoomPreviousToolStripButton"
        Me.ZoomPreviousToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoomPreviousToolStripButton.Text = "Zoom previous"
        '
        'ZoomToFullExtentToolStripButton
        '
        Me.ZoomToFullExtentToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ZoomToFullExtentToolStripButton.Image = CType(resources.GetObject("ZoomToFullExtentToolStripButton.Image"), System.Drawing.Image)
        Me.ZoomToFullExtentToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ZoomToFullExtentToolStripButton.Name = "ZoomToFullExtentToolStripButton"
        Me.ZoomToFullExtentToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ZoomToFullExtentToolStripButton.Text = "Zoom to full extent"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ExportSnapshotToolStripButton
        '
        Me.ExportSnapshotToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ExportSnapshotToolStripButton.Image = CType(resources.GetObject("ExportSnapshotToolStripButton.Image"), System.Drawing.Image)
        Me.ExportSnapshotToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ExportSnapshotToolStripButton.Name = "ExportSnapshotToolStripButton"
        Me.ExportSnapshotToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.ExportSnapshotToolStripButton.Text = "Export snapshot..."
        Me.ExportSnapshotToolStripButton.ToolTipText = "Export a snapshot of the map"
        '
        'ImportPointToolStripButton
        '
        Me.ImportPointToolStripButton.Image = CType(resources.GetObject("ImportPointToolStripButton.Image"), System.Drawing.Image)
        Me.ImportPointToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ImportPointToolStripButton.Name = "ImportPointToolStripButton"
        Me.ImportPointToolStripButton.Size = New System.Drawing.Size(94, 22)
        Me.ImportPointToolStripButton.Text = "Import point"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1008, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenExcelWorkbookToolStripMenuItem, Me.PreferencesToolStripMenuItem, Me.CloseToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ImportDBFToolStripMenuItem, Me.ImportCSVToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'OpenExcelWorkbookToolStripMenuItem
        '
        Me.OpenExcelWorkbookToolStripMenuItem.Image = CType(resources.GetObject("OpenExcelWorkbookToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OpenExcelWorkbookToolStripMenuItem.Name = "OpenExcelWorkbookToolStripMenuItem"
        Me.OpenExcelWorkbookToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.OpenExcelWorkbookToolStripMenuItem.Text = "Import Excel workbook..."
        '
        'PreferencesToolStripMenuItem
        '
        Me.PreferencesToolStripMenuItem.Image = CType(resources.GetObject("PreferencesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.PreferencesToolStripMenuItem.Name = "PreferencesToolStripMenuItem"
        Me.PreferencesToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.PreferencesToolStripMenuItem.Text = "Preferences..."
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Image = CType(resources.GetObject("CloseToolStripMenuItem.Image"), System.Drawing.Image)
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.CloseToolStripMenuItem.Text = "Close "
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'ImportDBFToolStripMenuItem
        '
        Me.ImportDBFToolStripMenuItem.Image = CType(resources.GetObject("ImportDBFToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImportDBFToolStripMenuItem.Name = "ImportDBFToolStripMenuItem"
        Me.ImportDBFToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImportDBFToolStripMenuItem.Text = "Import DBF"
        '
        'ImportCSVToolStripMenuItem
        '
        Me.ImportCSVToolStripMenuItem.Name = "ImportCSVToolStripMenuItem"
        Me.ImportCSVToolStripMenuItem.Size = New System.Drawing.Size(204, 22)
        Me.ImportCSVToolStripMenuItem.Text = "Import CSV"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DataSourceToolStripStatusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 708)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1008, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'DataSourceToolStripStatusLabel
        '
        Me.DataSourceToolStripStatusLabel.Enabled = False
        Me.DataSourceToolStripStatusLabel.Name = "DataSourceToolStripStatusLabel"
        Me.DataSourceToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.DataSourceToolStripStatusLabel.Text = "Ready"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SpatialToolStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Skeeter's Spatial Data Explorer"
        Me.SpatialToolStrip.ResumeLayout(False)
        Me.SpatialToolStrip.PerformLayout()
        CType(Me.DataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ImportedDataTabControl.ResumeLayout(False)
        Me.ImportedDataTabPage.ResumeLayout(False)
        Me.LogTabPage.ResumeLayout(False)
        Me.LogTabPage.PerformLayout()
        Me.MetadataTabPage.ResumeLayout(False)
        Me.MetadataTabPage.PerformLayout()
        Me.SourceTextTabPage.ResumeLayout(False)
        Me.SourceTextTabPage.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.PointsFeatureSetDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MapToolStrip.ResumeLayout(False)
        Me.MapToolStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents SpatialToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LatColumnToolStripComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents LonColumnToolStripComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents MapItToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Map As DotSpatial.Controls.Map
    Friend WithEvents MapToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents AddShapefileToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ZoominToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ZoomOutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents PanToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents Legend As DotSpatial.Controls.Legend
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenExcelWorkbookToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PointsFeatureSetDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents ImportedDataTabControl As System.Windows.Forms.TabControl
    Friend WithEvents ImportedDataTabPage As System.Windows.Forms.TabPage
    Friend WithEvents LogTabPage As System.Windows.Forms.TabPage
    Friend WithEvents LogTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PreferencesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents DataSourceToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OpenDataSourceToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExportSnapshotToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImportDBFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents WorksheetToolStripComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToggleLongitudeEastWestToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ImportPointToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ImportCSVToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MetadataTabPage As System.Windows.Forms.TabPage
    Friend WithEvents ImportedDataMetadataTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ZoomPreviousToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents ZoomToFullExtentToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SourceTextTabPage As System.Windows.Forms.TabPage
    Friend WithEvents SourceTextBox As System.Windows.Forms.TextBox

End Class
