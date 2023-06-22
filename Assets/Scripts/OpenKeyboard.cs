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
    void Start()
    {
        keyboard.SetActive(false);


        if (!IsMobileDevice())
        {
            /*inputField.onDeselect.RemoveAllListeners();
            inputField.onSelect.RemoveAllListeners();
            */
            Destroy(keyboard);

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

    private bool IsMobileDevice()
    {
        string userAgent = SystemInfo.operatingSystem;
        print(userAgent);
        return userAgent.Contains("Android") || userAgent.Contains("iPhone") || userAgent.Contains("iPad");
    }

}
