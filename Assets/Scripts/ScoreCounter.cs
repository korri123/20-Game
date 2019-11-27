using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI scoreLabel;

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = GameManager.Instance.Score.ToString();
    }
    
    
}
