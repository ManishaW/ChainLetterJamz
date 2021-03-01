using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class CardBehaviour : MonoBehaviour
{
    public TextMeshProUGUI letterText;
    public GameObject burstPE;
    public GameObject badBurst;
    
    // Start is called before the first frame update
    void Start()
    {
        //particles

    }

    // Update is called once per frame
    void Update()
    {
        //
        // if (WordGame.instantiateNewLetters){
        //     letterText.text="H";
        //     var test = WordGame.currentWord.ToCharArray();
        //     int ran = Random.Range(0, WordGame.currentWord.Length-1);
        //     Debug.Log(test+" "+ ran);
            
        // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if (other.tag=="Player"){
            
            if (WordGame.currentWord[WordGame.currentLetter].ToString()==letterText.text){
                WordGame.currentLetter +=1;
                (other.gameObject.GetComponents<AudioSource>())[0].Play();
                Instantiate(burstPE, transform.position, Quaternion.identity);

            }else{
                //health -1
                WordGame.health -=1;
                (other.gameObject.GetComponents<AudioSource>())[1].Play();
                Instantiate(badBurst, transform.position, Quaternion.identity);

            }
            // burstPE.SetActive(true);
            Destroy(this.gameObject);
            other.gameObject.GetComponent<RectTransform>().DOShakeAnchorPos(0.05f, 15f, 3, 10, true);
            


        }
    }
    //trigger with main player, explode and then destroy
}
