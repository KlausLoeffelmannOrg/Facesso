using System;
using System.Reflection;
using Xunit;
using Xunit.v3;

namespace Facesso.Tests.Infrastructure
{
    /// <summary>
    /// Automatically logs test start, end, duration, and pass/fail status
    /// to the central <see cref="TestRunLogger"/>.
    /// Applied globally via [assembly: TestRunLog].
    /// </summary>
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Method)]
    public sealed class TestRunLogAttribute : BeforeAfterTestAttribute
    {
        public override void Before(MethodInfo methodUnderTest, IXunitTest test)
        {
            TestRunLogger.TestStarted(FormatTestName(methodUnderTest));
        }

        public override void After(MethodInfo methodUnderTest, IXunitTest test)
        {
            string outcome = "DONE";
            try
            {
                var result = TestContext.Current?.TestState?.Result;
                if (result == TestResult.Passed) outcome = "PASSED";
                else if (result == TestResult.Failed) outcome = "FAILED";
                else if (result == TestResult.Skipped) outcome = "SKIPPED";
            }
            catch
            {
                // TestContext not available
            }

            TestRunLogger.TestFinished(FormatTestName(methodUnderTest), outcome);
        }

        private static string FormatTestName(MethodInfo method)
            => $"{method.DeclaringType?.Name}.{method.Name}";
    }
}
