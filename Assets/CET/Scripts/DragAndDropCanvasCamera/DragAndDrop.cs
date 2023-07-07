using CET.Common.Audio;
using CET.Common.Score;
using UnityEngine;
using UnityEngine.EventSystems;
using Utilities;

namespace CET.Scripts.DragAndDropCanvasCamera
{
    public class DragAndDrop : MonoBehaviour,IPointerDownHandler,IBeginDragHandler,IEndDragHandler,IDragHandler
    {
        private RectTransform rt;
        private CanvasGroup cg;
        public Canvas canvas;
        public int id;
        private Vector2 initialPos;
        private bool isDrop;
    
        void Start()
        {
            isDrop = false;
            rt = GetComponent<RectTransform>();
            cg = GetComponent<CanvasGroup>();
            //initialPos = transform.position;
            this.Invoke(() => SetInitialPosition(), 0.2f);
        }

        private void SetInitialPosition()
        {
            initialPos = transform.position;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            cg.blocksRaycasts = false;
        }
        public void OnDrag(PointerEventData eventData)
        {
            //rt.anchoredPosition += eventData.delta;
            rt.anchoredPosition += eventData.delta/canvas.scaleFactor;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            cg.blocksRaycasts = true;
            if(isDrop == false)
                transform.position = initialPos;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("On Pointer Down");
        }

        public void ResetPosition()
        {
            transform.position = initialPos;
        }
        public void UpdateHealth()
        {
            HealthManager.Instance.UpdateHealth(1);
            if (HealthManager.Instance.GetHealth() <= 0)
            {
                LevelFail.Instance.BringIn();
            }
        }
        public void UpdateIsDrop() {
            isDrop = true;
            UpdateScore();
            if(id==1)
                TextWithImageNarrator.Instance.BringInNarrator(TextWithImageNarrator.Instance.NTopArea, AudioName.TopArea, TextWithImageNarrator.Instance.spriteTopArea,() =>CETinterfaceManager.Instance.UpdateDragedCounter());
            else if (id == 2)
                TextWithImageNarrator.Instance.BringInNarrator(TextWithImageNarrator.Instance.NComponentsArea, AudioName.ComponentsArea, TextWithImageNarrator.Instance.spriteComponentsArea, () =>CETinterfaceManager.Instance.UpdateDragedCounter());
            else if (id == 3)
                TextWithImageNarrator.Instance.BringInNarrator(TextWithImageNarrator.Instance.N2DArea, AudioName.TwoDView, TextWithImageNarrator.Instance.sprite2DArea, () =>CETinterfaceManager.Instance.UpdateDragedCounter());
            else if (id == 4)
                TextWithImageNarrator.Instance.BringInNarrator(TextWithImageNarrator.Instance.N3DArea, AudioName.ThreeDView, TextWithImageNarrator.Instance.sprite3DArea, () =>CETinterfaceManager.Instance.UpdateDragedCounter());
        }

        public void UpdateScore()
        {
            ScoreManager.Instance.UpdateScore(10, 10);
        }

        public void ResetIsDrop()
        {
            isDrop = false;
        }
    }
}
