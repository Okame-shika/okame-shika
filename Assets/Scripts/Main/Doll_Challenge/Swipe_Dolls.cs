using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
人形を３回タッチ・スワイプする。受け取った指令で内容は変わる
３回タップし終わると、 3-呪い人形の数 だけの人形を入手する
*/
public class Swipe_Dolls : MonoBehaviour
{
    private float touchPos;
    private float endPos;

    float rotate_Z;

    public int speed;

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Rigidbody rigid = GetComponent<Rigidbody>();

        TouchInfo info = AppUtil.GetTouch();

        if (info == TouchInfo.Began)
        {
            Debug.Log(Input.mousePosition);

            touchPos = AppUtil.GetTouchPosition().x;
        }
        else if(info == TouchInfo.Ended)
        {
            endPos = AppUtil.GetTouchPosition().x;

            if(endPos - touchPos > 0)
            {
                Debug.Log(endPos - touchPos);
                /*
                Rigidbody rb = GetComponent<Rigidbody>();
                Vector3 vec = ;
                /*
                float next_x = vec.x * Mathf.Cos(Mathf.Deg2Rad * -1) - vec.z * (Mathf.Sin(Mathf.Deg2Rad * -1));
                float next_z = vec.x * Mathf.Sin(Mathf.Deg2Rad * -1) + vec.z * (Mathf.Cos(Mathf.Deg2Rad * -1));
                rb.velocity = new Vector3(next_x, rb.velocity.y, next_z);
                
                Quaternion target = Quaternion.LookRotation(vec);

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    target,
                    Time.deltaTime * speed
                );*/
                /*
                float angle = Mathf.LerpAngle(transform.rotation.x, endPos / 2, Time.time * speed);
                transform.eulerAngles = new Vector3(0, angle, 0);*/
            }
        }
    }
}
