using System.IO;
using System.Text;
using Moq;


namespace console1.test;

[TestClass]
public sealed class ProgramTests
{

    StringBuilder _consoleOutput;
    Mock<TextReader> _consoleInput;

    [TestInitialize]
    public void Setup()
    {
        _consoleOutput = new StringBuilder();
        _consoleInput = new Mock<TextReader>();
        Console.SetOut(new StringWriter(_consoleOutput));
        Console.SetIn(_consoleInput.Object);
    }

    private string[] RunAndGetConsoleOutput(string[] args)
    {
        Program.Main(args);
        return _consoleOutput.ToString().Split(Environment.NewLine);
    }

    private MockSequence SetupUserResponses(params string[] userResponses)
    {
        var sequence = new MockSequence();
        foreach (var response in userResponses)
            _consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);

        return sequence;
    }

    [TestMethod]
    public void TestMethod1()
    {
        SetupUserResponses("input1", "input2");
        var output = RunAndGetConsoleOutput(new[] { "arg1", "arg2" });

        Assert.AreEqual("Hello, World! arg1 arg2", output[0]);

    }
}
