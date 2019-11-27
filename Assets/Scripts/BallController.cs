using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 levelBounds;

    public float speed;

    public Rigidbody2D body;

    public Vector2 direction;

    public Vector2 startPosition;

    private Vector3 originalScale;

    
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        originalScale = GameManager.Instance.Paddle.transform.localScale;
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        float ballAngle = Vector2.Angle(transform.position, body.velocity);
        if (ballAngle < 90 && 
            transform.position.x < -levelBounds.x || 
            transform.position.x > levelBounds.x ||
            transform.position.y < -levelBounds.y || 
            transform.position.y > levelBounds.y)
        {
            Lose();
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = startPosition;
        body.velocity = direction.normalized * speed;
        GameManager.Instance.Score = 0;
        GameManager.Instance.Paddle.transform.localScale = originalScale;
    }

    private void Lose()
    {
        if (GameManager.Instance.Score > GameManager.Instance.Hiscore)
        {
            GameManager.Instance.Hiscore = GameManager.Instance.Score;
            GameManager.Instance.HiscoreAudio.Play();
            
        }
        else
        {
            GameManager.Instance.LoseAudio.Play();
        }
    }
}
