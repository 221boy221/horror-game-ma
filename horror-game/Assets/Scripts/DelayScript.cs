using UnityEngine;
using System.Collections;

public class DelayScript : MonoBehaviour {
	

	void Start () {
		Invoke("DelayInvoke",(Random.Range(1, 5)));
	}

	void TimerInvoke()
	{
		Debug.Log("ping");
	}

}
