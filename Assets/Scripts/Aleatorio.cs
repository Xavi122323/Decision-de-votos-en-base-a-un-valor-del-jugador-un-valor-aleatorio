using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aleatorio : MonoBehaviour
{
    public GameObject jugador;
    public GameObject botonFavor;
    public GameObject botonContra;
    [SerializeField] private GameObject votosFavor;
    [SerializeField] private GameObject votosContra;
    [SerializeField] private int[] votos;
    private Vector3 vectorFavor, vectorContra;
    private int ale;

    void Start()
    {
        votos=new int[7];
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision other) {
        ale=-1;
        Debug.Log("Ha chocado con: " + gameObject.name);
        vectorFavor = new(-68,0,125);
        vectorContra = new(-85,0,125);
        if(gameObject.name==("Favor")){
            Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),2);
            vectorFavor.z += 2;
            votos[0]=1;
            for(int i = 0; i < 6; i++){
                ale=Random.Range(1, 2);
                if(i<2 && ale==1){
                    Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),2);
                    vectorFavor.z += 2;
                    votos[i+1]=1;
                }else{
                    ale=Random.Range(0, 2);
                    if(ale==1){
                        Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),2);
                        vectorFavor.z += 2;
                        votos[i+1]=1;
                    }else if(ale==0){
                        Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),2);
                        vectorContra.z += 2;
                        votos[i+1]=0;
                    }
                }
            }
        }else if(gameObject.name==("Contra")){
            Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),2);
            vectorContra.z += 2;
            votos[0]=0;
            for(int i = 0; i < 6; i++){
                ale=Random.Range(1, 2);
                if(i<2 && ale==0){
                    Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),2);
                    vectorContra.z += 2;
                    votos[i+1]=0;
                }else{
                    ale=Random.Range(0, 2);
                    if(ale==0){
                        Destroy(Instantiate(votosContra, vectorContra, Quaternion.identity),2);
                        vectorContra.z += 2;
                        votos[i+1]=0;
                    }else if(ale==1){
                        Destroy(Instantiate(votosFavor, vectorFavor, Quaternion.identity),2);
                        vectorFavor.z += 2;
                        votos[i+1]=1;
                    }
                }
            }
        }
        foreach( var vot in votos)
        {
            Debug.Log(vot);
        }
        
    }
}
