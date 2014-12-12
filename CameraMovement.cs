using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject CameraObject;
    public float ExtraxWidth;
    public float ModifiedCameraObjectX;

    public Vector2
        Margin,
        Smoothing;

    public BoxCollider2D Bounds;

    private Vector3
        _min,
        _max;

    public bool IsFollowing { get; set; }

    public void Start()
    {
        _min = Bounds.bounds.min;
        _max = Bounds.bounds.max;
        IsFollowing = true;
    }

    public void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;

        if (IsFollowing)
        {
            if (ExtraxWidth >= 3)
                ExtraxWidth = 3;

            if (ExtraxWidth <= -3)
                ExtraxWidth = -3;

            CameraObject.transform.Translate(ExtraxWidth, 0, 0);

            if (Mathf.Abs(x - CameraObject.transform.position.x) > Margin.x)
                x = Mathf.Lerp(x, CameraObject.transform.position.x, Smoothing.x * Time.deltaTime);

            if (Mathf.Abs(y - CameraObject.transform.position.x) > Margin.y)
                y = Mathf.Lerp(y, CameraObject.transform.position.y, Smoothing.y * Time.deltaTime);
        }

        var cameraHalfWidth = camera.orthographicSize * ((float)Screen.width / Screen.height);

        x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
        y = Mathf.Clamp(y, _min.y + camera.orthographicSize, _max.y - camera.orthographicSize);

        transform.position = new Vector3(x, y, transform.position.z);
    }


}

