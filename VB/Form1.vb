Imports System
Imports System.Collections
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Exchange
Imports DevExpress.XtraScheduler.Outlook
Imports DevExpress.XtraScheduler.Outlook.Interop
Imports OutlookInterop = Microsoft.Office.Interop.Outlook

Namespace SchedulerSyncCustomFields
    Partial Public Class Form1
        Inherits Form

        Public Const OutlookUserPropertyName As String = "ContactInfo"

        Public Sub New()
            InitializeComponent()

            cbOutlookCalendars.DataSource = OutlookExchangeHelper.GetOutlookCalendarPaths()

            Dim row As SchedulerSyncCustomFields.DataSet1.EventsRow = dataSet11.Events.NewEventsRow()

            Dim baseTime As Date = Date.Today
            row.StartTime = baseTime.AddHours(1)
            row.EndTime = baseTime.AddHours(2)
            row.Subject = "Test"
            row.Description = "Test procedure"
            row.ContactInfo = "Test contact info"

            dataSet11.Events.AddEventsRow(row)

            schedulerControl1.Start = baseTime
        End Sub

        Private Sub btnImport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImport.Click
            Dim importSynchronizer As AppointmentImportSynchronizer = schedulerControl1.Storage.CreateOutlookImportSynchronizer()

            importSynchronizer.ForeignIdFieldName = "ForeignOutlookId"
            DirectCast(importSynchronizer, ISupportCalendarFolders).CalendarFolderName = cbOutlookCalendars.Text
            AddHandler importSynchronizer.AppointmentSynchronizing, AddressOf synchronizer_AppointmentSynchronizing
            importSynchronizer.Synchronize()
        End Sub

        Private Sub btnExport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnExport.Click
            Dim exportSynchronizer As AppointmentExportSynchronizer = schedulerControl1.Storage.CreateOutlookExportSynchronizer()

            exportSynchronizer.ForeignIdFieldName = "ForeignOutlookId"
            DirectCast(exportSynchronizer, ISupportCalendarFolders).CalendarFolderName = cbOutlookCalendars.Text
            AddHandler exportSynchronizer.AppointmentSynchronizing, AddressOf synchronizer_AppointmentSynchronizing
            exportSynchronizer.Synchronize()
        End Sub

        Private Sub synchronizer_AppointmentSynchronizing(ByVal sender As Object, ByVal e As AppointmentSynchronizingEventArgs)
            Dim args As OutlookAppointmentSynchronizingEventArgs = CType(e, OutlookAppointmentSynchronizingEventArgs)
            Dim apt As Appointment = e.Appointment

            Dim importSynchronizer As AppointmentImportSynchronizer = TryCast(sender, AppointmentImportSynchronizer)
            Dim exportSynchronizer As AppointmentExportSynchronizer = TryCast(sender, AppointmentExportSynchronizer)

            If apt IsNot Nothing AndAlso args.OutlookAppointment IsNot Nothing Then
                If importSynchronizer IsNot Nothing Then
                    apt.CustomFields(OutlookUserPropertyName) = GetOutlookAppointmentContactInfo(args.OutlookAppointment)
                Else
                    SetOutlookAppointmentContactInfo(args.OutlookAppointment, Convert.ToString(apt.CustomFields(OutlookUserPropertyName)))
                End If
            End If
        End Sub

        Private Sub SetOutlookAppointmentContactInfo(ByVal aptItem As _AppointmentItem, ByVal contactInfo As String)
            Dim olApt As OutlookInterop.AppointmentItem = CType(aptItem, OutlookInterop.AppointmentItem)
            Dim prop As OutlookInterop.UserProperty = olApt.UserProperties.Add(OutlookUserPropertyName, OutlookInterop.OlUserPropertyType.olText, False, Missing.Value)

            Try
                prop.Value = contactInfo
            Finally
                Marshal.ReleaseComObject(prop)
            End Try
        End Sub

        Private Function GetOutlookAppointmentContactInfo(ByVal aptItem As _AppointmentItem) As String
            Dim olApt As OutlookInterop.AppointmentItem = CType(aptItem, OutlookInterop.AppointmentItem)
            Dim en As IEnumerator = olApt.UserProperties.GetEnumerator()
            en.Reset()
            Do While en.MoveNext()
                Dim prop As OutlookInterop.UserProperty = DirectCast(en.Current, OutlookInterop.UserProperty)
                Try
                    If prop.Name = OutlookUserPropertyName Then
                        Return Convert.ToString(prop.Value)
                    End If
                Finally
                    Marshal.ReleaseComObject(prop)
                End Try
            Loop

            Return String.Empty
        End Function

        Private Sub schedulerControl1_InitAppointmentDisplayText(ByVal sender As Object, ByVal e As AppointmentDisplayTextEventArgs) Handles schedulerControl1.InitAppointmentDisplayText
            Dim contactInfo As Object = e.ViewInfo.Appointment.CustomFields(OutlookUserPropertyName)
            e.Text = String.Format("{0} (Contact Info: {1})", e.ViewInfo.Appointment.Subject, (If(contactInfo Is Nothing, "N/A", contactInfo.ToString())))
        End Sub
    End Class
End Namespace