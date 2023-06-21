using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    [SerializeField]
    private Text textResult;

    [SerializeField]
    public List<string> operations;

    public static Result SharedInstance;

	[SerializeField]
	private float resultCalculated;

	[SerializeField]
	string[] numbers = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

	[SerializeField]
	private Text resultInt;

	public List<string> resultTidy;

	public AddOperation[] buttons;

	private void Awake()
	{
		if (SharedInstance == null)
		{
		SharedInstance = this;
		}
		else
		{
			Debug.LogError("In script result 2 instance");
		}
	}


	private void Start()
	{
		buttons = FindObjectsOfType<AddOperation>();
	}
	public void OperationChanged()
	{
		textResult.text = "";
		for (int i = 0; i < operations.Count; i++)
		{
			textResult.text += operations[i];
		}
	}


	public void Calculate()
	{
		
		string allOperationsToCalculate="";
		resultCalculated = 0;


		for (int i = 0; i < operations.Count; i++)
		{
			allOperationsToCalculate += operations[i];
			//Debug.Log(operations[i]);
		}

		char[] arithmetic = { '+', '-', 'X', '÷' };

		int indice = allOperationsToCalculate.IndexOfAny(arithmetic);
		//Debug.Log(indice);
		if (indice == -1)
		{

			resultInt.text = allOperationsToCalculate;
			textResult.text = allOperationsToCalculate;

			return;
		}

		Separate(allOperationsToCalculate);

		//Debug.Log(resultTidy[0]);

		resultCalculated= int.Parse( resultTidy[0]);

		for (int i = 1; i < resultTidy.Count; i++)
		{
			switch (resultTidy[i])
			{
				case "X":

					
					resultCalculated *= int.Parse( resultTidy[i+=1]);
					break;

				case "-":
					
					resultCalculated -= int.Parse(resultTidy[i += 1]);
					
					break;

				case "+":
					
					resultCalculated += int.Parse(resultTidy[i += 1]);
					break;
				case "÷":
					
					resultCalculated /= int.Parse(resultTidy[i += 1]);
					break;
				default:
					break;
			}
		}




		resultInt.text = resultCalculated.ToString();

	}


	public string LastOperation()
	{
		return operations[operations.Count - 1];
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

	public string[] withoutNumbers;
	public string[] withoutAritmetica;
	[ContextMenu("test")]
	public void Separate(string input)
	{
		resultTidy.Clear();
		withoutAritmetica = new string[0];
		withoutNumbers = new string[0];


		char[] separatorsAritmetica = { '+', '-', 'X', '÷' };
		char[] separatorsNum = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };

		withoutAritmetica = input.Split(separatorsAritmetica);
		withoutNumbers = input.Split(separatorsNum,System.StringSplitOptions.RemoveEmptyEntries);

		//Debug.Log(withoutNumbers.Length);


		for (int i = 0; i < separatorsAritmetica.Length; i++)
		{

			try
			{
				resultTidy.Add(withoutAritmetica[i]);

				resultTidy.Add(withoutNumbers[i]);

			}
			catch (System.Exception)
			{

				//throw;
			}
		}

		//Debug.Log(resultTidy[resultTidy.Count-1]);

		if (resultTidy[resultTidy.Count - 1] == "")
		{
			resultTidy.RemoveAt(resultTidy.Count - 1);

			if (!isNumber(resultTidy[resultTidy.Count - 1]))
			{
				resultTidy.RemoveAt(resultTidy.Count - 1);
			}
		}

		

	}

	public void ResetCalculator()
	{
		for (int i = 0; i < buttons.Length; i++)
		{
			buttons[i].gameObject.SetActive(true);
			resultCalculated = 0;
			operations.Clear();
			resultInt.text = "Operation";
			textResult.text = "Operation";

		}
	}


	public void BackOperation()
	{
		//Debug.Log(operations.Count);
		if (operations.Count == 0)
		{
			return;
		}

		for (int i = 0; i < buttons.Length; i++)
		{
			if (buttons[i].GetComponentInChildren<Text>().text == operations[operations.Count - 1])
			{
				buttons[i].gameObject.SetActive(true);
			}
		}
		operations.RemoveAt(operations.Count - 1);

		//reset green screen is with numbers to calculate
		OperationChanged();



	}
}
