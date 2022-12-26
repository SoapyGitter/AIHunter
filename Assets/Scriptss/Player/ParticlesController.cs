using Assets.Scripts.Models.Particles;
using Assets.Scriptss.Models.Particles.ParticlesEnums;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesController : MonoBehaviour
{

    public List<ParticlesFiller> ParticlesFiller = new();
    private Dictionary<string, Particles> Particles = new Dictionary<string, Particles>();


    private void Awake()
    {
        ParticlesFiller.ForEach(p =>
        {
            Particles.Add(p.Name.ToStringFast(), new Particles { Particle = p.Particle, ParticlePosition = p.ParticlePosition });
        });
    }
    public Particles GetParticle(string id)
    {

        return Particles[id];
    }
    public void PlayParticle(string id)
    {
        var particle = Particles[id].Particle;
        if (particle != null)
            particle.Play();
    }

    public void StopParticle(string id)
    {
        var particle = Particles[id].Particle;
        if (particle != null)
            particle.Stop();
    }

    public void PlayParticle(string id, int rotation)
    {
        var particle = Particles[id].Particle;
        if (particle != null)
        {
            var shape = particle.shape;
            shape.rotation = new Vector3(0, rotation);
            particle.Play();
        }
    }

    public void RemoveParticle(string id) => Particles.Remove(id);

    private void Update()
    {
        foreach (var particle in Particles)
            particle.Value.Particle.transform.position = particle.Value.ParticlePosition.position;
    }
}
