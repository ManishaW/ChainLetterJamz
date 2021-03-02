using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    private bool isMoving;
    private Vector3 origPos, targetPos;
    private float timeToMove = 0.15f;
    public RectTransform character;
    private AudioSource moveSound;
    // private Dictionary <string, Vector2> allAvailablePositions = new Dictionary <string, Vector2>{
    //     {"test", new Vector2 (-30, 230)}, 
    //     {"test2", new Vector2 (-120, 230)} 
        
    // };
    int [] rows = {230, 150, 70,-10, -90, -170};
    int [] cols = {-120, -30, 60, 150, 240, 330};

    int currentRow, currentCol;

  
    // Start is called before the first frame update
    void Start()
    {
        currentRow=0;
        currentCol=0;
        moveSound= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 myPos = character.anchoredPosition;
        // if (isMoving){
        //     return;
        // }
        if (Input.GetKeyDown(KeyCode.UpArrow)){
            if (currentRow>0) currentRow = currentRow-1;
            else{character.DOShakeAnchorPos(0.05f, 5f, 3, 10, true);}
            // moveSound.Play();
            character.DOAnchorPos(new Vector2 (cols[currentCol], rows[currentRow]),0.20f);
            
        }
            // StartCoroutine(MovePlayer(Vector3.up));
         
            

        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            // StartCoroutine(MovePlayer("left"));
            // character.DOAnchorPos(allAvailablePositions["test2"],0.25f);
            if (currentCol>0) currentCol = currentCol-1;
            else{character.DOShakeAnchorPos(0.05f, 5f, 3, 10, true);}

            character.DOAnchorPos(new Vector2 (cols[currentCol], rows[currentRow]),0.20f);

        }
        // if (Input.GetKey(KeyCode.RightArrow)){if (currentCol<cols.Length-1) currentCol = currentCol+1; StartCoroutine(MovePlayer());}
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            if (currentRow<rows.Length-1) currentRow = currentRow+1;
            else{character.DOShakeAnchorPos(0.05f, 5f, 3, 10, true);}

            character.DOAnchorPos(new Vector2 (cols[currentCol], rows[currentRow]),0.2f);

        }
            // StartCoroutine(MovePlayer(Vector3.down));
            // character.DOAnchorPos(new Vector2 (cols[currentCol], rows[currentRow]),0.25f);


        if (Input.GetKeyDown(KeyCode.RightArrow)){
            if (currentCol<cols.Length-1) currentCol = currentCol+1;
            else{character.DOShakeAnchorPos(0.05f, 5f, 3, 10, true);}
            character.DOAnchorPos(new Vector2(cols[currentCol], rows[currentRow]),0.2f);
            // StartCoroutine(WaitAndPrint(0.35f));
            // currentCol = currentCol+1;
            // character.DOAnchorPos(new Vector2(cols[currentCol], rows[currentRow]),0.35f);
                // character.DOShakeAnchorPos(1f, 20f, 10, 5, true);
        }
            // StartCoroutine(MovePlayer(Vector3.right));
    }
     private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
            // character.DOShakeAnchorPos(0.05f, 20f, 10, 5, true);
        }
    }
/// Sent when another object enters a trigger collider attached to this
/// object (2D physics only).
// void OnTriggerEnter2D(Collider2D other)
// {
//     Debug.Log(other.name);
//     Destroy(other.gameObject);
// }

}