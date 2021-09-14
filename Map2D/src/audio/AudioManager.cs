using System.Collections.Generic;
using Map2D.assets;
using Microsoft.Xna.Framework.Audio;

namespace Map2D.audio
{
	public static class AudioManager
	{
		private static Dictionary<string, SoundEffectInstance> sounds, music;
		private static float soundVolume, musicVolume;

		public static void Initialize()
		{
			sounds = new Dictionary<string, SoundEffectInstance>();
			music = new Dictionary<string, SoundEffectInstance>();

			SoundEffect.MasterVolume = 1f;
			soundVolume = 1f;
			musicVolume = 1f;
		}

		public static void SetMasterVolume(float value)
		{
			SoundEffect.MasterVolume = value;
		}

		public static float GetMasterVolume()
		{
			return SoundEffect.MasterVolume;
		}

		public static void SetSoundVolume(float value)
		{
			foreach (KeyValuePair<string, SoundEffectInstance> pair in sounds)
				pair.Value.Volume = value;
		}

		public static void SetMusicVolume(float value)
		{
			foreach (KeyValuePair<string, SoundEffectInstance> pair in music)
				pair.Value.Volume = value;
		}

		public static void PlaySound(string asset)
		{
			SoundEffectInstance instance = Assets.GetSound(asset).CreateInstance();
			sounds.Add(asset, instance);

			instance.Volume = soundVolume;
			instance.Play();
		}

		public static void PlayMusic(string asset, bool looped = false)
		{
			SoundEffectInstance instance = Assets.GetSound(asset).CreateInstance();
			sounds.Add(asset, instance);
			
			instance.IsLooped = looped;
			instance.Volume = musicVolume;
			instance.Play();
		}

		public static void Resume()
		{
			foreach (KeyValuePair<string, SoundEffectInstance> pair in sounds)
				if (pair.Value.State == SoundState.Paused)
					pair.Value.Play();

			foreach (KeyValuePair<string, SoundEffectInstance> pair in music)
				if (pair.Value.State == SoundState.Paused)
					pair.Value.Play();
		}

		public static void Pause()
		{
			foreach (KeyValuePair<string, SoundEffectInstance> pair in sounds)
				if (pair.Value.State == SoundState.Playing)
					pair.Value.Pause();

			foreach (KeyValuePair<string, SoundEffectInstance> pair in music)
				if (pair.Value.State == SoundState.Playing)
					pair.Value.Pause();
		}

		public static void Stop()
		{
			foreach (KeyValuePair<string, SoundEffectInstance> pair in sounds)
				pair.Value.Stop();

			foreach (KeyValuePair<string, SoundEffectInstance> pair in music)
				pair.Value.Stop();
		}
	}
}
