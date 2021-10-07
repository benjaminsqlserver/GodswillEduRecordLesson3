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
    public partial class QualificationsComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.Qualification> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.Qualification> _getQualificationsResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.Qualification> getQualificationsResult
        {
            get
            {
                return _getQualificationsResult;
            }
            set
            {
                if (!object.Equals(_getQualificationsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getQualificationsResult", NewValue = value, OldValue = _getQualificationsResult };
                    _getQualificationsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getQualificationsCount;
        protected int getQualificationsCount
        {
            get
            {
                return _getQualificationsCount;
            }
            set
            {
                if (!object.Equals(_getQualificationsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getQualificationsCount", NewValue = value, OldValue = _getQualificationsCount };
                    _getQualificationsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddQualification>("Add Qualification", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportQualificationsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "QualificationID,QualificationName" }, $"Qualifications");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportQualificationsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "QualificationID,QualificationName" }, $"Qualifications");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetQualificationsResult = await ConData.GetQualifications(filter:$@"(contains(QualificationName,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getQualificationsResult = conDataGetQualificationsResult.Value.AsODataEnumerable();

                getQualificationsCount = conDataGetQualificationsResult.Count;
            }
            catch (System.Exception conDataGetQualificationsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Qualifications" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.Qualification args)
        {
            var dialogResult = await DialogService.OpenAsync<EditQualification>("Edit Qualification", new Dictionary<string, object>() { {"QualificationID", args.QualificationID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteQualificationResult = await ConData.DeleteQualification(qualificationId:data.QualificationID);
                    if (conDataDeleteQualificationResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteQualificationException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Qualification" });
            }
        }
    }
}
