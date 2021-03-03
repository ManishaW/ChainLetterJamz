using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordGame : MonoBehaviour
{
    // Start is called before the first frame update
    private string [] listOfWords={"JOY","CALM", "HATE","UGLY", "KIND", "SMILE", "UGLY","LOVE","FREE", "EVIL"};
    // private string [] listOfPositiveWords={"PEACE"};
    private int streak;
    public static int health=3;
    public static int currentLetter=0;
    public static string currentWord;
    public static bool instantiateNewLetters=true;
    public TextMeshProUGUI currentWordTextbox;
    public TextMeshProUGUI leftToWinText;
    private bool wordInProgress=false;
    public static int level=0;
    public GameObject health1, health2, health3;
    private AudioSource wordCompleteSound;
    public Animator wizAnim, girlAnim, negEnergy;
    // public GameObject negEnergy;
    bool tappedStaff=false;
    public GameObject healthLostBurst;

    void Start()
    {
        wordCompleteSound = GetComponents<AudioSource>()[0];
        getNewWord();
        // currentWordTextbox.text = "<color=red>H</color>ELLO";
        // musicMuffler = GetComponent<AudioLowPassFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level==3||level==4){
            currentWordTextbox.text = "<color=#8B70FF>" + currentWord.Substring(0,currentLetter) + "</color>" + "<color=#C50B00>"+currentWord.Substring(currentLetter)+"</color>";
            if (!tappedStaff && level!=0) {
                wizAnim.SetTrigger("TapStaff");
                tappedStaff=true;
                negEnergy.SetTrigger("NegEnergyComeIn");
                negEnergy.ResetTrigger("NegEnergyGoOut");
                girlAnim.SetTrigger("GoEmo");
                girlAnim.ResetTrigger("BackNormal");
                // musicMuffler.cutoffFrequency= (Mathf.Sin(Time.time) * 11010 -600);
                // negEnergy.SetActive(true);NegEnergyGoOut
            }

        }else if ( level==1||level==2||level==5){
            currentWordTextbox.text = "<color=#8B70FF>" + currentWord.Substring(0,currentLetter) + "</color>" + currentWord.Substring(currentLetter);
            tappedStaff=false;
            negEnergy.SetTrigger("NegEnergyGoOut");
            girlAnim.SetTrigger("BackNormal");

        }
        if (currentWord.Length == currentLetter){
            if (!wordInProgress){
                wordInProgress=true;
                currentLetter=0;
                getNewWord();
            } 
        }
        leftToWinText.text="To Win: "+(10-(level-1)).ToString();

        //HEALTH
        if (health==1){
            health3.SetActive(false);
            health2.SetActive(false);
            // Instantiate(healthLostBurst, health2.transform.position, Quaternion.identity);
            
        }else if(health==2){
            health3.SetActive(false);
            // Instantiate(healthLostBurst, health3.transform.position, Quaternion.identity);

        }else if (health==0){
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(false);
        }
    }
    void getNewWord(){
        if (level!=0) wordCompleteSound.Play();
        wordInProgress=false;
        // int ran = Random.Range(0, 2);
        currentWord = listOfWords[level];
        Debug.Log("getting new word "+currentWord +" "+level);
        var test = currentWord.ToCharArray();
        instantiateNewLetters = false;
        level +=1;
    }


}
