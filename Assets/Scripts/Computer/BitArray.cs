using System.Collections;
using UnityEngine;
using TMPro;

public class BitArray : MonoBehaviour
{
    [SerializeField] private TMP_Text _arrayText, _resultText;
    private char[] _alphabet = "\n 0123456789abcdefghijklmnopqrstuvwxyz_,.!?=><+-".ToCharArray();
    private bool[] _bits = new bool[6];

    private void Start() =>
        UpdateResultCharText();
    public void ResetArray() =>
        _bits = new bool[6];
    public void AddOne()
    {
        BitIncrement();
        if (BitsToInt() >= _alphabet.Length)
            ResetArray();
        UpdateArrayText();
        UpdateResultCharText();
    }
    public void Return()
    {
        ResetArray();
        UpdateArrayText();
        UpdateResultCharText();
    }
    private void BitIncrement()
    {
        bool carry = true;
        for (int i = _bits.Length - 1; i >= 0; i--)
        {
            if (carry)
            {
                if (_bits[i])
                {
                    _bits[i] = false;
                }
                else
                {
                    _bits[i] = true;
                    carry = false;
                }
            }
        }
    }
    private void UpdateArrayText() =>
        _arrayText.text = BitsToString();
    private void UpdateResultCharText()
    {
        char result = BitsToResultChar();
        switch (result)
        {
            case '\n':
                _resultText.text = "Enter";
                break;
            case ' ':
                _resultText.text = "Space";
                break;
            default:
                _resultText.text = result.ToString();
                break;
        }
    }
    private int BitsToInt()
    {
        int index = 0;
        for (int i = 0; i < _bits.Length; i++)
            if (_bits[i])
                index |= (1 << (_bits.Length - 1 - i));
        return index;
    }
    private char BitsToResultChar()
    {
        int index = 0;
        for (int i = 0; i < _bits.Length; i++)
            if (_bits[i])
                index |= (1 << (_bits.Length - 1 - i));
        return _alphabet[index];
    }
    private string BitsToString()
    {
        string output = "";
        for (int i = 0; i < _bits.Length; i++)
            output += _bits[i] ? '1' : '0';
        return output;
    }
}
