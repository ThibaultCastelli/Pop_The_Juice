using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using CustomVariablesTC;

public class SaveManager : MonoBehaviour
{
    #region Variables
    [SerializeField] IntReference score;
    [SerializeField] IntReference highScore;

    Save _save;

    string _path;
    #endregion

    #region Starts & Updates
    private void Awake()
    {
        _path = Application.persistentDataPath + "/PopSave.json";

        _save = GetSave();
        highScore.Value = _save.highScore;
    }
    #endregion

    #region Functions
    Save GetSave()
    {
        if (!File.Exists(_path))
            return new Save();

        string json = File.ReadAllText(_path);
        return JsonUtility.FromJson<Save>(json);
    }

    // Observer of OnPressSpace
    public void Save(bool isOnCollectible)
    {
        if (isOnCollectible || score.Value < _save.highScore)
            return;

        _save.highScore = score.Value;
        string json = JsonUtility.ToJson(_save);
        File.WriteAllText(_path, json);
    }
    #endregion
}
