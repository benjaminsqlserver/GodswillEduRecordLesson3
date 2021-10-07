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
    public partial class StudySessionsComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.StudySession> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.StudySession> _getStudySessionsResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.StudySession> getStudySessionsResult
        {
            get
            {
                return _getStudySessionsResult;
            }
            set
            {
                if (!object.Equals(_getStudySessionsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudySessionsResult", NewValue = value, OldValue = _getStudySessionsResult };
                    _getStudySessionsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getStudySessionsCount;
        protected int getStudySessionsCount
        {
            get
            {
                return _getStudySessionsCount;
            }
            set
            {
                if (!object.Equals(_getStudySessionsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudySessionsCount", NewValue = value, OldValue = _getStudySessionsCount };
                    _getStudySessionsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddStudySession>("Add Study Session", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportStudySessionsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "StudySessionID,StudySessionName,Time" }, $"Study Sessions");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportStudySessionsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "StudySessionID,StudySessionName,Time" }, $"Study Sessions");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetStudySessionsResult = await ConData.GetStudySessions(filter:$@"(contains(StudySessionName,""{search}"") or contains(Time,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getStudySessionsResult = conDataGetStudySessionsResult.Value.AsODataEnumerable();

                getStudySessionsCount = conDataGetStudySessionsResult.Count;
            }
            catch (System.Exception conDataGetStudySessionsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load StudySessions" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.StudySession args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStudySession>("Edit Study Session", new Dictionary<string, object>() { {"StudySessionID", args.StudySessionID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteStudySessionResult = await ConData.DeleteStudySession(studySessionId:data.StudySessionID);
                    if (conDataDeleteStudySessionResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteStudySessionException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete StudySession" });
            }
        }
    }
}
