using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _pressEvent;
    public void Press()
    {
        _animator.SetTrigger("Press");
        _pressEvent?.Invoke();
    }
}
