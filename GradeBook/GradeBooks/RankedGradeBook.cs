using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work.");
            }

            List<double> averageGrades = new List<double>(Students.Select(student => student.AverageGrade));
            switch (((double) averageGrades.Count(otherGrade => (otherGrade < averageGrade))) / Students.Count)
            {
                case double ratio when ratio >= 0.8:
                    return 'A';
                case double ratio when ratio >= 0.6:
                    return 'B';
                case double ratio when ratio >= 0.4:
                    return 'C';
                case double ratio when ratio >= 0.2:
                    return 'D';
                default:
                    return 'F';
            }

        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
