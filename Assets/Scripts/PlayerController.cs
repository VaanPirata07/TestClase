using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Parámetros de movimiento"), Space]
    [Tooltip("Velocidad de movimiento")]
    public float speed;

    //Referencia al valor del input axis horizontal
    private float h;

    //Referencia al valor del input axis vertical
    private float v;

    //Vector de movimiento
    private Vector2 movement;

    [Header("Límite de pantalla"), Space]
    [Tooltip("Límite de movimiento en el eje X")]
    public float xLimit;

    [Tooltip("Límite de movimiento en el eje Y")]
    public float yLimit;

    

    //Referencias
    //Referencia al rigidbody 2D
    private Rigidbody2D rb2d;

    //AWAKE
    private void Awake() {

        rb2d = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    //FIXED UPDATE
    private void FixedUpdate() {
        
        Movement();
        
    }

    // Update is called once per frame
    void Update()
    {
        #region Axis
        //Recuperamos los valores de los axis horizontal y vertical
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        #endregion

        LimitZones();
    }

    /// <summary>
    /// Metodo que se encargara de realizar el movimiento del jguador
    /// </summary>
    private void Movement() {

        

        //Generamos un vector de movimiento y lo normalizamos
        movement = new Vector2(h, v).normalized;

        //Aplicamos el movimiento sobre el jugador
        rb2d.MovePosition((Vector2)transform.position + movement * speed * Time.deltaTime);



    }

    public void LimitZones()
    {
        //Si la posicion en X es mayor a nuestra variable xLimit
        if (transform.position.x > xLimit)
        {
            //Decimos que la posicion del player sea en X la variable y nuestra posicion en y
            transform.position = new Vector2(xLimit, transform.position.y);

            //y si nuestra posicion en y es menor que nuestra variable en negativo xLimit para llegar a ambas zonas de la pantalla
        } else if (transform.position.x < -xLimit)
        {
            //Nuestra posicion sera un vector2 con valores de nuestra variable en negativo y la posicion del player en y.
            transform.position = new Vector2(-xLimit, transform.position.y);
        }

        //Si nuestra posicion en Y es mayor que nuestra variable yLimit
        if (transform.position.y > yLimit)
        {
            //La posicion de nuestro jugador será nuestra posicion en x y la posicion de nuestra variable yLimit
            transform.position = new Vector2(transform.position.x, yLimit);

            //Si nuestra posicion en y es menor que nuestra variable en negativo yLimit
        } else if (transform.position.y < -yLimit)
        {
            //la nueva posicion de nuestro player será su valor en x y el valor maximo de nuestra variable yLimit en negativo.
            transform.position = new Vector2(transform.position.x, -yLimit);
        }
    }


}
