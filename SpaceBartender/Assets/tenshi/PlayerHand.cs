using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Squared.DualShock4;

public class PlayerHand : MonoBehaviour {

    [SerializeField]
    PlayerHitSyokuzai m_PlayerHitSyokuzai;
    [SerializeField]
    GameObject m_CatchSyokuzaiPos;
    GameObject m_CatchSyokuzai;

    [SerializeField]
    float m_HandSpeed;

    [SerializeField]
    GameObject m_TablePoint;
    [SerializeField]
    GameObject m_KonbeaPoint;

	[SerializeField]
	GameObject m_LimitPointL;
	[SerializeField]
	GameObject m_LimitPointR;

    [SerializeField]
    float m_MoveTime;
    float m_MoveTimer;

	Vector2 m_lastv2;
	Vector2 m_lastv3;


	[SerializeField]
	GameObject m_SEPlayer;
	[SerializeField]
	List<AudioClip> m_HineriSE = new List<AudioClip>();
	float m_SE_Counter;

	DualShock4 ds4;

    enum PlayerMode {
        SelectSyokuzai,
        SelectSyokuzai_Hineri_Move,
        Hineri,
        Hineri_SelectSyokuzai_Move,
    }

    PlayerMode m_PlayerMode;


    // Use this for initialization
    void Start () {
        m_CatchSyokuzai = null;
        transform.position = m_KonbeaPoint.transform.position;
        m_MoveTimer = 0;
		m_SE_Counter=0;

		m_lastv2 = new Vector2(0,1);
		m_lastv3 = new Vector2(0,1);
		var ds = DualShock4Info.Enumerate();
		if(ds.Length>0)
			ds4 = new DualShock4(ds[0],false);
		foreach(var info in ds){
			if((ds4 == null)||!Object.ReferenceEquals(info.Device,ds4.Device))
				info.Dispose();
		}
    }


	
	// Update is called once per frame
	void Update () {

        float x = 0;
		//
		//x = Input.GetAxisRaw("Move") * m_HandSpeed;

		if(ds4 != null){
			ds4.TryUpdate();

			x = (float)ds4.Sensors[DualShock4Sensor.AccelerometerX] * -m_HandSpeed;
		}
		//x = m_HandSpeed;

		//transform.position += new Vector3(1,0,0) * Input.GetAxis("Vertical3");

		//System.BitConverter.ToInt16(_inpu


		if (Input.GetKey(KeyCode.LeftArrow))
		{
			x -= m_HandSpeed * 10;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			x += m_HandSpeed * 10;
		}

        transform.position = transform.position + new Vector3(x, 0, 0) * Time.deltaTime;
		x = transform.position.x;
		x = Mathf.Max(x,m_LimitPointL.transform.position.x);
		x = Mathf.Min(x,m_LimitPointR.transform.position.x);
		transform.position = new Vector3(x,transform.position.y,transform.position.z);



        switch (m_PlayerMode)
        {
            case PlayerMode.SelectSyokuzai:
                CatchSyokuzai();
                break;

            case PlayerMode.Hineri:
                Hineri();
                break;
            default:
                Move();
                break;
        }

    }


    void CatchSyokuzai()
    {
		
		if (Input.GetAxisRaw("Select") != 0 ||
			Input.GetKeyDown(KeyCode.Z))
        {
            if (m_PlayerHitSyokuzai.SelectSyokuzai)
            {
                var tar = m_PlayerHitSyokuzai.SelectSyokuzai;
                tar.transform.parent = m_CatchSyokuzaiPos.transform;

                tar.transform.localPosition = new Vector3(0, 0, 0);
                m_CatchSyokuzai = tar;

               var temp = tar.GetComponent<Rigidbody>();
                DestroyObject(temp);

                m_PlayerMode = PlayerMode.SelectSyokuzai_Hineri_Move;
            }
        }
    }

