#pragma checksum "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "07f17d323a1aeafb9319b8ac7a07919223a1ddaf"
// <auto-generated/>
#pragma warning disable 1591
namespace GodswillEduRecord.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\GodswillEduRecord\client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\GodswillEduRecord\client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\GodswillEduRecord\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\GodswillEduRecord\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\GodswillEduRecord\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\GodswillEduRecord\client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\GodswillEduRecord\client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\GodswillEduRecord\client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\GodswillEduRecord\client\_Imports.razor"
using GodswillEduRecord.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\GodswillEduRecord\client\_Imports.razor"
using GodswillEduRecord.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
using GodswillEduRecord.Models.ConData;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
using GodswillEduRecord.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/student-course-payments")]
    public partial class StudentCoursePayments : GodswillEduRecord.Pages.StudentCoursePaymentsComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Radzen.Blazor.RadzenContent>(0);
            __builder.AddAttribute(1, "Container", "main");
            __builder.AddAttribute(2, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Radzen.Blazor.RadzenHeading>(3);
                __builder2.AddAttribute(4, "Size", "H1");
                __builder2.AddAttribute(5, "Text", "Student Course Payments");
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\n    ");
                __builder2.OpenElement(7, "div");
                __builder2.AddAttribute(8, "class", "row");
                __builder2.OpenElement(9, "div");
                __builder2.AddAttribute(10, "class", "col-md-12");
                __builder2.OpenComponent<Radzen.Blazor.RadzenButton>(11);
                __builder2.AddAttribute(12, "Icon", "add_circle_outline");
                __builder2.AddAttribute(13, "style", "margin-bottom: 10px");
                __builder2.AddAttribute(14, "Text", "Add");
                __builder2.AddAttribute(15, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 20 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                               Button0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(16, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenSplitButton>(17);
                __builder2.AddAttribute(18, "Icon", "get_app");
                __builder2.AddAttribute(19, "style", "margin-left: 10px; margin-bottom: 10px");
                __builder2.AddAttribute(20, "Text", "Export");
                __builder2.AddAttribute(21, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.Blazor.RadzenSplitButtonItem>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.Blazor.RadzenSplitButtonItem>(this, 
#nullable restore
#line 22 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                               Splitbutton0Click

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(23);
                    __builder3.AddAttribute(24, "Text", "Excel");
                    __builder3.AddAttribute(25, "Value", "xlsx");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(26, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenSplitButtonItem>(27);
                    __builder3.AddAttribute(28, "Text", "CSV");
                    __builder3.AddAttribute(29, "Value", "csv");
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(30, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenTextBox>(31);
                __builder2.AddAttribute(32, "Placeholder", "Search ...");
                __builder2.AddAttribute(33, "style", "display: block; margin-bottom: 10px; width: 100%");
                __builder2.AddAttribute(34, "Name", "Textbox0");
                __builder2.AddAttribute(35, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 30 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                     async(args) => {search = $"{args.Value}";await grid0.GoToPage(0);await grid0.Reload();}

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(36, "\n        ");
                __builder2.OpenComponent<Radzen.Blazor.RadzenDataGrid<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(37);
                __builder2.AddAttribute(38, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(39, "FilterMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.FilterMode>(
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                       FilterMode.Advanced

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "AllowPaging", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                         true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(41, "AllowSorting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                             true

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(42, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                          getStudentCoursePaymentsResult

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(43, "Count", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                                                                  getStudentCoursePaymentsCount

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(44, "LoadData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.LoadDataArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.LoadDataArgs>(this, 
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                                                                                                                                                                          Grid0LoadData

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(45, "RowSelect", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<GodswillEduRecord.Models.ConData.StudentCoursePayment>(this, 
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                                                                                                                                                                                                     Grid0RowSelect

#line default
#line hidden
#nullable disable
                )));
                __builder2.AddAttribute(46, "Columns", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(47);
                    __builder3.AddAttribute(48, "Property", "PaymentID");
                    __builder3.AddAttribute(49, "Title", "Payment ID");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(50, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(51);
                    __builder3.AddAttribute(52, "Property", "BiodataID");
                    __builder3.AddAttribute(53, "SortProperty", "StudentBiodatum.Surname");
                    __builder3.AddAttribute(54, "FilterProperty", "StudentBiodatum.Surname");
                    __builder3.AddAttribute(55, "Title", "Student Biodatum");
                    __builder3.AddAttribute(56, "Template", (Microsoft.AspNetCore.Components.RenderFragment<GodswillEduRecord.Models.ConData.StudentCoursePayment>)((data) => (__builder4) => {
                        __builder4.AddContent(57, 
#nullable restore
#line 38 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                data.StudentBiodatum?.Surname

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(58, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(59);
                    __builder3.AddAttribute(60, "Property", "CourseOfStudyID");
                    __builder3.AddAttribute(61, "SortProperty", "SchoolCourse.CourseOfStudyName");
                    __builder3.AddAttribute(62, "FilterProperty", "SchoolCourse.CourseOfStudyName");
                    __builder3.AddAttribute(63, "Title", "School Course");
                    __builder3.AddAttribute(64, "Template", (Microsoft.AspNetCore.Components.RenderFragment<GodswillEduRecord.Models.ConData.StudentCoursePayment>)((data) => (__builder4) => {
                        __builder4.AddContent(65, 
#nullable restore
#line 43 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                data.SchoolCourse?.CourseOfStudyName

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(66, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(67);
                    __builder3.AddAttribute(68, "Property", "PaymentDate");
                    __builder3.AddAttribute(69, "FormatString", "{0:dd/MM/yyyy}");
                    __builder3.AddAttribute(70, "Title", "Payment Date");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(71, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(72);
                    __builder3.AddAttribute(73, "Property", "CourseFee");
                    __builder3.AddAttribute(74, "Title", "Course Fee");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(75, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(76);
                    __builder3.AddAttribute(77, "Property", "AmountPaid");
                    __builder3.AddAttribute(78, "Title", "Amount Paid");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(79, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(80);
                    __builder3.AddAttribute(81, "Property", "Balance");
                    __builder3.AddAttribute(82, "Title", "Balance");
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(83, "\n            ");
                    __builder3.OpenComponent<Radzen.Blazor.RadzenDataGridColumn<GodswillEduRecord.Models.ConData.StudentCoursePayment>>(84);
                    __builder3.AddAttribute(85, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 54 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                            false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(86, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 54 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                             false

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(87, "Width", "70px");
                    __builder3.AddAttribute(88, "TextAlign", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.TextAlign>(
#nullable restore
#line 54 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                                            TextAlign.Center

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(89, "Template", (Microsoft.AspNetCore.Components.RenderFragment<GodswillEduRecord.Models.ConData.StudentCoursePayment>)((godswillEduRecordModelsConDataStudentCoursePayment) => (__builder4) => {
                        __builder4.OpenComponent<Radzen.Blazor.RadzenButton>(90);
                        __builder4.AddAttribute(91, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 56 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                           ButtonStyle.Danger

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(92, "Icon", "close");
                        __builder4.AddAttribute(93, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonSize>(
#nullable restore
#line 56 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                  ButtonSize.Small

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(94, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 56 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                             (args) =>GridDeleteButtonClick(args, godswillEduRecordModelsConDataStudentCoursePayment)

#line default
#line hidden
#nullable disable
                        )));
                        __builder4.AddEventStopPropagationAttribute(95, "onclick", 
#nullable restore
#line 56 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                                                                                                                                                                                                                                  true

#line default
#line hidden
#nullable disable
                        );
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddComponentReferenceCapture(96, (__value) => {
#nullable restore
#line 32 "C:\GodswillEduRecord\client\Pages\StudentCoursePayments.razor"
                              grid0 = (Radzen.Blazor.RadzenDataGrid<GodswillEduRecord.Models.ConData.StudentCoursePayment>)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
