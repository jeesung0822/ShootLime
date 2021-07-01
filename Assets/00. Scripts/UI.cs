using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{    
    public bool isDelay;
    public bool onSetPop = false;

    public int powerMemory;
    
    private float delayTime = 0.5f;
    public float buttonPower1;
    public float buttonPower2;
    public float buttonPower3;

    public Text scoreTx;
    public Text slimeTx;
    public Text angleTx;
    
    public Text resultScoreTx;
    public Text highScoreTx;

    public GameObject setPopup;
    public GameObject resultPopup;

    SpriteRenderer sprite;

//--------------------------파워-----------------------------//
    public void ChangePower1()
    {
        DataManager.Instance.power = buttonPower1;
        powerMemory = 1;
    }

    public void ChangePower2()
    {
        DataManager.Instance.power = buttonPower2;
        powerMemory = 2;
    }

    public void ChangePower3()
    {
        DataManager.Instance.power = buttonPower3;
        powerMemory = 3;
    }

//-------------------------슬라임----------------------------//

    public void ChangeSlime1()
    {
        if(!isDelay)
        {
            DataManager.Instance.selectS = DataManager.Instance.memory[0];
        }
    }

    public void ChangeSlime2()
    {
        if(!isDelay)
        {
            DataManager.Instance.selectS = DataManager.Instance.memory[1];
        }
    }

    public void ChangeSlime3()
    {
        if(!isDelay)
        {
            DataManager.Instance.selectS = DataManager.Instance.memory[2];
        }
    }

    public void ChangeSlime4()
    {
        if(!isDelay)
        {
            DataManager.Instance.selectS = DataManager.Instance.memory[3];
        }
    }
//-------------------------------------------------------------//

    public void Shoot()
    {
        if(!isDelay)
        {
            isDelay = true;
            DataManager.Instance.Fire();
            StartCoroutine(ShootDelay());
        }
    }

    public void GoMain()
    {
        DataManager.Instance.previewSlimeImage[0].sprite = DataManager.Instance.changeSlimeImage[DataManager.Instance.memory[0]];
        DataManager.Instance.previewSlimeImage[1].sprite = DataManager.Instance.changeSlimeImage[DataManager.Instance.memory[1]];
        DataManager.Instance.previewSlimeImage[2].sprite = DataManager.Instance.changeSlimeImage[DataManager.Instance.memory[2]];
        DataManager.Instance.previewSlimeImage[3].sprite = DataManager.Instance.changeSlimeImage[DataManager.Instance.memory[3]];    
        SceneManager.LoadScene(0);
        DataManager.Instance.DestroyStage();

    }

    public void Replay()
    {
        DataManager.Instance.DestroyStage();
        switch (DataManager.Instance.stageMemory)
        {
            case 1:
            SceneManager.LoadScene(1);
            DataManager.Instance.Stage1();
            break;
            
            case 2:
            SceneManager.LoadScene(2);
            DataManager.Instance.Stage2();
            break;
        }
    }

    public void SetPopup()
    {
        if(!onSetPop)
        {
            setPopup.SetActive(true);
            onSetPop = true;
        }
        else
        {
            setPopup.SetActive(false);
            onSetPop = false;
        }
    }

//----------------------------------------------------------------//

    IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(delayTime);
        isDelay = false;
        
    }    

    void Awake()
    {
        DataManager.Instance.score = 0;

        powerMemory = 2;
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(DataManager.Instance.dessertCount == 0 && DataManager.Instance.bDessertCount)
        {
            DataManager.Instance.score += DataManager.Instance.haveSA * 10;
            DataManager.Instance.bDessertCount = false;
            resultPopup.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SetPopup();
        }

        if(DataManager.Instance.randomSFire) // 아무튼 랜덤슬라임 때문임
        {
            switch(powerMemory)
            {
                case 1:
                ChangePower1();
                break;

                case 2:
                ChangePower2();
                break;

                case 3:
                ChangePower3();
                break;
            }
            
            DataManager.Instance.randomSFire = false;
        }

//------------------------------------------------UI--------------------------------------------------------------//

        scoreTx.text = "점수 : " + DataManager.Instance.score;
        switch(DataManager.Instance.stageMemory)
        {
            case 1:
            if(DataManager.Instance.score > DataManager.Instance.highScore[0])
            {
                DataManager.Instance.highScore[0] = DataManager.Instance.score;
                DataManager.Instance.SaveData();
            }
            highScoreTx.text = "최고점수 : " + DataManager.Instance.highScore[0];
            break;

            case 2:
            if(DataManager.Instance.score > DataManager.Instance.highScore[1])
            {
                DataManager.Instance.highScore[1] = DataManager.Instance.score;
                DataManager.Instance.SaveData();
            }
            highScoreTx.text = "최고점수 : " + DataManager.Instance.highScore[1];
            break;

            default:
            break;
        }  

        resultScoreTx.text = "점수 : " + DataManager.Instance.score;
        //highScoreTx.text = "최고점수 : " + DataManager.Instance.highScore;

        slimeTx.text = "" + DataManager.Instance.haveSA;
//-----------------------------------------------------------------------------------------------------------------//
    }

}
