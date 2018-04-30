using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gamekit2D
{

    public class Accelate : MonoBehaviour
    { [SerializeField]
        private GameObject ellen;

        // Use this for initialization
        public float speed;
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

            if (Input.GetKey(KeyCode.LeftShift) == true && ellen.GetComponent<PlayerCharacter>().maxSpeed < 20f)
            {
                ellen.GetComponent<PlayerCharacter>().maxSpeed += Time.deltaTime*3;
            }
            else
            {
                if (ellen.GetComponent<PlayerCharacter>().maxSpeed > 10f)
                    ellen.GetComponent<PlayerCharacter>().maxSpeed -= Time.deltaTime*3;
            }
        }

    }
}