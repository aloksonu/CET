using System.Collections;
using CET.Common.Audio;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace CET.AudioData
{
    public class CETAudioManager : MonoSingleton<CETAudioManager>
    {
        private const float audioFinishDelay = 0.2f;
        void Start()
        {
        
        }

        internal void PlayAudio(AudioName audioName , Canvas canvas, float time=0f)
        {
            StartCoroutine(EPlayAudio(audioName, canvas, time));
            //canvas.GetComponent<GraphicRaycaster>().enabled = false;
            //GenericAudioManager.Instance.PlaySound(audioName);
            //this.Invoke(()=> {canvas.GetComponent<GraphicRaycaster>().enabled = true;}, GenericAudioManager.Instance.GetAudioLength(audioName) + audioFinishDelay);
        }

        IEnumerator EPlayAudio(AudioName audioName, Canvas canvas , float time)
        {
            yield return new WaitForSeconds(time);
            canvas.GetComponent<GraphicRaycaster>().enabled = false;
            GenericAudioManager.Instance.PlaySound(audioName);
            yield return new WaitForSeconds(GenericAudioManager.Instance.GetAudioLength(audioName) + audioFinishDelay);
            canvas.GetComponent<GraphicRaycaster>().enabled = true;
        }
    }
}
