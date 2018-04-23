Namespace SchedulerSyncCustomFields
    Partial Public Class Form1
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
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.dataSet11 = New SchedulerSyncCustomFields.DataSet1()
            Me.btnImport = New System.Windows.Forms.Button()
            Me.btnExport = New System.Windows.Forms.Button()
            Me.cbOutlookCalendars = New System.Windows.Forms.ComboBox()
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.dataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.schedulerControl1.Location = New System.Drawing.Point(16, 15)
            Me.schedulerControl1.Margin = New System.Windows.Forms.Padding(4)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(819, 419)
            Me.schedulerControl1.Start = New Date(2008, 9, 4, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.Appointments.CustomFieldMappings.Add(New DevExpress.XtraScheduler.AppointmentCustomFieldMapping("ContactInfo", "ContactInfo"))
            Me.schedulerStorage1.Appointments.DataMember = "Events"
            Me.schedulerStorage1.Appointments.DataSource = Me.dataSet11
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.End = "EndTime"
            Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo"
            Me.schedulerStorage1.Appointments.Mappings.Start = "StartTime"
            Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerStorage1.Appointments.Mappings.Type = "Type"
            ' 
            ' dataSet11
            ' 
            Me.dataSet11.DataSetName = "DataSet1"
            Me.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' btnImport
            ' 
            Me.btnImport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.btnImport.Location = New System.Drawing.Point(287, 451)
            Me.btnImport.Name = "btnImport"
            Me.btnImport.Size = New System.Drawing.Size(100, 25)
            Me.btnImport.TabIndex = 1
            Me.btnImport.Text = "Import"
            Me.btnImport.UseVisualStyleBackColor = True
            ' 
            ' btnExport
            ' 
            Me.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom
            Me.btnExport.Location = New System.Drawing.Point(463, 451)
            Me.btnExport.Name = "btnExport"
            Me.btnExport.Size = New System.Drawing.Size(100, 25)
            Me.btnExport.TabIndex = 2
            Me.btnExport.Text = "Export"
            Me.btnExport.UseVisualStyleBackColor = True
            ' 
            ' cbOutlookCalendars
            ' 
            Me.cbOutlookCalendars.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
            Me.cbOutlookCalendars.FormattingEnabled = True
            Me.cbOutlookCalendars.Location = New System.Drawing.Point(16, 452)
            Me.cbOutlookCalendars.Name = "cbOutlookCalendars"
            Me.cbOutlookCalendars.Size = New System.Drawing.Size(208, 24)
            Me.cbOutlookCalendars.TabIndex = 3
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8F, 16F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(851, 486)
            Me.Controls.Add(Me.cbOutlookCalendars)
            Me.Controls.Add(Me.btnExport)
            Me.Controls.Add(Me.btnImport)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.Name = "Form1"
            Me.Text = "Form1"
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.dataSet11, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private WithEvents schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage
        Private dataSet11 As DataSet1
        Private WithEvents btnImport As System.Windows.Forms.Button
        Private WithEvents btnExport As System.Windows.Forms.Button
        Private cbOutlookCalendars As System.Windows.Forms.ComboBox
    End Class
End Namespace

