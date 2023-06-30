using UnityEngine;
using UnityEngine.EventSystems;

public class PointController : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer SprRndr;
    public bool oneHot = true;
    public GridController gridCtrl;

    void Start()
    {
        SprRndr = GetComponent<SpriteRenderer>();
        gridCtrl = GameObject.Find("Management").GetComponent<GridController>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        oneHot = !oneHot;
        if (oneHot == true)
        {
            SprRndr.color = Color.black;
        }
        else if (oneHot == false)
        {
            SprRndr.color = Color.white;
        }
    }
}
