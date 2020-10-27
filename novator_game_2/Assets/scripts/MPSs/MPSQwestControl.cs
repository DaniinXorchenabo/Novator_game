using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MPSQwestControl : MonoBehaviour
{
    // Start is called before the first frame update
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
    private GameObject MainCanvasUI;
    private GameObject TolkingButton;
    private GameObject TolkingButtonObj;
    public Sprite TolkingButtonSprite;
    private EditEventOnClickInButton TolkingButtonObjScr;
    private bool isClickTolkingButton;
    private int dialogStatus;
    private int progressDialog;
    private bool firstGoingLoop;
    //private int HowChangeAnswer;
    private int nextSetupDialog;
    private int tryNextSetupDialog;

    public Dictionary<int, dialog_classLoc> dialog;
    private List<Dictionary<int, dialog_classLoc>> dialogs;
    private CanvasDialogWindowController CanvasScr;
    [SerializeField]
    private string myNameIs;

    private int dialogProgres1;

    private bool playerOnCollider = false;
    private bool fistTalking = true;
    void Awake()
    {
        //myNameIs = "Шкаф";
        MainCanvasUI = GameObject.FindWithTag("UIMainCanvas");
        CanvasScr = MainCanvasUI.GetComponent<CanvasDialogWindowController>();
        prefabsStorageScript = GameObject.FindWithTag("PrefabStorage").GetComponent<PrefabsStorageController>();
        dialogs = GameObject.FindWithTag("PrefabStorage").GetComponent<listForDialog>().GetAllDialogs()[myNameIs];
        //dialog1 = GameObject.FindWithTag("PrefabStorage").GetComponent<listForDialog>().generateDict();
        print("myNameIs" + myNameIs);
        
        /* 
        UITextMonologPrefab = prefabsStorageScript.UITextMonologPrefab;
        UITextDilog1AnsPrefab = prefabsStorageScript.UITextDilog1AnsPrefab;
        UITextDilog2AnsPrefab = prefabsStorageScript.UITextDilog2AnsPrefab;
        UITextDilog3AnsPrefab = prefabsStorageScript.UITextDilog3AnsPrefab;
        UITextMonologPrefabObj = Instantiate(UITextMonologPrefab, MainCanvasUI.transform, false);
        UITextMonologPrefabObj.SetActive(false);
        UITextDilog1AnsPrefabObj = Instantiate(UITextDilog1AnsPrefab, MainCanvasUI.transform, false);
        UITextDilog1AnsPrefabObjScr = UITextDilog1AnsPrefabObj.GetComponent<ManyButtonsUICOntroller>();
        UITextDilog1AnsPrefabObj.SetActive(false);
        UITextDilog2AnsPrefabObj = Instantiate(UITextDilog2AnsPrefab, MainCanvasUI.transform, false);
        UITextDilog2AnsPrefabObjScr = UITextDilog2AnsPrefabObj.GetComponent<ManyButtonsUICOntroller>();
        UITextDilog2AnsPrefabObj.SetActive(false);
        UITextDilog3AnsPrefabObj = Instantiate(UITextDilog3AnsPrefab, MainCanvasUI.transform, false);
        UITextDilog3AnsPrefabObjScr = UITextDilog3AnsPrefabObj.GetComponent<ManyButtonsUICOntroller>();
        UITextDilog3AnsPrefabObj.SetActive(false);
        

        */
        TolkingButton = prefabsStorageScript.UITalkingDutton;
        TolkingButtonObj = TolkingButton; //Instantiate(TolkingButton, MainCanvasUI.transform, false);
        TolkingButtonObjScr = TolkingButtonObj.GetComponent<EditEventOnClickInButton>();
        //TolkingButtonObjScr.SetSprite(TolkingButtonSprite);
        TolkingButtonObj.SetActive(false);
        isClickTolkingButton = false;
        dialogStatus = 1;
        progressDialog = 0;
        firstGoingLoop = false;
        workUIDilogObj = UITextDilog2AnsPrefabObj;
        workUIDilogObjScr = UITextDilog2AnsPrefabObjScr;

        //HowChangeAnswer = -1;
        nextSetupDialog = -1000;
        //print(dialog1[1].GetCountAnswers() + "   " + dialog1[2].GetCountAnswers() + "  " + dialog1[3].GetCountAnswers());
        dialogProgres1 = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogProgres1 <= 0){
            if (TolkingButtonObj.activeInHierarchy & playerOnCollider)
            {
                if(fistTalking)
                {
                    fistTalking = false;
                    TolkingButtonObjScr.SetSprite(TolkingButtonSprite);
                }
                isClickTolkingButton = TolkingButtonObjScr.GetOnClickValue();
                if (isClickTolkingButton)
                {
                    isClickTolkingButton = false;
                    //dialogStatus = Mathf.Abs(dialogStatus) + 1;
                    TolkingButtonObj.SetActive(false);
                    firstGoingLoop = true;
                    //nextSetupDialog = 1;
                    //progressDialog = 1;
                    dialogProgres1 = 1;
                    //print("###################");
                }
            } 
        }
        else 
        {
            if (playerOnCollider)
            {
                DialogProgress();
            }
        }
    }
    private void OnTriggerEnter(Collider other) //вошёл
    {
        
        if (dialogProgres1 <= 0)
        {
            if (other.tag == "Player")
            {
                print("go in collider" + myNameIs);
                playerOnCollider = true;
                TolkingButtonObj.SetActive(true);
                
            }
        }
        
    }
    private void OnTriggerStay(Collider other) // находится внутри
    {
        
    }
    private void OnTriggerExit(Collider other)
    {   if (dialogProgres1 <= 0)
        {
            if (other.tag == "Player")
            {
                playerOnCollider = false;
                TolkingButtonObj.SetActive(false);
                fistTalking = true;
                //Destroy(TolkingButtonObj);
            }
        }
    }
    public void OnClickDialogButton()
    {

    }
    public void DialogProgress()
    {
        playingDialog(dialogs[dialogStatus-1]);
    }
    public void playingDialog(Dictionary<int, dialog_classLoc> dialoggg)
    {
        if (firstGoingLoop)
        {
            if (dialogProgres1 > 0)
            {
                firstGoingLoop = false;
                print(")))))myNameIs" + myNameIs);
                CanvasScr.PaintDialogWindow(dialoggg[dialogProgres1].GetMainText(),
                                            myNameIs, dialoggg[dialogProgres1].GetMissionProgress(), 
                                            dialoggg[dialogProgres1].GetAnswers(), 
                                            dialoggg[dialogProgres1].GetAnswerKeys(), 
                                            dialogProgres1, 
                                            dialoggg[dialogProgres1].GetPrivateKey(),
                                            dialoggg[dialogProgres1].GetWhatGiveAway()); 
                nextSetupDialog = -1000;
            }
        }
        tryNextSetupDialog = CanvasScr.GetNextListIndex();
        if (tryNextSetupDialog > -100)
        {
            if (tryNextSetupDialog == -1)
            {
                EndDialog();
            } 
            else 
            {
                firstGoingLoop = true;
            }
            dialogProgres1 = tryNextSetupDialog;

        }

        
    /* 
        if (nextSetupDialog > -100)
        {
            if (nextSetupDialog == -1) // выход из диалога
            {
                print("7777  " + CanvasScr.GetMissionProgress());
                dialogStatus += CanvasScr.GetMissionProgress();
                progressDialog = 0;
                CanvasScr.desactivateWorkingDialogWindow();
                firstGoingLoop = false;
                nextSetupDialog = -1000;
            } else {
                
                firstGoingLoop = true;
                progressDialog = nextSetupDialog;
            }
        }*/
    }
    private void EndDialog()
    {
        print("dialogStatus " + dialogStatus);
        dialogStatus += CanvasScr.GetMissionProgress();
        CanvasScr.desactivateWorkingDialogWindow();
    }
    public int GetDialogStatus()
    {
        return dialogStatus;
    }
}
