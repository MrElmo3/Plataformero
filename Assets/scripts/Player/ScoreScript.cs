using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using System.Threading.Tasks;

public class ScoreScript : MonoBehaviour
{
    public float score;
    private float timePointsAlter;
    public bool usingScore;

    private const float TIME_POINTS = 2f;
    private const float TIME_POINTS_AMOUNT = 10f;

    void Start()
    {
        score = 0;
        timePointsAlter = TIME_POINTS;
        usingScore = true;
    }

    private void FixedUpdate()
    {
        this.timePointsAlter-= Time.deltaTime;
        if(timePointsAlter <=0){
            score+=TIME_POINTS_AMOUNT;
            timePointsAlter = TIME_POINTS;
        }
    }

    //[ContextMenu("prueba get")]
    public async void SubirScore(){

        var url = "localhost:8080/getTScore";

        WWWForm form = new WWWForm();
        form.AddField("Score", this.score.ToString());
 
        using var wwwPOST = UnityWebRequest.Post(url, form);
        var operation = wwwPOST.SendWebRequest();
        
        while(!operation.isDone){
            await Task.Yield();
        }
        if(wwwPOST.result != UnityWebRequest.Result.Success){
            Debug.Log($"{wwwPOST.error}");
        }
        else
            wwwPOST.Dispose();
    }


}
