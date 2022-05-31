using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerTargetSystem : MonoBehaviour
{
    Transform actualTarget;
    Material actualTestMat;
    public List<Transform> enemyTest;
    public List<Material> matTest;
    public Transform player;
    void Start()
    {
        foreach(Transform aEnemy in enemyTest)
        {
            matTest.Add(aEnemy.gameObject.GetComponent<MeshRenderer>().material);

        }
        actualTarget = enemyTest[0];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(actualTestMat != null)
        actualTestMat.color = Color.magenta;
        for (int i = 0; i < enemyTest.Count;i++)
        {
            if(Vector3.Distance(player.position,actualTarget.position) > Vector3.Distance(player.position, enemyTest[i].position))
            {
                actualTarget = enemyTest[i];
                actualTestMat = matTest[i]; //test
            }
        }

        actualTestMat.color = Color.red; //test
    }
}
