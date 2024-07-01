using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	Vector2 rawInput;
	[SerializeField] float moveSpeed = 10f;
	void Update()
	{
		Move();
	}

	private void Move()
	{
		Vector2 moveInput = rawInput;
		transform.Translate(moveInput * Time.deltaTime * moveSpeed);
	}

	void OnMove(InputValue value)
	{
		rawInput = value.Get<Vector2>();
		Debug.Log($"RawInput: {rawInput}");
	}
}
