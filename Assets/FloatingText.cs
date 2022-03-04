using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    Renderer textRenderer;
    // Start is called before the first frame update
    private void Awake()
    {
        textRenderer = gameObject.GetComponent<Renderer>();
    }
    void Start()
    {
        textRenderer.sortingLayerID = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
