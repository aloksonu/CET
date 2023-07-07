using System.Collections.Generic;
using CET.Common.Audio;
using CET.Scripts.DragAndDropCanvasCamera;
using UnityEngine;
using Utilities;

namespace CET.Scripts
{
    public class CETinterfaceManager : MonoSingleton<CETinterfaceManager>
    {
        [SerializeField] GameObject[] dragObjects;
        private List<Vector3> listPos = new List<Vector3>();
        private int dragCounter;
        void Start()
        {
            GenericAudioManager.Instance.PlaySound(AudioName.CETinterface);
            dragCounter = 0;

            for (int i = 0; i< dragObjects.Length;i++)
            {
                listPos.Add(dragObjects[i].transform.position);
            }
            listPos.Shuffle();
            for (int i = 0; i < dragObjects.Length; i++)
            {
                dragObjects[i].transform.position = listPos[i];
            }

        }

        internal void ResetGame()
        {
            foreach(GameObject g in dragObjects)
            {
                g.GetComponent<DragAndDrop>().ResetPosition();
                g.GetComponent<DragAndDrop>().ResetIsDrop();
            }
            dragCounter = 0;
        }

        internal void UpdateDragedCounter()
        {
            dragCounter++;
            if(dragCounter>= dragObjects.Length)
            {
                LevelComplete.Instance.BringIn(0f);
            }
        }
        internal int GetDragedCounter()
        {
            return dragCounter;
        }
    }
}
