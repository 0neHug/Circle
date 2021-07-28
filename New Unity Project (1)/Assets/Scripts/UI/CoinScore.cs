
using UnityEngine;
using UnityEngine.UI;
public class CoinScore : MonoBehaviour
{
    public Text ScoreText;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        ScoreText.text = MovePlayer.CoinScore.ToString("0");

    }
}