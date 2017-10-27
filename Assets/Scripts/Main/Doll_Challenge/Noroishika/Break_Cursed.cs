using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
呪い人形は5回タップすると破壊される
*/
public class Break_Cursed : MonoBehaviour
{
    int count = 0;  // タップ数のカウント

	void Start ()
    {
		
	}
	
	void Update ()
    {
        TouchInfo info = AppUtil.GetTouch();

        // タップを取得
        if (info == TouchInfo.Began)
        {
            // Debug.Log(Input.mousePosition + ":"+ count);

            GameObject target = null;   // タップしたオブジェクトの取得

            // タップ位置とオブジェクトをタップしたかの取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            // タップしたオブジェクトを取得する
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.collider.gameObject;
            }

            if(hit.collider.gameObject.name == "test_doll" && count == 4)
            {
                Debug.Log(hit.collider.gameObject);
                count += 1;
            }
        }
        if(info == TouchInfo.Ended)
        {
            GameObject target = null;   // タップしたオブジェクトの取得

            // タップ位置とオブジェクトをタップしたかの取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            // タップしたオブジェクトを取得する
            if (Physics.Raycast(ray, out hit))
            {
                target = hit.collider.gameObject;
            }

            if (hit.collider.gameObject.name == "test_doll")
            {
                Debug.Log(hit.collider.gameObject);
                count += 1;
            }
        }

        // タップが5回で破壊
        if(count == 5)
        {
            MeshRenderer mesh = GetComponent<MeshRenderer>();

            mesh.material.color = new Color(0, 0, 0, 0.0f);
        }
	}
}
