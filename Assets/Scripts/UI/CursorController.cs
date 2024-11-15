using UnityEngine;

public class CursorController : MonoBehaviour
{
    #region Singleton
    public static CursorController Instance;
    private void Awake() =>
        Instance = this;
    #endregion
    private void Start() =>
        ActivateCursor(false);
    public void ActivateCursor(bool activate)
    {
        Cursor.visible = activate;
        Cursor.lockState = activate ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
