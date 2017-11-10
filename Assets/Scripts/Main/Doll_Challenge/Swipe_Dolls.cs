using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
人形を３回タッチ・スワイプする。受け取った指令で内容は変わる
３回タップし終わると、 3-呪い人形の数 だけの人形を入手する
*/
public class Swipe_Dolls : MonoBehaviour
{
	public int moveR = 0;
	public int moveL = 0;

	Vector3 touchPos;
	Vector3 endPos;

    public float speed;

	//Transform target1;
	//Transform target2;

	float minAngle = 0.0f;
	float maxAngleR = -20.0f;
	float maxAngleL = 20.0f;

	IEnumerator StopTimer ()
	{
		yield return new WaitForSeconds (0.5f);
		moveR = 0;
		moveL = 0;
		transform.Rotate (0, 0, 0);
	}

	// Use this for initialization
	void Start ()
    {
		//target1 = GameObject.Find ("Cube/target_1").transform;
		//target2 = GameObject.Find ("Cube/target_2").transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
		TouchInfo info = AppUtil.GetTouch();

		if (info == TouchInfo.Began) 
		{
			touchPos = AppUtil.GetTouchPosition ();
		}
		else if (info == TouchInfo.Ended) 
		{
			endPos = AppUtil.GetTouchPosition ();
		}

		if (transform.position.y != endPos.y) 
		{
			endPos.y = 0;
			endPos.z = 0;
		}

		Quaternion targetRotate = Quaternion.LookRotation (endPos - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, targetRotate, Time.deltaTime);
		float f = transform.eulerAngles.y;
		if (f > 360) 
		{
			f = 0;
		}

		Debug.Log ("f;" + f);

		/*
		TouchInfo info = AppUtil.GetTouch();

		if (info == TouchInfo.Began) 
		{
			touchPos = AppUtil.GetTouchPosition ().x;
			StopCoroutine (StopTimer ());
		}
		else if (info == TouchInfo.Ended) 
		{
			endPos = AppUtil.GetTouchPosition ().x;

			if(endPos - touchPos > 5)
			{
				Debug.Log(endPos - touchPos);
				moveR = 10;
				if (moveL == 10) 
				{
					moveL = 0;
				}
			}
			else if (endPos - touchPos < -5)
			{
				Debug.Log(endPos - touchPos);
				moveL = 10;
				if (moveR == 10) 
				{
					moveR = 0;
				}
			}
		}

		if (moveR == 10) 
		{
			transform.Rotate (new Vector3 (0, -1 * speed, 0));
			StartCoroutine (StopTimer ());
		}
		else if (moveL == 10) 
		{
			transform.Rotate (new Vector3 (0, speed, 0));
			StartCoroutine (StopTimer ());
		}

		
		if (transform.position.y != endPos.y) 
		{
			endPos.y = 0;
			endPos.z = 0;
		}*/

		/*
        //Rigidbody rigid = GetComponent<Rigidbody>();

		Vector3 targetPosR = target1.position;
		Vector3 targetPosL = target2.position;

        TouchInfo info = AppUtil.GetTouch();

        if (info == TouchInfo.Began)
        {
            Debug.Log(Input.mousePosition);

            touchPos = AppUtil.GetTouchPosition().x;
        }
        else if(info == TouchInfo.Ended)
        {
            endPos = AppUtil.GetTouchPosition().x;

            if(endPos - touchPos > 5)
            {
				Debug.Log(endPos - touchPos);

				Quaternion targetRotR = Quaternion.LookRotation (targetPosR - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotR, Time.deltaTime * speed);
            }
            else if (endPos - touchPos < -5)
            {
				Debug.Log(endPos - touchPos);

				Quaternion targetRotL = Quaternion.LookRotation (targetPosL - transform.position);
				transform.rotation = Quaternion.Slerp (transform.rotation, targetRotL, Time.deltaTime * speed);
            }
        }*/
    }
}
