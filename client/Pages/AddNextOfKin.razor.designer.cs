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
    public partial class AddNextOfKinComponent : ComponentBase
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

        GodswillEduRecord.Models.ConData.NextOfKin _nextofkin;
        protected GodswillEduRecord.Models.ConData.NextOfKin nextofkin
        {
            get
            {
                return _nextofkin;
            }
            set
            {
                if (!object.Equals(_nextofkin, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "nextofkin", NewValue = value, OldValue = _nextofkin };
                    _nextofkin = value;
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
            var conDataGetStudentBiodataResult = await ConData.GetStudentBiodata();
            getStudentBiodataResult = conDataGetStudentBiodataResult.Value.AsODataEnumerable();

            var conDataGetRelationshipsResult = await ConData.GetRelationships();
            getRelationshipsResult = conDataGetRelationshipsResult.Value.AsODataEnumerable();

            nextofkin = new GodswillEduRecord.Models.ConData.NextOfKin(){};
        }

        protected async System.Threading.Tasks.Task Form0Submit(GodswillEduRecord.Models.ConData.NextOfKin args)
        {
            try
            {
                var conDataCreateNextOfKinResult = await ConData.CreateNextOfKin(nextOfKin:nextofkin);
                DialogService.Close(nextofkin);
            }
            catch (System.Exception conDataCreateNextOfKinException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to create new NextOfKin!" });
            }
        }

        protected async System.Threading.Tasks.Task Button2Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
