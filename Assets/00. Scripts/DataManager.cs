using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;

[SerializeField]
public class PlayerData
{
    public int highscoreStg1;
    public int highscoreStg2;

    public void GetData()
    {
        DataManager.Instance.highScore[0] = highscoreStg1;
        DataManager.Instance.highScore[1] = highscoreStg2;
    }

}

public class DataManager : MonoBehaviour
{
    public bool fireClick = false;
    public bool isRandomS = false;
    public bool randomSFire = false;
    public bool isTwinS = false;
    public bool twinSFire = false;
    public bool leverOn = false;
    public bool buttonOn = false;
    public bool bDessertCount = false;
    public bool eatBigCake = false;

    
    public float power = 666.154f;

    public int score = 0;
    public int[] highScore;
    public int haveSA = 200;
    public int useSA;
    public int selectS;
    public int changeS;
    public int buttonNum = 0;
    public int[] memory;
    public int bombCount = 0;
    public int pigStack = 0;
    public int dessertCount;
    public int stageMemory;

    public GameObject[] slimePrefab;
    public GameObject endPopup;
    public GameObject stageSet;
    public GameObject[] stagePrefab;
    public GameObject stage;
    public GameObject gravityZone;

    public Transform firePos;

    public Image[] startSlimeImage;
    public Image[] previewSlimeImage;

    public Sprite[]  changeSlimeImage;

    public GameObject Pop;

    private AudioSource audioSource;
    public AudioClip audioClip;


//--------------------------------------------------------------------------------------------------//
        private static DataManager instance;
    public static DataManager Instance
    {
        get
        {
            if (instance == null)
            {
                var obj = FindObjectOfType<DataManager>();
                if (obj != null)
                {
                    instance = obj;

                }
                else
                {
                    var newSingleton = new GameObject("DataManager").AddComponent<DataManager>();
                    instance = newSingleton;
                }
            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
//--------------------------------------------------------------------------------------------------//


    private void Awake()
    {
        var objs = FindObjectsOfType<DataManager>();
        audioSource = GetComponent<AudioSource>();
        
        if (objs.Length != 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/GameData.json");
        PlayerData save = JsonUtility.FromJson<PlayerData>(jsonData); // 데이터 로드
        save.GetData();

        memory[0] = 0;
        memory[1] = 1;
        memory[2] = 2;
        memory[3] = 3;
    }

    void Update()
    {
        if(selectS != 6)
        {
            isTwinS = false;
        }
    }

    public void GameQuit()
    {
        Application.Quit();
    }


    public void StageSet()
    {
        score = 0;
        stageSet.SetActive(true);
    }

    public void Stage1()
    {
        haveSA = 200;
        selectS = memory[0];
        stage = Instantiate(stagePrefab[0], new Vector3(0.5f, -0.1f, 0), Quaternion.identity, transform);
        dessertCount = 15;
        bDessertCount = true;

        stageMemory = 1;
    }

    public void Stage2()
    {
        haveSA = 250;
        selectS = memory[0];
        stage = Instantiate(stagePrefab[1], new Vector3(-0.2f, -0.1f, 0), Quaternion.identity, transform);
        dessertCount = 19;
        bDessertCount = true;
        eatBigCake = false;

        stageMemory = 2;
    }


    public void DestroyStage()
    {
        Destroy(stage);
    }

    public void Fire()
    {
        if(haveSA >= useSA)
        {
                audioSource.PlayOneShot(audioClip);
            fireClick = true;
            DataManager.instance.haveSA -= useSA;
            GameObject slime = Instantiate(slimePrefab[selectS], firePos.position, Quaternion.identity);
            SlimeScript ss = slime.GetComponent<SlimeScript>();
            ss.shoot( firePos.up, power);
            Debug.Log("발싸");
            bombCount = 0;
        }
        else
        {
            SaLack();
        }
    }

        public void SaLack()
        {
            endPopup.SetActive(true);
        }

 //---------------------------------------스테이지 슬라임 버튼-------------------------------------------------//

    
    public void B1Change()
    {
        startSlimeImage[0].sprite = changeSlimeImage[changeS];
        previewSlimeImage[0].sprite = changeSlimeImage[changeS];
        memory[0] = changeS;
    }
    
    public void B2Change()
    {
        startSlimeImage[1].sprite = changeSlimeImage[changeS];
        previewSlimeImage[1].sprite = changeSlimeImage[changeS];
        
        memory[1] = changeS;
    }
    
    public void B3Change()
    {
        startSlimeImage[2].sprite = changeSlimeImage[changeS];
        previewSlimeImage[2].sprite = changeSlimeImage[changeS];
        memory[2] = changeS;
    }
    
    public void B4Change()
    {
        startSlimeImage[3].sprite = changeSlimeImage[changeS];
        previewSlimeImage[3].sprite = changeSlimeImage[changeS];
        memory[3] = changeS; 
    }

    public void SaveData()
    {
        PlayerData myData = new PlayerData();
        myData.highscoreStg1 = highScore[0];
        myData.highscoreStg2 = highScore[1];

        string str = JsonUtility.ToJson(myData);

        Debug.Log(str); //로그 찍어보기 

        File.WriteAllText(Application.persistentDataPath + "/GameData.json", JsonUtility.ToJson(myData));
        PlayerData data2 = JsonUtility.FromJson<PlayerData>(JsonUtility.ToJson(myData)); // 데이터 로드
        data2.GetData();
    }
}
