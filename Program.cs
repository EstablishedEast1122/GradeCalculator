using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace PracticeExam
{
    class Program
    {
        static void Main(string[] args)
        {
            string filepath = "Grades.txt";
            string[] contents = File.ReadAllLines(filepath);

            List<Student> students = new List<Student>();

            List<int> allGrades = new List<int>();

            foreach(string line in contents)
            {

                string[] colonSplit = line.Split(":");

                Student student = new Student();

                student.Name = colonSplit[0];

                student.Grades = new List<GradeList>();

                string[] commaSplit = colonSplit[1].Split(",");
                double[] numGrades = Array.ConvertAll(commaSplit, x => double.Parse(x));


                foreach (int indvGrade in numGrades)
                {
                    GradeList gradeList = new GradeList();
                    gradeList.grade = indvGrade;
                    student.Grades.Add(gradeList);
                    allGrades.Add(indvGrade);
                }

                students.Add(student);
               
                int numofF = 0;
                int numofD = 0;
                int numofC = 0;
                int numofB = 0;
                int numofA = 0;

                foreach (double val in numGrades)
                {
                    while (true)
                    {
                        if (val <= 59.9)
                        {
                            numofF++;
                            break;
                        }
                        else if (val <= 69.9)
                        {
                            numofD++;
                            break;
                        }
                        else if (val <= 79.9)
                        {
                            numofC++;
                            break;
                        }
                        else if (val <= 89.9)
                        {
                            numofB++;
                            break;
                        }
                        else
                        {
                            numofA++;
                            break;
                        }
                    }
                }

                Console.WriteLine($"<{line}>");

                Console.WriteLine($"There are {numofA} A's");
                Console.WriteLine($"There are {numofB} B's");
                Console.WriteLine($"There are {numofC} C's");
                Console.WriteLine($"There are {numofD} D's");
                Console.WriteLine($"There are {numofF} F's");
                
                double count = numGrades.Length;
                double min = numGrades.Min();
                double max = numGrades.Max();
                double average = numGrades.Average();

                // This is a lambda statment I can use a val even though I have already decalred it before
                double sumOfSquaresOfDifferences = numGrades.Select(val => (val - average) * (val - average)).Sum();
                double sd = Math.Sqrt(sumOfSquaresOfDifferences / count);

                Console.WriteLine($"Count of {student.Name} grades: {count}");
                Console.WriteLine($"Minimum of {student.Name} grades: {min}");
                Console.WriteLine($"Maximumn of {student.Name} grades: {max}");
                Console.WriteLine($"Average of {student.Name} grades: {Math.Round(average, 2)}%");
                Console.WriteLine($"Standard deviation of {student.Name} grades: {Math.Round(sd, 2)}");
                Console.WriteLine();
            }

            //This will perform the same statistics but for the whole class
            foreach(int num in allGrades)
            {

                
            }
            Stats(allGrades);
            
            double[] Stats(List<int> vs)
            {
                double[] arrayOfStats = new double[] {vs.Min(), vs.Max(), vs.Average()};
                Console.WriteLine(arrayOfStats[0]);
                Console.WriteLine(arrayOfStats[1]);
                Console.WriteLine(Math.Round(arrayOfStats[2], 2));
                return arrayOfStats;
                
            }
            //Console.WriteLine(Stats(allGrades));
        }
    }
}
