using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenKeyboard : MonoBehaviour
{
    public TMP_InputField inputField;

    [ContextMenu("open")]
    public void OpenKeyboardOnClick()
    {
        // Establece el campo de entrada como seleccionado
        inputField.Select();

        // Activa el teclado en el campo de entrada
        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }
}
