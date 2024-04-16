using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _movementForce = 1f;
    [SerializeField] private float _maxSpeed = 1f;

    
    private ThirdPersonController _playerActions;
    private InputAction _move;
    private Rigidbody _rigidbody;
    private Vector3 _forceDirection = Vector3.zero;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerActions = new ThirdPersonController();
    }

    private void OnEnable()
    {
        _move = _playerActions.Player.Move;
        _playerActions?.Enable();
    }

    private void OnDisable()
    {
        _playerActions?.Disable();
    }

    private void FixedUpdate()
    {
        _forceDirection += _move.ReadValue<Vector2>().x * GetCameraRight(_camera) * _movementForce;
        _forceDirection += _move.ReadValue<Vector2>().y * GetCameraForward(_camera) * _movementForce;

        _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
        _forceDirection = Vector3.zero;

        Vector3 horizontalVelocity = _rigidbody.velocity;
        horizontalVelocity.y = 0;
        if(horizontalVelocity.sqrMagnitude > _maxSpeed* _maxSpeed)
        {
            _rigidbody.velocity = horizontalVelocity.normalized * _maxSpeed + Vector3.up * _rigidbody.velocity.y;
        }

        LookAt();
    }

    private Vector3 GetCameraForward(Camera camera)
    {
        Vector3 forward = camera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera camera)
    {
        Vector3 right = camera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    
    private void LookAt()
    {
        Vector3 direction = _rigidbody.velocity;
        direction.y = 0;

        if(_move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
            _rigidbody.rotation = Quaternion.LookRotation(direction, Vector3.up);
        else
            _rigidbody.angularVelocity = Vector3.zero;
    }
}
