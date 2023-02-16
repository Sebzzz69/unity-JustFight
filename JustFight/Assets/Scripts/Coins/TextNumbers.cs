using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class TextNumbers : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;
    public GameObject colekted;
    public int counter;

    void Start()
    {
    }
    void Update()
    {
        if (colekted != null)
        {
            counter = colekted.GetComponent<CoinCollector>().coins;
        }
        else
        {
            colekted = null;
        }

        if (counter >= 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[singular(counter)];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[counter];
        }
        
        // Player wins if 15 or more score
        if (counter >= 15)
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.WinSenario(this.gameObject.name);   
        }
    }
    int singular(int dubbleDidgets)
    {
        return dubbleDidgets % 10;

    }
}