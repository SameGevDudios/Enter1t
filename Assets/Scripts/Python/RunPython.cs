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
        RunCode("print('Hello Unity!')");
    }
    private void InitializePython()
    {
        _scriptEngine = Python.CreateEngine();
        _scriptScope = _scriptEngine.CreateScope();
    }
    public void RunCode(string code)
    {
        try
        {
            ScriptSource source = _scriptEngine.CreateScriptSourceFromString(code);
            source.Compile();
            source.Execute(_scriptScope);
            Debug.Log("IronPython Script Executed Successfully.");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error executing Python script: " + ex.Message);
        }
    }
}
