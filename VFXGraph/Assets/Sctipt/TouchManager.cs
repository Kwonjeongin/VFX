using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Android;


public class TouchManager : MonoBehaviour
{
    public VisualEffect vfx;  // VFX Graph���� ����� VisualEffect ������Ʈ

    void Update()
    {
        // ��ġ�� �ִ��� Ȯ��
        if (Input.touchCount > 0)
        {
            // ù ��° ��ġ ��������
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            // ��ġ ���� Ȯ��
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("��ġ ����: " + touch.position);
                    break;

                case TouchPhase.Moved:
                    Debug.Log("��ġ �̵� ��: " + touch.position);
                    break;

                case TouchPhase.Ended:
                    Debug.Log("��ġ ����: " + touch.position);
                    break;
            }

            // ��ġ ��ġ�� VFX Graph�� ����
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                vfx.SetVector3("TouchPosition", touchPosition);
            }
        }
    }
}
