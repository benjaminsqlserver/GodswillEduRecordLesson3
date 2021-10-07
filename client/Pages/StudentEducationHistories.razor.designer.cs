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
    public partial class StudentEducationHistoriesComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.StudentEducationHistory> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.StudentEducationHistory> _getStudentEducationHistoriesResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.StudentEducationHistory> getStudentEducationHistoriesResult
        {
            get
            {
                return _getStudentEducationHistoriesResult;
            }
            set
            {
                if (!object.Equals(_getStudentEducationHistoriesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentEducationHistoriesResult", NewValue = value, OldValue = _getStudentEducationHistoriesResult };
                    _getStudentEducationHistoriesResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getStudentEducationHistoriesCount;
        protected int getStudentEducationHistoriesCount
        {
            get
            {
                return _getStudentEducationHistoriesCount;
            }
            set
            {
                if (!object.Equals(_getStudentEducationHistoriesCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentEducationHistoriesCount", NewValue = value, OldValue = _getStudentEducationHistoriesCount };
                    _getStudentEducationHistoriesCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddStudentEducationHistory>("Add Student Education History", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportStudentEducationHistoriesToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,Qualification", Select = "EducationRecordID,StudentBiodatum.Surname,NameOfInstitution,StartDate,EndDate,Qualification.QualificationName" }, $"Student Education Histories");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportStudentEducationHistoriesToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,Qualification", Select = "EducationRecordID,StudentBiodatum.Surname,NameOfInstitution,StartDate,EndDate,Qualification.QualificationName" }, $"Student Education Histories");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetStudentEducationHistoriesResult = await ConData.GetStudentEducationHistories(filter:$@"(contains(NameOfInstitution,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"StudentBiodatum,Qualification", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getStudentEducationHistoriesResult = conDataGetStudentEducationHistoriesResult.Value.AsODataEnumerable();

                getStudentEducationHistoriesCount = conDataGetStudentEducationHistoriesResult.Count;
            }
            catch (System.Exception conDataGetStudentEducationHistoriesException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load StudentEducationHistories" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.StudentEducationHistory args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStudentEducationHistory>("Edit Student Education History", new Dictionary<string, object>() { {"EducationRecordID", args.EducationRecordID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteStudentEducationHistoryResult = await ConData.DeleteStudentEducationHistory(educationRecordId:data.EducationRecordID);
                    if (conDataDeleteStudentEducationHistoryResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteStudentEducationHistoryException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete StudentEducationHistory" });
            }
        }
    }
}
