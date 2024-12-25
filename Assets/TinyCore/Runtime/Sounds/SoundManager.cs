using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMei;

namespace GameMei
{
    [DefaultExecutionOrder(0)]
    public class SoundManager : MonoSingle<SoundManager>
    {
        //public static SoundManager Instance;


        //music
        private AudioSource musicSource;
        private float musicVolum = 1.0f;

        //SoundEffects
        private AudioSource[] soundEffectSources;
        private float soundEffectVolume = 1.0f;

        private int index;



        protected override void Start()
        {
            //Instance = this;
            base.Awake();
            Debug.Log("soundMAnager被实例化了");

            GameObject newMusicSource = new GameObject { name = "Music Scorce" };
            musicSource = newMusicSource.AddComponent<AudioSource>();
            newMusicSource.transform.SetParent(transform);

            soundEffectSources = new AudioSource[7];
            for(int i=0;i<soundEffectSources.Length;i++)
            {
                GameObject newSoundEffectSources = new GameObject { name = $"Sound Source{i + 1}" };
                soundEffectSources[i] = newSoundEffectSources.AddComponent<AudioSource>();
                newSoundEffectSources.transform.SetParent(this.transform);
            }

            if(ResoursesManager.Instance==null)
            {
                Debug.Log("没有实例化出来");
            }
            else
            {
                Debug.Log("已经实例化出来了");
            }

            PlayMusic("Main");

            //这边有一个bug为什么这个默认可以加载，但是在别的场景通过名字加载不了


            //StartCoroutine(InitAfterDelay());
        }

/*        private IEnumerator InitAfterDelay()
        {
            yield return null;
            while(ResoursesManager.Instance==null)
            {
                yield return null;
            }
            PlayMusic("Main");

        }*/


        #region Music

        public void PlayMusic(string musicName)
        {
            ResoursesManager.Instance.LoadAsync<AudioClip>($"Music/{musicName}", clip =>
            {
                musicSource.clip = clip;
                musicSource.loop = true;
                musicSource.volume = musicVolum;
                musicSource.Play();
            });

        }

        public void PauseMusic()
        {
            musicSource.Pause();
        }
        public void StopMusic()
        {
            musicSource.Stop();
        }

        public void ChangeMusicVolume(float volume)
        {
            musicVolum = volume;
            musicSource.volume = musicVolum;
        }

        #endregion

        public void PlaySound(string sonudName,bool isLoop=false,UnityEngine.Events.UnityAction<AudioSource>callback=null)
        {
            ResoursesManager.Instance.LoadAsync<AudioClip>($"Sound/{sonudName}", clip => 
            {
                AudioSource soundSource = soundEffectSources[index];
                index++;
                index %= soundEffectSources.Length;
                soundSource.clip = clip;
                Debug.Log(soundSource.clip.name);
                soundSource.volume = musicVolum;
                soundSource.loop = isLoop;

                soundSource.Play();

                callback?.Invoke(soundSource);

                
            
            });
        }

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Debug.Log("按下了左键1");
                PlaySound("Assault Shoot");
            }
        }

    }
}
