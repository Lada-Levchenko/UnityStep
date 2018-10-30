using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float panSpeed = 20f;
    public float speed = 0.1f;
    public float panBorderThickness = 10f;
    public Vector2 panLimit;

    public float scrollSpeed = 40f;
    public float minY = 20f;
    public float maxY = 120f;

    void Start()
    {
        Vector3 Terr = FindObjectOfType<Terrain>().terrainData.size;
        panLimit = new Vector2(Terr.x, Terr.z);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 ToutchDeltaPos = Input.GetTouch(0).deltaPosition;
            transform.Translate(-ToutchDeltaPos.x * speed, -ToutchDeltaPos.y * speed, 0);
            Debug.Log(ToutchDeltaPos.x + " " + ToutchDeltaPos.y);
        }

		if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
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
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed * 100f * Time.deltaTime;

        pos.x = Mathf.Clamp(pos.x, 0, panLimit.x);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        pos.z = Mathf.Clamp(pos.z, 0, panLimit.y);

        transform.position = pos;
	}
}
