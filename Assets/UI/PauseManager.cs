using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private List<string> menuItems;
    [SerializeField] private UIDocument uiDoc;
    private VisualElement rootEl;
    private VisualElement pauseEl;
    private VisualElement menuItemsEl;

    private int selectedIndex = 0;

    private string activeClass = "pause-active";
    private string activeMenuItemClass = "menu-item-active";

    private void OnEnable()
    {
        rootEl = uiDoc.rootVisualElement;
        pauseEl = rootEl.Q(className: "pause");
        menuItemsEl = rootEl.Q(className: "menu-items");

        BuildMenu();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Open();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            HandleDown();
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            HandleUp();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            HandleSelect();
        }
    }

    private void BuildMenu()
    {
        int currentIndex = 0;

        foreach (string menuItem in menuItems)
        {
            menuItemsEl.Add(BuildMenuItem(menuItem, currentIndex == 0, currentIndex != 0));
            currentIndex++;
        }
    }

    private void Open()
    {
        pauseEl.AddToClassList(activeClass);
    }

    private void Close()
    {
        pauseEl.RemoveFromClassList(activeClass);
    }

    private void SelectSelected()
    {
        rootEl.Q(className: activeMenuItemClass).RemoveFromClassList(activeMenuItemClass);
        rootEl.Query(className: "menu-item").AtIndex(selectedIndex).AddToClassList(activeMenuItemClass);
    }

    private void HandleUp()
    {
        if (selectedIndex == 0)
        {
            selectedIndex = menuItems.Count - 1;
        }
        else
        {
            selectedIndex--;
        }

        SelectSelected();
    }

    private void HandleDown()
    {
        if (selectedIndex == menuItems.Count - 1)
        {
            selectedIndex = 0;
        }
        else
        {
            selectedIndex++;
        }

        SelectSelected();
    }

    private VisualElement BuildMenuItem(string text, bool active, bool spaceTop)
    {
        VisualElement menuItem = new VisualElement();
        menuItem.AddToClassList("menu-item");
        if (active) menuItem.AddToClassList("menu-item-active");
        if (spaceTop) menuItem.AddToClassList("space-top");

        VisualElement shadow = new VisualElement();
        shadow.AddToClassList("menu-item-shadow");

        VisualElement textEl = new VisualElement();
        textEl.AddToClassList("menu-item-text");

        Label textElLabel = new Label(text);

        menuItem.Add(shadow);
        menuItem.Add(textEl);
        textEl.Add(textElLabel);

        return menuItem;
    }

    private void HandleSelect()
    {
        string selectedItem = menuItems[selectedIndex];
        Debug.Log($"{selectedItem} has been selected, do something");
    }
}
