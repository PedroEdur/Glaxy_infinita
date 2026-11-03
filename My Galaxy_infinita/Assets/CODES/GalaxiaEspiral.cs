
using UnityEngine;

public class GalaxiaEspiral : MonoBehaviour
{
    public int quantidadeEstrelas = 3000;
    public int quantidadeBracos = 4;
    public float tamanho = 10f;
    public float rotacao = 2f;

    ParticleSystem particulas;
    ParticleSystem.Particle[] estrelas;

    void Start()
    {
        particulas = GetComponent<ParticleSystem>();

        estrelas = new ParticleSystem.Particle[quantidadeEstrelas];

        for (int i = 0; i < quantidadeEstrelas; i++)
        {
            float distancia = Random.Range(0.5f, tamanho);

            float braco = i % quantidadeBracos;

            float angulo =
                braco * Mathf.PI * 2f / quantidadeBracos
                + distancia * rotacao
                + Random.Range(-0.3f, 0.3f);

            Vector3 posicao = new Vector3(
                Mathf.Cos(angulo) * distancia,
                Mathf.Sin(angulo) * distancia,
                0
            );

            estrelas[i].position = posicao;
            estrelas[i].startSize = Random.Range(0.03f, 0.09f);
            estrelas[i].startColor = Color.Lerp(
                Color.white,
                new Color(0.4f, 0.6f, 1f),
                Random.value
            );

            estrelas[i].remainingLifetime = 9999;
        }

        particulas.SetParticles(estrelas, estrelas.Length);
    }

    void Update()
    {
        transform.Rotate(0, 0, 10f * Time.deltaTime);
    }
}
