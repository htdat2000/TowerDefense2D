using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;

    public Sprite tabIdle;
    public Sprite tabSelected;

    private TabButton selectedTab;

    public List<GameObject> pages;

    public void AddTabButton(TabButton button)
    {
        if(tabButtons == null)
        {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button)
    {
        ResetTab();
        SwitchPage(button);
    }

    public void ResetTab()
    {
        foreach (TabButton button in tabButtons)
        {
            if (selectedTab != null && button == selectedTab)
                continue;
            //button.background.sprite = tabIdle;
        }
    }

    void SwitchPage(TabButton button)
    {
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < pages.Count; i++)
        {
            if(i == index)
            {
                pages[i].SetActive(true);
            }
            else
            {
                pages[i].SetActive(false);
            }
        }
    }
}
