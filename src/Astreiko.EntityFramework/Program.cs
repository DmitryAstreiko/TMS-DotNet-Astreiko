using System;
using Astreiko.EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Astreiko.EntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            var cont = new StrContext.StrContext();

            var ddl = cont.Database.GenerateCreateScript();

            Console.WriteLine(ddl);

            //tms.Database.ExecuteSqlRaw(
            //    @"CREATE VIEW View_HomeworksCounts AS
            //        SELECT s.[Name], Count(s.[StudentId]) as StudentHomeworksCount
            //        FROM [dbo].[homeworks] h
            //        JOIN [dbo].[Students] s on s.[StudentId] = h.[NewStudentId]
            //        GROUP BY s.[Name]");

            var shc = cont.Set<StudentHomeworksCount>().ToArrayAsync().Result;
        }
    }
}
