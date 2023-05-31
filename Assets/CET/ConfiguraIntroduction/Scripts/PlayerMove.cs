using Audio.CET;
using System.Collections;
using System.Collections.Generic;
using Ui.ScoreSystem;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private IntroTextNarrator introTextNarrator;
    public JoystickMovement joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerInitialPosition;
    private int collectCounter;
    void Start()
    {
        collectCounter = 0;
        playerInitialPosition = this.transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (joystickMovement.joysticVect.y != 0)
        {
            rb.velocity = new Vector2(joystickMovement.joysticVect.x * playerSpeed, joystickMovement.joysticVect.y * playerSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(CallOnCollide(other.gameObject));
    }

    private IEnumerator CallOnCollide(GameObject other)
    {
        yield return new WaitForSeconds(0.0f);
        if (other.GetComponent<SubLevelName>().subLevelName == SubLevel.CET)
        {
            collectCounter++;
            ScoreManager.Instance.UpdateScore(10, 10);
            GenericAudioManager.Instance.PlaySound(AudioName.Correct);
            string str = introTextNarrator.CET1 + introTextNarrator.CET2;
            other.SetActive(false);
            yield return new WaitForSeconds(0.0f);
            introTextNarrator.BringInNarrator(str, OnComplete, other.GetComponent<SubLevelName>().audioName);
        }
        else if (other.GetComponent<SubLevelName>().subLevelName == SubLevel.EMacs)
        {
            collectCounter++;
            ScoreManager.Instance.UpdateScore(10, 10);
            GenericAudioManager.Instance.PlaySound(AudioName.Correct);
            string str = introTextNarrator.Emacs;
            other.SetActive(false);
            yield return new WaitForSeconds(0.0f);
            introTextNarrator.BringInNarrator(str, OnComplete, other.GetComponent<SubLevelName>().audioName);
        }
        else if (other.GetComponent<SubLevelName>().subLevelName == SubLevel.CM)
        {
            collectCounter++;
            ScoreManager.Instance.UpdateScore(10, 10);
            GenericAudioManager.Instance.PlaySound(AudioName.Correct);
            string str = introTextNarrator.CM1 + introTextNarrator.CM2;
            other.SetActive(false);
            yield return new WaitForSeconds(0.0f);
            introTextNarrator.BringInNarrator(str, OnComplete, other.GetComponent<SubLevelName>().audioName);
        }
        else
        {
            GenericAudioManager.Instance.PlaySound(AudioName.Wrong);
            GetComponent<BoxCollider2D>().enabled = false;
            LevelFail.Instance.BringIn();
        }
    }

    private void OnComplete()
    {
        if (collectCounter >= 3) {
            LevelComplete.Instance.BringIn();
        }       
    }
}
