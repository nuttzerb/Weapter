using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterMenu : MonoBehaviour
{
    public Text characterText, priceText;

    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;

    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;
            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChange();
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;
            OnSelectionChange();
        }
    }

    private void OnSelectionChange()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        GameManager.instance.player.spriteRenderer.sprite = characterSelectionSprite.sprite;
        GameManager.instance.player.animator.runtimeAnimatorController = GameManager.instance.playerAnimation[currentCharacterSelection] as RuntimeAnimatorController;
    }
    public void OnBuyClick()
    {

    }
    public void UpdateMenu()
    {
         
    }
}
