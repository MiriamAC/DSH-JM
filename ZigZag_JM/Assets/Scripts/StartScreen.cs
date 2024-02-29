using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScreen : MonoBehaviour
{
    public Button btn;
    public Image img;
    public TextMeshProUGUI txt;

    public Sprite[] images;

    private int mostrar;
    private bool contar;

    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(pulsado);
        contar = false;
        mostrar = 3;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if (contar){
            switch(mostrar){
                case 0: CargarLevel1(); Debug.Log(""); break;
                case 1: img.sprite = images[0]; break;
                case 2: img.sprite = images[1]; break;
                case 3: img.sprite = images[2]; break;
            }
            StartCoroutine(Esperar());
            contar = false;
            mostrar--;
        }
    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(1f);
        contar = true;
    }

    void pulsado(){

        img.gameObject.SetActive(true);
        btn.gameObject.SetActive(false);
        txt.gameObject.SetActive(false);
        contar = true;
    }

    void CargarLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
}
