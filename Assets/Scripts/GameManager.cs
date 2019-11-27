using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Score;

    public Camera GameCamera;

    public AudioSource PunchAudio;

    public GameObject Paddle;

    public AudioSource LoseAudio;

    public AudioSource HiscoreAudio;

    public int Hiscore;

    private void Awake()
    {
        Instance = this;
    }

    public void PaddleHit()
    {
        Score++;
        Color c = GameCamera.backgroundColor;
        Color preflash = new Color(c.r+0.2F, c.g + 0.2F, c.b + 0.2F);
        GameCamera.backgroundColor = preflash;
        Color flash = new Color(c.r+0.5F, c.g + 0.5F, c.b + 0.5F);
        Vector3 originalPosition = GameCamera.transform.localPosition;
        Vector3 down = new Vector3(0, 0, 0.4F);
        GameCamera.transform.localPosition += down;
        StartCoroutine(Common.DelayedAction(() =>
        {
            GameCamera.transform.localPosition -= new Vector3(0, 0, 0.2F);
            GameCamera.backgroundColor = flash;
        }, 0.02F));
        StartCoroutine(Common.DelayedAction(() =>
        {
            GameCamera.transform.localPosition = originalPosition;
            GameCamera.backgroundColor = Random.ColorHSV();
        }, 0.05F));
        
        Paddle.transform.localScale *= 0.9F;
        PunchAudio.Play();
    }
    
    
}
