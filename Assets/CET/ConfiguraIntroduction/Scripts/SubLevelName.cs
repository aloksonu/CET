using CET.Common.Audio;
using UnityEngine;

namespace CET.ConfiguraIntroduction.Scripts
{
    public class SubLevelName : MonoBehaviour
    {
        public SubLevel subLevelName;
        public AudioName audioName;
        void Start()
        {
        
        }
    }

    public enum SubLevel
    {
        NotSet = 0,
        CET = 1,
        EMacs = 2,
        CM = 3,
    }
}