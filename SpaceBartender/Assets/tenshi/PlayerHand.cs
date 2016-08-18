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
        if (Input.GetKey(KeyCode.Z))
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

        if (Input.GetKey(KeyCode.X))
        {
            Syokuzai s = m_CatchSyokuzai.GetComponent<Syokuzai>();
            if(!s)return;
            s.Hineri();
            m_CatchSyokuzai.transform.rotation *= new Quaternion(0,0,10 * Time.deltaTime,1);


            m_PlayerMode = PlayerMode.Hineri_SelectSyokuzai_Move;
        }
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
