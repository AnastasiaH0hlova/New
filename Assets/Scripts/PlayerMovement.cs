using UnityEngine;
using UnityEngine.InputSystem;
using static InventoryManager;

public class PlayerMovement : MonoBehaviour
{
	private const float MovementSmoothing = .07f;
	private Camera _mainCamera;
	private PlayerInputActions _playerInputActions;
	private Rigidbody _playerRigidbody;
	private float _speed;
	private Vector3 _zeroVelocity = Vector3.zero;

	private void Awake()
	{
		_playerRigidbody = GetComponent<Rigidbody>();

		// enable input actions for the new input system
		_playerInputActions = new PlayerInputActions();
		_playerInputActions.Player.Enable();
		_mainCamera = Camera.main;
	}

	private void FixedUpdate()
	{
		if (InventoryPanelIsActive) return;
		_speed = Keyboard.current.shiftKey.isPressed ? 2.5f : 1.3f;

		// character rotation
		Vector3 mousePosition = _playerInputActions.Player.MousePosition.ReadValue<Vector2>();
		var mouseRay = _mainCamera.ScreenPointToRay(mousePosition);
		var p = new Plane(Vector3.up, transform.position);
		if (!p.Raycast(mouseRay, out var hitDist)) return;
		var hitPoint = mouseRay.GetPoint(hitDist);
		transform.LookAt(hitPoint);

		// for WASD keys pressed moves character position
		var inputVector = _playerInputActions.Player.Movement.ReadValue<Vector2>();
		var targetVelocity = new Vector3(inputVector.x, 0f, inputVector.y).normalized;

		if (targetVelocity == Vector3.forward) targetVelocity = transform.forward;
		else if (targetVelocity == Vector3.back) targetVelocity = -transform.forward;
		else if (targetVelocity == Vector3.right) targetVelocity = transform.right;
		else if (targetVelocity == Vector3.left) targetVelocity = -transform.right;

		_playerRigidbody.velocity = Vector3.SmoothDamp(_playerRigidbody.velocity, targetVelocity * _speed,
			ref _zeroVelocity, MovementSmoothing);
	}
}