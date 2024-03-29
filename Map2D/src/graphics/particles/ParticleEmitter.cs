﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Map2D.graphics.particles
{
	public class ParticleEmitter
	{
		private DateTime timer;
		private readonly List<Particle> particles;

		public ParticleEmitter()
		{
			timer = DateTime.Now;
			particles = new List<Particle>();
		}

		public void Emit(int delay, Texture2D texture, Vector2 position, Vector2 velocity, float timeToLive)
		{
			DateTime now = DateTime.Now;
			if ((now - timer).TotalMilliseconds >= delay) {
				timer = now;
				Particle particle = new Particle(texture, position, velocity, timeToLive);
				particles.Add(particle);
			}
		}

		public void Emit(int delay, Texture2D texture, Vector2 position, Vector2 velocity, float timeToLive,
			Color color, float speed, float speedDelta, float angle, float angleDelta,
			float scale, float scaleDelta, float opacity, float opacityDelta, float layer)
		{
			DateTime now = DateTime.Now;
			if ((now - timer).TotalMilliseconds >= delay) {
				timer = now;
				Particle particle = new Particle(texture, position, velocity, timeToLive, color, speed, 
					speedDelta, angle, angleDelta, scale, scaleDelta, opacity, opacityDelta, layer);
				particles.Add(particle);
			}
		}

		public void Update(GameTime gameTime)
		{
			for (int i = particles.Count - 1; i >= 0; i--) {
				particles[i].Update(gameTime);
				if (particles[i].ShouldBeRemoved)
					particles.Remove(particles[i]);
			}
		}

		public void Render(SpriteBatch spriteBatch)
		{
			for (int i = particles.Count - 1; i >= 0; i--) {
				particles[i].Render(spriteBatch);
			}
		}
	}
}
