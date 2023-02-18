using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    int idelTest;
    int timeRight = 0;
    [SerializeField] private Sprite[] spriteArray;

    [SerializeField] KeyCode moveLeft;
    [SerializeField] KeyCode moveRight;

    void Start()
    {

    }


    void Update()
    {
        Vector3 newScale = transform.localScale;

        _ = timeRight++ * Time.deltaTime;

        if (Input.GetKey(moveRight))
        {
           // newScale.x = 7f;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[timeRight / 100];
            idelTest = 0;
        }
        else if (Input.GetKey(moveLeft))
        {
           // newScale.x = -7f;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[timeRight / 100];
            idelTest = 0;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[4];
        }

        if (timeRight == 400)
        {
            timeRight = 0;
        }
        transform.localScale = newScale;

    }
}
