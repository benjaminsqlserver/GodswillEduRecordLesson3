using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using GodswillEduRecord.Models.ConData;
using Microsoft.AspNetCore.Identity;
using GodswillEduRecord.Models;
using GodswillEduRecord.Client.Pages;

namespace GodswillEduRecord.Pages
{
    public partial class StudentCoursePaymentsComponent : ComponentBase
    {
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, dynamic> Attributes { get; set; }

        public void Reload()
        {
            InvokeAsync(StateHasChanged);
        }

        public void OnPropertyChanged(PropertyChangedEventArgs args)
        {
        }

        [Inject]
        protected IJSRuntime JSRuntime { get; set; }

        [Inject]
        protected NavigationManager UriHelper { get; set; }

        [Inject]
        protected DialogService DialogService { get; set; }

        [Inject]
        protected TooltipService TooltipService { get; set; }

        [Inject]
        protected ContextMenuService ContextMenuService { get; set; }

        [Inject]
        protected NotificationService NotificationService { get; set; }

        [Inject]
        protected SecurityService Security { get; set; }

        [Inject]
        protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }

        [Inject]
        protected ConDataService ConData { get; set; }
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.StudentCoursePayment> grid0;

        string _search;
        protected string search
        {
            get
            {
                return _search;
            }
            set
            {
                if (!object.Equals(_search, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "search", NewValue = value, OldValue = _search };
                    _search = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<GodswillEduRecord.Models.ConData.StudentCoursePayment> _getStudentCoursePaymentsResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.StudentCoursePayment> getStudentCoursePaymentsResult
        {
            get
            {
                return _getStudentCoursePaymentsResult;
            }
            set
            {
                if (!object.Equals(_getStudentCoursePaymentsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentCoursePaymentsResult", NewValue = value, OldValue = _getStudentCoursePaymentsResult };
                    _getStudentCoursePaymentsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getStudentCoursePaymentsCount;
        protected int getStudentCoursePaymentsCount
        {
            get
            {
                return _getStudentCoursePaymentsCount;
            }
            set
            {
                if (!object.Equals(_getStudentCoursePaymentsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentCoursePaymentsCount", NewValue = value, OldValue = _getStudentCoursePaymentsCount };
                    _getStudentCoursePaymentsCount = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        protected override async System.Threading.Tasks.Task OnInitializedAsync()
        {
            await Security.InitializeAsync(AuthenticationStateProvider);
            if (!Security.IsAuthenticated())
            {
                UriHelper.NavigateTo("Login", true);
            }
            else
            {
                await Load();
            }
        }
        protected async System.Threading.Tasks.Task Load()
        {
            if (string.IsNullOrEmpty(search)) {
                search = "";
            }
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            var dialogResult = await DialogService.OpenAsync<AddStudentCoursePayment>("Add Student Course Payment", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportStudentCoursePaymentsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,SchoolCourse", Select = "PaymentID,StudentBiodatum.Surname,SchoolCourse.CourseOfStudyName,PaymentDate,CourseFee,AmountPaid,Balance" }, $"Student Course Payments");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportStudentCoursePaymentsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,SchoolCourse", Select = "PaymentID,StudentBiodatum.Surname,SchoolCourse.CourseOfStudyName,PaymentDate,CourseFee,AmountPaid,Balance" }, $"Student Course Payments");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetStudentCoursePaymentsResult = await ConData.GetStudentCoursePayments(filter:$@"{(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"StudentBiodatum,SchoolCourse", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getStudentCoursePaymentsResult = conDataGetStudentCoursePaymentsResult.Value.AsODataEnumerable();

                getStudentCoursePaymentsCount = conDataGetStudentCoursePaymentsResult.Count;
            }
            catch (System.Exception conDataGetStudentCoursePaymentsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load StudentCoursePayments" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.StudentCoursePayment args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStudentCoursePayment>("Edit Student Course Payment", new Dictionary<string, object>() { {"PaymentID", args.PaymentID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteStudentCoursePaymentResult = await ConData.DeleteStudentCoursePayment(paymentId:data.PaymentID);
                    if (conDataDeleteStudentCoursePaymentResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteStudentCoursePaymentException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete StudentCoursePayment" });
            }
        }
    }
}
