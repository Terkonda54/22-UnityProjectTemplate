using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Vector3[] Positions;

    private int mCurrentIndex = 0;

    public static int stage = 1;
    private int oldStage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPos = Positions[mCurrentIndex];

        if (stage > oldStage)
        {
            if (mCurrentIndex < Positions.Length - 1)
            {
                mCurrentIndex++;
            }
            oldStage = stage;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (mCurrentIndex > 0)
            {
                mCurrentIndex--;
            }
        }

        transform.position = Vector3.Lerp(transform.position, currentPos, 0.75f * Time.deltaTime);
    }
}
