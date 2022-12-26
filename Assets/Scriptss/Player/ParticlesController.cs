using Assets.Scripts.Models.Particles;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{

    public List<Particles> Particles = new List<Particles>();


    public Particles GetParticle(string id)
    {
        return Particles.Where(p => p.Id.ToLower() == id.ToLower()).FirstOrDefault();
    }
    public void PlayParticle(string id)
    {
        var particle = Particles.Where(p => p.Id.ToLower() == id.ToLower()).FirstOrDefault().Particle;
        if (particle != null)
            particle.Play();
    }

    public void StopParticle(string id)
    {
        var particle = Particles.Where(p => p.Id.ToLower() == id.ToLower()).FirstOrDefault().Particle;
        if (particle != null)
            particle.Stop();
    }

    public void PlayParticle(string id, int rotation)
    {
        var particle = Particles.Where(p => p.Id.ToLower() == id.ToLower()).FirstOrDefault().Particle;
        if (particle != null)
        {
            var shape = particle.shape;
            shape.rotation = new Vector3(0, rotation);
            particle.Play();
        }
    }

    private void Update()
    {
        Particles.ForEach(p => p.Particle.transform.position = p.ParticlePosition.position);
    }
}
