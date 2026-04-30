using UnityEngine;
using UnityEngine.UI;

public class ResolutionManager : MonoBehaviour
{
    #region variables
    private int _fullscreenMode = 0;

    [Header("References")]
    [SerializeField] Text _label;
    //[SerializeField] Toggle _fullScreenWindowToggle;
    //[SerializeField] Toggle _windowedToggle;
    #endregion

    #region properties
    public int CurrentFullscreenMode
    {
        set { _fullscreenMode = value; }
        get { return _fullscreenMode; }
    }
    #endregion

    #region unity callbacks
    private void Start()
    {
        switch (CurrentFullscreenMode)
        {
            case 0:
                _label.text = "Fullscreen";
                break;
            case 1:
                _label.text = "Borderless Window";
                break;
            case 2:
                _label.text = "Windowed";
                break;
            default:
                _label.text = "Fullscreen";
                break;
        }
    }
    #endregion

    #region Public Methods
    public void SetScreenMode(int mode)
    {
        CurrentFullscreenMode = mode;
        switch (CurrentFullscreenMode)
        {
            case 0:
                Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
                break;
            case 1:
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
                break;
            case 2:
                Screen.fullScreenMode = FullScreenMode.Windowed;
                break;           
        }
    }
    #endregion
}
