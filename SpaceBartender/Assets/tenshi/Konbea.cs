using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Konbea : MonoBehaviour
{
    [SerializeField]
    float m_Speed;

    [SerializeField]
    GameObject m_EmitPoint;
    [SerializeField]
    float m_EmitTime;
    float m_EmitTimer;

    [SerializeField]
    List<GameObject> m_SyokuzaiList;

    // Use this for initialization
    void Start()
    {
        m_EmitTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        m_EmitTimer += Time.deltaTime;

        if (m_EmitTime < m_EmitTimer)
        {
            Emit();

            m_EmitTimer -= m_EmitTime;
        }
    }

    void Emit()
    {
        if (m_SyokuzaiList.Count == 0) return;

        int i = Random.Range(0, m_SyokuzaiList.Count);
        var obj = Instantiate(m_SyokuzaiList[i]);

        obj.transform.position = m_EmitPoint.transform.position;
    }

    void OnCollisionStay(Collision collision)
    {
        collision.transform.position += new Vector3(m_Speed, 0, 0) * Time.deltaTime;
    }
}
