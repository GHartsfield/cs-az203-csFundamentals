using System;
using System.Collections.Generic;
using System.Text;

namespace Grades {
    public class RemoveLowestGradeBook : GradeBook {
        public override GradeStatistics ComputeStatistics () {
            float lowest = float.MaxValue;
            foreach (float grade in grades) {
                lowest = Math.Min(grade,lowest);
            }
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
