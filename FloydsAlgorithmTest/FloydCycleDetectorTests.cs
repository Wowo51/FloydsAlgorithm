using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FloydsAlgorithm;

namespace FloydsAlgorithmTest
{
    [TestClass]
    public class FloydCycleDetectorTests
    {
        [TestMethod]
        public void TestImmediateCycle()
        {
            int start = 42;
            Func<int, int> f = delegate (int x)
            {
                return x;
            };
            CycleDetectionResult<int> result = FloydCycleDetector.FindCycle<int>(start, f);
            Assert.AreEqual(start, result.CycleStart, "CycleStart should be the same as start");
            Assert.AreEqual(0, result.NonCycleLength, "NonCycleLength should be 0 for self-cycle");
            Assert.AreEqual(1, result.CycleLength, "CycleLength should be 1 for self-cycle");
        }

        [TestMethod]
        public void TestModCycle()
        {
            int start = 0;
            Func<int, int> f = delegate (int x)
            {
                return (x + 1) % 10;
            };
            CycleDetectionResult<int> result = FloydCycleDetector.FindCycle<int>(start, f);
            Assert.AreEqual(0, result.CycleStart, "CycleStart should be 0");
            Assert.AreEqual(0, result.NonCycleLength, "NonCycleLength should be 0 in mod cycle");
            Assert.AreEqual(10, result.CycleLength, "CycleLength should be 10 in mod cycle");
        }

        [TestMethod]
        public void TestNonTrivialCycle()
        {
            IDictionary<int, int> mapping = new Dictionary<int, int>();
            mapping.Add(1, 2);
            mapping.Add(2, 3);
            mapping.Add(3, 4);
            mapping.Add(4, 5);
            mapping.Add(5, 3);
            int start = 1;
            Func<int, int> f = delegate (int x)
            {
                return mapping[x];
            };
            CycleDetectionResult<int> result = FloydCycleDetector.FindCycle<int>(start, f);
            Assert.AreEqual(3, result.CycleStart, "CycleStart should be 3");
            Assert.AreEqual(2, result.NonCycleLength, "NonCycleLength should be 2");
            Assert.AreEqual(3, result.CycleLength, "CycleLength should be 3");
        }

        [TestMethod]
        public void TestStringCycle()
        {
            string start = "a";
            Func<string, string> f = delegate (string s)
            {
                return s;
            };
            CycleDetectionResult<string> result = FloydCycleDetector.FindCycle<string>(start, f);
            Assert.AreEqual("a", result.CycleStart, "CycleStart should be 'a'");
            Assert.AreEqual(0, result.NonCycleLength, "NonCycleLength should be 0");
            Assert.AreEqual(1, result.CycleLength, "CycleLength should be 1");
        }
    }
}