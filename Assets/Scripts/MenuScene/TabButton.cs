using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public TabGroup tabGroup;

    public Image background;

    public void OnPointerClick()
    {
        tabGroup.OnTabSelected(this);
    }

    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.AddTabButton(this);

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnPointerClick);
    }
}
