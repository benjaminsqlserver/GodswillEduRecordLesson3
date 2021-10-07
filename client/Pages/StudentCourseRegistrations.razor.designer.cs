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
    public partial class StudentCourseRegistrationsComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.StudentCourseRegistration> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.StudentCourseRegistration> _getStudentCourseRegistrationsResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.StudentCourseRegistration> getStudentCourseRegistrationsResult
        {
            get
            {
                return _getStudentCourseRegistrationsResult;
            }
            set
            {
                if (!object.Equals(_getStudentCourseRegistrationsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentCourseRegistrationsResult", NewValue = value, OldValue = _getStudentCourseRegistrationsResult };
                    _getStudentCourseRegistrationsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getStudentCourseRegistrationsCount;
        protected int getStudentCourseRegistrationsCount
        {
            get
            {
                return _getStudentCourseRegistrationsCount;
            }
            set
            {
                if (!object.Equals(_getStudentCourseRegistrationsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentCourseRegistrationsCount", NewValue = value, OldValue = _getStudentCourseRegistrationsCount };
                    _getStudentCourseRegistrationsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddStudentCourseRegistration>("Add Student Course Registration", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportStudentCourseRegistrationsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,SchoolCourse,StudySession", Select = "CourseRegistrationID,StudentBiodatum.Surname,SchoolCourse.CourseOfStudyName,StudySession.StudySessionName,IsPrivateStudent,PrivateTrainingVenue,PrivateTrainingTime,Signature" }, $"Student Course Registrations");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportStudentCourseRegistrationsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,SchoolCourse,StudySession", Select = "CourseRegistrationID,StudentBiodatum.Surname,SchoolCourse.CourseOfStudyName,StudySession.StudySessionName,IsPrivateStudent,PrivateTrainingVenue,PrivateTrainingTime,Signature" }, $"Student Course Registrations");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetStudentCourseRegistrationsResult = await ConData.GetStudentCourseRegistrations(filter:$@"(contains(PrivateTrainingVenue,""{search}"") or contains(PrivateTrainingTime,""{search}"") or contains(Signature,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"StudentBiodatum,SchoolCourse,StudySession", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getStudentCourseRegistrationsResult = conDataGetStudentCourseRegistrationsResult.Value.AsODataEnumerable();

                getStudentCourseRegistrationsCount = conDataGetStudentCourseRegistrationsResult.Count;
            }
            catch (System.Exception conDataGetStudentCourseRegistrationsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load StudentCourseRegistrations" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.StudentCourseRegistration args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStudentCourseRegistration>("Edit Student Course Registration", new Dictionary<string, object>() { {"CourseRegistrationID", args.CourseRegistrationID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteStudentCourseRegistrationResult = await ConData.DeleteStudentCourseRegistration(courseRegistrationId:data.CourseRegistrationID);
                    if (conDataDeleteStudentCourseRegistrationResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteStudentCourseRegistrationException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete StudentCourseRegistration" });
            }
        }
    }
}
