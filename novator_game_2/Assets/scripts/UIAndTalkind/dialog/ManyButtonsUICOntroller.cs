using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManyButtonsUICOntroller : MonoBehaviour
{
    private int OnClickPer;
    private bool isRead;
    private string  MainTextLable;
    public Text MainTextObj;
    public Text MPSNameTextObj;
    public Text Answ1TextObj;
    public Text Answ2TextObj;
    public Text Answ3TextObj;
    private GameObject Answ1Obj;
    private GameObject Answ2Obj;
    private GameObject Answ3Obj;
    private int countAnswers;
    private int OnClickPerloc;

    //public ManyButtonsUICOntroller (): this(1){}

    //public ManyButtonsUICOntroller (int AnsCount){}
    void Start()
    {

        OnClickPer = 0;
        isRead = false;
        countAnswers = -1;
        creatingObj();
        //print(transform.GetChild(1).gameObject.GetComponent<Text>());
        //print(MainTextObj);
    }

    public void myOnClick(int indexButton)
    {
        OnClickPer = indexButton;
        
    }

    void FixUpdate() // FixedUpdate
    {
        if (OnClickPer != 0)
        {
            if (isRead) 
            {
                OnClickPer = 0;
                isRead = false;
            }
        }
    }

    public int GetOnClickValue()
    {
        if (OnClickPer != 0)
        {
            isRead = true;
            OnClickPerloc = OnClickPer;
            OnClickPer = 0;
            return OnClickPerloc;
        }
        return 0;
    }

    public void creatingObj()
    {
        if (MainTextObj == null)
        {
            MainTextObj = transform.Find("MainText").gameObject.GetComponent<Text>();
        }
        if (MPSNameTextObj == null)
        {
            MPSNameTextObj = transform.Find("NamePanel").Find("NameText").gameObject.GetComponent<Text>();
            //MPSNameTextObj = transform.Find("answers").Find("answ1").gameObject.GetComponent<Text>();
        }
        if (Answ1TextObj == null)
        {
            if (transform.Find("answers").Find("answ1") != null)
            {
                Answ1Obj = transform.Find("answers").Find("answ1").gameObject;
                Answ1TextObj = Answ1Obj.transform.Find("Text").gameObject.GetComponent<Text>();
                if (Answ2TextObj == null)
                {
                    if (transform.Find("answers").Find("answ2") != null)
                    {
                        Answ2Obj = transform.Find("answers").Find("answ2").gameObject;
                        Answ2TextObj = Answ2Obj.transform.Find("Text").gameObject.GetComponent<Text>();
                        if (Answ3TextObj == null)
                        {
                            if (transform.Find("answers").Find("answ3") != null)
                            {
                                Answ3Obj = transform.Find("answers").Find("answ3").gameObject;
                                Answ3TextObj = Answ3Obj.transform.Find("Text").gameObject.GetComponent<Text>();
                                countAnswers = 3;
                            } else {
                                countAnswers = 2;
                            }
                        }
                    } else {
                        countAnswers = 1;
                    }
                }
            } else {
                countAnswers = 0;
            }
        }
    }

    private void MySetMainText(string text_)
    {
        MainTextObj.text = text_;
    }
    private void MySetNameMPSText(string text_)
    {
        MPSNameTextObj.text = text_;
    }
    private void MySet1AnswerText(string text_)
    {
        //print("---кнопка");
        if (countAnswers >= 1)
        {
            Answ1TextObj.text = text_;
        }
    }
    private void MySet2AnswerText(string text_)
    {
        if (countAnswers >= 2)
        {
            Answ2TextObj.text = text_;
        }
    }
    private void MySet3AnswerText(string text_)
    {
        if (countAnswers >= 3)
        {
        Answ3TextObj.text = text_;
        }
    }

    public void MySetAllAnswersText(string mainText, string name, int count, string ans1, string ans2, string ans3)
    {
        //creatingObj();
        countAnswers = count;
        MySetMainText(mainText);
        MySetNameMPSText(name);
        //print("----count  " + count);
        if (count == 3)
        {
            MySet1AnswerText(ans1);
            MySet2AnswerText(ans2);
            MySet3AnswerText(ans3);
        }
        else if (count == 2)
        {
            MySet1AnswerText(ans1);
            MySet2AnswerText(ans2);
        }
        else if (count == 1)
        {
            //print("---Buttons " + ans1);
            MySet1AnswerText(ans1); // по какой-то причине не записывает
        }
    }
    public void SetActiveButtons(int numberButt, bool Active)
    {
        if (numberButt == 1)
        {
            Answ1Obj.SetActive(Active);
        }
        else if (numberButt == 2)
        {
            Answ2Obj.SetActive(Active);
        }
        else if (numberButt == 3)
        {
            Answ3Obj.SetActive(Active);
        }
    }
    void OnDisable()
    {
        if (Answ1Obj != null)
        {
            Answ1Obj.SetActive(true);
        }
        if (Answ2Obj != null)
        {
             Answ2Obj.SetActive(true);
        }
        if (Answ3Obj != null)
        {
             Answ3Obj.SetActive(true);
        }
    }
}
