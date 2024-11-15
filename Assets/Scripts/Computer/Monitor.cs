using UnityEngine;
using TMPro;

public class Monitor : MonoBehaviour
{
    [SerializeField] private RunPython _python;
    [SerializeField] private TMP_Text _monitorText, _runText;
    [SerializeField] private float _pointerFlickTimer;
    private string _message;
    private bool _pointerActive;
    private void Start()
    {
        _message = "print('[WASD] to move')" +
            "\nprint('[Left Mouse Button] to press buttons')" +
            "\nprint('[Space] to jump')" +
            "\nprint('Provide letters and digits using bit array')" +
            "\nprint('Use [Run] button to run python code')" +
            "\nprint('Use [Reset] button to clear monitor')";
        UpdateMonitorText(_message);
        ActivatePointer();
    }
    private void ActivatePointer()
    {
        UpdateMonitorText(_message + (_pointerActive ? '|' : ""));
        _pointerActive = !_pointerActive;
        Invoke("ActivatePointer", _pointerFlickTimer);
    }
    public void RunProgram() =>
        _runText.text = _python.RunCode(_message);
    public void ResetText()
    {
        _message = "";
        UpdateMonitorText(_message);
        UpdateRunText("");
    }
    public void AddChar(char newChar)
    {
        _message += newChar;
        UpdateMonitorText(_message);
    }
    private void UpdateMonitorText(string newMessage) =>
        _monitorText.text = newMessage;
    private void UpdateRunText(string newResults) =>
        _runText.text = newResults;

}
