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
    public partial class RelationshipsComponent : ComponentBase
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
        protected RadzenDataGrid<GodswillEduRecord.Models.ConData.Relationship> grid0;

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

        IEnumerable<GodswillEduRecord.Models.ConData.Relationship> _getRelationshipsResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.Relationship> getRelationshipsResult
        {
            get
            {
                return _getRelationshipsResult;
            }
            set
            {
                if (!object.Equals(_getRelationshipsResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRelationshipsResult", NewValue = value, OldValue = _getRelationshipsResult };
                    _getRelationshipsResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        int _getRelationshipsCount;
        protected int getRelationshipsCount
        {
            get
            {
                return _getRelationshipsCount;
            }
            set
            {
                if (!object.Equals(_getRelationshipsCount, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getRelationshipsCount", NewValue = value, OldValue = _getRelationshipsCount };
                    _getRelationshipsCount = value;
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
            var dialogResult = await DialogService.OpenAsync<AddRelationship>("Add Relationship", null);
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task Splitbutton0Click(RadzenSplitButtonItem args)
        {
            if (args?.Value == "csv")
            {
                await ConData.ExportRelationshipsToCSV(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "RelationshipID,RelationshipName" }, $"Relationships");

            }

            if (args == null || args.Value == "xlsx")
            {
                await ConData.ExportRelationshipsToExcel(new Query() { Filter = $@"{grid0.Query.Filter}", OrderBy = $"{grid0.Query.OrderBy}", Expand = "", Select = "RelationshipID,RelationshipName" }, $"Relationships");

            }
        }

        protected async System.Threading.Tasks.Task Grid0LoadData(LoadDataArgs args)
        {
            try
            {
                var conDataGetRelationshipsResult = await ConData.GetRelationships(filter:$@"(contains(RelationshipName,""{search}"")) and {(string.IsNullOrEmpty(args.Filter)? "true" : args.Filter)}", orderby:$"{args.OrderBy}", top:args.Top, skip:args.Skip, count:args.Top != null && args.Skip != null);
                getRelationshipsResult = conDataGetRelationshipsResult.Value.AsODataEnumerable();

                getRelationshipsCount = conDataGetRelationshipsResult.Count;
            }
            catch (System.Exception conDataGetRelationshipsException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to load Relationships" });
            }
        }

        protected async System.Threading.Tasks.Task Grid0RowSelect(GodswillEduRecord.Models.ConData.Relationship args)
        {
            var dialogResult = await DialogService.OpenAsync<EditRelationship>("Edit Relationship", new Dictionary<string, object>() { {"RelationshipID", args.RelationshipID} });
            await grid0.Reload();

            await InvokeAsync(() => { StateHasChanged(); });
        }

        protected async System.Threading.Tasks.Task GridDeleteButtonClick(MouseEventArgs args, dynamic data)
        {
            try
            {
                if (await DialogService.Confirm("Are you sure you want to delete this record?") == true)
                {
                    var conDataDeleteRelationshipResult = await ConData.DeleteRelationship(relationshipId:data.RelationshipID);
                    if (conDataDeleteRelationshipResult != null)
                    {
                        await grid0.Reload();
                    }
                }
            }
            catch (System.Exception conDataDeleteRelationshipException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to delete Relationship" });
            }
        }
    }
}
