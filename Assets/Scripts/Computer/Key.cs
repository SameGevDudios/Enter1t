using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] private UnityEvent _pressEvent;
    public void Press() =>
        _pressEvent?.Invoke();
}
