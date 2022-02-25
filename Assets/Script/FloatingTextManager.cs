using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();
    private void Start()
    {
        DontDestroyOnLoad(transform.parent.gameObject);
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
      //  FloatingText floatingText = GetFloatingText();
/*        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;
        floatingText.txt.transform.position = Camera.main.WorldToScreenPoint(position); // transfer world space to scene space
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();*/
    }

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
        {
          //  txt.UpdateFloatingText();
        }
    }
/*    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }*/
}
