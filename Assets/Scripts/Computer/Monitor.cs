using UnityEngine;
using TMPro;

public class Monitor : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    private string _message;
    public void AddChar(char newChar)
    {
        _message += newChar;
        UpdateText();
    }
    private void UpdateText() =>
        _text.text = _message;
    private void UpdateText(string newMessage) =>
        _text.text = newMessage;

}
