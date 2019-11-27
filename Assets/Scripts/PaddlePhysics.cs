using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddlePhysics : MonoBehaviour
{    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D ball = other.attachedRigidbody;
        if (ball != null)
        {
            Vector2 paddleNormal = transform.up;
            float ballAngle = Vector2.Angle(paddleNormal, ball.velocity);
            if (ballAngle > 90)
            {
                Vector2 reflectedVelocity = Vector2.Reflect(ball.velocity, paddleNormal);
                float reflectAngle = Vector2.SignedAngle(paddleNormal, reflectedVelocity);

                if (Mathf.Abs(reflectAngle) > 90)
                {
                    float deltaAngle = (Mathf.Sign(reflectAngle) * 90) - reflectAngle;
                    Quaternion clampRotation = Quaternion.Euler(0, 0, deltaAngle);
                    reflectedVelocity = clampRotation * reflectedVelocity;
                }

                ball.velocity = reflectedVelocity;

                GameManager.Instance.PaddleHit();
            }
        }
    }
}
