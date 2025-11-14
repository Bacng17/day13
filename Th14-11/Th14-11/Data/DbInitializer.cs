using Microsoft.EntityFrameworkCore;
using Th14_11.Models;

namespace Th14_11.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SchoolContext(
                serviceProvider.GetRequiredService<DbContextOptions<SchoolContext>>()))
            {
                context.Database.EnsureCreated();

                // Nếu đã có dữ liệu thì không seed nữa
                if (context.Majors.Any())
                {
                    return;
                }

                // ===== Seed Major =====
                var majors = new Major[]
                {
                    new Major { MajorName = "IT" },
                    new Major { MajorName = "Economics" },
                    new Major { MajorName = "Mathematics" }
                };

                foreach (var m in majors)
                {
                    context.Majors.Add(m);
                }
                context.SaveChanges();

                // ===== Seed Learner =====
                var learners = new Learner[]
                {
                    new Learner {
                        FirstMidName = "Carson",
                        LastName = "Alexander",
                        EnrollmentDate = DateTime.Parse("2005-09-01"),
                        MajorID = 1
                    },
                    new Learner {
                        FirstMidName = "Meredith",
                        LastName = "Alonso",
                        EnrollmentDate = DateTime.Parse("2002-09-01"),
                        MajorID = 2
                    }
                };

                foreach (var l in learners)
                {
                    context.Learners.Add(l);
                }
                context.SaveChanges();

                // ===== Seed Course =====
                var courses = new Course[]
                {
                    new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                    new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                    new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
                };

                foreach (var c in courses)
                {
                    context.Courses.Add(c);
                }
                context.SaveChanges();

                // ===== Seed Enrollment =====
                var enrollments = new Enrollment[]
                {
                    new Enrollment { LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                    new Enrollment { LearnerID = 1, CourseID = 4022, Grade = 8f },
                    new Enrollment { LearnerID = 2, CourseID = 1050, Grade = 6f },
                    new Enrollment { LearnerID = 2, CourseID = 4041, Grade = 7f }
                };

                foreach (var e in enrollments)
                {
                    context.Enrollments.Add(e);
                }
                context.SaveChanges();
            }
        }

    }
}
