using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; }

	public List<QueuedClip> instrument1ClipsAndKeys = new List<QueuedClip>();
	public List<QueuedClip> instrument2ClipsAndKeys = new List<QueuedClip>();
	public List<QueuedClip> instrument3ClipsAndKeys = new List<QueuedClip>();

	public Queue<MovieTexture> instrument1ClipQueue = new Queue<MovieTexture>();
	public Queue<MovieTexture> instrument2ClipQueue = new Queue<MovieTexture>();
	public Queue<MovieTexture> instrument3ClipQueue = new Queue<MovieTexture>();
	
	void Awake()
	{
		Instance = this;

		foreach (QueuedClip qc in instrument1ClipsAndKeys) {
			qc.clip.loop = true;
			qc.clip.Play();
			audio.clip = qc.clip.audioClip;
			audio.Play();
		}
	}
	void Update()
	{
		HandleInput();
	}
	public void HandleInput()
	{
		// Instrument 1
		foreach (QueuedClip qc1 in instrument1ClipsAndKeys)
			if (Input.GetKeyDown(qc1.key))
				instrument1ClipQueue.Enqueue(qc1.clip);
		
		// Instrument 2
		foreach (QueuedClip qc2 in instrument2ClipsAndKeys)
			if (Input.GetKeyDown(qc2.key))
				instrument2ClipQueue.Enqueue(qc2.clip);

		// Instrument 2
		foreach (QueuedClip qc3 in instrument3ClipsAndKeys)
			if (Input.GetKeyDown(qc3.key))
				instrument3ClipQueue.Enqueue(qc3.clip);
	}
}
[Serializable]
public class QueuedClip
{
	public MovieTexture clip;
	public KeyCode key;
}