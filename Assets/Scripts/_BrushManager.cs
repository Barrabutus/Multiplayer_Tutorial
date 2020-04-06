using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _BrushManager : MonoBehaviour
{

    public bool isDragging = false;
    public float startPosX; 
    public float startPosY;

    public GameObject paint;

    public List<Color> colors = new List<Color>();

    // Start is called before the first frame update

    void Update()
    {
        if(isDragging == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);

            Instantiate(paint,new Vector3(mousePos.x, mousePos.y, 0),Quaternion.identity);
            

        }

    }
    private void OnMouseDown() {

        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            isDragging = true;
            
        }

    }
    private void OnMouseUp() {

        isDragging = false;
        
    }


}
