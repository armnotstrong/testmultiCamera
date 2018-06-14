using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerController : MonoBehaviour {


    [SerializeField]
    private GameObject diamondPrefab;

    [SerializeField]
    private GameObject diamondUI;


    [SerializeField]
    private GameObject diamondCnt;

    [SerializeField]
    private Camera otherCamera;


    private void OnGUI()
    {
        if(GUI.Button(new Rect(100,100,100,100), "GO"))
        {
            collectDiamond();
        }
    }


    private void collectDiamond()
    {
        GameObject go = Instantiate(diamondPrefab);
        var p1R = diamondUI.GetComponent<RectTransform>();
        Vector3 p1WorldPos = p1R.TransformPoint(p1R.rect.center);

        Vector3 startPos = otherCamera.ScreenToWorldPoint(p1WorldPos);

        Debug.Log(" start pos is :" + startPos);

        go.transform.position = startPos;

        var p2R = diamondCnt.GetComponent<RectTransform>();
        Vector3 p2WorldPos = p2R.TransformPoint(p2R.rect.center);

        Vector3 endPos = otherCamera.ScreenToWorldPoint(p2WorldPos);
        Debug.Log(" end pos is :" + endPos);
        go.transform.DOMove(endPos, 1f);
        
    }

}
