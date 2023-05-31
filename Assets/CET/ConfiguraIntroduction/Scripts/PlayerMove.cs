using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public JoystickMovement joystickMovement;
    public float playerSpeed;
    private Rigidbody2D rb;
    private Vector2 playerInitialPosition;
    void Start()
    {
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

        if (other.gameObject.GetComponent<SubLevelName>().subLevelName == SubLevel.CET)
        {
            StartCoroutine(CallOnCorrect(other.gameObject));
            //other.gameObject.SetActive(false);
        }
        if (other.gameObject.GetComponent<SubLevelName>().subLevelName == SubLevel.EMacs)
        {
            StartCoroutine(CallOnCorrect(other.gameObject));
            //other.gameObject.SetActive(false);
        }
        if (other.gameObject.GetComponent<SubLevelName>().subLevelName == SubLevel.CM)
        {
            StartCoroutine(CallOnCorrect(other.gameObject));
            //other.gameObject.SetActive(false);
        }
    }

    private IEnumerator CallOnCorrect(GameObject other)
    {
        other.SetActive(false);
        yield return new WaitForSeconds(0.0f);
    }
}
