using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

	public UnityEvent onSpawnAction;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
			onSpawnAction.Invoke();
        }
    }
}
