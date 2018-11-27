using System.Collections;
using UnityEngine;
[RequireComponent(typeof(ParticleSystem))]
public class particleAttractorLinear : MonoBehaviour {
	ParticleSystem ps;
	ParticleSystem.Particle[] m_Particles;
	public Transform target;
	public float speed = 5f;
	int numParticlesAlive;
    public float force;
    private float[] stockTimeStamps;
	void Start () {
		ps = GetComponent<ParticleSystem>();
		if (!GetComponent<Transform>()){
			GetComponent<Transform>();
		}
	}
	void Update () {
		m_Particles = new ParticleSystem.Particle[ps.main.maxParticles];
        stockTimeStamps = new float[ps.main.maxParticles];
        numParticlesAlive = ps.GetParticles(m_Particles);

        float step = speed * Time.deltaTime;
		for (int i = 0; i < numParticlesAlive; i++) {
            /*Vector3 particlePos;
            ParticleSystem.Particle p = m_Particles[i];
            if (ps.main.simulationSpace == ParticleSystemSimulationSpace.Local)
            {
                particlePos = transform.TransformPoint(p.position);
            }
            else if (ps.main.simulationSpace == ParticleSystemSimulationSpace.Custom)
            {
                particlePos = ps.main.customSimulationSpace.TransformPoint(p.position);
            }
            else
            {
                particlePos = p.position;
            }*/
            /*Vector3 dir = target.position;
            Vector3 seekForce = (dir * force) * Time.deltaTime;
            p.velocity += seekForce;*/
            ParticleSystem.Particle p = m_Particles[i];
            
            m_Particles[i].position = Vector3.LerpUnclamped(m_Particles[i].position, target.position, step);
            Debug.Log(target.position);
		}
        ps.SetParticles(m_Particles, numParticlesAlive);
	}
}
