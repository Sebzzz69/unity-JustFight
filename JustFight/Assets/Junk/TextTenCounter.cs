using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using TMPro.EditorUtilities;
using UnityEngine;

public class TextTenCounter : MonoBehaviour
{
    [SerializeField] private Sprite[] spriteArray;
    public GameObject colekted;
    int counter;
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
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteArray[Dubledidgets(counter) / 10];
        }



    }
    int Dubledidgets(int valu)
    {
        return valu - valu % 10;

    }
}