    void Hineri()
    {

		float _x = Input.GetAxis("Horizontal");
		float _y = Input.GetAxis("Vertical");
		float _x2 = Input.GetAxis("Horizontal2");
		float _y2 = Input.GetAxis("Vertical2");

		Vector2 v2 = new Vector2(_x,_y);
		Vector2 v3 = new Vector2(_x2,_y2);

		float pow = 0;

		if(Vector2.Distance(new Vector2(0,0),v2) > 0.5f){

			v2.Normalize();
			float dot = Vector2.Dot(v2,m_lastv2);
			dot -= 1;
			dot = Mathf.Abs(dot);
			dot = Mathf.Min(dot,0.5f);
			pow +=dot;
		}
		if(Vector2.Distance(new Vector2(0,0),v3) > 0.5f){

			v3.Normalize();
			float dot = Vector2.Dot(v3,m_lastv3);
			dot -= 1;
			dot = Mathf.Abs(dot);
			dot = Mathf.Min(dot,0.5f);
			pow +=dot;
		}

		if(Input.GetKeyDown(KeyCode.X)){
			pow+=1.0f;
		}
		m_SE_Counter += pow;

		if(m_SE_Counter>1.0f){
			m_SE_Counter-=1.0f;
			HineriSEPlay();
		}
		{
			m_lastv2 = v2;
			m_lastv3 = v3;

			Syokuzai s = m_CatchSyokuzai.GetComponent<Syokuzai>();
			if(!s)return;
			s.Hineri(pow*0.5f);

			if (s.IsBreak())
			{
				m_PlayerMode = PlayerMode.Hineri_SelectSyokuzai_Move;
			}
		}


        //if (Input.GetKeyDown(KeyCode.X))
        //{
        //    Syokuzai s = m_CatchSyokuzai.GetComponent<Syokuzai>();
        //    if(!s)return;
        //    s.Hineri();
        //    //m_CatchSyokuzai.transform.rotation *= new Quaternion(10 * Time.deltaTime,0,0,1);
		//
		//
        //    if (s.IsBreak())
        //    {
        //        m_PlayerMode = PlayerMode.Hineri_SelectSyokuzai_Move;
        //    }
        //}
    }

    void Move()
    {
        Vector3 startpos;
        Vector3 endpos;

        switch (m_PlayerMode)
        {
            case PlayerMode.SelectSyokuzai_Hineri_Move:
                startpos = m_KonbeaPoint.transform.position;
                endpos = m_TablePoint.transform.position;
                break;

            case PlayerMode.Hineri_SelectSyokuzai_Move:
                startpos = m_TablePoint.transform.position;
                endpos = m_KonbeaPoint.transform.position;
                break;
            default:
                startpos = new Vector3(0, 0, 0);
                endpos = new Vector3(0, 0, 0);
                break;
        }

        m_MoveTimer += Time.deltaTime;

        float x = transform.position.x;
        startpos.x = x;
        endpos.x = x;

        float t = m_MoveTimer / m_MoveTime;

        t = Mathf.Min(1.0f, t);
        transform.position = Vector3.Lerp(startpos, endpos, t);
        if (t >= 1.0f)
        {
            m_MoveTimer = 0.0f;
            switch (m_PlayerMode)
            {
                case PlayerMode.SelectSyokuzai_Hineri_Move:
                    m_PlayerMode = PlayerMode.Hineri;
                    break;
                case PlayerMode.Hineri_SelectSyokuzai_Move:
                    m_PlayerMode = PlayerMode.SelectSyokuzai;
                    break;
                default:
                    m_PlayerMode = PlayerMode.SelectSyokuzai;
                    break;
            }

        }

    }

	void HineriSEPlay(){
		if(m_HineriSE.Count==0)return;

		int i = Random.Range(0, m_HineriSE.Count);
		var se = Instantiate(m_HineriSE[i]);

		var onj = Instantiate(m_SEPlayer);
		onj.GetComponent<AudioSource>().clip = se;
		onj.GetComponent<AudioSource>().Play();
	}
}
