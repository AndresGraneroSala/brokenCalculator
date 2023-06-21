using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddOperation : MonoBehaviour
{
    [SerializeField]
    private string newOperation;

	[SerializeField]
	string[] numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

	[SerializeField]
	private Result _result;

	private void Start()
	{
		_result = Result.SharedInstance;

		//I can do it in editor but it seems to me is a very time-consuming task
		newOperation = GetComponentInChildren<Text>().text;
		gameObject.GetComponent<Button>().onClick.AddListener(AddNewOperation);

		 
	}

	public void AddNewOperation()
	{
		if (_result.operations.Count == 0)
		{
			//just numbers no operations
			if (!isNumber(newOperation))
			{
				return;
			}
			else
			{
				_result.operations.Add(newOperation);
				_result.OperationChanged();

				gameObject.SetActive(false);

				return;
			}
		}

		if (!isNumber( _result.LastOperation()))
		{
			//can't add + - / * just numbers
			if (isNumber(newOperation))
			{
				_result.operations.Add(newOperation);
				_result.OperationChanged();

				gameObject.SetActive(false);

				return;
			}
			else
			{
				return;
			}
		}
			//Debug.Log(_result.LastOperation());


		_result.operations.Add(newOperation);
        _result.OperationChanged();

        gameObject.SetActive(false);



	}


	public bool isNumber(string maybeNumber)
	{
		for (int i = 0; i < numbers.Length; i++)
		{
			if (numbers[i] == maybeNumber)
			{
				return true;
			}
		}

		return false;
	}

}
