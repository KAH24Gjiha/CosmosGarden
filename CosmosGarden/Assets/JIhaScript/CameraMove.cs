using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum GESTURE
{
    MOVE = 1,
    ZOOM,
}

public class CameraMove : MonoBehaviour
{
    float m_fSpeed = 0.01f;       // ���� �ӵ��� �����մϴ� 
    float m_fFieldOfView = 60f;     // ī�޶��� FieldOfView�� �⺻���� 60���� ���մϴ�.

    public GameObject background;

    private float Speed = 0.25f;
    private Vector2 nowPos, prePos;
    private Vector3 movePos;

    public SpriteRenderer sr;

    public float SpriteX;
    public float SpriteY;
    public float ScreenX;
    public float ScreenY;

    private void Start()
    {
        sr = background.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        CheckTouch();
        MoveCam();
    }
    private void MoveCam()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                prePos = touch.position - touch.deltaPosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                nowPos = touch.position - touch.deltaPosition;
                movePos = (Vector3)(prePos - nowPos) * Time.deltaTime * Speed;
                GetComponent<Camera>().transform.Translate(movePos);
                prePos = touch.position - touch.deltaPosition;
            }
        }
        background.transform.position =  new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
    }
    void CheckTouch()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            //�ι�° ��ġ ���� ����
            Touch touchOne = Input.GetTouch(1);

            //���� ��ġ�� ���� ��ġ�� ����Ѵ�.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            //(������-������ġ).magnitude : ���� �Ÿ�
            //���� ��ġ�� ���� ��ġ���� �Ÿ��� ����Ѵ�
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            //�� �հ��� ���� �Ÿ��� ����Ѵ�
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            //orthographic����϶�
            if (GetComponent<Camera>().orthographic)
            {
                GetComponent<Camera>().orthographicSize += deltaMagnitudeDiff * m_fSpeed;
                GetComponent<Camera>().orthographicSize = Mathf.Max(GetComponent<Camera>().orthographicSize, 0.1f);
            }
            //fieldOfView����϶�
            else
            {
                GetComponent<Camera>().fieldOfView += deltaMagnitudeDiff * m_fSpeed;
                GetComponent<Camera>().fieldOfView = Mathf.Clamp(GetComponent<Camera>().fieldOfView, 0.1f, 179.9f);
            }
            SpriteScaleChange();
        }
    }
    public void SpriteScaleChange()
    {
        SpriteX = sr.sprite.bounds.size.x;
        SpriteY = sr.sprite.bounds.size.y;

        ScreenY = Camera.main.orthographicSize * 2;
        ScreenX = ScreenY / Screen.height * Screen.width;
        
        background.transform.localScale = new Vector3(Mathf.Ceil(ScreenX / SpriteX), Mathf.Ceil(ScreenY / SpriteY), 0);
    }
    
}

