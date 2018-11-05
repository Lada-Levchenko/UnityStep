using UnityEngine;
using UnityEngine.UI;

public class CameraControl : MonoBehaviour
{

    public float panSpeed = 0.1f;
    //public float speed = 0.1f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 40f;
    public float minY = 20f;
    public float maxY = 120f;

    Vector3 touchStart;
    public Text debugText;
    Camera cam;

    void Start()
    {
        Vector3 Terr = FindObjectOfType<Terrain>().terrainData.size;
        panLimit = new Vector2(Terr.x, Terr.z);
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;


        if (Input.GetMouseButtonDown(0))
        {
            touchStart = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if(Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;
            float prevMaginitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;
            float difference = currentMagnitude - prevMaginitude;
            //zoom(difference * 0.01f);
        }
        else if(Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - cam.ScreenToWorldPoint(Input.mousePosition);
            transform.Translate(direction.x * panSpeed, 0, direction.y * panSpeed, Space.World);
        }
        //zoom(Input.GetAxis("Mouse ScrollWheel"));*/
        /*
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ToutchDeltaPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-ToutchDeltaPos.x * panSpeed, -ToutchDeltaPos.y * panSpeed, 0, Space.World);
            debugText.text += ToutchDeltaPos.x + " " + ToutchDeltaPos.y + "\n";
        }*/

        /*if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.z += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            pos.z -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            pos.x -= panSpeed * Time.deltaTime;
        }
        if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            pos.x += panSpeed * Time.deltaTime;
        }*/

        //pos.x = Mathf.Clamp(pos.x, 0, panLimit.x);
        //pos.y = Mathf.Clamp(pos.y, minY, maxY);
        //pos.z = Mathf.Clamp(pos.z, 0, panLimit.y);

        //transform.position = pos;
    }

    void zoom(float axis)
    {
        transform.position -= axis * scrollSpeed * 100f * Time.deltaTime * Vector3.up;
    }
}

