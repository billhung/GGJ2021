using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GetItem : MonoBehaviour
{

    public AudioClip GetVois;
    AudioSource audioSource;
    ItemManeger _ItemManeger;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        _ItemManeger = GetComponent<ItemManeger>();
    }
    
    public void OnTriggerEnter(Collider other)
    {
        //触れたモノがアイテムなら
        if(other.tag == "Item")
        {
            //触れたオブジェクトのタグがItemなら破棄する
            DestroyItem(other.gameObject);
            audioSource.PlayOneShot(GetVois);
            _ItemManeger.GetItem();
        }
        //触れたものが会社なら
        if (other.tag == "Company")
        {
            //シーン遷移を行う　リザルトに行く
            SceneManager.LoadScene("Risult");
            _ItemManeger.GoRisult(true);
        }
    }

    //引数のオブジェクトを破棄する
    private void DestroyItem(GameObject Item)
    {
        Destroy(Item);
    }
}
