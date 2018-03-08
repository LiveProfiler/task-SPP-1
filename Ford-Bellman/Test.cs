using NUnit.Framework;

namespace Ford_Bellman
{
    [TestFixture]
    class Test
    {
        [Test]
        public void StandartTest()
        {
            var input = new[]
            {
                "4",
                "-32768 25 4 -32768",
                "-32768 -32768 -32768 -32768",
                "-32768 0 -32768 7",
                "-32768 -32768 -32768 -32768",
                "1",
                "4"
            };
            var expected = new[]
            {
                "Y",
                "1 3 4",
                "28"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void TestWithCycle()
        {
            var input = new[]
            {
                "4",
                "-32768 -32768 4 -32768",
                "25 -32768 -32768 -32768",
                "-32768 0 -32768 7",
                "-32768 -32768 -32768 -32768",
                "1",
                "4"
            };
            var expected = new[]
            {
                "Y",
                "1 3 4",
                "28"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void StandartTestWithNewEdge()
        {
            var input = new[]
            {
                "4",
                "-32768 -32768 4 -32768",
                "25 -32768 -32768 -32768",
                "-32768 0 -32768 7",
                "-32768 2 -32768 -32768",
                "1",
                "2"
            };
            var expected = new[]
            {
                "Y",
                "1 3 4 2",
                "56"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void TestWithBigCycle()
        {
            var input = new[]
            {
                "4",
                "-32768 2 -32768 -32768",
                "-32768 -32768 2 -32768",
                "-32768 -32768 -32768 2",
                "2 -32768 -32768 -32768",
                "1",
                "3"
            };
            var expected = new[]
            {
                "Y",
                "1 2 3",
                "4"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void NegativeTest()
        {
            var input = new[]
            {
                "3",
                "-32768 1 -32768",
                "1 -32768 -32768",
                "1 1 -32768",
                "1",
                "3"
            };
            var expected = new[]
            {
                "N"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void TestWithIsolatedEnd()
        {
            var input = new[]
            {
                "4",
                "-32768 4 4 -32768",
                "-32768 -32768 -32768 -32768",
                "-32768 -32768 -32768 -32768",
                "4 -32768 -32768 -32768",
                "1",
                "4"
            };
            var expected = new[]
            {
                "N"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void TestWithSingleWay()
        {
            var input = new[]
            {
                "4",
                "-32768 4 4 7",
                "-32768 -32768 -32768 -32768",
                "-32768 -32768 -32768 -32768",
                "4 -32768 -32768 -32768",
                "1",
                "4"
            };
            var expected = new[]
            {
                "Y",
                "1 4",
                "7"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }

        [Test]
        public void TestWithTriangle()
        {
            var input = new[]
            {
                "4",
                "-32768 4 4 7",
                "-32768 -32768 -32768 -32768",
                "-32768 -32768 -32768 4",
                "4 -32768 -32768 -32768",
                "1",
                "4"
            };
            var expected = new[]
            {
                "Y",
                "1 3 4",
                "16"
            };
            Assert.AreEqual(expected, Solver.Solve(input));
        }
    }
}
