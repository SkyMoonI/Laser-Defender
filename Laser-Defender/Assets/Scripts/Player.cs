using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	[Header("Input")]
	Vector2 rawInput;
	Vector2 moveInput;
	[SerializeField] float moveSpeed = 10f;

	[Header("Screen Boundaries")]
	Vector2 minBounds;
	Vector2 maxBounds;
	[SerializeField] float paddingLeft = 1f;
	[SerializeField] float paddingRight = 1f;
	[SerializeField] float paddingTop = 1f;
	[SerializeField] float paddingBottom = 1f;
	void Start()
	{
		InitBounds();
	}
	void Update()
	{
		Move();
	}
	// Sets the min and max bounds of the screen in world space 
	void InitBounds()
	{
		Camera mainCamera = Camera.main;
		minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
		maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
	}
	private void Move()
	{
		moveInput = rawInput * Time.deltaTime * moveSpeed;
		Vector2 newPosition = new Vector2();
		// Clamp the player's position to the screen bounds with padding
		newPosition.x = Mathf.Clamp(transform.position.x + moveInput.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
		newPosition.y = Mathf.Clamp(transform.position.y + moveInput.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
		transform.position = newPosition;
	}

	void OnMove(InputValue value)
	{
		rawInput = value.Get<Vector2>();
		Debug.Log($"RawInput: {rawInput}");
	}
}
