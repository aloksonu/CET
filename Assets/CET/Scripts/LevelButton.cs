using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public Button btnLevel;
    public LevelsName levelsName;
    void Start()
    {
        btnLevel.onClick.AddListener(OnClickLeveButton);
    }

    private void OnClickLeveButton()
    {
        //LevelPanel.Instance.levelName = levelsName.ToString();
        LevelPanel.Instance.OnContinueButtonPressed(levelsName.ToString());
    }
}
public enum LevelsName
{

    NotSet = -1,
    CETInstallation = 0,
    CETinterface = 1,
    CETnavigation = 2,
}
