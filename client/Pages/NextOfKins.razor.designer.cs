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
    public partial class NextOfKinsComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.NextOfKin> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.NextOfKin> _getNextOfKinsResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.NextOfKin> getNextOfKinsResult
        {
            get
            {
                return _getNextOfKinsResult;
            }
            set
            {
                if (!object.Equals(_getNextOfKinsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getNextOfKinsResult", NewValue = value, OldValue = _getNextOfKinsResult };
                    _getNextOfKinsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getNextOfKinsCount;
        protected int getNextOfKinsCount
        {
            get
            {
                return _getNextOfKinsCount;
            }
            set
            {
                if (!object.Equals(_getNextOfKinsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getNextOfKinsCount", NewValue = value, OldValue = _getNextOfKinsCount };
                    _getNextOfKinsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddNextOfKin>("Add Next Of Kin", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportNextOfKinsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,Relationship", Select = "NextOfKinID,StudentBiodatum.Surname,NameOfNextOfKin,Relationship.RelationshipName,NextOfKinPhoneNo,NextOfKinEmail,NextOfKinContactAddress" }, $"Next Of Kins");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportNextOfKinsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "StudentBiodatum,Relationship", Select = "NextOfKinID,StudentBiodatum.Surname,NameOfNextOfKin,Relationship.RelationshipName,NextOfKinPhoneNo,NextOfKinEmail,NextOfKinContactAddress" }, $"Next Of Kins");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetNextOfKinsResult = await ConData.GetNextOfKins(filter:$@"(contains(NameOfNextOfKin,""{search}"") or contains(NextOfKinPhoneNo,""{search}"") or contains(NextOfKinEmail,""{search}"") or contains(NextOfKinContactAddress,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", expand:$"StudentBiodatum,Relationship", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getNextOfKinsResult = conDataGetNextOfKinsResult.Value.AsODataEnumerable();

                getNextOfKinsCount = conDataGetNextOfKinsResult.Count;
            }
            catch (System.Exception conDataGetNextOfKinsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load NextOfKins" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.NextOfKin args)
        {
            var dialogResult = await DialogService.OpenAsync<EditNextOfKin>("Edit Next Of Kin", new Dictionary<string, object>() { {"NextOfKinID", args.NextOfKinID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteNextOfKinResult = await ConData.DeleteNextOfKin(nextOfKinId:data.NextOfKinID);
                    if (conDataDeleteNextOfKinResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteNextOfKinException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete NextOfKin" });
            }
        }
    }
}
