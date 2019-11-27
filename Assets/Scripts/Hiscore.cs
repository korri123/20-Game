using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiscore : MonoBehaviour
{

    public TMPro.TextMeshProUGUI HiscoreLabel;

    public TMPro.TextMeshProUGUI HiscoreText;
    // Start is called before the first frame update

    private int HiscoreValue = 0;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.Hiscore != HiscoreValue)
        {
            HiscoreLabel.text = GameManager.Instance.Hiscore.ToString();
            HiscoreValue = GameManager.Instance.Hiscore;
            Flash();
        }
    }

    public void Flash()
    {
        Color color = Color.white;
        for (int i = 0; i < 120; i++)
        {
            StartCoroutine(Common.DelayedAction(() =>
                {
                    if (color == Color.white)
                    {
                        color = Color.black;
                    }
                    else
                    {
                        color = Color.white;
                    }

                    HiscoreLabel.color = color;
                    HiscoreText.color = color;
                }, i * 0.017F));
        }
    }
    
}
