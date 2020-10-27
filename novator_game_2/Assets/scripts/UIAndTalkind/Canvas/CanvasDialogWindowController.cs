using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDialogWindowController : MonoBehaviour
{
    private GameObject UITextMonologPrefab;
    private GameObject UITextDilog1AnsPrefab;
    private GameObject UITextDilog2AnsPrefab;
    private GameObject UITextDilog3AnsPrefab;
    private GameObject UITextMonologPrefabObj;
    private GameObject UITextDilog1AnsPrefabObj;
    private GameObject UITextDilog2AnsPrefabObj;
    private GameObject UITextDilog3AnsPrefabObj;
    private ManyButtonsUICOntroller UITextDilog1AnsPrefabObjScr;
    private ManyButtonsUICOntroller UITextDilog2AnsPrefabObjScr;
    private ManyButtonsUICOntroller UITextDilog3AnsPrefabObjScr;

    private GameObject workUIDilogObj;
    private ManyButtonsUICOntroller workUIDilogObjScr;

    private PrefabsStorageController prefabsStorageScript;

    private int countAnswers;
    private int whereButtonClicked;
    private List<string> answers;
    private List<int> answerKeys;
    private List<int> missionProgres;
    private int missionProgresCount;

    private bool firstReadClickButton;

    private int dialogProgresCanvas;
    private PlayerInventaryControl playerInvScr;
    private CoinsControl coinsControlScr;
    private Dictionary<string, GameObject> inventarObjByType;
    void Awake()
    {
        prefabsStorageScript = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>();

        UITextMonologPrefab = prefabsStorageScript.UITextMonologPrefab;
        UITextDilog1AnsPrefab = prefabsStorageScript.UITextDilog1AnsPrefab;
        UITextDilog2AnsPrefab = prefabsStorageScript.UITextDilog2AnsPrefab;
        UITextDilog3AnsPrefab = prefabsStorageScript.UITextDilog3AnsPrefab;
        UITextMonologPrefabObj = UITextMonologPrefab; //Instantiate(UITextMonologPrefab, transform, false);
        UITextDilog1AnsPrefabObj = UITextDilog1AnsPrefab; //Instantiate(UITextDilog1AnsPrefab, transform, false);
        UITextDilog1AnsPrefabObjScr = UITextDilog1AnsPrefabObj.GetComponent<ManyButtonsUICOntroller>();
        UITextDilog1AnsPrefabObjScr.creatingObj();
        UITextDilog1AnsPrefabObj.SetActive(false);

        UITextDilog2AnsPrefabObj = UITextDilog2AnsPrefab; // Instantiate(UITextDilog2AnsPrefab, transform, false);
        UITextDilog2AnsPrefabObjScr = UITextDilog2AnsPrefabObj.GetComponent<ManyButtonsUICOntroller>();
        UITextDilog2AnsPrefabObjScr.creatingObj();
        UITextDilog2AnsPrefabObj.SetActive(false);

        UITextDilog3AnsPrefabObj = UITextDilog3AnsPrefab; //Instantiate(UITextDilog3AnsPrefab, transform, false);
        UITextDilog3AnsPrefabObjScr = UITextDilog3AnsPrefabObj.GetComponent<ManyButtonsUICOntroller>();
        UITextDilog3AnsPrefabObjScr.creatingObj();
        UITextDilog3AnsPrefabObj.SetActive(false);

        playerInvScr = GameObject.FindWithTag("Player").GetComponent<PlayerInventaryControl>();
        coinsControlScr = GameObject.FindWithTag("Player").GetComponent<CoinsControl>();
        countAnswers = -1;
        whereButtonClicked = 0;
        firstReadClickButton = false;
        missionProgresCount = -1;
    }
    void Start()
    {
        UITextMonologPrefabObj.SetActive(false);
        UITextDilog1AnsPrefabObj.SetActive(false);
        UITextDilog2AnsPrefabObj.SetActive(false);
        UITextDilog3AnsPrefabObj.SetActive(false);
        inventarObjByType = prefabsStorageScript.GetInvObjDict();
    }

    public void PaintDialogWindow(string mainText, string nameText,
                                    List<int> missionProgresLoc, 
                                    List<string> answersLoc, 
                                    List<int> answerKeysLoc, 
                                    int dialogProgres1Loc, 
                                    Dictionary<int,string> noActivButt,
                                    string whatGiveAway)
    {
        dialogProgresCanvas = dialogProgres1Loc;
        missionProgres = new List<int>();
        answers = new List<string>();
        
        if (workUIDilogObj != null)
        {
            workUIDilogObj.SetActive(false);
        }
        missionProgres = new List<int>(missionProgresLoc);
        answers = new List<string>(answersLoc);
        answerKeys = new List<int>(answerKeysLoc);

        if (answersLoc.Count == 3)
        {
            countAnswers = 3;
            workUIDilogObj = UITextDilog3AnsPrefabObj;
            workUIDilogObjScr = UITextDilog3AnsPrefabObjScr;
            BlokingButton(noActivButt, answerKeysLoc);
            print("nameTextCanvas" + nameText + " " + answersLoc.Count);
        }
        else if (answersLoc.Count == 2)
        {
            countAnswers = 2;
            workUIDilogObj = UITextDilog2AnsPrefabObj;
            workUIDilogObjScr = UITextDilog2AnsPrefabObjScr;
            answers.Add("");
            BlokingButton(noActivButt, answerKeysLoc);
            print("nameTextCanvas" + nameText + " " + answersLoc.Count);
        }
        else if (answersLoc.Count == 1)
        {                    
            countAnswers = 1;
            workUIDilogObj = UITextDilog1AnsPrefabObj;
            workUIDilogObjScr = UITextDilog1AnsPrefabObjScr;
            answers.Add("");
            answers.Add("");
            BlokingButton(noActivButt, answerKeysLoc);
            print("nameTextCanvas" + nameText + " " + answersLoc.Count);
        }

        if (workUIDilogObj != null)
        {
            if (countAnswers >= 0)
            {
            //print("%%%%%%countAnswers  " + countAnswers);
            workUIDilogObj.SetActive(true);
            //print("-----Canvas " + answers[0]);
            workUIDilogObjScr.MySetAllAnswersText(mainText, nameText, countAnswers, answers[0], answers[1], answers[2]);
            }
            GiveAwayObjForPlayer(whatGiveAway);
        }
        countAnswers = -1;
        //answersLoc = new List<string>();
    }
    /* 
    public int ClickingController()
    {
        whereButtonClicked = workUIDilogObjScr.GetOnClickValue(); // значения кнопок от 1 до 3. 0 - отсутствие значения
        if (whereButtonClicked != null)
        {
            
            if (firstReadClickButton)
            {
                firstReadClickButton = false;
            }
            if (whereButtonClicked > 0)
            {
                firstReadClickButton = true;
                print("=====" + whereButtonClicked);
                print("+++++" + answerKeys[whereButtonClicked - 1]);
                missionProgresCount = missionProgres[whereButtonClicked - 1];
                return answerKeys[whereButtonClicked - 1];
            }
        }
        return -1000;
    }
    */
    private void BlokingButton(Dictionary<int,string> noActivButt,
                                List<int> answerKeysLoc)
    {
        int counter = 1;
        foreach (int key in answerKeysLoc)
        {
            if (noActivButt[key] != "--")
            {
                var FindIt = noActivButt[key].Split(' ');
                if( ! playerInvScr.IsElementIntoInv(FindIt[1], FindIt[0]))
                {
                    workUIDilogObjScr.SetActiveButtons(counter, false);// блокируем кнопку
                }
                else
                {
                    workUIDilogObjScr.SetActiveButtons(counter, true);
                }
            }
            counter++;
        }
    }
    private void GiveAwayObjForPlayer(string whatGiveAway)
    {
        if (whatGiveAway.Contains("#"))
        {
            var FrooGroups = whatGiveAway.Split('#');
            
            if (FrooGroups[0] != "--")
            {
                var FindIt = FrooGroups[0].Split(' ');
                playerInvScr.PlayerGiveObject(FindIt[1], FindIt[0]);
                coinsControlScr.AddCoins(int.Parse(FindIt[2]));
            }
            if (FrooGroups[1] != "--")
            {
                var FindIt1 = FrooGroups[1].Split(' ');
                print("^^^^^^^^^^^^^^^^^" + ":" + FindIt1[0] + ":" +FindIt1[1] + " " + FrooGroups[1]);
                if (FindIt1[1] != "Null" & FindIt1[0] != "$Type")
                {
                    playerInvScr.PlayerGetObject(inventarObjByType[FindIt1[1]]);
                }
                if (FindIt1[0] == "$Type")
                {
                     playerInvScr.PlayerGetObject(FindIt1[1]);
                }
                print("-------many" + -int.Parse(FindIt1[2]));
                coinsControlScr.AddCoins(-int.Parse(FindIt1[2]));
            }
        }
        else{
            if (whatGiveAway != "--")
            {
                if (whatGiveAway.Contains("#"))
                {}
                else{

                }
            }
        }
    }
    public int GetNextListIndex()
    {
        whereButtonClicked = workUIDilogObjScr.GetOnClickValue();
        if (whereButtonClicked > 0)
        {
            missionProgresCount = missionProgres[whereButtonClicked-1];
            return answerKeys[whereButtonClicked-1];
        }
        return -1000;
    }

    public int GetMissionProgress()
    {
        return missionProgresCount;
    }

    public void desactivateWorkingDialogWindow()
    {
        missionProgresCount = -1;
        answerKeys = new List<int>();
        answers = new List<string>();
        missionProgres = new List<int>();
        workUIDilogObj.SetActive(false);
        countAnswers = -1;
        whereButtonClicked = 0;
        firstReadClickButton = false;
        missionProgresCount = -1;
        workUIDilogObj = null;
        workUIDilogObjScr = null;
        dialogProgresCanvas = -1;
    }
}
