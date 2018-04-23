using System;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Exchange;
using DevExpress.XtraScheduler.Outlook;
using DevExpress.XtraScheduler.Outlook.Interop;
using OutlookInterop = Microsoft.Office.Interop.Outlook;

namespace SchedulerSyncCustomFields {
    public partial class Form1 : Form {
        public const string OutlookUserPropertyName = "ContactInfo";

        public Form1() {
            InitializeComponent();

            cbOutlookCalendars.DataSource = OutlookExchangeHelper.GetOutlookCalendarPaths();

            SchedulerSyncCustomFields.DataSet1.EventsRow row = dataSet11.Events.NewEventsRow();

            DateTime baseTime = DateTime.Today;
            row.StartTime = baseTime.AddHours(1);
            row.EndTime = baseTime.AddHours(2);
            row.Subject = "Test";
            row.Description = "Test procedure";
            row.ContactInfo = "Test contact info";
 
            dataSet11.Events.AddEventsRow(row);

            schedulerControl1.Start = baseTime;
        }

        private void btnImport_Click(object sender, EventArgs e) {
            AppointmentImportSynchronizer importSynchronizer = schedulerControl1.Storage.CreateOutlookImportSynchronizer();

            importSynchronizer.ForeignIdFieldName = "ForeignOutlookId";
            ((ISupportCalendarFolders)importSynchronizer).CalendarFolderName = cbOutlookCalendars.Text;
            importSynchronizer.AppointmentSynchronizing += new DevExpress.XtraScheduler.AppointmentSynchronizingEventHandler(synchronizer_AppointmentSynchronizing);
            importSynchronizer.Synchronize();
        }

        private void btnExport_Click(object sender, EventArgs e) {
            AppointmentExportSynchronizer exportSynchronizer = schedulerControl1.Storage.CreateOutlookExportSynchronizer();

            exportSynchronizer.ForeignIdFieldName = "ForeignOutlookId";
            ((ISupportCalendarFolders)exportSynchronizer).CalendarFolderName = cbOutlookCalendars.Text;
            exportSynchronizer.AppointmentSynchronizing += new DevExpress.XtraScheduler.AppointmentSynchronizingEventHandler(synchronizer_AppointmentSynchronizing);
            exportSynchronizer.Synchronize();
        }

        private void synchronizer_AppointmentSynchronizing(object sender, AppointmentSynchronizingEventArgs e) {
            OutlookAppointmentSynchronizingEventArgs args = (OutlookAppointmentSynchronizingEventArgs)e;
            Appointment apt = e.Appointment;
           
            AppointmentImportSynchronizer importSynchronizer = sender as AppointmentImportSynchronizer;
            AppointmentExportSynchronizer exportSynchronizer = sender as AppointmentExportSynchronizer;

            if (apt != null && args.OutlookAppointment != null) {
                if (importSynchronizer != null) {
                    apt.CustomFields[OutlookUserPropertyName] = GetOutlookAppointmentContactInfo(args.OutlookAppointment);
                }
                else {
                    SetOutlookAppointmentContactInfo(args.OutlookAppointment, Convert.ToString(apt.CustomFields[OutlookUserPropertyName]));
                }
            }
        }

        private void SetOutlookAppointmentContactInfo(_AppointmentItem aptItem, string contactInfo) {
            OutlookInterop.AppointmentItem olApt = (OutlookInterop.AppointmentItem)aptItem;
            OutlookInterop.UserProperty prop = olApt.UserProperties.Add(OutlookUserPropertyName, OutlookInterop.OlUserPropertyType.olText, false, Missing.Value);
            
            try {
                prop.Value = contactInfo;
            }
            finally {
                Marshal.ReleaseComObject(prop);
            }
        }

        private string GetOutlookAppointmentContactInfo(_AppointmentItem aptItem) {
            OutlookInterop.AppointmentItem olApt = (OutlookInterop.AppointmentItem)aptItem;
            IEnumerator en = olApt.UserProperties.GetEnumerator();
            en.Reset();
            while (en.MoveNext()) {
                OutlookInterop.UserProperty prop = (OutlookInterop.UserProperty)en.Current;
                try {
                    if (prop.Name == OutlookUserPropertyName)
                        return Convert.ToString(prop.Value);
                }
                finally {
                    Marshal.ReleaseComObject(prop);
                }
            }

            return string.Empty;
        }

        private void schedulerControl1_InitAppointmentDisplayText(object sender, AppointmentDisplayTextEventArgs e) {
            object contactInfo = e.ViewInfo.Appointment.CustomFields[OutlookUserPropertyName];
            e.Text = string.Format("{0} (Contact Info: {1})", e.ViewInfo.Appointment.Subject, (contactInfo == null ? "N/A" : contactInfo.ToString()));
        }
    }
}