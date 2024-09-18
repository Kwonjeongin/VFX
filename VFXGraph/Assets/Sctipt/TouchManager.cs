using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Android;


public class TouchManager : MonoBehaviour
{
    public VisualEffect vfx;  // VFX Graph에서 사용할 VisualEffect 컴포넌트

    void Update()
    {
        // 터치가 있는지 확인
        if (Input.touchCount > 0)
        {
            // 첫 번째 터치 가져오기
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));

            // 터치 상태 확인
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("터치 시작: " + touch.position);
                    break;

                case TouchPhase.Moved:
                    Debug.Log("터치 이동 중: " + touch.position);
                    break;

                case TouchPhase.Ended:
                    Debug.Log("터치 종료: " + touch.position);
                    break;
            }

            // 터치 위치를 VFX Graph로 전달
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                vfx.SetVector3("TouchPosition", touchPosition);
            }
        }
    }
}
