
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using Radzen;
using GodswillEduRecord.Models.ConData;

namespace GodswillEduRecord
{
    public partial class ConDataService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public ConDataService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/ConData/");
        }

        public async System.Threading.Tasks.Task ExportGendersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/genders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/genders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportGendersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/genders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/genders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetGenders(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Gender>> GetGenders(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Genders");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetGenders(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Gender>>();
        }
        partial void OnCreateGender(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Gender> CreateGender(Gender gender = default(Gender))
        {
            var uri = new Uri(baseUri, $"Genders");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(gender), Encoding.UTF8, "application/json");

            OnCreateGender(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Gender>();
        }

        public async System.Threading.Tasks.Task ExportNextOfKinsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/nextofkins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/nextofkins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportNextOfKinsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/nextofkins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/nextofkins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetNextOfKins(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<NextOfKin>> GetNextOfKins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"NextOfKins");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetNextOfKins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<NextOfKin>>();
        }
        partial void OnCreateNextOfKin(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<NextOfKin> CreateNextOfKin(NextOfKin nextOfKin = default(NextOfKin))
        {
            var uri = new Uri(baseUri, $"NextOfKins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(nextOfKin), Encoding.UTF8, "application/json");

            OnCreateNextOfKin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<NextOfKin>();
        }

        public async System.Threading.Tasks.Task ExportQualificationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/qualifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/qualifications/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportQualificationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/qualifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/qualifications/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetQualifications(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Qualification>> GetQualifications(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Qualifications");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetQualifications(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Qualification>>();
        }
        partial void OnCreateQualification(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Qualification> CreateQualification(Qualification qualification = default(Qualification))
        {
            var uri = new Uri(baseUri, $"Qualifications");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(qualification), Encoding.UTF8, "application/json");

            OnCreateQualification(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Qualification>();
        }

        public async System.Threading.Tasks.Task ExportRelationshipsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/relationships/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/relationships/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportRelationshipsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/relationships/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/relationships/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetRelationships(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<Relationship>> GetRelationships(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"Relationships");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRelationships(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<Relationship>>();
        }
        partial void OnCreateRelationship(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Relationship> CreateRelationship(Relationship relationship = default(Relationship))
        {
            var uri = new Uri(baseUri, $"Relationships");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(relationship), Encoding.UTF8, "application/json");

            OnCreateRelationship(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Relationship>();
        }

        public async System.Threading.Tasks.Task ExportSchoolCoursesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/schoolcourses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/schoolcourses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSchoolCoursesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/schoolcourses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/schoolcourses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSchoolCourses(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<SchoolCourse>> GetSchoolCourses(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"SchoolCourses");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSchoolCourses(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<SchoolCourse>>();
        }
        partial void OnCreateSchoolCourse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SchoolCourse> CreateSchoolCourse(SchoolCourse schoolCourse = default(SchoolCourse))
        {
            var uri = new Uri(baseUri, $"SchoolCourses");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(schoolCourse), Encoding.UTF8, "application/json");

            OnCreateSchoolCourse(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<SchoolCourse>();
        }

        public async System.Threading.Tasks.Task ExportStatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/states/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/states/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportStatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/states/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/states/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetStates(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<State>> GetStates(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"States");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStates(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<State>>();
        }
        partial void OnCreateState(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<State> CreateState(State state = default(State))
        {
            var uri = new Uri(baseUri, $"States");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(state), Encoding.UTF8, "application/json");

            OnCreateState(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<State>();
        }

        public async System.Threading.Tasks.Task ExportStudentBiodataToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studentbiodata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studentbiodata/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportStudentBiodataToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studentbiodata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studentbiodata/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetStudentBiodata(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<StudentBiodatum>> GetStudentBiodata(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"StudentBiodata");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentBiodata(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<StudentBiodatum>>();
        }
        partial void OnCreateStudentBiodatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentBiodatum> CreateStudentBiodatum(StudentBiodatum studentBiodatum = default(StudentBiodatum))
        {
            var uri = new Uri(baseUri, $"StudentBiodata");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentBiodatum), Encoding.UTF8, "application/json");

            OnCreateStudentBiodatum(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentBiodatum>();
        }

        public async System.Threading.Tasks.Task ExportStudentCoursePaymentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studentcoursepayments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studentcoursepayments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportStudentCoursePaymentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studentcoursepayments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studentcoursepayments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetStudentCoursePayments(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<StudentCoursePayment>> GetStudentCoursePayments(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"StudentCoursePayments");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentCoursePayments(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<StudentCoursePayment>>();
        }
        partial void OnCreateStudentCoursePayment(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentCoursePayment> CreateStudentCoursePayment(StudentCoursePayment studentCoursePayment = default(StudentCoursePayment))
        {
            var uri = new Uri(baseUri, $"StudentCoursePayments");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentCoursePayment), Encoding.UTF8, "application/json");

            OnCreateStudentCoursePayment(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentCoursePayment>();
        }

        public async System.Threading.Tasks.Task ExportStudentCourseRegistrationsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studentcourseregistrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studentcourseregistrations/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportStudentCourseRegistrationsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studentcourseregistrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studentcourseregistrations/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetStudentCourseRegistrations(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<StudentCourseRegistration>> GetStudentCourseRegistrations(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"StudentCourseRegistrations");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentCourseRegistrations(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<StudentCourseRegistration>>();
        }
        partial void OnCreateStudentCourseRegistration(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentCourseRegistration> CreateStudentCourseRegistration(StudentCourseRegistration studentCourseRegistration = default(StudentCourseRegistration))
        {
            var uri = new Uri(baseUri, $"StudentCourseRegistrations");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentCourseRegistration), Encoding.UTF8, "application/json");

            OnCreateStudentCourseRegistration(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentCourseRegistration>();
        }

        public async System.Threading.Tasks.Task ExportStudentEducationHistoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studenteducationhistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studenteducationhistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportStudentEducationHistoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studenteducationhistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studenteducationhistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetStudentEducationHistories(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<StudentEducationHistory>> GetStudentEducationHistories(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"StudentEducationHistories");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentEducationHistories(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<StudentEducationHistory>>();
        }
        partial void OnCreateStudentEducationHistory(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentEducationHistory> CreateStudentEducationHistory(StudentEducationHistory studentEducationHistory = default(StudentEducationHistory))
        {
            var uri = new Uri(baseUri, $"StudentEducationHistories");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentEducationHistory), Encoding.UTF8, "application/json");

            OnCreateStudentEducationHistory(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentEducationHistory>();
        }

        public async System.Threading.Tasks.Task ExportStudySessionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studysessions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studysessions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportStudySessionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/studysessions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/studysessions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetStudySessions(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<ODataServiceResult<StudySession>> GetStudySessions(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string))
        {
            var uri = new Uri(baseUri, $"StudySessions");
            uri = uri.GetODataUri(filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:null, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudySessions(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<ODataServiceResult<StudySession>>();
        }
        partial void OnCreateStudySession(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudySession> CreateStudySession(StudySession studySession = default(StudySession))
        {
            var uri = new Uri(baseUri, $"StudySessions");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studySession), Encoding.UTF8, "application/json");

            OnCreateStudySession(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudySession>();
        }
        partial void OnDeleteGender(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteGender(int? genderId = default(int?))
        {
            var uri = new Uri(baseUri, $"Genders({genderId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteGender(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetGenderByGenderId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Gender> GetGenderByGenderId(int? genderId = default(int?))
        {
            var uri = new Uri(baseUri, $"Genders({genderId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetGenderByGenderId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Gender>();
        }
        partial void OnUpdateGender(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateGender(int? genderId = default(int?), Gender gender = default(Gender))
        {
            var uri = new Uri(baseUri, $"Genders({genderId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", gender.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(gender), Encoding.UTF8, "application/json");

            OnUpdateGender(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteNextOfKin(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteNextOfKin(Int64? nextOfKinId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"NextOfKins({nextOfKinId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteNextOfKin(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetNextOfKinByNextOfKinId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<NextOfKin> GetNextOfKinByNextOfKinId(Int64? nextOfKinId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"NextOfKins({nextOfKinId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetNextOfKinByNextOfKinId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<NextOfKin>();
        }
        partial void OnUpdateNextOfKin(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateNextOfKin(Int64? nextOfKinId = default(Int64?), NextOfKin nextOfKin = default(NextOfKin))
        {
            var uri = new Uri(baseUri, $"NextOfKins({nextOfKinId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", nextOfKin.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(nextOfKin), Encoding.UTF8, "application/json");

            OnUpdateNextOfKin(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteQualification(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteQualification(int? qualificationId = default(int?))
        {
            var uri = new Uri(baseUri, $"Qualifications({qualificationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteQualification(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetQualificationByQualificationId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Qualification> GetQualificationByQualificationId(int? qualificationId = default(int?))
        {
            var uri = new Uri(baseUri, $"Qualifications({qualificationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetQualificationByQualificationId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Qualification>();
        }
        partial void OnUpdateQualification(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateQualification(int? qualificationId = default(int?), Qualification qualification = default(Qualification))
        {
            var uri = new Uri(baseUri, $"Qualifications({qualificationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", qualification.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(qualification), Encoding.UTF8, "application/json");

            OnUpdateQualification(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteRelationship(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteRelationship(int? relationshipId = default(int?))
        {
            var uri = new Uri(baseUri, $"Relationships({relationshipId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteRelationship(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetRelationshipByRelationshipId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Relationship> GetRelationshipByRelationshipId(int? relationshipId = default(int?))
        {
            var uri = new Uri(baseUri, $"Relationships({relationshipId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetRelationshipByRelationshipId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<Relationship>();
        }
        partial void OnUpdateRelationship(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateRelationship(int? relationshipId = default(int?), Relationship relationship = default(Relationship))
        {
            var uri = new Uri(baseUri, $"Relationships({relationshipId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", relationship.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(relationship), Encoding.UTF8, "application/json");

            OnUpdateRelationship(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSchoolCourse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSchoolCourse(int? courseOfStudyId = default(int?))
        {
            var uri = new Uri(baseUri, $"SchoolCourses({courseOfStudyId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSchoolCourse(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSchoolCourseByCourseOfStudyId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<SchoolCourse> GetSchoolCourseByCourseOfStudyId(int? courseOfStudyId = default(int?))
        {
            var uri = new Uri(baseUri, $"SchoolCourses({courseOfStudyId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSchoolCourseByCourseOfStudyId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<SchoolCourse>();
        }
        partial void OnUpdateSchoolCourse(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSchoolCourse(int? courseOfStudyId = default(int?), SchoolCourse schoolCourse = default(SchoolCourse))
        {
            var uri = new Uri(baseUri, $"SchoolCourses({courseOfStudyId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", schoolCourse.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(schoolCourse), Encoding.UTF8, "application/json");

            OnUpdateSchoolCourse(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteState(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteState(int? stateId = default(int?))
        {
            var uri = new Uri(baseUri, $"States({stateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteState(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetStateByStateId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<State> GetStateByStateId(int? stateId = default(int?))
        {
            var uri = new Uri(baseUri, $"States({stateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStateByStateId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<State>();
        }
        partial void OnUpdateState(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateState(int? stateId = default(int?), State state = default(State))
        {
            var uri = new Uri(baseUri, $"States({stateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", state.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(state), Encoding.UTF8, "application/json");

            OnUpdateState(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteStudentBiodatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteStudentBiodatum(Int64? biodataId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentBiodata({biodataId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteStudentBiodatum(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetStudentBiodatumByBiodataId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentBiodatum> GetStudentBiodatumByBiodataId(Int64? biodataId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentBiodata({biodataId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentBiodatumByBiodataId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentBiodatum>();
        }
        partial void OnUpdateStudentBiodatum(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateStudentBiodatum(Int64? biodataId = default(Int64?), StudentBiodatum studentBiodatum = default(StudentBiodatum))
        {
            var uri = new Uri(baseUri, $"StudentBiodata({biodataId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", studentBiodatum.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentBiodatum), Encoding.UTF8, "application/json");

            OnUpdateStudentBiodatum(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteStudentCoursePayment(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteStudentCoursePayment(Int64? paymentId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentCoursePayments({paymentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteStudentCoursePayment(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetStudentCoursePaymentByPaymentId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentCoursePayment> GetStudentCoursePaymentByPaymentId(Int64? paymentId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentCoursePayments({paymentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentCoursePaymentByPaymentId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentCoursePayment>();
        }
        partial void OnUpdateStudentCoursePayment(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateStudentCoursePayment(Int64? paymentId = default(Int64?), StudentCoursePayment studentCoursePayment = default(StudentCoursePayment))
        {
            var uri = new Uri(baseUri, $"StudentCoursePayments({paymentId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", studentCoursePayment.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentCoursePayment), Encoding.UTF8, "application/json");

            OnUpdateStudentCoursePayment(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteStudentCourseRegistration(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteStudentCourseRegistration(Int64? courseRegistrationId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentCourseRegistrations({courseRegistrationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteStudentCourseRegistration(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetStudentCourseRegistrationByCourseRegistrationId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentCourseRegistration> GetStudentCourseRegistrationByCourseRegistrationId(Int64? courseRegistrationId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentCourseRegistrations({courseRegistrationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentCourseRegistrationByCourseRegistrationId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentCourseRegistration>();
        }
        partial void OnUpdateStudentCourseRegistration(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateStudentCourseRegistration(Int64? courseRegistrationId = default(Int64?), StudentCourseRegistration studentCourseRegistration = default(StudentCourseRegistration))
        {
            var uri = new Uri(baseUri, $"StudentCourseRegistrations({courseRegistrationId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", studentCourseRegistration.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentCourseRegistration), Encoding.UTF8, "application/json");

            OnUpdateStudentCourseRegistration(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteStudentEducationHistory(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteStudentEducationHistory(Int64? educationRecordId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentEducationHistories({educationRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteStudentEducationHistory(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetStudentEducationHistoryByEducationRecordId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudentEducationHistory> GetStudentEducationHistoryByEducationRecordId(Int64? educationRecordId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"StudentEducationHistories({educationRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudentEducationHistoryByEducationRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudentEducationHistory>();
        }
        partial void OnUpdateStudentEducationHistory(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateStudentEducationHistory(Int64? educationRecordId = default(Int64?), StudentEducationHistory studentEducationHistory = default(StudentEducationHistory))
        {
            var uri = new Uri(baseUri, $"StudentEducationHistories({educationRecordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", studentEducationHistory.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studentEducationHistory), Encoding.UTF8, "application/json");

            OnUpdateStudentEducationHistory(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteStudySession(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteStudySession(int? studySessionId = default(int?))
        {
            var uri = new Uri(baseUri, $"StudySessions({studySessionId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteStudySession(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetStudySessionByStudySessionId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<StudySession> GetStudySessionByStudySessionId(int? studySessionId = default(int?))
        {
            var uri = new Uri(baseUri, $"StudySessions({studySessionId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetStudySessionByStudySessionId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await response.ReadAsync<StudySession>();
        }
        partial void OnUpdateStudySession(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateStudySession(int? studySessionId = default(int?), StudySession studySession = default(StudySession))
        {
            var uri = new Uri(baseUri, $"StudySessions({studySessionId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", studySession.ETag);

            httpRequestMessage.Content = new StringContent(ODataJsonSerializer.Serialize(studySession), Encoding.UTF8, "application/json");

            OnUpdateStudySession(httpRequestMessage);
            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
