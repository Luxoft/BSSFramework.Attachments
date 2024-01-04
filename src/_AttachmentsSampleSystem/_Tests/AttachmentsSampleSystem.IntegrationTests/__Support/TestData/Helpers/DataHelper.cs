using System;

using Framework.Configuration.Domain;
using Framework.Configuration.Generated.DTO;
using Framework.Core;

using AttachmentsSampleSystem.Domain;
using AttachmentsSampleSystem.Domain.Inline;
using AttachmentsSampleSystem.Generated.DTO;

using Automation.ServiceEnvironment;
using Automation.Utils;

namespace AttachmentsSampleSystem.IntegrationTests.__Support.TestData.Helpers
{
    public partial class DataHelper
    {
        public ExceptionMessageIdentityDTO SaveExceptionMessage(
            Guid? id = null,
            string message = null)
        {
            return this.EvaluateWrite(
                context =>
                {
                    var bll = context.Configuration.Logics.ExceptionMessage;
                    var exceptionMessage = bll.GetById(this.GetGuid(id));

                    if (exceptionMessage == null)
                    {
                        exceptionMessage = new ExceptionMessage()
                        {
                            Message = message
                        };

                        bll.Insert(exceptionMessage, this.GetGuid(id));
                    }

                    return exceptionMessage.ToIdentityDTO();
                });
        }

        public LocationIdentityDTO SaveLocation(
            Guid? id = null,
            string name = null,
            LocationIdentityDTO? parent = null,
            bool isFinancial = true,
            int code = 1,
            bool active = true,
            int closeDate = 20)
        {
            name = name ?? TextRandomizer.UniqueString("Location");
            var parentId = parent != null ? ((LocationIdentityDTO)parent).Id : DefaultConstants.LOCATION_PARENT_ID;

            return this.EvaluateWrite(
                context =>
                {
                    var location = context.Logics.Location.GetById(this.GetGuid(id));

                    if (location == null)
                    {
                        location = new Location
                        {
                            Active = active,
                            Name = name,
                            Parent = context.Logics.Location.GetById(parentId),
                        };

                        context.Logics.Location.Insert(location, this.GetGuid(id));
                    }

                    return location.ToIdentityDTO();
                });
        }

        public BusinessUnitIdentityDTO SaveBusinessUnit(
            Guid? id = null,
            string name = null,
            BusinessUnitIdentityDTO? parent = null,
            bool parentIsNeeded = true,
            Period? period = null,
            bool isPool = true,
            bool isNewBusiness = false,
            decimal commision = 0,
            bool isSpecialCommision = false,
            bool isProduction = true,
            int newBusinessStatusLeft = 0,
            int rank = 1,
            bool active = true)
        {
            name = name ?? TextRandomizer.UniqueString("BusinessUnit");

            var parentId = parent != null
                ? ((BusinessUnitIdentityDTO)parent).Id
                : DefaultConstants.BUSINESS_UNIT_PARENT_COMPANY_ID;

            BusinessUnit businessUnit;

            return this.EvaluateWrite(
                context =>
                {
                    period = period ?? new Period(this.FinancialYearService.GetCurrentFinancialYear().StartDate.AddYears(-1));
                    businessUnit = context.Logics.BusinessUnit.GetById(this.GetGuid(id));

                    if (businessUnit == null)
                    {
                        businessUnit =
                            new BusinessUnit(parentIsNeeded ? context.Logics.BusinessUnit.GetById(parentId) : null)
                            {
                                Active = active,
                                Name = name,
                                Parent = context.Logics.BusinessUnit.GetById(parentId),
                                Period = period.Value
                            };

                        context.Logics.BusinessUnit.Insert(businessUnit, this.GetGuid(id));
                    }

                    return businessUnit.ToIdentityDTO();
                });
        }

        public HRDepartmentIdentityDTO SaveHRDepartment(
            Guid? id = null,
            string name = null,
            string nameNative = null,
            HRDepartmentIdentityDTO? parent = null,
            EmployeeIdentityDTO? employee = null,
            string code = null,
            string codeNative = null,
            LocationIdentityDTO? location = null,
            bool isLegal = true,
            bool isProduction = true,
            long externalId = 1,
            bool active = true)
        {
            name = name ?? TextRandomizer.UniqueString("Department");
            nameNative = nameNative ?? name;
            code = code ?? name;
            codeNative = codeNative ?? name;

            var locationId = location != null
                ? ((LocationIdentityDTO)location).Id
                : DefaultConstants.LOCATION_PARENT_ID;

            var parentId = parent != null
                ? ((HRDepartmentIdentityDTO)parent).Id
                : DefaultConstants.HRDEPARTMENT_PARENT_ID;

            return this.EvaluateWrite(
                context =>
                {
                    var department = context.Logics.HRDepartment.GetById(this.GetGuid(id));

                    if (department == null)
                    {
                        var head = employee != null
                            ? context.Logics.Employee.GetById(((EmployeeIdentityDTO)employee).Id)
                            : context.Logics.Employee.GetObjectBy(e => e.Login == this.AuthHelper.GetCurrentUserLogin());

                        department = new HRDepartment
                        {
                            Active = active,
                            Name = name,
                            NameNative = nameNative,
                            Location = context.Logics.Location.GetById(locationId),
                            Parent = context.Logics.HRDepartment.GetById(parentId),
                            Head = head,
                            Code = code,
                            CodeNative = codeNative,
                            IsLegal = isLegal,
                            IsProduction = isProduction,
                            ExternalId = externalId
                        };

                        context.Logics.HRDepartment.Insert(department, this.GetGuid(id));
                    }

                    return department.ToIdentityDTO();
                });
        }
        public Employee SaveEmployee(string name, string login = null)
        {
            var result = this.EvaluateWrite(context =>
            {
                var employee = new Employee() { CellPhone = "2123" };
                employee.NameNative = new Fio { FirstName = name };
                employee.WorkPeriod = new Period(DateTime.Now.AddDays(-1), DateTime.Now);
                employee.EducationDuration = new Period(DateTime.Now.AddYears(-5), DateTime.Now.AddYears(-2));

                if (login != null)
                {
                    employee.Login = login;
                }

                var bll = context.Logics.EmployeeFactory.Create();
                bll.Save(employee);

                return employee;
            });

            return result;
        }
    }
}
