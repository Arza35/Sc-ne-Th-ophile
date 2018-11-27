using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmesVFX : MonoBehaviour {

    public ParticleSystem ps;
    private ParticleSystem.Particle[] ps_Particles;
    public float speed = 5f;
    private int numParticleAlive;

    //public Transform RondVert;


	void Start () {
        //ps = GetComponent<ParticleSystem>();
        if (!GetComponent<Transform>())
        {
            GetComponent<Transform>();
        }
    }
	
	// Update is called once per frame
	void Update () {
        ps_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        numParticleAlive = ps.GetParticles(ps_Particles);
        float step = speed * Time.deltaTime;
        for (int i = 0; i < numParticleAlive; i++) {
            ps_Particles[i].position = Vector3.SlerpUnclamped(ps_Particles[i].position, transform.position, step);
            Debug.Log("dsf");
        }
        ps.SetParticles(ps_Particles, numParticleAlive);

    }
}
