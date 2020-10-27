using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabsStorageController : MonoBehaviour
{
    public GameObject UITextMonologPrefab;
    public GameObject UITextDilog1AnsPrefab;
    public GameObject UITextDilog2AnsPrefab;
    public GameObject UITextDilog3AnsPrefab;
    public GameObject UITalkingDutton;
    public GameObject newTerain;
    public GameObject flour1; //объект муки
    private Dictionary<string, GameObject> inventarObjByType = new Dictionary<string, GameObject>(); //словарь, где ключём являются id объектов а содержимим - префабы объекта
    private List<Vector3> positionsOutRiverPoint = new List<Vector3>();
    private static List<GoblinAndWoulfControl> goblinAndWoulfControl = new List<GoblinAndWoulfControl>();
    public Sprite NullSpr;
    // Start is called before the first frame update
    void Awake()
    {
        inventarObjByType["food_flour1"] = flour1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Dictionary<string, GameObject> GetInvObjDict()
    {
        return inventarObjByType;
    }
    public void SetOutRivPoint(List<Vector3> poss)
    {
        positionsOutRiverPoint = poss;
        foreach (GoblinAndWoulfControl sscr in goblinAndWoulfControl)
        {
            sscr.SetGoblinTargetPoints(positionsOutRiverPoint);
        }
        print("88888------");
    }
    public List<Vector3>  GetOutRivPoint()
    {
        return positionsOutRiverPoint;
    }
    public void TryingClass()
    {
        print("--------^^^^^^^");
    }
    public void SetGoblinAndWoulfControl(GoblinAndWoulfControl scr)
    {
        goblinAndWoulfControl.Add(scr);
        print("88888888888888888888888------------");
    }
    
}
