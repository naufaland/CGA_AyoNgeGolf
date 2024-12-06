using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public Slider sliderMusic;
    public GameObject ObjectMusic;    // Referensi ke objek untuk kontrol volume
    private float MusicVolume = 1f;    // Volume musik default
    private AudioSource audioSource;   // Declare AudioSource at the class level

    private void Start()
    {
        // Mencari objek dengan tag "GameMusic"
        ObjectMusic = GameObject.FindGameObjectWithTag("GameMusic");

        // Mengecek apakah objek ditemukan
        if (ObjectMusic != null)
        {
            // Mengambil komponen AudioSource dari objek
            audioSource = ObjectMusic.GetComponent<AudioSource>();

            // Mengecek apakah AudioSource ada pada objek
            if (audioSource == null)
            {
                Debug.LogError("AudioSource component not found on GameMusic object!");
                return;  // Keluar dari fungsi Start jika AudioSource tidak ada
            }
        }
        else
        {
            // Jika objek dengan tag "GameMusic" tidak ditemukan
            Debug.LogError("GameMusic GameObject not found!");
            return;  // Keluar dari fungsi Start jika objek tidak ditemukan
        }

        // Memuat volume musik dari PlayerPrefs, jika tidak ada, gunakan volume default
        MusicVolume = PlayerPrefs.GetFloat("MusicVolume", MusicVolume);

        // Menetapkan volume audio source dan slider sesuai dengan nilai yang diambil
        audioSource.volume = MusicVolume;
        sliderMusic.value = MusicVolume;
    }

    private void Update()
    {
        // Memastikan AudioSource sudah ada dan memperbarui volume sesuai dengan nilai slider
        if (audioSource != null)
        {
            audioSource.volume = sliderMusic.value;
            PlayerPrefs.SetFloat("MusicVolume", sliderMusic.value);
        }
    }

    public void VolumeUpdater(float volume)
    {
        // Memperbarui volume berdasarkan nilai yang diterima
        MusicVolume = volume;
    }

    public void MusicReset()
    {
        // Menghapus volume dari PlayerPrefs dan mengatur ulang volume slider
        PlayerPrefs.DeleteKey("MusicVolume");
        MusicVolume = 1f;
        sliderMusic.value = MusicVolume;
    }
}
