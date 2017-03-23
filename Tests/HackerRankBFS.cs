using System;
using NUnit.Framework;
using Library;
using System.Collections.Generic;
using System.IO;

namespace Tests {
[TestFixture]
    public class HackerRankBFS {
        [Test]
        public void HackerRankBFS1() {
            // first hackerrank example
            // arrange
            var _sut = new Graph();
            var n = 4;
            var m = 2; // not interesting really
            for (int i = 1; i <= n; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(1, 2);
            _sut.AddEdge(1, 3);
            var start = 1;
            // act
            var result = new List<Int32> ();
            for (int i = 1; i <= n; i++) {
                if (i == start) { continue; }
                var r = _sut.GetNumberOfSteps(start, i);
                result.Add( r == -1 ? -1 : r * 6);
            }
            // assert
            var expected = new Int32[3] { 6, 6, -1 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void HackerRankBFS2() {
            // arrange
            var _sut = new Graph();
            var n = 3;
            var m = 1; // not interesting really
            for (int i = 1; i <= n; i++) {
                _sut.AddVertice(i);
            }
            _sut.AddEdge(2, 3);
            var s = 2;
            // act
            var result = new List<Int32>();
            for (int i = 1; i <= n; i++) {
                if (i == s) { continue; }
                var r = _sut.GetNumberOfSteps(s, i);
                result.Add(r == -1 ? -1 : r * 6);
            }
            // assert
            var expected = new Int32[2] { -1, 6 };
            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void TestMethod3() {
            // arrange
            String line;
            // Read the file and display it line by line.
            var fullPath = Directory.GetCurrentDirectory();
            var path = Path.GetFullPath(Path.Combine(fullPath, "Tests"));
            System.IO.StreamReader file = new System.IO.StreamReader(Path.Combine(path,"BFSinput.txt"));
            while ((line = file.ReadLine()) != null) {
                // n of queries
                var q = Convert.ToInt32(line);
                var result = new List<Int32>[q];



                for (int j = 0; j < q; j++) {
                    var l1 = file.ReadLine();
                    var n = Convert.ToInt32(l1.Split(' ')[0]);
                    var m = Convert.ToInt32(l1.Split(' ')[1]);

                    // create graph
                    var graph = new Graph();
                    // add vertices to graph
                    for (int i = 1; i <= 1000; i++) {
                        graph.AddVertice(i);
                    }
                    // add edges to graph
                    for (int i = 0; i < m; i++) {
                        l1 = file.ReadLine();
                        graph.AddEdge(
                            Convert.ToInt32(l1.Split(' ')[0]),
                            Convert.ToInt32(l1.Split(' ')[1]));
                    }
                    // get s
                    l1 = file.ReadLine();
                    var s = Convert.ToInt32(l1);
                    var localrResult = new List<Int32>();
                    for (int i = 1; i <= n; i++) {
                        if (i == s) { continue; }
                        var r = graph.GetNumberOfSteps(s, i);
                        localrResult.Add(r == -1 ? -1 : r * 6);
                    }
                    result[j] = localrResult;
                }


            }
            // make sure it can read the test input
            Assert.AreEqual(1, 1);
        }
    }
}
