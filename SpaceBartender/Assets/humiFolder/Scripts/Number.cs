using UnityEngine;
using System.Collections;

public class Number : MonoBehaviour {

    private int number;
    private GameObject child0;
    private GameObject child1;
    private GameObject child2;
    private GameObject child3;
    private GameObject child4;
    private GameObject child5;
    private GameObject child6;
    private GameObject child7;
    private GameObject child8;
    private GameObject child9;

    // Use this for initialization
    void Start()
    {
        number = -1;
        child0 = gameObject.transform.Find("0").gameObject;
        child1 = gameObject.transform.Find("1").gameObject;
        child2 = gameObject.transform.Find("2").gameObject;
        child3 = gameObject.transform.Find("3").gameObject;
        child4 = gameObject.transform.Find("4").gameObject;
        child5 = gameObject.transform.Find("5").gameObject;
        child6 = gameObject.transform.Find("6").gameObject;
        child7 = gameObject.transform.Find("7").gameObject;
        child8 = gameObject.transform.Find("8").gameObject;
        child9 = gameObject.transform.Find("9").gameObject;
        Rset();
    }

    // Update is called once per frame
    public void Set (int num) {
        number = num;
        Rset();
        Change();
	}

    void Change(){
        switch (number)
        {
            case 0:
                child0.SetActive(true);
                break;
            case 1:
                child1.SetActive(true);
                break;
            case 2:
                child2.SetActive(true);
                break;
            case 3:
                child3.SetActive(true);
                break;
            case 4:
                child4.SetActive(true);
                break;
            case 5:
                child5.SetActive(true);
                break;
            case 6:
                child6.SetActive(true);
                break;
            case 7:
                child7.SetActive(true);
                break;
            case 8:
                child8.SetActive(true);
                break;
            case 9:
                child9.SetActive(true);
                break;
        }
    }

    void Rset(){
        child0.SetActive(false);
        child1.SetActive(false);
        child2.SetActive(false);
        child3.SetActive(false);
        child4.SetActive(false);
        child5.SetActive(false);
        child6.SetActive(false);
        child7.SetActive(false);
        child8.SetActive(false);
        child9.SetActive(false);
    }
}
