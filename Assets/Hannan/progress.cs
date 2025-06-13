using UnityEngine;
using UnityEngine.UI;

public class progress : MonoBehaviour
{
    public float mileage = 0.0f;
    public Transform startingPoint, player;
    public Text mileageText;
    public Slider mileageProgress;
    public float maxDistance = 490.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mileage = Vector3.Distance(startingPoint.position, player.position);
        mileageText.text = "Mileage : " + Mathf.RoundToInt(mileage).ToString();
        float percent = mileage / maxDistance;
        mileageProgress.value = percent;
    }
}
