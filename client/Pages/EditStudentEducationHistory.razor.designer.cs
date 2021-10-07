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
    public partial class EditStudentEducationHistoryComponent : ComponentBase
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
        public dynamic EducationRecordID { get; set; }

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

        GodswillEduRecord.Models.ConData.StudentEducationHistory _studenteducationhistory;
        protected GodswillEduRecord.Models.ConData.StudentEducationHistory studenteducationhistory
        {
            get
            {
                return _studenteducationhistory;
            }
            set
            {
                if (!object.Equals(_studenteducationhistory, value))
                {
                    var args = new PropertyChangedEventArgs(){ Name = "studenteducationhistory", NewValue = value, OldValue = _studenteducationhistory };
                    _studenteducationhistory = value;
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

            var conDataGetStudentEducationHistoryByEducationRecordIdResult = await ConData.GetStudentEducationHistoryByEducationRecordId(educationRecordId:EducationRecordID);
            studenteducationhistory = conDataGetStudentEducationHistoryByEducationRecordIdResult;

            canEdit = conDataGetStudentEducationHistoryByEducationRecordIdResult != null;

            var conDataGetStudentBiodataResult = await ConData.GetStudentBiodata();
            getStudentBiodataResult = conDataGetStudentBiodataResult.Value.AsODataEnumerable();

            var conDataGetQualificationsResult = await ConData.GetQualifications();
            getQualificationsResult = conDataGetQualificationsResult.Value.AsODataEnumerable();
        }

        protected async System.Threading.Tasks.Task CloseButtonClick(MouseEventArgs args)
        {
            DialogService.Close(null);
        }

        protected async System.Threading.Tasks.Task Button0Click(MouseEventArgs args)
        {
            await this.Load();
        }

        protected async System.Threading.Tasks.Task Form0Submit(GodswillEduRecord.Models.ConData.StudentEducationHistory args)
        {
            try
            {
                var conDataUpdateStudentEducationHistoryResult = await ConData.UpdateStudentEducationHistory(educationRecordId:EducationRecordID, studentEducationHistory:studenteducationhistory);
                if (conDataUpdateStudentEducationHistoryResult.StatusCode != System.Net.HttpStatusCode.PreconditionFailed) {
                  DialogService.Close(studenteducationhistory);
                }

                hasChanges = conDataUpdateStudentEducationHistoryResult.StatusCode == System.Net.HttpStatusCode.PreconditionFailed;
            }
            catch (System.Exception conDataUpdateStudentEducationHistoryException)
            {
                NotificationService.Notify(new NotificationMessage(){ Severity = NotificationSeverity.Error,Summary = $"Error",Detail = $"Unable to update StudentEducationHistory" });
            }
        }

        protected async System.Threading.Tasks.Task Button4Click(MouseEventArgs args)
        {
            DialogService.Close(null);
        }
    }
}
