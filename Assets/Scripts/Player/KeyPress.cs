using UnityEngine;

public class KeyPress : MonoBehaviour
{
    [SerializeField] private GameObject _crosshair;
    [SerializeField] private Transform _aimTransform;
    [SerializeField] private float _reachDistance;
    [SerializeField] private LayerMask _searchMask;
    private RaycastHit _hit;
    private void Update()
    {
        bool inRange = KeyInRange();
        ActivateCrosshair(inRange);
        if (inRange && Input.GetMouseButtonDown(0))
            PressKey();
    }
    private void ActivateCrosshair(bool active) =>
        _crosshair.SetActive(active);
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
