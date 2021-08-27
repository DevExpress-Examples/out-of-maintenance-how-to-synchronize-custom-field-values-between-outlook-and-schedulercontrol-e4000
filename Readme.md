<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128636180/10.1.12%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4000)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/SchedulerSyncCustomFields/Form1.cs) (VB: [Form1.vb](./VB/SchedulerSyncCustomFields/Form1.vb))
* [Program.cs](./CS/SchedulerSyncCustomFields/Program.cs) (VB: [Program.vb](./VB/SchedulerSyncCustomFields/Program.vb))
<!-- default file list end -->
# How to synchronize custom field values between Outlook and SchedulerControl


<p>Note that <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument5228"><u>custom fields</u></a> are not synchronized by default. This example illustrates how to synchronize (import/export) them manually by using the MS Outlook Interop functionality (from the Microsoft.Office.Interop.Outlook assembly). We handle the <a href="http://documentation.devexpress.com/#CoreLibraries/DevExpressXtraSchedulerExchangeAppointmentSynchronizer_AppointmentSynchronizingtopic"><u>AppointmentSynchronizer.AppointmentSynchronizing Event</u></a> and use custom-made <strong>GetOutlookAppointmentContactInfo</strong><strong>()</strong><strong>/</strong><strong>S</strong><strong>etOutlookAppointmentContactInfo</strong><strong>()</strong><strong> </strong>methods to exchange values of the <strong>ContactInfo</strong> custom field. Note that we also handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerControl_InitAppointmentDisplayTexttopic"><u>SchedulerControl.InitAppointmentDisplayText Event</u></a> to display a custom field value to the end-user.</p><p>You can find basic concepts of the synchronization functionality in the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument3937"><u>Synchronization with MS Outlook</u></a> help section.<br />
</p>

<br/>


