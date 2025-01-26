using _2025_02_refactoring;
using JetBrains.Annotations;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _2025_02_refactoring.Tests;

[TestClass]
[TestSubject(typeof(Refactoring))]
public class RefactoringTest
{

    [TestMethod]
    public void shouldRecognizeRefactoringImprovesCodeQuality()
    {
        var refactoring = new Refactoring();
        
        bool actual = refactoring.isImprovingCodeQuality();
        
        Assert.IsTrue(actual);
    }
}