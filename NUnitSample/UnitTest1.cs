namespace NUnit.Tests
{
    namespace Assemblies
    {
        [Category("FixtureCategory")]
        [Description("Fake Test Fixture")]
        public class MockTestFixture
        {
            // fail
            [Test]
            public void FailingTest()
            {
                Assert.Fail();
            }

            // inconclusive
            [Test]
            public void InconclusiveTest()
            {
                Assert.Inconclusive();
            }

            // description
            [Test]
            [Description("Mock Test #1")]
            public void MockTest1()
            {
            }

            // priority second category
            [Test]
            [Property("Severity", "Critical")]
            [Category("MockCategory")]
            [Description("This is a really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really, really long description")]
            public void MockTest2()
            {
            }

            // multiple categories
            [Test]
            [Category("AnotherCategory")]
            [Category("MockCategory")]
            public void MockTest3()
            {
            }

            // ignore
            [Test]
            [Ignore("Ignored")]
            [Category("Foo")]
            public void MockTest4()
            {
            }

            // not runnable?
            [Test]
#pragma warning disable NUnit1026 // The test or setup/teardown method is not public
            internal void MockTest5()
#pragma warning restore NUnit1026 // The test or setup/teardown method is not public
            {
            }

#pragma warning disable NUnit1027 // The test method has parameters, but no arguments are supplied by attributes
            [Test]
#pragma warning restore NUnit1027 // The test method has parameters, but no arguments are supplied by attributes
            public void NotRunnable(string name)
            {
            }

            // with exception
            [Test]
            public void TestWithException()
            {
                throw new NotImplementedException();
            }

            // test with many properties
            [Test]
            [Property("TargetMethod", "SomeClassName")]
            [Property("Size", "5")]
            public void TestWithManyProperties()
            {
            }
        }
    }

    [TestFixture]
    public class BadFixture
    {
        // no suitable constructor
        public BadFixture(string invalid) { }

        [Test]
        public void Test() { }
    }
    

    [TestFixture]
    public class FixtureWithTestCases
    {
        [TestCase(2,2)]
        [TestCase(9,11)]
        public void MethodWithParameters(int arg1, int arg2)
        {
        }
    }

    [TestFixture]
    [Ignore("")]
    public class IgnoredFixture
    {
        [Test]
        public void Test1() { }

        [Test]
        public void Test2() { }

        [Test]
        public void Test3() { }

    }

    [TestFixture(42)]
    [TestFixture(5)]
    public class ParameterizedFixture
    {
        public ParameterizedFixture(int name) { }

        [Test]
        public void Test1() { }

        [Test]
        public void Test2() { }
    }

    namespace Singletons
    {
        [TestFixture]
        public static class OneTestCase
        {
            [Test]
            public static void TestCase()
            {

            }
        }
    }

    namespace TestAssembly
    {
        [TestFixture]
        public class MockTestFixture
        {
            [Test]
            public void MyTest() { }
        }

        [TestFixture]
        public class AttachmentsFixture
        {
            [Test]
            public void TestOneAttachment()
            {
                SaveAttachment("c:\\dev\\code\\_Experiments\\NUnitSample\\NUnitSample\\dummy.txt", "my description");
            }

            //[Test]
            //public void TestTwoAttachments()
            //{
            //    var files = new string[]
            //      {
            //        "C:\\dev\\code\\_Experiments\\NUnitSample\\NUnitSample\\dummy2.txt",
            //        "C:\\dev\\code\\_Experiments\\NUnitSample\\NUnitSample\\dummy3.txt",
            //      };
            //    foreach (var file in files)
            //    {
            //        SaveAttachment(file);
            //    }
            //}

            private void SaveAttachment(string source, string? description = null)
            {
                if (File.Exists(source))
                {
                    description ??= Path.GetFileName(source);
                    // add attachment
                    TestContext.AddTestAttachment(source, description);
                }

            }
        }
    }

 
}