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
    float m_fSpeed = 0.1f;       // ���� �ӵ��� �����մϴ� 
    float m_fFieldOfView = 60f;     // ī�޶��� FieldOfView�� �⺻���� 60���� ���մϴ�.

    public GameObject background;

    void Update()
    {
        CheckTouch();
        MoveCam();
        ObjMove();
    }
    private void MoveCam()
    {
        if (Input.touchCount == (int)GESTURE.MOVE)
        {
            Touch touch = Input.touches[0];
            Camera.main.transform.position = new Vector3(
                Camera.main.transform.position.x - touch.deltaPosition.x,
                Camera.main.transform.position.y - touch.deltaPosition.y,
                Camera.main.transform.position.z);

            background.transform.position = new Vector3
                (
                background.transform.position.x - touch.deltaPosition.x,
                background.transform.position.y - touch.deltaPosition.y,
                background.transform.position.z);
        }
    }
    void CheckTouch()
    {
        if (Input.touchCount == 2)
        {
            Vector2 vecPreTouchPos0 = Input.touches[0].position - Input.touches[0].deltaPosition;
            Vector2 vecPreTouchPos1 = Input.touches[1].position - Input.touches[1].deltaPosition;

            // ���� �� ��ġ�� ���� 
            float fPreDis = (vecPreTouchPos0 - vecPreTouchPos1).magnitude;
            // ���� �� ��ġ�� ��
            float fToucDis = (Input.touches[0].position - Input.touches[1].position).magnitude;


            // ���� �� ��ġ�� �Ÿ��� ���� �� ��ġ�� �Ÿ��� ����
            float fDis = fPreDis - fToucDis;

            // ���� �� ��ġ�� �Ÿ��� ���� �� ��ġ�� �Ÿ��� ���̸� FleldOfView�� �����մϴ�.
            m_fFieldOfView += (fDis * m_fSpeed);

            // �ִ�� 100, �ּҴ� 20���� ���̻� ���� Ȥ�� ���Ұ� ���� �ʵ��� �մϴ�.
            m_fFieldOfView = Mathf.Clamp(m_fFieldOfView, 20.0f, 100.0f);

            Camera.main.fieldOfView = m_fFieldOfView;
            

        }
    }
    void ObjMove()
    {
        if (Input.touchCount == 2)
        {
            Vector2 prevPos0 = Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition;
            Vector2 prevPos1 = Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition;

            float prevDistance = (prevPos0 - prevPos1).magnitude;
            float currDistance = (Input.GetTouch(0).position - Input.GetTouch(1).position).magnitude;

            float diff = currDistance - prevDistance;

            this.transform.localScale += this.transform.localScale * Time.deltaTime * diff * m_fFieldOfView;
        }
    }
}

