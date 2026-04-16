using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEditor.Overlays;

public class GameSettings
{
    //public float masterVolume;
    //public float bgmVolume;
    //public float sfxVolume;
    //public int resolutionIndex;
    public string keybindSelected;
}
public class SaveLoadData : MonoBehaviour
{
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
    public static string filePath = Application.streamingAssetsPath + "/saveData.json";
    #endregion

    private void Start()
    {
        //GameSettings _saveData;
        GameSettings settings = new GameSettings { keybindSelected = "WASD" };

    }
    void SaveJSON(SaveLoadData data, string path)
    {
        string lineToSave = JsonUtility.ToJson(data);
        File.WriteAllText(path, lineToSave);
    }

    public void SaveGame()
    {
        //GetDataToSave();
        //SaveJSON(_saveData, filePath);
        SceneManager.LoadScene(0);
    }
}