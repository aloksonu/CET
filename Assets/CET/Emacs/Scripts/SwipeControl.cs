using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour
{
    [SerializeField] private GameObject scrollBar;
    [SerializeField] private Button buttonNext;
    [SerializeField] private Button buttonPrevious;
    float scrollPos = 0;
    float[] pos;

    int currentIndex = 0;
    void Start()
    {
        buttonNext.onClick.AddListener(next);
        buttonPrevious.onClick.AddListener(previous);
        pos = new float[transform.childCount];
        EnableSwipeButtons();
    }

    private void OnDestroy()
    {
        buttonNext.onClick.RemoveAllListeners();
        buttonPrevious.onClick.RemoveAllListeners();
    }

    private void EnableSwipeButtons()
    {
        if (currentIndex == pos.Length - 1)
            buttonNext.gameObject.SetActive(false);
        else
            buttonNext.gameObject.SetActive(true);

        if (currentIndex == 0)
            buttonPrevious.gameObject.SetActive(false);
        else
            buttonPrevious.gameObject.SetActive(true);
    }

    public void next()
    {
        if(currentIndex < pos.Length - 1)
        {
            currentIndex++;
            scrollPos = pos[currentIndex];
        }
        EnableSwipeButtons();
    }

    public void previous()
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            scrollPos = pos[currentIndex];
        }
        EnableSwipeButtons();
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];
        float distance = 1f / (pos.Length - 1f);
        for(int i=0; i<pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButtonDown(0))
        {
            scrollPos = scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if(scrollPos < pos[i]+ (distance/2) && scrollPos > pos[i] - (distance / 2))
                {
                    // 0.5 on increasing scroll will move fast and decreasing scroll move slow
                    scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
                    currentIndex = i;
                }
            }
        }
    }
}
