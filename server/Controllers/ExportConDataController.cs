using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GodswillEduRecord.Data;

namespace GodswillEduRecord
{
    public partial class ExportConDataController : ExportController
    {
        private readonly ConDataContext context;

        public ExportConDataController(ConDataContext context)
        {
            this.context = context;
        }
        [HttpGet("/export/ConData/genders/csv")]
        [HttpGet("/export/ConData/genders/csv(fileName='{fileName}')")]
        public FileStreamResult ExportGendersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Genders, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/genders/excel")]
        [HttpGet("/export/ConData/genders/excel(fileName='{fileName}')")]
        public FileStreamResult ExportGendersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Genders, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/nextofkins/csv")]
        [HttpGet("/export/ConData/nextofkins/csv(fileName='{fileName}')")]
        public FileStreamResult ExportNextOfKinsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.NextOfKins, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/nextofkins/excel")]
        [HttpGet("/export/ConData/nextofkins/excel(fileName='{fileName}')")]
        public FileStreamResult ExportNextOfKinsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.NextOfKins, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/qualifications/csv")]
        [HttpGet("/export/ConData/qualifications/csv(fileName='{fileName}')")]
        public FileStreamResult ExportQualificationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Qualifications, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/qualifications/excel")]
        [HttpGet("/export/ConData/qualifications/excel(fileName='{fileName}')")]
        public FileStreamResult ExportQualificationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Qualifications, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/relationships/csv")]
        [HttpGet("/export/ConData/relationships/csv(fileName='{fileName}')")]
        public FileStreamResult ExportRelationshipsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Relationships, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/relationships/excel")]
        [HttpGet("/export/ConData/relationships/excel(fileName='{fileName}')")]
        public FileStreamResult ExportRelationshipsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Relationships, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/schoolcourses/csv")]
        [HttpGet("/export/ConData/schoolcourses/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSchoolCoursesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SchoolCourses, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/schoolcourses/excel")]
        [HttpGet("/export/ConData/schoolcourses/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSchoolCoursesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SchoolCourses, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/states/csv")]
        [HttpGet("/export/ConData/states/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.States, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/states/excel")]
        [HttpGet("/export/ConData/states/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.States, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/studentbiodata/csv")]
        [HttpGet("/export/ConData/studentbiodata/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStudentBiodataToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.StudentBiodata, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/studentbiodata/excel")]
        [HttpGet("/export/ConData/studentbiodata/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStudentBiodataToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.StudentBiodata, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/studentcoursepayments/csv")]
        [HttpGet("/export/ConData/studentcoursepayments/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStudentCoursePaymentsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.StudentCoursePayments, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/studentcoursepayments/excel")]
        [HttpGet("/export/ConData/studentcoursepayments/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStudentCoursePaymentsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.StudentCoursePayments, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/studentcourseregistrations/csv")]
        [HttpGet("/export/ConData/studentcourseregistrations/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStudentCourseRegistrationsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.StudentCourseRegistrations, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/studentcourseregistrations/excel")]
        [HttpGet("/export/ConData/studentcourseregistrations/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStudentCourseRegistrationsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.StudentCourseRegistrations, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/studenteducationhistories/csv")]
        [HttpGet("/export/ConData/studenteducationhistories/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStudentEducationHistoriesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.StudentEducationHistories, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/studenteducationhistories/excel")]
        [HttpGet("/export/ConData/studenteducationhistories/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStudentEducationHistoriesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.StudentEducationHistories, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/studysessions/csv")]
        [HttpGet("/export/ConData/studysessions/csv(fileName='{fileName}')")]
        public FileStreamResult ExportStudySessionsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.StudySessions, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/studysessions/excel")]
        [HttpGet("/export/ConData/studysessions/excel(fileName='{fileName}')")]
        public FileStreamResult ExportStudySessionsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.StudySessions, Request.Query), fileName);
        }
    }
}
