using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashEffect : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float duration;

    private SpriteRenderer spriteRenderer;
    private Material originalMaterial;
 //  private Coroutine flashRoutine;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalMaterial = spriteRenderer.material;
    }
    IEnumerator FlashRoutine()
    {
        spriteRenderer.material = flashMaterial;
        yield return new WaitForSeconds(duration);
        spriteRenderer.material = originalMaterial;
    //  flashRoutine = null;
    }
    public void Flash()
    {
/*        if (flashRoutine!=null)
        {
            Debug.Log(flashRoutine);
            StopCoroutine(flashRoutine);
        }*/
     //   flashRoutine = StartCoroutine(FlashRoutine());
        StartCoroutine(FlashRoutine());
    }
}
