using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    private Camera cameraComponent;
    public bool isRightSide;

    // Start is called before the first frame update
    void Start()
    {
        cameraComponent = GetComponent<Camera>();

        if (isRightSide)
        {
            MakeRightSideSplitScreen();
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
        //TODO: Make Full Screen
    }

    public void MakeRightSideSplitScreen()
    {
        cameraComponent.rect = new Rect(0, 0, 0.5f, 1);
    }

    public void MakeLeftSideSplitScreen()
    {
        cameraComponent.rect = new Rect(0.5f, 0, 0.5f, 1);
    }

    public void LookAtTarget()
    {
        transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }


}
