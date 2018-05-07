using AWSServerlessWebApi.Models;
using AWSServerlessWebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Data
{
    public class Seeder
    {
        private KORE_Interactive_MSCRMContext _context;

        public Seeder(KORE_Interactive_MSCRMContext context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if (_context.AccountBase.Any())
            {
                return;
            }
            var clients = new AccountBase[]
            {
                new AccountBase { AccountId = Guid.NewGuid(), Name = "Calgary Flames", DeletionStateCode = 0, StateCode = 0 },
                new AccountBase { AccountId = Guid.NewGuid(), Name = "Vancouver Canucks", DeletionStateCode = 0, StateCode = 0 },
                new AccountBase { AccountId = Guid.NewGuid(), Name = "Winnipeg Jets", DeletionStateCode = 0, StateCode = 0 }
            };
            foreach (AccountBase a in clients)
            {
                _context.AccountBase.Add(a);
            }
            _context.SaveChanges();

            if (_context.NewProjectTypeExtensionBase.Any())
            {
                return;
            }
            var projectTypes = new NewProjectTypeExtensionBase[]
            {
                new NewProjectTypeExtensionBase
                {
                    NewProjectTypeId = Guid.NewGuid(),
                    NewName = "Sports related"
                }
            };
            foreach (NewProjectTypeExtensionBase t in projectTypes)
            {
                _context.NewProjectTypeExtensionBase.Add(t);
            }
            _context.SaveChanges();

            if (_context.NewProjectExtensionBase.Any())
            {
                return;
            }
            var projects = new NewProjectExtensionBase[]
            {
                new NewProjectExtensionBase { NewProjectId = Guid.NewGuid(),
                                              NewName = "Project Calgary",
                                              NewStartDate = new DateTime(2018, 01, 20, 01, 01, 01),
                                              NewEndDate =  new DateTime(2018, 01, 30, 02, 02, 02),
                                              NewAccountId = clients.Single(c => c.Name == "Calgary Flames").AccountId,
                                              NewProjectTypeId = projectTypes.Single(t => t.NewName == "Sports related").NewProjectTypeId },
                new NewProjectExtensionBase { NewProjectId = Guid.NewGuid(),
                                              NewName = "Project Vancouver",
                                              NewStartDate = new DateTime(2018, 02, 20, 01, 01, 01),
                                              NewEndDate = new DateTime(2018, 02, 27, 02, 02, 02),
                                              NewAccountId = clients.Single(c => c.Name == "Vancouver Canucks").AccountId,
                                              NewProjectTypeId = projectTypes.Single(t => t.NewName == "Sports related").NewProjectTypeId },
                new NewProjectExtensionBase { NewProjectId = Guid.NewGuid(),
                                              NewName = "Project Winnipeg",
                                              NewStartDate = new DateTime(2018, 03, 20, 01, 01, 01),
                                              NewEndDate = new DateTime(2018, 03, 30, 02, 02, 02),
                                              NewAccountId = clients.Single(c => c.Name == "Winnipeg Jets").AccountId,
                                              NewProjectTypeId = projectTypes.Single(t => t.NewName == "Sports related").NewProjectTypeId }
            };
            foreach (NewProjectExtensionBase p in projects)
            {
                _context.NewProjectExtensionBase.Add(p);
            }
            _context.SaveChanges();

            if (_context.NewChangeRequestExtensionBase.Any())
            {
                return;
            }
            var workBreakdownItems = new NewChangeRequestExtensionBase[]
            {
                new NewChangeRequestExtensionBase { NewChangeRequestId = Guid.NewGuid(),
                                                    NewRemarks = "Calgary's Finance",
                                                    NewEstimatedHours = 999,
                                                    NewActualHours = 20,
                                                    NewProjectId = projects.Single(p => p.NewName == "Project Calgary").NewProjectId},
                new NewChangeRequestExtensionBase { NewChangeRequestId = Guid.NewGuid(),
                                                    NewRemarks = "Calgary's Management",
                                                    NewEstimatedHours = 999,
                                                    NewActualHours = 30,
                                                    NewProjectId = projects.Single(p => p.NewName == "Project Calgary").NewProjectId},
                new NewChangeRequestExtensionBase { NewChangeRequestId = Guid.NewGuid(),
                                                    NewRemarks = "Vancouver's Finance",
                                                    NewEstimatedHours = 999,
                                                    NewActualHours = 20,
                                                    NewProjectId = projects.Single(p => p.NewName == "Project Vancouver").NewProjectId},
                new NewChangeRequestExtensionBase { NewChangeRequestId = Guid.NewGuid(),
                                                    NewRemarks = "Vancouver's Management",
                                                    NewEstimatedHours = 999,
                                                    NewActualHours = 30,
                                                    NewProjectId = projects.Single(p => p.NewName == "Project Vancouver").NewProjectId},
                new NewChangeRequestExtensionBase { NewChangeRequestId = Guid.NewGuid(),
                                                    NewRemarks = "Winnipeg's Finance",
                                                    NewEstimatedHours = 999,
                                                    NewActualHours = 20,
                                                    NewProjectId = projects.Single(p => p.NewName == "Project Winnipeg").NewProjectId},
                new NewChangeRequestExtensionBase { NewChangeRequestId = Guid.NewGuid(),
                                                    NewRemarks = "Winnipeg's Management",
                                                    NewEstimatedHours = 999,
                                                    NewActualHours = 30,
                                                    NewProjectId = projects.Single(p => p.NewName == "Project Winnipeg").NewProjectId},
            };
            foreach (NewChangeRequestExtensionBase w in workBreakdownItems)
            {
                _context.NewChangeRequestExtensionBase.Add(w);
            }
            _context.SaveChanges();

            if (_context.Users.Any())
            {
                return;
            }
            var users = new User[]
            {
                new User { UserId = Guid.NewGuid(),
                           Email = "bob@home.com",
                           Password = "password",
                           FirstName = "Bob",
                           LastName = "Jones" },
                new User { UserId = Guid.NewGuid(),
                           Email = "sally@home.com",
                           Password = "password",
                           FirstName = "Sally",
                           LastName = "Smith" }
            };
            foreach (User u in users)
            {
                _context.Users.Add(u);
            }
            _context.SaveChanges();


            if (_context.NewTimesheetEntryExtensionBase.Any())
            {
                return;
            }
            var timeslips = new NewTimesheetEntryExtensionBase[]
            {
                new NewTimesheetEntryExtensionBase
                {
                    NewTimesheetEntryId = Guid.NewGuid(),
                    NewStartTask = DateTime.ParseExact("2018-04-20 08:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    NewEndTask = DateTime.ParseExact("2018-04-20 11:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    NewRemarks = "Test Remark",
                    NewChangeRequestId = workBreakdownItems.Single(w => w.NewRemarks == "Calgary's Finance").NewChangeRequestId,
                    OwningUser = users.Single(u => u.Email == "bob@home.com").UserId
                },
                new NewTimesheetEntryExtensionBase
                {
                    NewTimesheetEntryId = Guid.NewGuid(),
                    NewStartTask = DateTime.ParseExact("2018-04-20 13:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    NewEndTask = DateTime.ParseExact("2018-04-20 16:00", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
                    NewRemarks = "Test Remark two",
                    NewChangeRequestId = workBreakdownItems.Single(w => w.NewRemarks == "Vancouver's Finance").NewChangeRequestId,
                    OwningUser = users.Single(u => u.Email == "sally@home.com").UserId
                },
            };
            foreach (NewTimesheetEntryExtensionBase t in timeslips)
            {
                _context.NewTimesheetEntryExtensionBase.Add(t);
            }
            _context.SaveChanges();

            if (_context.CustomDays.Any())
            {
                return;
            }
            var customMonday = new CustomDay
            {
                CustomDayId = "aosidjf",
                Name = "My Monday",
                Description = "This is my typical monday",
                UserId = _context.Users.FirstOrDefault().UserId
            };
            _context.CustomDays.Add(customMonday);
            _context.SaveChanges();

            if (_context.Timeslip_Templates.Any())
            {
                return;
            }
            var timeslipTemplates = new CustomDay_WBI[]
            {
                new CustomDay_WBI
                {
                    TimeslipTemplateId = "testId1",
                    NewChangeRequestId = workBreakdownItems.Single(w => w.NewRemarks == "Calgary's Finance").NewChangeRequestId,
                    CustomDayId = customMonday.CustomDayId,
                    StartTime = DateTime.ParseExact("08:00", "HH:mm", CultureInfo.InvariantCulture),
                    EndTime = DateTime.ParseExact("11:00", "HH:mm", CultureInfo.InvariantCulture),
                    Remarks = "This is a test remark on morning timeslip template"
                },
                new CustomDay_WBI
                {
                    TimeslipTemplateId = "testId2",
                    NewChangeRequestId = workBreakdownItems.Single(w => w.NewRemarks == "Vancouver's Finance").NewChangeRequestId,
                    CustomDayId = customMonday.CustomDayId,
                    StartTime = DateTime.ParseExact("13:00", "HH:mm", CultureInfo.InvariantCulture),
                    EndTime = DateTime.ParseExact("16:00", "HH:mm", CultureInfo.InvariantCulture),
                    Remarks = "This is a test remark on afternoon timeslip template"
                },
            };
            foreach (CustomDay_WBI c in timeslipTemplates)
            {
                _context.Timeslip_Templates.Add(c);
            }
            _context.SaveChanges();
        }

        public void SeedStringMap()
        {
            if (_context.StringMap.Any())
            {
                return;
            }

            var filepath = "string-map-data.csv";
            var readcsv = File.ReadAllText(filepath);
            string[] csvfilerecord = readcsv.Split('\n');

            foreach (var row in csvfilerecord)
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var cells = row.Split(',');

                    var stringmaps = new StringMap[]
                    {
                        new StringMap
                        {
                            ObjectTypeCode = Convert.ToInt32(cells[0]),
                            AttributeName = cells[1],
                            AttributeValue = Convert.ToInt32(cells[2]),
                            LangId = Convert.ToInt32(cells[3]),
                            OrganizationId = Guid.Parse(cells[4]),
                            Value = cells[5],
                            DisplayOrder = Convert.ToInt32(cells[6]),
                            Rowguid = Guid.Parse(cells[7]),
                            VersionNumber = Encoding.UTF8.GetBytes(cells[8]),
                            StringMapId = Guid.Parse(cells[9])
                        }
                    };
                    foreach ( StringMap s in stringmaps)
                    {
                        _context.StringMap.Add(s);
                    }
                    _context.SaveChanges();
                }
            }
        }
    }
}
