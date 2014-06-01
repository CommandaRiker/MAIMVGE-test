using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public float bpm = 110;
	private float beatProgress;
	private int beatCounter;

	public MovieTexture instrument1LoopDefault;
	public MovieTexture instrument2LoopDefault;
	public MovieTexture instrument3LoopDefault;

	public GameObject instrument1Display;
	public GameObject instrument2Display;
	public GameObject instrument3Display;

	void Awake()
	{
		Instance = this;
	}
	void Update()
	{
		if (beatProgress < 60f / bpm)
			beatProgress += Time.deltaTime;
		else
		{
			DoBeat();
			beatProgress -= 60f / bpm;
		}
	}
	public void DoBeat()
	{
		beatCounter++;
		Debug.Log("--------Start of beat--------" + beatCounter);

		// Instrument 1
		if (InputManager.Instance.instrument1ClipQueue.Count > 0)
			instrument1Display.renderer.material.mainTexture = InputManager.Instance.instrument1ClipQueue.Dequeue();
		else
		{
			Debug.Log("Instrument 1 input missing, play default clip");
			instrument1Display.renderer.material.mainTexture = instrument1LoopDefault;
		}
		// Instrument 2
		if (InputManager.Instance.instrument2ClipQueue.Count > 0)
			instrument2Display.renderer.material.mainTexture = InputManager.Instance.instrument2ClipQueue.Dequeue();
		else
		{
			Debug.Log("Instrument 2 input missing, play default clip");
			instrument2Display.renderer.material.mainTexture = instrument2LoopDefault;
		}
		// Instrument 3
		if (InputManager.Instance.instrument3ClipQueue.Count > 0)
			instrument3Display.renderer.material.mainTexture = InputManager.Instance.instrument3ClipQueue.Dequeue();
		else
		{
			Debug.Log("Instrument 3 input missing, play default clip");
			instrument3Display.renderer.material.mainTexture = instrument3LoopDefault;
		}
		Debug.Log("--------End of beat--------");
	}
}