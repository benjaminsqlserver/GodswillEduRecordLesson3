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
    public partial class SchoolCoursesComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.SchoolCourse> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.SchoolCourse> _getSchoolCoursesResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.SchoolCourse> getSchoolCoursesResult
        {
            get
            {
                return _getSchoolCoursesResult;
            }
            set
            {
                if (!object.Equals(_getSchoolCoursesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSchoolCoursesResult", NewValue = value, OldValue = _getSchoolCoursesResult };
                    _getSchoolCoursesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getSchoolCoursesCount;
        protected int getSchoolCoursesCount
        {
            get
            {
                return _getSchoolCoursesCount;
            }
            set
            {
                if (!object.Equals(_getSchoolCoursesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getSchoolCoursesCount", NewValue = value, OldValue = _getSchoolCoursesCount };
                    _getSchoolCoursesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddSchoolCourse>("Add School Course", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportSchoolCoursesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CourseOfStudyID,CourseOfStudyName,CourseFee,DurationInMonths" }, $"School Courses");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportSchoolCoursesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "CourseOfStudyID,CourseOfStudyName,CourseFee,DurationInMonths" }, $"School Courses");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetSchoolCoursesResult = await ConData.GetSchoolCourses(filter:$@"(contains(CourseOfStudyName,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getSchoolCoursesResult = conDataGetSchoolCoursesResult.Value.AsODataEnumerable();

                getSchoolCoursesCount = conDataGetSchoolCoursesResult.Count;
            }
            catch (System.Exception conDataGetSchoolCoursesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load SchoolCourses" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.SchoolCourse args)
        {
            var dialogResult = await DialogService.OpenAsync<EditSchoolCourse>("Edit School Course", new Dictionary<string, object>() { {"CourseOfStudyID", args.CourseOfStudyID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteSchoolCourseResult = await ConData.DeleteSchoolCourse(courseOfStudyId:data.CourseOfStudyID);
                    if (conDataDeleteSchoolCourseResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteSchoolCourseException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete SchoolCourse" });
            }
        }
    }
}
