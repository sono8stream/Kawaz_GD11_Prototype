using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LettersController : MonoBehaviour
{
    public GameObject paper;
    public RectTransform pRt;
    public float pIniX, pLimX;

    [SerializeField]
    int activeNo;

    Letter[] letters;

    void Awake()
    {
        paper = GameObject.Find("LPaper");
        pRt = paper.GetComponent<RectTransform>();

        pIniX = paper.GetComponent<RectTransform>().anchoredPosition.x;
        pLimX = -50;
    }

    // Use this for initialization
    void Start()
    {
        letters = transform.GetComponentsInChildren<Letter>();
        SetNumbers();
        letters[0].OnClick();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SetNumbers()
    {
        for (int i = 0; i < letters.Length; i++)
        {
            letters[i].no = i;
        }
    }

    public bool ChangeActiveNo(int nextNo)
    {
        if (letters[activeNo].onClose)//閉じるまで待つ
        {
            letters[activeNo].onClose = false;
            activeNo = nextNo;
            return true;
        }
        else if (!letters[activeNo].onClosing)
        {
            letters[activeNo].onClosing = true;
        }
        return false;
    }
}
