using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPause : MonoBehaviour
{
	public GameObject Canvas;
	private bool paused = false;


	void Start()
	{
		Canvas.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown("Escape"))
		{
			if (paused == true)
			{
				Time.timeScale = 1.0f;
				Canvas.gameObject.SetActive(false);
				paused = false;
			}
			else
			{
				Time.timeScale = 0.0f;
				Canvas.gameObject.SetActive(true);
				paused = true;
			}
		}
	}

	public void Resume()
	{
		Time.timeScale = 1.0f;
		Canvas.gameObject.SetActive(false);
	}
}