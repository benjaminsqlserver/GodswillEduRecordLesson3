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
    public partial class StudentBiodataComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.StudentBiodatum> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.StudentBiodatum> _getStudentBiodataResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.StudentBiodatum> getStudentBiodataResult
        {
            get
            {
                return _getStudentBiodataResult;
            }
            set
            {
                if (!object.Equals(_getStudentBiodataResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentBiodataResult", NewValue = value, OldValue = _getStudentBiodataResult };
                    _getStudentBiodataResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getStudentBiodataCount;
        protected int getStudentBiodataCount
        {
            get
            {
                return _getStudentBiodataCount;
            }
            set
            {
                if (!object.Equals(_getStudentBiodataCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStudentBiodataCount", NewValue = value, OldValue = _getStudentBiodataCount };
                    _getStudentBiodataCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddStudentBiodatum>("Add Student Biodatum", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportStudentBiodataToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Gender,State", Select = "BiodataID,Surname,FirstName,OtherNames,ContactAddress,DateOfBirth,Gender.GenderName,State.StateName,PhoneNumber,EmailAddress,FacebookID,Picture" }, $"Student Biodata");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportStudentBiodataToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "Gender,State", Select = "BiodataID,Surname,FirstName,OtherNames,ContactAddress,DateOfBirth,Gender.GenderName,State.StateName,PhoneNumber,EmailAddress,FacebookID,Picture" }, $"Student Biodata");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetStudentBiodataResult = await ConData.GetStudentBiodata(filter:$@"(contains(Surname,""{search}"") or contains(FirstName,""{search}"") or contains(OtherNames,""{search}"") or contains(ContactAddress,""{search}"") or contains(PhoneNumber,""{search}"") or contains(EmailAddress,""{search}"") or contains(FacebookID,""{search}"") or contains(Picture,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"Gender,State", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getStudentBiodataResult = conDataGetStudentBiodataResult.Value.AsODataEnumerable();

                getStudentBiodataCount = conDataGetStudentBiodataResult.Count;
            }
            catch (System.Exception conDataGetStudentBiodataException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load StudentBiodata" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.StudentBiodatum args)
        {
            var dialogResult = await DialogService.OpenAsync<EditStudentBiodatum>("Edit Student Biodatum", new Dictionary<string, object>() { {"BiodataID", args.BiodataID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteStudentBiodatumResult = await ConData.DeleteStudentBiodatum(biodataId:data.BiodataID);
                    if (conDataDeleteStudentBiodatumResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteStudentBiodatumException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete StudentBiodatum" });
            }
        }
    }
}
