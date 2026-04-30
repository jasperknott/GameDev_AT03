using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

[Serializable]
public class GameSettings
{
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public string keybindSelected;
    public int fullscreenMode;
    public string resolutionText;
    public string keybindsText;
}
public class SaveLoadData : MonoBehaviour
{
    public KeybindsManager keybindsManager;
    public ResolutionManager resolutionManager;
    public Slider masterVolume;
    public Slider sfxVolume;
    public Slider musicVolume;
    public Text keybindsText;
    public Text resolutionText;


    /// <summary>
    /// Variables that need to be saved:
    ///     - Keybinds
    ///     - Volume Control
    ///         - Master
    ///         - BGM
    ///         - SFX
    ///     - Resolution
    /// </summary>
     
    #region Variables
    public static string filePath = $"{Application.streamingAssetsPath}/saveData.json";
    [SerializeField] GameSettings _gameSettings;
    #endregion
    private void OnEnable()
    {
        if (File.Exists(filePath))
        {
            LoadGame();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }
    }

    public void GetDataToSave()
    {
        _gameSettings.keybindSelected = keybindsManager.currentKeyBind;
        _gameSettings.fullscreenMode = resolutionManager.CurrentFullscreenMode;
        _gameSettings.masterVolume = masterVolume.value;
        _gameSettings.sfxVolume = sfxVolume.value;
        _gameSettings.musicVolume = musicVolume.value;
        _gameSettings.keybindsText = keybindsText;

    }

    void SaveJSON(GameSettings data, string path)
    {
        string lineToSave = JsonUtility.ToJson(data);
        File.WriteAllText(path, lineToSave);
    }

    public void SaveGame()
    {
        GetDataToSave();
        SaveJSON(_gameSettings, filePath);
    }
    
    GameSettings LoadData()
    {
        string loadedData = File.ReadAllText(filePath);
        return JsonUtility.FromJson<GameSettings>(loadedData);
    }

    void SendDataFromLoad()
    {
        keybindsManager.currentKeyBind = _gameSettings.keybindSelected;
        resolutionManager.CurrentFullscreenMode = _gameSettings.fullscreenMode;
        masterVolume.value = _gameSettings.masterVolume;
        sfxVolume.value = _gameSettings.sfxVolume;
        musicVolume.value = _gameSettings.musicVolume;
    }

    public void LoadGame()
    {
        _gameSettings = LoadData();
        SendDataFromLoad();
    }
}