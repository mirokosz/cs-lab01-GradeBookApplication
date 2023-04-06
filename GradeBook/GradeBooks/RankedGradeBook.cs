using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Name = name;
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count() < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                double[]table=new double[Students.Count()];
                int i = 0;
                foreach(var student in Students)
                {
                    table[i] = student.AverageGrade; i++;
                }
                bool change;
                do
                {
                    change = false;
                    for(int j=0; j < table.Length - 1;j++)
                    {
                        double cz1 = table[j];
                        double cz2 = table[j+1];
                        if(cz1 > cz2)
                        {
                            table[j] = cz2;
                            table[j+1] = cz1;
                            change = true;
                        }
                    }
                }while (change);
                int pos = -1;
                for (int k=0; k < Students.Count(); k++)
                {
                    if (table[k] == averageGrade) pos = k;
                }
                if (pos>=Students.Count()*0.8)
                    return 'A';
                else if (pos>=Students.Count()*0.6)
                    return 'B';
                else if (pos >= Students.Count() * 0.4)
                    return 'C';
                else if (pos >= Students.Count() * 0.2)
                    return 'D';
                else
                    return 'F';
            }
        }
    }
}
