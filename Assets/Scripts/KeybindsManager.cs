using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeybindsManager : MonoBehaviour
{
    #region Pseudocode
    /// <summary>
    /// on scene start
    ///     debug currently selected controls
    ///     if dropdown = wasd
    ///         change keybinds to wasd
    ///     if else dropdown = arrows
    ///         change keybinds to arrows
    /// </summary>
    #endregion

    #region Variables
    public string currentKeyBind;
    public Dropdown keybindsDropDown;
    public Text _label;
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log($"Input is {currentKeyBind}");
        }
        _label.text = currentKeyBind;
    }

    public void SetKeybinds()
    {
        if (keybindsDropDown.value == 0)
        {
            currentKeyBind = "WASD";
        }
        else if (keybindsDropDown.value == 1)
        {
            currentKeyBind = "Arrows";
        }
    }


}
