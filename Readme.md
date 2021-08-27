<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128636180/14.1.7%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4000)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [Program.cs](./CS/Program.cs) (VB: [Program.vb](./VB/Program.vb))
<!-- default file list end -->
# How to synchronize custom field values between Outlook and SchedulerControl


<p>Note that <a href="https://docs.devexpress.com/WindowsForms/5228/controls-and-libraries/scheduler/examples/data-binding/how-to-create-appointments-with-custom-fields"><u>custom fields</u></a> are not synchronized by default. This example illustrates how to synchronize (import/export) them manually by using the MS Outlook Interop functionality (from the Microsoft.Office.Interop.Outlook assembly). We handle the <a href="https://docs.devexpress.com/CoreLibraries/DevExpress.XtraScheduler.Exchange.AppointmentSynchronizer.AppointmentSynchronizing"><u>AppointmentSynchronizer.AppointmentSynchronizing Event</u></a> and use custom-made <strong>GetOutlookAppointmentContactInfo</strong><strong>()</strong><strong>/</strong><strong>S</strong><strong>etOutlookAppointmentContactInfo</strong><strong>()</strong><strong> </strong>methods to exchange values of the <strong>ContactInfo</strong> custom field. Note that we also handle the <a href="https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerControl.InitAppointmentDisplayText"><u>SchedulerControl.InitAppointmentDisplayText Event</u></a> to display a custom field value to the end-user.</p><p>You can find basic concepts of the synchronization functionality in the <a href="https://docs.devexpress.com/WindowsForms/3937/controls-and-libraries/scheduler/import-and-export/synchronization-with-microsoft-outlook"><u>Synchronization with MS Outlook</u></a> help section.<br />
</p>

<br/>


