using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private AudioLowPassFilter musicMuffler;
    public GameObject creepy;
    // Start is called before the first frame update
    void Start()
    {
        musicMuffler = GetComponent<AudioLowPassFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (WordGame.level%3==0 && WordGame.level!=0){
            //low pass
            creepy.SetActive(true);
            musicMuffler.cutoffFrequency= (Mathf.Sin(Time.time) * 600 + 850);
        }else{
            musicMuffler.cutoffFrequency= 5000;;

            creepy.SetActive(false);

        }
    }
}
