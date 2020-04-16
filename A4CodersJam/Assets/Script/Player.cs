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

        //private Rigidbody rb;
        private Vector3 movement;
        private int lifemax;
        [HideInInspector]
        public bool stop;

        private Rigidbody2D _rb;
        private List<CameraAreaTrigger> _areasList = new List<CameraAreaTrigger>();

        private void Awake()
        {
            lifemax = 8;
            StaticVariable.Life = lifemax;
            StaticVariable.Death = 0;
            //rb = this.GetComponent<Rigidbody>();
            _rb = this.GetComponent<Rigidbody2D>();

        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (!stop)
            {
                float hAxis = Input.GetAxis("Horizontal");
                float vAxis = Input.GetAxis("Vertical");
                movement = new Vector3(hAxis, vAxis, 0) * moveSpeed * Time.deltaTime;
            }

        }

        private void FixedUpdate()
        {
            //rb.MovePosition(transform.position + movement);
            _rb.MovePosition(transform.position + movement);
        }

        void explosion()
        {
            //tache.GetComponent<SpriteRenderer>().sharedMaterial.color = Random.ColorHSV(0f,1f,0f,0f);

            GameObject blood = Instantiate(tache, transform.position, Quaternion.identity);
            blood.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),  Random.Range(0f, 1f));
            blood.transform.rotation = new Quaternion(0, 0, Random.Range(0f, 1f), Random.Range(0f, 1f));
            //Instantiate(tache, Bas.transform.position, Quaternion.identity);
            //Instantiate(tache, Gauche.transform.position, Quaternion.identity);
            //Instantiate(tache, Droite.transform.position, Quaternion.identity);
            StaticVariable.Life--;
            lifeManager();
        }

        void lifeManager()
        {
            if (StaticVariable.Life <= 0)
            {
                this.transform.position = spawn.transform.position;
                StaticVariable.Death++;
                StaticVariable.Life = lifemax;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Wall")
            {
                explosion();
            }
        }

        public void EnterArea(CameraAreaTrigger area)
        {
            if (_areasList.IndexOf(area) > 0) return;
            _areasList.Add(area);
            area.Activate(this);
        }

        public void ExitArea(CameraAreaTrigger area)
        {
            int areaIndex = _areasList.IndexOf(area);
            if (areaIndex < 0) return;

            if (areaIndex == _areasList.Count - 1)
            {
                _areasList.Remove(area);
                area.Deactivate(this);
                if (_areasList.Count > 0)
                {
                    CameraAreaTrigger lastArea = _areasList[_areasList.Count - 1];
                    lastArea.Activate(this);
                }
            }
            else
            {
                _areasList.Remove(area);
            }
        }
    }
}
