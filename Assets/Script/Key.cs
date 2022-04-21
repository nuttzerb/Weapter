using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Key : MonoBehaviour
{
    public Sprite[] key;
    private Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.haveKey)
        {
            image.sprite = key[1];
        }
        else
        {
            image.sprite = key[0];
        }
    }
}
