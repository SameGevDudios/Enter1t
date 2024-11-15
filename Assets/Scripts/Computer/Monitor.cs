using UnityEngine;
using TMPro;

public class Monitor : MonoBehaviour
{
    [SerializeField] private RunPython _python;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _pointerFlickTimer;
    private string _message;
    private bool _pointerActive;
    private void Start()
    {
        _python.RunCode("print('Provide letters and digits using bit array and run python code by pressing [Run] button')");
        ActivatePointer();
    }
    private void ActivatePointer()
    {
        UpdateText(_message + (_pointerActive ? '|' : ""));
        _pointerActive = !_pointerActive;
        Invoke("ActivatePointer", _pointerFlickTimer);
    }
    public void ResetText()
    {
        _message = "";
        UpdateText(_message);
    }
    public void AddChar(char newChar)
    {
        _message += newChar;
        UpdateText(_message);
    }
    private void UpdateText(string newMessage) =>
        _text.text = newMessage;

}
