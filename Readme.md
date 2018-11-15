<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/SchedulerSyncCustomFields/Form1.cs) (VB: [Form1.vb](./VB/SchedulerSyncCustomFields/Form1.vb))
* [Program.cs](./CS/SchedulerSyncCustomFields/Program.cs) (VB: [Program.vb](./VB/SchedulerSyncCustomFields/Program.vb))
<!-- default file list end -->
# How to synchronize custom field values between Outlook and SchedulerControl


<p>Note that <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument5228"><u>custom fields</u></a> are not synchronized by default. This example illustrates how to synchronize (import/export) them manually by using the MS Outlook Interop functionality (from the Microsoft.Office.Interop.Outlook assembly). We handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerExchangeAppointmentSynchronizer_AppointmentSynchronizingtopic"><u>AppointmentSynchronizer.AppointmentSynchronizing Event</u></a> and use custom-made <strong>GetOutlookAppointmentContactInfo</strong><strong>()</strong><strong>/</strong><strong>S</strong><strong>etOutlookAppointmentContactInfo</strong><strong>()</strong><strong> </strong>methods to exchange values of the <strong>ContactInfo</strong> custom field. Note that we also handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_InitAppointmentDisplayTexttopic"><u>SchedulerControl.InitAppointmentDisplayText Event</u></a> to display a custom field value to the end-user.</p><p>You can find basic concepts of the synchronization functionality in the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument3937"><u>Synchronization with MS Outlook</u></a> help section.<br />
</p>

<br/>


