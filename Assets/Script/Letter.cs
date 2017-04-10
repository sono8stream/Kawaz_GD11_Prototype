using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
    public int no;//手紙番号
    public bool onClosing, onClose;

    [SerializeField]
    string text;
    [SerializeField]
    Color color;
    LettersController letCon;
    RectTransform rt;
    float iniX, limX;//y方向位置限界
    public bool onOpening,onOpen;//タッチ後移動中、タッチ後移動完了状態

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>().color = color;
        letCon = transform.parent.GetComponent<LettersController>();
        rt = GetComponent<RectTransform>();

        iniX = rt.anchoredPosition.x;
        limX = 1080 / 2 + rt.sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (onOpening && letCon.ChangeActiveNo(no))
        {
            onOpening = false;
            onOpen = true;
            letCon.paper.GetComponent<Image>().color = color;
            letCon.paper.transform.FindChild("Text").GetComponent<Text>().text = text;
        }
        if (onOpen)
        {
            if (Mathf.Round(rt.anchoredPosition.x - limX) == 0)
            {
                letCon.pRt.anchoredPosition = new Vector2(letCon.pLimX, letCon.pRt.anchoredPosition.y);
                onOpen = false;
            }
            else
            {
                rt.anchoredPosition += Vector2.right * (limX - rt.anchoredPosition.x) / 2;
                letCon.pRt.anchoredPosition += Vector2.right * (letCon.pLimX - letCon.pRt.anchoredPosition.x) / 2;
            }
        }
        else if(onClosing)
        {
            if (Mathf.Round(rt.anchoredPosition.x - iniX) == 0)
            {
                letCon.pRt.anchoredPosition = new Vector2(letCon.pIniX, letCon.pRt.anchoredPosition.y);
                onClosing = false;
                onClose = true;
            }
            else
            {
                rt.anchoredPosition += Vector2.right * (iniX - rt.anchoredPosition.x) / 2;
                letCon.pRt.anchoredPosition += Vector2.right * (letCon.pIniX - letCon.pRt.anchoredPosition.x) / 2;
            }
        }
    }

    public void OnClick()
    {
        if (!onOpen)
        {
            onOpening = true;
        }
    }
}
