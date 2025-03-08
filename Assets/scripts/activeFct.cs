using UnityEngine;

public class activeFct : MonoBehaviour
{
    public GameObject stock;
    public GameObject carte;
    public GameObject fakeBG;
    public GameObject simuMenu;
    public GameObject settingPanel;
    public GameObject saveWarningPanel;

    [Header("obj to disable")]
    public GameObject mainMenu;
    public GameObject otherMenu;
    public GameObject btnClose;

    public CarteScript cartscr;

    public void ChangeStateStock()
    {
        if (true == stock.activeInHierarchy)
        {
            stock.SetActive(false);
            otherMenu.SetActive(false);
            mainMenu.SetActive(true);     
        }
        else if (false == stock.activeInHierarchy)
        {
            otherMenu.SetActive(true);
            stock.SetActive(true);
            mainMenu.SetActive(false);
        }

    }
    public void ChangeStateSimu()
    {
        if (true == stock.activeInHierarchy)
        {
            simuMenu.SetActive(false);
            otherMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if (false == stock.activeInHierarchy)
        {
            otherMenu.SetActive(true);
            simuMenu.SetActive(true);
            btnClose.SetActive(true);
            mainMenu.SetActive(false);
        }

    }

    public void ChangeStateCarte()
    {
        if (true == carte.activeInHierarchy)
        {
            carte.SetActive(false);
            otherMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if (false == stock.activeInHierarchy)
        {
            otherMenu.SetActive(true);
            carte.SetActive(true);
            btnClose.SetActive(true);
            mainMenu.SetActive(false);
        }

    }

    public void GoToMainMenue()
    {
        if (true == btnClose.activeInHierarchy)
        {
            if(true == stock.activeInHierarchy)
            {
                stock.SetActive(false);
            }
            else if (true == carte.activeInHierarchy)
            {
                carte.SetActive(false);
            }
            else if (true == simuMenu.activeInHierarchy)
            {
                simuMenu.SetActive(false);
            }
            otherMenu.SetActive(false);
            btnClose.SetActive(false);
            mainMenu.SetActive(true);

        }
    }

    public void GoToSettingsMenues()
    {
        if (true == settingPanel.activeInHierarchy)
        {
            settingPanel.SetActive(false);
        }
        else
        {
            settingPanel.SetActive(true);
        }
    }

    public void ActivePageVerifSave()
    {
        if (true == saveWarningPanel.activeInHierarchy)
        {
            saveWarningPanel.SetActive(false);
        }
        else
        {
            saveWarningPanel.SetActive(true);
        }
    }

    public void YesInStock()
    {
        if (true == stock.activeInHierarchy)
        {
            stock.SetActive(false);
        }
        otherMenu.SetActive(false);
        btnClose.SetActive(false);
        mainMenu.SetActive(true);
        cartscr.activeAddCartePanel();
        
    }

    public void YesInMainMenu()
    {
        Exit();
    }

    public void verifWichIsActive()
    {
        if(true == stock.activeInHierarchy)
        {
            YesInStock();
        }
        else
        {
            YesInMainMenu();
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
