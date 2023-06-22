using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoveNumberExpectedResult : MonoBehaviour
{
    public TMP_InputField TMP_InputField;

    public void RemoveBack()
	{
		TMP_InputField.text = TMP_InputField.text.Substring(0, TMP_InputField.text.Length-1);
	}

	public void RemoveAll()
	{
		TMP_InputField.text = "";
	}

}
