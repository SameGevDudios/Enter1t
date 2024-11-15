using UnityEngine;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

public class RunPython : MonoBehaviour
{

    private ScriptEngine _scriptEngine;
    private ScriptScope _scriptScope;

    #region Singleton
    public static RunPython Instance;
    private void Awake() =>
        Instance = this;
    #endregion

    private void Start()
    {
        InitializePython();
        print(RunCode("print('Hello Unity!')"));
    }
    private void InitializePython()
    {
        _scriptEngine = Python.CreateEngine();
        _scriptScope = _scriptEngine.CreateScope();
    }
    public string RunCode(string code)
    {
        try
        {
            // Redirect the standard output to capture printed text
            var stream = new System.IO.MemoryStream();
            var writer = new System.IO.StreamWriter(stream);
            _scriptEngine.Runtime.IO.SetOutput(stream, writer);

            _scriptEngine.Execute(code, _scriptScope);

            writer.Flush();
            stream.Seek(0, System.IO.SeekOrigin.Begin);
            var reader = new System.IO.StreamReader(stream);
            return reader.ReadToEnd().Trim();
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Python Execution Error: " + ex.Message);
            return null;
        }
    }
}
