using UnityEngine;

public class CrewStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum CrewMember {NULL, Jackie, Logan, Steve, Vera};

    public CrewMember crewName;

    [Range(-1, 1)]
    public int hunger;
    [Range(-1, 1)]
    public int thirst;
    [Range(-1, 1)]
    public int sanity;
}
