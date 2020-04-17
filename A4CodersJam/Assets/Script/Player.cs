using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoderJam
{
    public class Player : MonoBehaviour
    {
        public float moveSpeed = 5f;
        public GameObject spawn;
        public GameObject tache;
        public GameObject pupille1;
        public GameObject pupille2;
        public float lerpRatio;
        private AudioSource hitSound;


        private Vector3 movement;
        private int lifemax;
        [HideInInspector]
        public bool stop;
        [HideInInspector]
        public Vector2 addVelocity;

        private Rigidbody2D _rb;
        private List<CameraAreaTrigger> _areasList = new List<CameraAreaTrigger>();
        private bool isMove;

        private void Awake()
        {
            lifemax = 8;
            StaticVariable.Life = lifemax;
            StaticVariable.Death = 0;
            _rb = this.GetComponent<Rigidbody2D>();
            hitSound = GetComponent<AudioSource>();
            Debug.Log(gameObject.transform.position);

        }

        void Update()
        {
            if (!stop)
            {
                float hAxis = Input.GetAxis("Horizontal");
                float vAxis = Input.GetAxis("Vertical");
                movement = new Vector3(hAxis, vAxis, 0) * moveSpeed * Time.deltaTime + new Vector3(addVelocity.x,addVelocity.y,0)*Time.deltaTime;
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pupille1.transform.position = Vector3.Lerp(pupille1.transform.position,pupille1.GetComponent<VariablesPupilles>().posUp.transform.position,lerpRatio);
                    pupille2.transform.position = Vector3.Lerp(pupille2.transform.position, pupille2.GetComponent<VariablesPupilles>().posUp.transform.position, lerpRatio);
                    gameObject.GetComponent<Animator>().SetBool("isMove", true);

                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pupille1.transform.position = Vector3.Lerp(pupille1.transform.position, pupille1.GetComponent<VariablesPupilles>().posDown.transform.position, lerpRatio);
                    pupille2.transform.position = Vector3.Lerp(pupille2.transform.position, pupille2.GetComponent<VariablesPupilles>().posDown.transform.position, lerpRatio);
                    gameObject.GetComponent<Animator>().SetBool("isMove", true);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pupille1.transform.position = Vector3.Lerp(pupille1.transform.position, pupille1.GetComponent<VariablesPupilles>().posRight.transform.position, lerpRatio);
                    pupille2.transform.position = Vector3.Lerp(pupille2.transform.position, pupille2.GetComponent<VariablesPupilles>().posRight.transform.position, lerpRatio);
                    gameObject.GetComponent<Animator>().SetBool("isMove", true);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pupille1.transform.position = Vector3.Lerp(pupille1.transform.position, pupille1.GetComponent<VariablesPupilles>().posLeft.transform.position, lerpRatio);
                    pupille2.transform.position = Vector3.Lerp(pupille2.transform.position, pupille2.GetComponent<VariablesPupilles>().posLeft.transform.position, lerpRatio);
                    gameObject.GetComponent<Animator>().SetBool("isMove", true);
                }
                if(!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))
                {
                    pupille1.transform.position = Vector3.Lerp(pupille1.transform.position, pupille1.GetComponent<VariablesPupilles>().posInit.transform.position, lerpRatio);
                    pupille2.transform.position = Vector3.Lerp(pupille2.transform.position, pupille2.GetComponent<VariablesPupilles>().posInit.transform.position, lerpRatio);
                    gameObject.GetComponent<Animator>().SetBool("isMove", false);
                }

            }

        }

        private void FixedUpdate()
        {
            _rb.MovePosition(transform.position + movement);
        }

        void explosion()
        {

            GameObject blood = Instantiate(tache, transform.position, Quaternion.identity);
            blood.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f),  Random.Range(0f, 1f));
            blood.transform.rotation = new Quaternion(0, 0, Random.Range(0f, 1f), Random.Range(0f, 1f));
            hitSound.Play();
            gameObject.GetComponent<Animator>().Play("touche", 0, 0);
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
