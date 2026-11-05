using UnityEngine;

// Generates jump and coin sounds in code (no audio files needed).
public static class SnowSfx
{
    const int Rate = 44100;
    static AudioClip jumpClip, coinClip;
    static AudioSource src;

    public static float volume = 0.6f;

    public static void Jump() { Play(ref jumpClip, MakeJump); }
    public static void Coin() { Play(ref coinClip, MakeCoin); }

    static void Play(ref AudioClip clip, System.Func<AudioClip> make)
    {
        if (clip == null) clip = make();
        if (src == null)
        {
            var go = new GameObject("SnowSfx");
            Object.DontDestroyOnLoad(go);
            src = go.AddComponent<AudioSource>();
            src.playOnAwake = false;
            src.spatialBlend = 0f;
        }
        src.PlayOneShot(clip, volume);
    }

    // Quick rising "boing" sweep
    static AudioClip MakeJump()
    {
        float len = 0.2f;
        int n = (int)(Rate * len);
        var d = new float[n];
        float phase = 0f;
        for (int i = 0; i < n; i++)
        {
            float t = i / (float)n;
            float f = 280f + 520f * t;
            phase += 2f * Mathf.PI * f / Rate;
            float env = Mathf.Pow(1f - t, 1.5f) * Mathf.Min(1f, i / 200f);
            d[i] = (Mathf.Sin(phase) * 0.8f + Mathf.Sin(phase * 2f) * 0.2f) * env * 0.6f;
        }
        var c = AudioClip.Create("SnowJump", n, 1, Rate, false);
        c.SetData(d, 0);
        return c;
    }

    // Classic two-note coin "ding"
    static AudioClip MakeCoin()
    {
        float len = 0.35f, split = 0.09f;
        int n = (int)(Rate * len), sn = (int)(Rate * split);
        var d = new float[n];
        float phase = 0f;
        for (int i = 0; i < n; i++)
        {
            float f = i < sn ? 987.8f : 1318.5f;
            phase += 2f * Mathf.PI * f / Rate;
            float t = i < sn ? i / (float)sn : (i - sn) / (float)(n - sn);
            float env = (i < sn ? 1f : Mathf.Exp(-5f * t)) * Mathf.Min(1f, i / 100f);
            float sq = Mathf.Sign(Mathf.Sin(phase)) * 0.35f + Mathf.Sin(phase) * 0.65f;
            d[i] = sq * env * 0.45f;
        }
        var c = AudioClip.Create("SnowCoin", n, 1, Rate, false);
        c.SetData(d, 0);
        return c;
    }
}
