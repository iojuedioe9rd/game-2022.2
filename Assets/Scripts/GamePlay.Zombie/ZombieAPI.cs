using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay.Zombie
{
    public class ZombieAPI : ZombieAPIHelpers
    {
        public GameObject DefaultZombie;

        private void Awake()
        {
            if(instance != null)
            {
                Destroy(instance.gameObject);
            }
            instance = this;
            DontDestroyOnLoad(gameObject);

        }

        static Dictionary<int, List<Dictionary<string, ZombieBase>>> waves;
        static List<string> waveNames;
        public int waveIndex = -1;

        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public bool AddZombie(int waveIndex, string name, ZombieBase zombie)
        {
            try
            {
                if (waveIndex > this.waveIndex)
                {
                    this.waveIndex = waveIndex;

                    waveNames.Add(name);

                    //waves.Add(waveIndex, )

                    List<Dictionary<string, ZombieBase>> v;

                    if (waves.TryGetValue(waveIndex, out v))
                    {
                        Dictionary<string, ZombieBase> d = new Dictionary<string, ZombieBase>();
                        d.Add(name, zombie);
                        v.Add(d);
                    }else
                    {
                        v = new List<Dictionary<string, ZombieBase>>();
                        Dictionary<string, ZombieBase> d = new Dictionary<string, ZombieBase>();
                        d.Add(name, zombie);
                        v.Add(d);
                    }

                    waves.Add(waveIndex, v);

                }
                return true;
                
            }catch
            {
                return false;
            }
        }

        public IEnumerator SpawnWaves()
        {
            yield return new WaitForSecondsRealtime(0.1f);
            for (int i = 0; i < waveIndex; i++)
                {
                    List<Dictionary<string, ZombieBase>> v;
                    if ( waves.TryGetValue(i, out v))
                    {
                        for (int j = 0; j < v.Count; j++)
                        {
                            var Dictionary = v[j];
                            string waveName = waveNames[i];

                            ZombieBase zombie;
                            if (Dictionary.TryGetValue(waveName, out zombie))
                            {
                            
                                GameObject obj = Instantiate(DefaultZombie);

                                obj.name = waveName;

                                Zombie zombie1 = obj.GetComponent<Zombie>();
                                zombie.Setup(zombie1, 
                                    out obj.GetComponent<Zombie>().health, 
                                    out obj.GetComponent<Zombie>().speed, 
                                    out obj.GetComponent<Zombie>().tintColor);
                                obj.GetComponent<Zombie>().speed = zombie1.speed;
                                obj.GetComponent<Zombie>().Name = zombie1.name;
                                obj.GetComponent<Zombie>().tintColor = zombie1.tintColor;
                                obj.GetComponent<Zombie>().health = zombie1.health;
                            }
                        }
                    }
                    
                }
            yield return new WaitForSecondsRealtime(5f);
            StartCoroutine(SpawnWaves());
        }
        }
    }

