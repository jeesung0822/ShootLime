using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUI : MonoBehaviour
{
    public void GoStage1()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.StageSet();
        DataManager.Instance.Stage1();
    }

    public void GoStage2()
    {
        SceneManager.LoadScene(2);
        DataManager.Instance.StageSet();
        DataManager.Instance.Stage2();
    }

    void Start()
    {
        DataManager.Instance.buttonNum = 0;
    }

//-------------------------------------------------------------//

    public void ChangeS1()
    {
        DataManager.Instance.changeS = 0;
    }

    public void ChangeS2()
    {
        DataManager.Instance.changeS = 1;
    }

    public void ChangeS3()
    {
        DataManager.Instance.changeS = 2;
    }

    public void ChangeS4()
    {
        DataManager.Instance.changeS = 3;
    }

    public void ChangeS5()
    {
        DataManager.Instance.changeS = 4;
    }

    public void ChangeS6()
    {
        DataManager.Instance.changeS = 5;
    }

    public void ChangeS7()
    {
        DataManager.Instance.changeS = 6;
    }

    public void ChangeS8()
    {
        DataManager.Instance.changeS = 7;
    }

    public void ChangeS9()
    {
        DataManager.Instance.changeS = 8;
    }

    public void ChangeS10()
    {
        DataManager.Instance.changeS = 9;
    }

    public void ChangeS11()
    {
        DataManager.Instance.changeS = 10;
    }

    public void ChangeS12()
    {
        DataManager.Instance.changeS = 11;
    }

    //-------------------------------------------------------------//

    public void Memory()
    {
        if(DataManager.Instance.buttonNum % 4 == 0)
        {
            DataManager.Instance.B1Change();
            DataManager.Instance.buttonNum++;
        }
        else if(DataManager.Instance.buttonNum % 4 == 1)
        {
            DataManager.Instance.B2Change();
            DataManager.Instance.buttonNum++;
        }
        else if(DataManager.Instance.buttonNum % 4 == 2)
        {
            DataManager.Instance.B3Change();
            DataManager.Instance.buttonNum++;
        }
        else if(DataManager.Instance.buttonNum % 4 == 3)
        {
            DataManager.Instance.B4Change();
            DataManager.Instance.buttonNum++;
        }
    }

    public void PopOn()
    {
        DataManager.Instance.Pop.SetActive(true);
    }

}
