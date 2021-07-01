using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : MonoBehaviour
{
    Rigidbody2D rigid;

    private AudioSource audioSource;
    public AudioClip audioClip;
    
    void Awake() 
    {
        rigid = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    
    public void shoot(Vector2 dir, float power)
    {
        rigid.AddForce(dir * power);

        if(DataManager.Instance.isRandomS) // 랜덤슬라임 때문임
        {
            DataManager.Instance.randomSFire = true;
            DataManager.Instance.isRandomS = false;
        }
        else if(DataManager.Instance.isTwinS && DataManager.Instance.twinSFire) // 트윈슬라임 때문임
        {
            DataManager.Instance.twinSFire = false;
            Invoke("TwinFire", 0.5f);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        rigid.gravityScale = 1f;
        audioSource.PlayOneShot(audioClip);
        Invoke("SoundStop", 6f);
    }

    public void SoundStop()
    {
        audioSource.mute = true;
    }

    void TwinFire()
    {
        DataManager.Instance.useSA = 0;
        DataManager.Instance.selectS = 12;
        DataManager.Instance.Fire();
        DataManager.Instance.useSA = 20;
        DataManager.Instance.selectS =  6;
    }
}