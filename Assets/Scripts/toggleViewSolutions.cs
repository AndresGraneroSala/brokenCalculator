using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class toggleViewSolutions : MonoBehaviour
{
    public Toggle toggle;
    public GameObject cover;


	private void Start()
	{
		ViewSolutions();
	}

	public void ViewSolutions()
	{
		if (toggle.isOn)
		{
			cover.SetActive(false);
		}
		else
		{
			cover.SetActive(true);
		}
	}
}
