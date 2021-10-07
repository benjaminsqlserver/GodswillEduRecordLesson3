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
    public partial class AddStudentBiodatumComponent : ComponentBase
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
            var conDataGetGendersResult = await ConData.GetGenders();
            getGendersResult = conDataGetGendersResult.Value.AsODataEnumerable();

            var conDataGetStatesResult = await ConData.GetStates();
            getStatesResult = conDataGetStatesResult.Value.AsODataEnumerable();

            studentbiodatum = new GodswillEduRecord.Models.ConData.StudentBiodatum(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(GodswillEduRecord.Models.ConData.StudentBiodatum args)
        {
            try
            {
                var conDataCreateStudentBiodatumResult = await ConData.CreateStudentBiodatum(studentBiodatum:studentbiodatum);
                DialogService.Close(studentbiodatum);
            }
            catch (System.Exception conDataCreateStudentBiodatumException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new StudentBiodatum!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
