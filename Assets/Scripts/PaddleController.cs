using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float rotationSpeed;

    private bool wantsToRotate;

    private float velocity;

    public GameObject Trailing;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        bool rightButton = Input.GetKey(KeyCode.RightArrow);
        bool leftButton = Input.GetKey(KeyCode.LeftArrow);

        if (rightButton && leftButton)
        {
            //velocity = 0F;
        }
        else if (rightButton)
        {
            velocity = Time.fixedDeltaTime * rotationSpeed;
        }
        else if (leftButton)
        {
            velocity = Time.fixedDeltaTime * rotationSpeed * -1;
        }
        
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, velocity);
        velocity *= 0.8F;
    }
}