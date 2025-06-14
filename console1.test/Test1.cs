using System.IO;
using System.Text;
using Moq;


namespace console1.test;

[TestClass]
public sealed class ProgramTests
{

    // StringBuilder _consoleOutput = new StringBuilder();
    // Mock<TextReader> consoleInput;

    [TestInitialize]
    public void Setup()
    {
        // _consoleOutput = new StringBuilder();
        // Console.SetOut(new StringWriter(_consoleOutput));
        // Console.SetIn(consoleInput.Object);
    }

    private string[] RunAndGetConsoleOutput(string[] args, params string[] userResponses)
    {

        //Output
        var _consoleOutput = new StringBuilder();
        Console.SetOut(new StringWriter(_consoleOutput));
        // var consoleOutput = new StringWriter();
        // Console.SetOut(consoleOutput);

        // Run the main method of the Program class
        console1.cmd.Program.Main(args);

        // Capture the console output
        var ret = _consoleOutput.ToString().Split(Environment.NewLine);

        // Return the console output as an array of strings
        return ret;
    }

    // private MockSequence SetupUserResponses(params string[] userResponses)
    // {
    //     var sequence = new MockSequence();
    //     foreach (var response in userResponses)
    //         consoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);

    //     return sequence;
    // }

    [TestMethod]
    public void TestMethod1()
    {

        // SetupUserResponses("input1", "input2");

        var output = RunAndGetConsoleOutput(new[] { "opt1", "opt2" });

        Assert.AreEqual("Hello, World! opt1 opt2", output[0]);

    }

    [TestMethod]
    public void TestMethod2()
    {
        // SetupUserResponses("input1", "input2");

        var output = RunAndGetConsoleOutput(new[] { "arg1", "arg2" });

        Assert.AreEqual("Hello, World! arg1 arg2", output[0]);

    }
}
