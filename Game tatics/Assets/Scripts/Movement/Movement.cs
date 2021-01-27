using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool teste;
    public Vector3Int destino;
    SpriteRenderer SR;
    // Start is called before the first frame update


    void Start()
    {
        SR = GetComponentInChildren<SpriteRenderer>();
    }
    // Update is called one per freme
    void Update(){
        if(teste){
            teste = false;
            StopAllCoroutines();
            StartCoroutine(Move());
        }
        
    }
    IEnumerator Move(){
        yield return null;
        TileLogic t = Board.instance.tiles[destino];
        
        Vector3 startPos = transform.position;
        Vector3 endPos = t.worldPos;
        float totalTime=1;
        float tempTime=0;

        while(transform.position!=endPos){
            tempTime += Time.deltaTime;
            float perc = tempTime/totalTime;
            transform.position = Vector3.Lerp(startPos, endPos, perc);
            yield return null;
        }

        SR.sortingOrder = t.contentOrder;
        t.content = this.gameObject;
    }
}
