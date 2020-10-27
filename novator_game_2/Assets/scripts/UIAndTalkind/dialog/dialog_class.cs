using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class dialog_class: MonoBehaviour
{
    private string MainText;
    private int key;
    private int countAnswers;
    private List<string> answers;
    private List<int> answersKeys;
    private List<int> isGoMissionProgress;
    private Dictionary<int,string> privateKey;
    private string whatGiveAway;

    public List<int> GetMissionProgress()
    {
        return isGoMissionProgress;
    }
    public int GetMyKey()
    {
        return key;
    }
    public string GetMainText()
    {
        return MainText;
    }
    public int GetCountAnswers()
    {
        return countAnswers;
    }
    public List<string> GetAnswers()
    {
        return answers;
    }
    public List<int> GetAnswerKeys()
    {
        return answersKeys;
    }
    public Dictionary<int,string> GetPrivateKey()
    {
        return privateKey;
    }
    public string GetWhatGiveAway()
    {
        return whatGiveAway;
    }
    public void editAllParametrs(int key_loc, string MainText_loc,
                                 int countAnswers_loc, List<int> missionProgressLoc,
                                 List<string> answers_loc, List<int> answersKeys_loc, Dictionary<int,string> privateKey1, string whatGiveAway1) //
                                 {
                                    MainText = MainText_loc;
                                    key = key_loc;
                                    countAnswers = countAnswers_loc;
                                    answers = answers_loc;
                                    answersKeys = answersKeys_loc;
                                    isGoMissionProgress = missionProgressLoc;
                                    privateKey = privateKey1;
                                    whatGiveAway = whatGiveAway1;
                                 }
    public void editAllParametrs(int key_loc, string MainText_loc,
                                 int countAnswers_loc, List<int> missionProgressLoc,
                                 List<string> answers_loc, List<int> answersKeys_loc) //
    {
        this.editAllParametrs(key_loc, MainText_loc,
                                countAnswers_loc, missionProgressLoc,
                                answers_loc, answersKeys_loc, GetDictnonKey(answersKeys_loc), "--"); 
    }
    public void editAllParametrs(int key_loc, string MainText_loc,
                                 int countAnswers_loc, List<int> missionProgressLoc,
                                 List<string> answers_loc, List<int> answersKeys_loc, Dictionary<int,string> privateKey1){
        this.editAllParametrs(key_loc, MainText_loc,
                                countAnswers_loc, missionProgressLoc,
                                answers_loc, answersKeys_loc, privateKey1, "--");
    }
    public void editAllParametrs(int key_loc, string MainText_loc,
                                 int countAnswers_loc, List<int> missionProgressLoc,
                                 List<string> answers_loc, List<int> answersKeys_loc, string whatGiveAway1){
        this.editAllParametrs(key_loc, MainText_loc,
                                countAnswers_loc, missionProgressLoc,
                                answers_loc, answersKeys_loc, GetDictnonKey(answersKeys_loc), whatGiveAway1);
    
    }
    private Dictionary<int,string> GetDictnonKey(List<int> answersKeys_loc)
    {
        Dictionary<int,string> nonkey = new  Dictionary<int,string> ();
        foreach (int setup in answersKeys_loc)
        {
            nonkey[setup] =  "--";
        }
    return nonkey;
    }
                

}
