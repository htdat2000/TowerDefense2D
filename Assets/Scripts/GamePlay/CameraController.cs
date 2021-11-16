using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public float xMin, xMax, yMin, yMax;

    void Update()
    {
        if (GameManager.gameOver)
        {
            this.enabled = false;
        }

       //if(Input.touchCount == 1)
       // {
            PanCamera();
       // }

        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 prevTouchZeroPos = touchZero.position - touchZero.deltaPosition;
            Vector2 prevTouchOnePos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (prevTouchZeroPos - prevTouchOnePos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMagnitude;

            ZoomCamera(difference * 0.01f);
        }

        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            ZoomCamera(Input.GetAxis("Mouse ScrollWheel"));      
        }
    }

    Vector3 touchStart;
    void PanCamera()
    {
        if(Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), Mathf.Clamp(transform.position.y, yMin, yMax), -10f);
        }
    }

    public float minZoom = 1f;
    public float maxZoom = 5f;
    void ZoomCamera(float increment)
    {
        Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize - increment, minZoom, maxZoom);
    }
}
