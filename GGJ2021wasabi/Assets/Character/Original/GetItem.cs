using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{

    public AudioClip GetVois;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        //触れたモノがアイテムなら
        if(other.tag == "Item")
        {
            //触れたオブジェクトのタグがItemなら破棄する
            DestroyItem(other.gameObject);
            audioSource.PlayOneShot(GetVois);
        }
        //触れたものが会社なら
        if (other.tag == "Company")
        {
            //触れたオブジェクトのタグがItemなら破棄する
            DestroyItem(other.gameObject);
            audioSource.PlayOneShot(GetVois);
        }
    }

    //引数のオブジェクトを破棄する
    private void DestroyItem(GameObject Item)
    {
        Destroy(Item);
    }
}
