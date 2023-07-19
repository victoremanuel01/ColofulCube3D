using System.Collections;
using UnityEngine;

public class MovPlayer : MonoBehaviour {
    
    Vector2 direction;
    Vector2 StartPosition;

    private const float speed = 300f;
    int count;
    bool isMoving = false;
    public float HalfSize = 0.5f;
    public LayerMask CheckCollision;
    public int PassosTotais;
    public AudioSource passos;

    
    void Update() {
        if (isMoving)return;

        if (Input.touchCount < 1)return;
        Touch touch = Input.GetTouch(0);
        switch (touch.phase) {

            case TouchPhase.Began:

                StartPosition = touch.position;
                break;

            case TouchPhase.Ended:
                direction = touch.position - StartPosition;
                if (!ScriptCanvas.Instance.isPaused)
                {
                    Move(direction);
                }
                break;
        

        }
    
        
    }

    private void Move(Vector2 direction) {

        if (direction.magnitude < 100f)return;

        Vector2 normalizedDirection = direction.normalized;
        float Rotation = Mathf.Deg2Rad * 45f;
        normalizedDirection = new Vector2(
                normalizedDirection.x * Mathf.Cos(Rotation) - normalizedDirection.y * Mathf.Sin(Rotation),
                normalizedDirection.x * Mathf.Sin(Rotation) + normalizedDirection.y * Mathf.Cos(Rotation)
        );

        if (Mathf.Abs(normalizedDirection.x) > Mathf.Abs(normalizedDirection.y)) {
            if (normalizedDirection.x > 0) {
                if (!Physics.Raycast(transform.position, Vector3.right, out RaycastHit hit, 3f, CheckCollision.value)){
                    if(Tutorial.tutorial != null)
                    {
                        if(Tutorial.tutorial.tutorialOn == false)
                        {
                            StartCoroutine(Roll(Vector3.right));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();
                        }
                    }else
                    {
                        StartCoroutine(Roll(Vector3.right));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();
                    }
                }
                 
            } else {
                if (!Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, 3f, CheckCollision.value)) {
                    if(Tutorial.tutorial != null)
                    {
                        if(Tutorial.tutorial.inputLeft == true || Tutorial.tutorial.tutorialOn == false)
                        {
                            StartCoroutine(Roll(Vector3.left));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();
                            Tutorial.tutorial.DontActiveTutorialOn();
                        }
                    }else
                    {
                        StartCoroutine(Roll(Vector3.left));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();
                    }

                }
            }
        } else {
            if (normalizedDirection.y > 0) {
                if (!Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 3f, CheckCollision.value)){
                    if(Tutorial.tutorial != null)
                    {
                        if(Tutorial.tutorial.tutorialOn == false)
                        {
                            StartCoroutine(Roll(Vector3.forward));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();
                        }
                    }else
                    {
                        StartCoroutine(Roll(Vector3.forward));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();
                    }
                }
                    
            } else {
                if (!Physics.Raycast(transform.position, Vector3.back, out RaycastHit hit, 3f, CheckCollision.value)){
                    if(Tutorial.tutorial != null)
                    {
                        if(Tutorial.tutorial.inputLeft == false || Tutorial.tutorial.tutorialOn == false)
                        {
                            StartCoroutine(Roll(Vector3.back));
                            --ScriptCanvas.Instance.contaPassos.value;
                            ScriptCanvas.Instance.UpdateStar(PassosTotais);
                            PassosTotais--;
                            passos.Play();   
                            Tutorial.tutorial.ActiveLeft();
                    }
                    }else
                    {
                        StartCoroutine(Roll(Vector3.back));
                        --ScriptCanvas.Instance.contaPassos.value;
                        ScriptCanvas.Instance.UpdateStar(PassosTotais);
                        PassosTotais--;
                        passos.Play();   
                    }
                }
            }
        }


    }

    IEnumerator Roll(Vector3 direction) {
        isMoving = true;

        float remainingAngle = 90f;
        Vector3 rotationCenter = transform.position + direction * HalfSize + Vector3.down * HalfSize;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0f) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;

            yield return null;
        }

        isMoving = false;
    }
    
}




