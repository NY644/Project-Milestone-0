using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    private Camera cameraComponent;
    public bool isRightSide;
    public bool Fullscreen;

    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = GetComponent<Camera>();

        if (Fullscreen)
        {
            MakeFullScreen();
        }

        else if (isRightSide)
        {
            MakeRightSideSplitScreen();
            //TODO: Test full screen here.
            // MakeFullScreen();
        }

        else
        {
            MakeLeftSideSplitScreen();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtTarget();
    }

    public void MakeFullScreen()
    {
        // By doing nothing here, a new Rect is not created
        // thus, it stays full screen.
        cameraComponent.rect = new Rect(0, 0, 1, 1);
    }

    public void MakeLeftSideSplitScreen()
    {
        cameraComponent.rect = new Rect(0, 0, 0.5f, 1);
    }

    public void MakeRightSideSplitScreen()
    {
        cameraComponent.rect = new Rect(0.5f, 0, 0.5f, 1);
    }

    public void LookAtTarget()
    {
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }


}
