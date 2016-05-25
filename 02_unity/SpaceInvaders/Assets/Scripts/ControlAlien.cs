using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlAlien : MonoBehaviour
{
	// Conexión al marcador, para poder actualizarlo
	private GameObject marcador;

	// Por defecto, 100 puntos por cada alien
	// private int puntos = 100;
	// Ponemos puntuación diferente por cada Alien

	// Objeto para reproducir la explosión de un alien
	private GameObject efectoExplosion;

	// Use this for initialization
	void Start ()
	{
		// Localizamos el objeto que contiene el marcador
		marcador = GameObject.Find ("Marcador");

		// Objeto para reproducir la explosión de un alien
		efectoExplosion = GameObject.Find ("EfectoExplosion");
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void OnCollisionEnter2D (Collision2D coll)
	{
		// Detectar la colisión entre el alien y otros elementos

		// Necesitamos saber contra qué hemos chocado
		if (coll.gameObject.tag == "disparo") {

			// Sonido de explosión
			GetComponent<AudioSource> ().Play ();

			// Sumar la puntuación al marcador
			// Dependiendo de qué tipo de alien sea le damos más o menos puntuación.
			// 100 para los de la primera fila, 200 para los de la segunda, 300 para los de la tercera y 400 para los de la cuarta.
			if (gameObject.tag == "Alien1"){
				marcador.GetComponent<ControlMarcador> ().puntos += 100;
			}
			if (gameObject.tag == "Alien2"){
				marcador.GetComponent<ControlMarcador> ().puntos += 200;
			}
			if (gameObject.tag == "Alien3"){
				marcador.GetComponent<ControlMarcador> ().puntos += 300;
			}
			if (gameObject.tag == "Alien4"){
				marcador.GetComponent<ControlMarcador> ().puntos += 400;
			}
			
			

			// El disparo desaparece (cuidado, si tiene eventos no se ejecutan)
			Destroy (coll.gameObject);

			// El alien desaparece (no hace falta retraso para la explosión, está en otro objeto)
			efectoExplosion.GetComponent<AudioSource> ().Play ();
			Destroy (gameObject);

		} else if (coll.gameObject.tag == "nave") {
			//SceneManager.LoadScene ("Nivel1");
			//Cargamos la escena de "GameOver"
			SceneManager.LoadScene ("GameOver");
		}
	}
}
