using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoderJam
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public GameObject spawn;
        public GameObject Haut;
        public GameObject Bas;
        public GameObject Gauche;
        public GameObject Droite;
        public GameObject tache;

        public static int life = 3;
        public static int death = 0;

        private Rigidbody rb;
        private Vector3 movement;

        private void Awake()
        {

            life = 3;
            death = 0;
            rb = this.GetComponent<Rigidbody>();

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float hAxis = Input.GetAxis("Horizontal");
            float vAxis = Input.GetAxis("Vertical");
            movement = new Vector3(hAxis, vAxis, 0) * moveSpeed * Time.deltaTime;

            explosion();
        }

        private void FixedUpdate()
        {
            rb.MovePosition(transform.position + movement);
        }

        void explosion()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(tache, Haut.transform.position, Quaternion.identity);
                Instantiate(tache, Bas.transform.position, Quaternion.identity);
                Instantiate(tache, Gauche.transform.position, Quaternion.identity);
                Instantiate(tache, Droite.transform.position, Quaternion.identity);
                life--;
                lifeManager();
            }
        }

        void lifeManager()
        {
            if (life <= 0)
            {
                this.transform.position = spawn.transform.position;
                death++;
                life = 3;
            }
        }
    }
}
