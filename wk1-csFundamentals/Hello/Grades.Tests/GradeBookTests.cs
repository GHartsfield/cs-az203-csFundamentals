using System;
using Xunit;

namespace Grades.Tests {
    public class GradeBookTests {
        [Fact]
        public void TestHighestGrade() {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.Equal(90,result.HighestGrade);
        }
        [Fact]
        public void TestLowestGrade() {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.Equal(10,result.LowestGrade);
        }
        [Fact]
        public void TestAverageGrade() {
            GradeBook book = new GradeBook();
            book.AddGrade(10);
            book.AddGrade(90);
            book.AddGrade(60.5f);

            GradeStatistics result = book.ComputeStatistics();
            Assert.True(53.5.Equals(result.AverageGrade));
            //Assert.Equal(53.5, result.AverageGrade,0.01);
        }
    }

    public class ReferenceTests {
        /*
        [Fact]
        public void TestReferenceVar1() {
            GradeBook gb1 = new GradeBook();
            GradeBook gb2 = gb1;

            gb1.Name = "Geoff's Grade Book";
            Assert.Equal(gb1.Name,gb2.Name);
        }
        */
        [Fact]
        public void TestStrings() {
            string one = "Test";
            string two = "test";

            bool result = String.Equals(one,two,StringComparison.InvariantCultureIgnoreCase);
            Assert.True(result);
        }
    }

    public class TypeTests {
        /*
        [Fact]
        public void RefTypesPassByValue() {
            GradeBook gb1 = new GradeBook();
            GradeBook gb2 = gb1;

            GiveBookAName(gb2);
            Assert.Equal("GB Name",gb1.Name);
        }
        */
        private void GiveBookAName(GradeBook gb) {
            gb.Name = "GB Name";
        }

        [Fact]
        public void ValueTypesPassByValue() {
            int x = 1;
            IncrementNumber(x);
            Assert.Equal(1,x);
        }

        private void IncrementNumber(int num) {
            num += 1;
        }
        [Fact]
        public void ArrayTest() {
            int[] nums = new int[] { 1,2,3,4 };
            int selection = nums[1];
            Assert.Equal(2,selection);
        }
        [Fact]
        public void ArrayTest2() {
            string[] words = new string[] { "test","test2","test3" };
            string selection = words[0];
            Assert.Equal("test",selection);
        }
    }

    public class FileTests {
        [Fact]
        public void FileOutTest() {
            string[] lines = { "Line One","Line Two","Line Three" };
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\temp\fileTest.txt")) {
                foreach (string line in lines) {
                    if (!line.Contains("Two")) {
                        file.WriteLine(line);
                    }
                }
            }
            Assert.True(System.IO.File.Exists(@"C:\temp\fileTest.txt"));
        }
    }
}
