using UnityEngine;
using TMPro;

public class Monitor : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private float _pointerFlickTimer;
    private string _message;
    private bool _pointerActive;
    private void Start()
    {
        ActivatePointer();
    }
    private void ActivatePointer()
    {
        UpdateText(_message + (_pointerActive ? '|' : ""));
        _pointerActive = !_pointerActive;
        Invoke("ActivatePointer", _pointerFlickTimer);
    }
    public void AddChar(char newChar)
    {
        _message += newChar;
        UpdateText(_message);
    }
    private void UpdateText(string newMessage) =>
        _text.text = newMessage;

}
