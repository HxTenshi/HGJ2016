using UnityEngine;
using System.Collections;

public class CustomerScript : MonoBehaviour {

    public float RemoveTime;       //帰るまでの時間

    private float ElapsedTime;      //経過時間

    private Animator anim;          //アニメーション

	bool DrinkingFlag;

	[SerializeField]
	bool m_NG_Alien;
	[SerializeField]
	bool m_NG_Human;
	[SerializeField]
	bool m_NG_Kemono;
	[SerializeField]
	bool m_NG_Gyojin;
	[SerializeField]
	bool m_NG_Robot;

    // Use this for initialization
    void Start () {

        ElapsedTime = 0;

        anim = GetComponent<Animator>();

		DrinkingFlag=false;
	}

	// Update is called once per frame
	void Update () {
		if(DrinkingFlag)return;

        if((ElapsedTime += Time.deltaTime) > RemoveTime)
        {
			if(ElapsedTime> RemoveTime*2)
			{
				DestroyObject(this.gameObject);
			}
            anim.SetBool("IsAngry", true);
		}else{
			anim.SetBool("IsAngry", false);
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
	public void Drip(){
		ElapsedTime -= RemoveTime;
		ElapsedTime = Mathf.Max(0,ElapsedTime);
	}

    //飲み物が完成した時の処理
	public void Drinking(int filter){

		DrinkingFlag=true;
		int i = 0;
		i |= m_NG_Alien?1:0;
		i |= m_NG_Human?2:0;
		i |= m_NG_Kemono?4:0;
		i |= m_NG_Gyojin?8:0;
		i |= m_NG_Robot?16:0;

		if((filter & i) != 0){
			anim.SetBool("IsAngry", true);
			Destroy(this.gameObject, 2);
			return;
		}

        anim.SetBool("IsHappy", true);


		Destroy(this.gameObject, 2);
    }
}
