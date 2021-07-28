
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public Text ScoreText;
    public Transform Player;
    public static float stat = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        stat = (Player.position.z+1)/4;
        ScoreText.text = stat.ToString("0");

    }
}
