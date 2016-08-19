using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CustomerControllScript : MonoBehaviour {

    public Object[] CustomerType;       //客の種類
    public Vector3[] SpawnPoiint;     //客が座る場所

    private GameObject[] CustomerObject;          //客のオブジェクト

    public float RsspawnTime;          //リスポーンする時間
    private float NowTime = 0;              //今の経過時間

    // Use this for initialization
    void Start () {

        //客が一度に出る最大数にする
        CustomerObject = new GameObject[SpawnPoiint.Length];

	}
	
	// Update is called once per frame
	void Update () {

        if ((NowTime += Time.deltaTime) > RsspawnTime)
        {
            NowTime = 0;

            Spawn();
        }
    
        //
        //飲み物ができた時の処理
        //Debug用です
        //ドリンクができた時に呼ぶようにしてください
        //
        if (Input.GetKeyDown(KeyCode.Alpha1) && CustomerObject[0] != null)
        {
            CustomerObject[0].GetComponent<CustomerScript>().Drinking();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && CustomerObject[1] != null)
        {
            CustomerObject[1].GetComponent<CustomerScript>().Drinking();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && CustomerObject[2] != null)
        {
            CustomerObject[2].GetComponent<CustomerScript>().Drinking();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) && CustomerObject[3] != null)
        {
            CustomerObject[3].GetComponent<CustomerScript>().Drinking();
        }
    }

    void Spawn()
    {
        //客の種類が1つ以上あったら
        if (CustomerType.Length > 0)
        {
            List<int> SpaceNum = new List<int>();         //空いてる席の番号

            //客がいるか確認
            for (int i = 0; i < SpawnPoiint.Length; i++)
            {
                if (CustomerObject[i] == null)
                {
                    SpaceNum.Add(i);
                }
            }

            //空いてる席があったら
            if (SpaceNum.Count > 0)
            {
                int SpawnNum = SpaceNum[Random.Range(0, SpaceNum.Count)];       //リスポーンする席の番号

                //客の生成
                CustomerObject[SpawnNum] = (GameObject)Instantiate(CustomerType[Random.Range(0, CustomerType.Length)], SpawnPoiint[SpawnNum], new Quaternion(0, 0, 0, 0));
            }
        }
    }
}
