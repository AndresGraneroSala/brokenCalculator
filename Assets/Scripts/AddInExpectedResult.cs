using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddInExpectedResult : MonoBehaviour
{
    public TMP_InputField TMP_InputField;

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(AddNumber);
    }

    public void AddNumber()
	{
        TMP_InputField.text+= GetComponentInChildren<Text>().text;
	}
}
