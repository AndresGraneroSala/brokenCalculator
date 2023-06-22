using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Linq;
using System.Text;
public class CalculateResults : MonoBehaviour
{
	public TMP_InputField InputField;
	public int requested;
	public List<string> solutions;

	public RectTransform contentScrollView;
	public GameObject prefabText;
	public Transform poolText;

	public Text numSolutions;

	public static CalculateResults SharedInstance;
	public List<string> brokenCharacters;

	private void Awake()
	{
		if (SharedInstance == null)
		{
			SharedInstance = this;
		}
		else
		{
			Debug.LogError("In script calculate results 2 instance");
		}
	}

	public void LookOptions()
	{
		if (InputField.text == "")
		{
			return;
		}

		solutions.Clear();
		GameObject[] texts = GameObject.FindGameObjectsWithTag("textSolution");

		for (int i = 0; i < texts.Length; i++)
		{
			Destroy(texts[i]);
		}
		requested = int.Parse(InputField.text);

		FindMult();
		FindSum();
		FindSubstraction();
		FindDivide();

		SolutionsToUI();


	}

	public void CheckIfRepeat(string operation)
	{
		string tempSolution = operation.Replace(" ", "");


		if (!(tempSolution.Distinct().Count() != tempSolution.Length))
		{
			if (brokenCharacters.Count == 0)
			{

				solutions.Add(operation);
			}
			else
			{
				Debug.Log(brokenCharacters.Count);
				for (int i = 0; i < brokenCharacters.Count; i++)
				{
					if (operation.Contains(brokenCharacters[i]))
					{
						return;
					}
				}
				solutions.Add(operation);
			}
		}
	}

	public void WithoutOperations()
	{
		/*if (requested)
		{

		}*/
	}

	[ContextMenu("multiply")]
	public void FindMult()
	{
		for (int i = 2; i < (requested)-1; i++)
		{

			if (requested % i==0)
			{
				//is divisor

				string solution = string.Format("{0} X {1}", i, requested / i);

				CheckIfRepeat(solution);



			}
			else
			{
				//not divisor so find with + the rest

				int rest = requested % i;
				string solution = string.Format("{0} X  {1} + {2}", i, requested / i,rest);
				CheckIfRepeat(solution);

			}

		}




	}

	[ContextMenu("Sum")]
	public void FindSum()
	{
		for (int i = 0; i < requested; i++)
		{
			//63 + 1
			//62 + 2

			StringBuilder sb = new StringBuilder();
			sb.Append(" ");
			sb.Append(i.ToString());
			sb.Append(" + ");
			sb.Append((requested - i).ToString());

			string result = sb.ToString();

			CheckIfRepeat(result);
		}
	}

	[ContextMenu("substraction")]
	public void FindSubstraction()
	{
		//64
		//65-1
		//

		//the 9999 it's because the numbers can substract it's infinite but with 4 numbers it's very similar to 8 because the posibility to reapeat it's minor and the time response it's faster
		for (int i = 0; i < 9999; i++)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append((requested + i));
			sb.Append(" - ");
			sb.Append((i));

			string solution = sb.ToString();

			CheckIfRepeat(solution);
		}

	}

	[ContextMenu("divide")]
	public void FindDivide()
	{
		for (int i = 0; i < 9999; i++)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(requested * i);
			sb.Append(" ÷ ");
			sb.Append(i);
			string solution= sb.ToString();

			CheckIfRepeat(solution);


		}
	}

	public void SolutionsToUI()
	{
		Vector2 sizePrefab = prefabText.GetComponent<RectTransform>().sizeDelta;
		//contentScrollView.sizeDelta = sizePrefab;
		Vector2 sumScroll = new Vector2(sizePrefab.x, 0);

		contentScrollView.sizeDelta = new Vector2(0,100*solutions.Count);

		for (int i = 0; i < solutions.Count; i++)
		{
			GameObject newText = Instantiate(prefabText);
			newText.transform.SetParent(poolText);
			newText.transform.localScale = new Vector3(1, 1, 1);
			newText.GetComponent<Text>().text = solutions[i];


		}

		numSolutions.text = solutions.Count.ToString();
	}


}
