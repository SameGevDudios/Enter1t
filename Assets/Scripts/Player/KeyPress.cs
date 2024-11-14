using UnityEngine;

public class KeyPress : MonoBehaviour
{
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private float _reachDistance;
    [SerializeField] private LayerMask _searchMask;
    private RaycastHit _hit;
    private void Update()
    {
        if (KeyInRange())
        {
            if (Input.GetMouseButtonDown(0))
            {
                PressKey();
            }
        }
    }
    private bool KeyInRange()
    {
        return Physics.Raycast(_aimTransform.position, _aimTransform.forward, out _hit, _reachDistance, _searchMask);
    }
    private void PressKey()
    {
        Key key = _hit.collider.gameObject.GetComponent<Key>();
        if (key != null)
            key.Press();
    }
}
