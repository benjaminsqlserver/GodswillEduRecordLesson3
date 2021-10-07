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
    public partial class EditStudentBiodatumComponent : ComponentBase
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

        [Parameter]
        public dynamic BiodataID { get; set; }

        bool _hasChanges;
        protected bool hasChanges
        {
            get
            {
                return _hasChanges;
            }
            set
            {
                if (!object.Equals(_hasChanges, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "hasChanges", NewValue = value, OldValue = _hasChanges };
                    _hasChanges = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        bool _canEdit;
        protected bool canEdit
        {
            get
            {
                return _canEdit;
            }
            set
            {
                if (!object.Equals(_canEdit, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "canEdit", NewValue = value, OldValue = _canEdit };
                    _canEdit = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        GodswillEduRecord.Models.ConData.StudentBiodatum _studentbiodatum;
        protected GodswillEduRecord.Models.ConData.StudentBiodatum studentbiodatum
        {
            get
            {
                return _studentbiodatum;
            }
            set
            {
                if (!object.Equals(_studentbiodatum, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "studentbiodatum", NewValue = value, OldValue = _studentbiodatum };
                    _studentbiodatum = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<GodswillEduRecord.Models.ConData.Gender> _getGendersResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.Gender> getGendersResult
        {
            get
            {
                return _getGendersResult;
            }
            set
            {
                if (!object.Equals(_getGendersResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getGendersResult", NewValue = value, OldValue = _getGendersResult };
                    _getGendersResult = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        IEnumerable<GodswillEduRecord.Models.ConData.State> _getStatesResult;
        protected IEnumerable<GodswillEduRecord.Models.ConData.State> getStatesResult
        {
            get
            {
                return _getStatesResult;
            }
            set
            {
                if (!object.Equals(_getStatesResult, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "getStatesResult", NewValue = value, OldValue = _getStatesResult };
                    _getStatesResult = value;
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
            hasChanges = false;

            canEdit = true;

            var conDataGetStudentBiodatumByBiodataIdResult = await ConData.GetStudentBiodatumByBiodataId(biodataId:BiodataID);
            studentbiodatum = conDataGetStudentBiodatumByBiodataIdResult;

            canEdit = conDataGetStudentBiodatumByBiodataIdResult != null;

            var conDataGetGendersResult = await ConData.GetGenders();
            getGendersResult = conDataGetGendersResult.Value.AsODataEnumerable();

            var conDataGetStatesResult = await ConData.GetStates();
            getStatesResult = conDataGetStatesResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(GodswillEduRecord.Models.ConData.StudentBiodatum args)
        {
            try
            {
                var conDataUpdateStudentBiodatumResult = await ConData.UpdateStudentBiodatum(biodataId:BiodataID, studentBiodatum:studentbiodatum);
                if (conDataUpdateStudentBiodatumResult.StatusCode != System.Net.HttpStatusCode.PreconditionFailed) {
                  DialogService.Close(studentbiodatum);
                }

                hasChanges = conDataUpdateStudentBiodatumResult.StatusCode == System.Net.HttpStatusCode.PreconditionFailed;
            }
            catch (System.Exception conDataUpdateStudentBiodatumException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update StudentBiodatum" });
            }
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
