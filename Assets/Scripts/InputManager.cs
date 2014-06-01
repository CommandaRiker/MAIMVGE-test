using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }

	public Queue<KeyCode> instrument1InputQueue = new Queue<KeyCode>();
	public Queue<KeyCode> instrument2InputQueue = new Queue<KeyCode>();

	public KeyCode instrument1Loop1Key = KeyCode.Q;
	public KeyCode instrument1Loop2Key = KeyCode.W;
	public KeyCode instrument1Loop3Key = KeyCode.E;

	public KeyCode instrument2Loop1Key = KeyCode.A;
	public KeyCode instrument2Loop2Key = KeyCode.S;
	public KeyCode instrument2Loop3Key = KeyCode.D;
	
	void Awake()
	{
		Instance = this;
	}
	void Update()
	{
		HandleInput();
	}
	public void HandleInput()
	{
		// Instrument 1
		if (Input.GetKeyDown(instrument1Loop1Key))
			instrument1InputQueue.Enqueue(instrument1Loop1Key);

		if (Input.GetKeyDown(instrument1Loop2Key))
			instrument1InputQueue.Enqueue(instrument1Loop2Key);

		if (Input.GetKeyDown(instrument1Loop3Key))
			instrument1InputQueue.Enqueue(instrument1Loop3Key);

		// Instrument 2
		if (Input.GetKeyDown(instrument2Loop1Key))
			instrument2InputQueue.Enqueue(instrument2Loop1Key);

		if (Input.GetKeyDown(instrument2Loop2Key))
			instrument2InputQueue.Enqueue(instrument2Loop2Key);

		if (Input.GetKeyDown(instrument2Loop3Key))
			instrument2InputQueue.Enqueue(instrument2Loop3Key);
	}
}