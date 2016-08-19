using UnityEngine;
using System.Collections;

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
    float m_MoveTime;
    float m_MoveTimer;

	Vector2 m_lastv2;
	Vector2 m_lastv3;

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

		m_lastv2 = new Vector2(0,1);
		m_lastv3 = new Vector2(0,1);

    }
	
	// Update is called once per frame
	void Update () {

        float x = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= m_HandSpeed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += m_HandSpeed;
        }

		x = Input.GetAxisRaw("Move") * m_HandSpeed;

        transform.position = transform.position + new Vector3(x, 0, 0) * Time.deltaTime;

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
		
		if (Input.GetAxisRaw("Select") != 0)
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
}
