using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordGame : MonoBehaviour
{
    // Start is called before the first frame update
    private string [] listOfWords={"JOY","CALM", "HATE", "KIND", "SMILE", "UGLY","LOVE","FREE", "EVIL"};
    // private string [] listOfPositiveWords={"PEACE"};
    private int streak;
    public static int health=3;
    public static int currentLetter=0;
    public static string currentWord;
    public static bool instantiateNewLetters=true;
    public TextMeshProUGUI currentWordTextbox;
    private bool wordInProgress=false;
    private int level=0;
    public GameObject health1, health2, health3;
    private AudioSource wordCompleteSound;
    void Start()
    {
        wordCompleteSound = GetComponent<AudioSource>();
        getNewWord();
        // currentWordTextbox.text = "<color=red>H</color>ELLO";
    }

    // Update is called once per frame
    void Update()
    {
        currentWordTextbox.text = "<color=#FF787B>" + currentWord.Substring(0,currentLetter) + "</color>" + currentWord.Substring(currentLetter);
        if (currentWord.Length == currentLetter){
            if (!wordInProgress){
                wordInProgress=true;
                currentLetter=0;
                getNewWord();
            } 
        }


        //HEALTH
        if (health==1){
            health3.SetActive(false);
            health2.SetActive(false);
            
        }else if(health==2){
            health3.SetActive(false);
        }else if (health==0){
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);
        }
    }
    void getNewWord(){
        wordCompleteSound.Play();
        wordInProgress=false;
        // int ran = Random.Range(0, 2);
        currentWord = listOfWords[level];
        Debug.Log("getting new word "+currentWord +" "+level);
        var test = currentWord.ToCharArray();
        instantiateNewLetters = false;
        level +=1;
    }


}
