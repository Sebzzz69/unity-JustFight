using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    int timeRight = 0;
    [SerializeField] private Sprite[] spriteArray;

    [SerializeField] KeyCode rightKey;
    [SerializeField] KeyCode leftKey;

    void Update()
    {

        Vector3 newScale = transform.localScale;

        _ = timeRight++ * Time.deltaTime;
        if (Input.GetKey(rightKey))
        {
            newScale.x = 27f;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[timeRight / 100];
        }

        if (Input.GetKey(leftKey))
        {
            newScale.x = -27f;
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[timeRight / 100];
        }


        if (timeRight == 400)
        {
            timeRight = 0;
        }
        transform.localScale = newScale;

    }
}
