using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }

	public float lengthOfBeat = 1;
	private float beatProgress;
	private int beatCounter;

	public MovieTexture instrument1Loop1;
	public MovieTexture instrument1Loop2;
	//public MovieTexture instrument1Loop3;

	public MovieTexture instrument1LoopDefault;

	public MovieTexture instrument2Loop1;
	public MovieTexture instrument2Loop2;
	//public MovieTexture instrument2Loop3;

	public MovieTexture instrument2LoopDefault;

	public GameObject instrument1Display;
	public GameObject instrument2Display;

	void Awake()
	{
		Instance = this;
	}
	void Update()
	{
		if (beatProgress < lengthOfBeat)
			beatProgress += Time.deltaTime;
		else
		{
			beatProgress -= lengthOfBeat;
			DoBeat();
		}
	}
	public void DoBeat()
	{
		beatCounter++;
		Debug.Log("--------Start of beat--------" + beatCounter);

		// Instrument 1
		if (InputManager.Instance.instrument1InputQueue.Count > 0)
		{
			KeyCode k = InputManager.Instance.instrument1InputQueue.Dequeue();

			if (k == InputManager.Instance.instrument1Loop1Key)
			{
				Debug.Log("Play instrument 1 loop 1");
				instrument1Display.renderer.material.mainTexture = instrument1Loop1;
			}
			else if (k == InputManager.Instance.instrument1Loop2Key)
			{
				Debug.Log("Play instrument 1 loop 2");
				instrument1Display.renderer.material.mainTexture = instrument1Loop2;
			}
			else if (k == InputManager.Instance.instrument1Loop3Key)
			{
				Debug.Log("Play instrument 1 loop 3");
				//instrument1Display.renderer.material.mainTexture = instrument1Loop3;
			}
		}
		else
		{
			Debug.Log("Instrument 1 input missing, play default clip");
			instrument1Display.renderer.material.mainTexture = instrument1LoopDefault;
		}
		// Instrument 2
		if (InputManager.Instance.instrument2InputQueue.Count > 0)
		{
			KeyCode k = InputManager.Instance.instrument2InputQueue.Dequeue();

			if (k == InputManager.Instance.instrument2Loop1Key)
			{
				Debug.Log("Play instrument 2 loop 1");
				instrument2Display.renderer.material.mainTexture = instrument2Loop1;
			}
			else if (k == InputManager.Instance.instrument2Loop2Key)
			{
				Debug.Log("Play instrument 2 loop 2");
				instrument2Display.renderer.material.mainTexture = instrument2Loop2;
			}
			else if (k == InputManager.Instance.instrument2Loop3Key)
			{
				Debug.Log("Play instrument 2 loop 3");
				//instrument2Display.renderer.material.mainTexture = instrument2Loop3;
			}
		}
		else
		{
			Debug.Log("Instrument 2 input missing, play default clip");
			instrument2Display.renderer.material.mainTexture = instrument2LoopDefault;
		}
		Debug.Log("--------End of beat--------");
	}
}