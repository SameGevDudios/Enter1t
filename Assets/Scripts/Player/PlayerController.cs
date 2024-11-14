using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] private LayerMask _mask;

    [SerializeField]
    private float _lookSensitivity = 2f, _walkSpeed = 2f, _runSpeed = 5f,
        _jumpForce = 5f;

    private float _verticalLookRotation, _currentSpeed;
    private Vector3 _currentVelocity;
    private void Start()
    {
        LockCursor();
        _currentSpeed = _walkSpeed;
    }
    private void Update()
    {
        RotateCamera();
        CheckMoveModeInput();
        CheckMovementInput();
        MovePlayer();
        if (Input.GetButtonDown("Jump") && IsGrounded())
            Jump();
    }
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void RotateCamera()
    {
        float yRotation = Input.GetAxis("Mouse X") * _lookSensitivity;
        transform.Rotate(Vector3.up * yRotation);

        _verticalLookRotation += Input.GetAxis("Mouse Y") * _lookSensitivity;
        _verticalLookRotation = Mathf.Clamp(_verticalLookRotation, -90f, 90f);

        _cameraTransform.localEulerAngles = Vector3.left * _verticalLookRotation;
    }
    private void CheckMoveModeInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
            _currentSpeed = _runSpeed;
        else
            _currentSpeed = _walkSpeed;
    }
    private void CheckMovementInput() 
    {
        _currentVelocity = 
            Vector3.right * Input.GetAxis("Horizontal") +
            Vector3.forward * Input.GetAxis("Vertical");
    }

    private void MovePlayer() =>
           transform.Translate(_currentVelocity * _currentSpeed * Time.deltaTime);
    private void Jump() =>
        _rigidbody.linearVelocity = new Vector3(_rigidbody.linearVelocity.x, _jumpForce, _rigidbody.linearVelocity.z);
    private bool IsGrounded() =>
        Physics.Raycast(transform.position + transform.up * 0.03f, -transform.up, 0.05f, _mask);
}
