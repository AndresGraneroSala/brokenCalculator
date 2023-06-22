using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hammer : MonoBehaviour
{
	public Texture2D sprite;
	public Button button;


	public GameObject filter;
	public bool usingHammer=false;
	public static hammer SharedInstance;
	private void Awake()
	{
		if (SharedInstance == null)
		{
			SharedInstance = this;
		}
		else
		{
			Debug.LogError("In script hammer 2 instance");
		}
	}

	private void Start()
	{
		ButtonHammer();
	}

	public void ButtonHammer()
	{
		if(!filter.activeSelf)
		{
			WithHammer();
		}
		else
		{
			QuitHammer();
		}
	}

    public void WithHammer()
	{
		Cursor.SetCursor(sprite,Vector2.zero,CursorMode.Auto);

		filter.SetActive(true);

		usingHammer = true;
	}

	public void QuitHammer()
	{
		Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

		filter.SetActive(false);

		usingHammer = false;


	}


}
