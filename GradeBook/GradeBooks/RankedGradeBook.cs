using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("You must have at least 5 students to do ranked grading.");
            }

            var  Calc = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (averageGrade >= grades[Calc - 1])
                return 'A';
            if (averageGrade >= grades[(Calc * 2) - 1])
                return 'B';
            if (averageGrade >= grades[(Calc * 3) - 1])
                return 'C';
            if (averageGrade >= grades[(Calc * 4) - 1])
                return 'D';
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked granding requires atleast 5 stundets.");
                return;
            }

            base.CalculateStatistics();

        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked granding requires atleast 5 stundets.");
                return;
            }

            base.CalculateStatistics();

        }




    }
}
