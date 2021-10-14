using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.GetComponentInChildren<Text>().color = new Color(0.4509804f, 0.172549f, 0.1058824f, 1);
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        // Hexadecimal: CB9A0D
        this.GetComponentInChildren<Text>().color = new Color(0.7960785f, 0.6039216f, 0.0509804f, 1);
    }
}
