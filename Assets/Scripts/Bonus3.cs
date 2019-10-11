using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus3 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public interface IBonusable
{
    void ApplyBonus(Bonus bonus);

    void RemoveBonus(Bonus bonus);
}
