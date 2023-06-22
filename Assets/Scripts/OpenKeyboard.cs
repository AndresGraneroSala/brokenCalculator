using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
using System.Collections;

public class OpenKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject keyboard;

   

    [ContextMenu("web")]
    IEnumerator Start()
    {
        keyboard.SetActive(false);

        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://service.andriupostre.repl.co"))
        //https://replit.com/@AndriuPostre/service
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error al realizar la petición: " + webRequest.error);
            }
            else
            {
                // Accede a los datos de la respuesta
                string responseText = webRequest.downloadHandler.text;
                if(responseText== "no mobile phone")
				{
                    /*inputField.onDeselect.RemoveAllListeners();
                    inputField.onSelect.RemoveAllListeners();
                    */
                    Destroy(keyboard);

				}
            }
        }
    }


public void Open()
    {
        if(keyboard!=null)
        keyboard.SetActive(true);

    }


    public void CloseKeyboard()
	{
        if (keyboard != null)

            keyboard.SetActive(false);

    }
}
