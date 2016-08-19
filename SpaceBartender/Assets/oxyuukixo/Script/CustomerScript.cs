using UnityEngine;
using System.Collections;

public class CustomerScript : MonoBehaviour {

    public float RemoveTime;       //帰るまでの時間

    private float ElapsedTime;      //経過時間

    private Animator anim;          //アニメーション

    // Use this for initialization
    void Start () {

        ElapsedTime = 0;

        anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

        if((ElapsedTime += Time.deltaTime) > RemoveTime)
        {
            anim.SetBool("IsAngry", true);

            Destroy(this.gameObject, 2);
        }
    }

    //帰るまでの時間を回復する処理
    //
    //time  回復する時間
    //
    public void RecoveryTime(float time)
    {
        ElapsedTime -= time;
    }

    //飲み物が完成した時の処理
    public void Drinking(){

        anim.SetBool("IsHappy", true);

        Destroy(this.gameObject, 2);
    }
}
