using UnityEngine;
using UnityEngine.UI;

namespace CET.Scripts
{
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
            LevelPanel.Instance.levelName = levelsName;
            LevelPanel.Instance.OnContinueButtonPressed(levelsName.ToString());
        }
    }
    public enum LevelsName
    {

        NotSet = -1,
        ConfiguraIntroduction =0,
        CETInstallation = 1,
        CETinterface = 2,
        CETnavigation = 3,
        Emacs = 4,
    }
}