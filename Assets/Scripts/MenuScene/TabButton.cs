using UnityEngine;
using UnityEngine.UI;

public class TabButton : MonoBehaviour
{
    public TabGroup tabGroup;

    public Image background;

    private AudioManager audioGO;

    public void OnPointerClick()
    {
        tabGroup.OnTabSelected(this);
        audioGO.Play("Click");
    }

    void Start()
    {
        audioGO = FindObjectOfType<AudioManager>();

        background = GetComponent<Image>();
        tabGroup.AddTabButton(this);

        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(OnPointerClick);
    }
}
