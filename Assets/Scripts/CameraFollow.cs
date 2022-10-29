using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Vector3 offset;
	public Transform target;
	private const float SmoothSpeed = 0.5f;

	private void Start()
	{
		Cursor.visible = false;
	}

	private void FixedUpdate()
	{
		var desiredPosition = target.position + offset;
		var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
		transform.position = smoothedPosition;
		transform.LookAt(target);
	}
}