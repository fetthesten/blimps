using UnityEngine;

public class killzone : MonoBehaviour 
{
    private Transform _playerSpawn;
	void Start () 
	{
        _playerSpawn = GameObject.Find("playerSpawn").transform;
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            other.transform.position = _playerSpawn.position;
    }
}
