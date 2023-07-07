using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CET.Emacs.Scripts
{
    public class ChapterSwipe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        [SerializeField] private Button buttonLeft;
        [SerializeField] private Button buttonRight;
        [SerializeField] private Scrollbar scrollbar;
        [SerializeField] private float swipeDeltaFactor = 20;

        [SerializeField] private TextMeshProUGUI typeTextMeshProUGUI;

        private CanvasGroup[] _canvasGroupChapter;
        private Canvas[] _chapterCanvas;
        private Image[] _imageSethestiscope;
        private float[] _itemPos;
        private float _distance;
        private int i, j;
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        private float _dragDeltaMagnitude;
        private bool _canSwipe;
        private int _currentIndex;
        private float nextPosition;
        private bool _isLeftSwipe;
        private float _fadeDuration = .5f;

        void Start()
        {
            buttonLeft.onClick.AddListener(OnClickButtonLeft);
            buttonRight.onClick.AddListener(OnClickButtonRight);

            var numberOfChapter = transform.childCount;
            _itemPos = new float[numberOfChapter];
            _chapterCanvas = new Canvas[numberOfChapter];
            _canvasGroupChapter = new CanvasGroup[numberOfChapter];
            _imageSethestiscope = new Image[numberOfChapter];
            _distance = 1f / (_itemPos.Length - 1f);
            for (int i = 0; i < _itemPos.Length; i++)
            {
                _itemPos[i] = _distance * i;
               // _canvasGroupChapter[i] = transform.GetChild(i).GetComponent<CanvasGroup>();
                //_chapterCanvas[i] = transform.GetChild(i).GetComponent<Canvas>();
               // _imageSethestiscope[i] = transform.GetChild(i).transform.GetChild(0).GetComponent<Image>();
            }
            SwipePanel();
        }
        private void OnDestroy()
        {
            buttonLeft.onClick.RemoveAllListeners();
            buttonRight.onClick.RemoveAllListeners();
        }
        private void Update()
        {
            if (!_canSwipe) return;
            scrollbar.value = Mathf.Lerp(scrollbar.value, nextPosition, _fadeDuration * Time.deltaTime * 20f);
            if (_isLeftSwipe)
            {
                if (scrollbar.value > nextPosition - .001f)
                {
                    scrollbar.value = nextPosition;
                    _canSwipe = false;
                }
            }
            else
            {
                if (scrollbar.value < nextPosition + .001f)
                {
                    scrollbar.value = nextPosition;
                    _canSwipe = false;
                }
            }

        }
        private void OnClickButtonLeft()
        {
            if (_currentIndex < _itemPos.Length - 1 && !_canSwipe)
            {
                nextPosition = _itemPos[++_currentIndex];
                _canSwipe = true;
                _isLeftSwipe = true;
                SwipePanel();
            }

        }
        private void OnClickButtonRight()
        {

            if (_currentIndex > 0 && !_canSwipe)
            {
                nextPosition = _itemPos[--_currentIndex];
                _canSwipe = true;
                _isLeftSwipe = false;
                SwipePanel();
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            _startPosition = eventData.position;
        }
        public void OnEndDrag(PointerEventData eventData)
        {
            _endPosition = eventData.position;
            _dragDeltaMagnitude = Vector3.Distance(_endPosition, _startPosition);
            if (Mathf.Abs(_endPosition.x - _startPosition.x) > Mathf.Abs(_endPosition.y - _startPosition.y) &&
                _dragDeltaMagnitude >= swipeDeltaFactor)
            {
                if (_endPosition.x > _startPosition.x)
                    OnClickButtonRight();
                else
                    OnClickButtonLeft();
            }
            _dragDeltaMagnitude = 0;
        }

        private void EnableSwipeButtons()
        {
            if (_currentIndex == _itemPos.Length - 1)
                buttonLeft.gameObject.SetActive(false);
            else
                buttonLeft.gameObject.SetActive(true);

            if (_currentIndex == 0)
                buttonRight.gameObject.SetActive(false);
            else
                buttonRight.gameObject.SetActive(true);
        }

        private void SwipePanel()
        {
            EnableSwipeButtons();
            //_chapterCanvas[_currentIndex].overrideSorting = true;
            //transform.GetChild(_currentIndex).DOScale(new Vector3(1, 1, 1), _fadeDuration);
           // _canvasGroupChapter[_currentIndex].UpdateState(1, true, fadeDuration: _fadeDuration);
            _imageSethestiscope[_currentIndex].DOFade(1, _fadeDuration);

            for (j = 0; j < _itemPos.Length; j++)
            {
                if (j != _currentIndex)
                {
                    if (j == _currentIndex + 1 || j == _currentIndex - 1)
                    {
                        //_chapterCanvas[j].overrideSorting = false;
                        //transform.GetChild(j).DOScale(new Vector3(.7f, .7f, 1f), _fadeDuration);
                       // _canvasGroupChapter[j].UpdateState(endAlphaValue: .4f, false, fadeDuration: _fadeDuration);
                        _imageSethestiscope[j].DOFade(0, _fadeDuration);
                    }
                    else
                    {
                      //  _canvasGroupChapter[j].UpdateState(endAlphaValue: 0, false, fadeDuration: .3f);
                    }
                }
            }
        }
    }
}
