using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerMovement;
    [SerializeField] private GameObject _pausePanel;
    private bool _paused;
    private void Update() =>
        CheckPause();
    private void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            Pause();
    }
    private void Pause()
    {
        _paused = !_paused;
        _playerMovement.enabled = !_paused;
        _pausePanel.SetActive(_paused);
        CursorController.Instance.ActivateCursor(_paused);
    }
}
