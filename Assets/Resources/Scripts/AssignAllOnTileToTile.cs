using UnityEngine;
using System.Collections;

public class AssignAllOnTileToTile : MonoBehaviour {

   // void onTriggerEnter2D(Collision2D coll)
   // {
        //if (coll.gameObject.tag == "Building")
        //coll.gameObject.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
     //   Debug.Log("Udało się");
        //Debug.Log(gameObject.transform);

   // }
    void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.GetComponent<SpriteRenderer>().sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }
}
