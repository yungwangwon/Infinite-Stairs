using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

	// �����
	[Header("# BGM")]
	public AudioClip bgmClip;
	public float bgmVolum;
	AudioSource bgmPlayer;
	AudioHighPassFilter bgmHighPassFilter;


	// ȿ����
	[Header("# SFX")]
	public AudioClip[] sfxClips;
	public float sfxVolum;
	public int channels;	// ä�� ����
	AudioSource[] sfxPlayers;
	int channelIndex;

	public enum Sfx
	{
		Button,
		Coin,
		Dead,
		Hp,
		Walk,
	}

	private void Awake()
	{
		instance = this;
		Init();
	}


	void Init()
	{
		// ����� �ÿ��̾� �ʱ�ȭ
		GameObject bgmObject = new GameObject("BgmPlayer");
		bgmObject.transform.parent = transform;
		bgmHighPassFilter = Camera.main.GetComponent<AudioHighPassFilter>();
		// AddComponent - ������Ʈ �����Լ� AudioSource ��ȯ
		bgmPlayer = bgmObject.AddComponent<AudioSource>();
		bgmPlayer.playOnAwake = false;
		bgmPlayer.loop = true;
		bgmPlayer.volume = bgmVolum;
		bgmPlayer.clip = bgmClip;

		// ȿ���� �ÿ��̾� �ʱ�ȭ
		GameObject sfxObject = new GameObject("SfxPlayer");
		sfxObject.transform.parent = transform;
		sfxPlayers = new AudioSource[channels];

		for (int i = 0; i < channels; i++)
		{
			sfxPlayers[i] = sfxObject.AddComponent<AudioSource>();
			sfxPlayers[i].playOnAwake = false;
			sfxPlayers[i].volume = sfxVolum;
			sfxPlayers[i].bypassListenerEffects = true;

		}

	}

	// ȿ���� ���
	public void SfxPlay(Sfx sfx)
	{
		// ä�� ���� ��ŭ
		for (int i = 0; i < channels; i++)
		{
			int loopIndex = (i + channelIndex) % sfxPlayers.Length;

			// �ش� ä���� �̿����̶�� continue
			if (sfxPlayers[loopIndex].isPlaying) { continue; }

			channelIndex = loopIndex;
			sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
			sfxPlayers[loopIndex].Play();
			break;
		}
	}

	// ����� ���
	public void BgmPlay(bool isPlay)
	{
		if (isPlay)
		{
			bgmPlayer.Play();
		}
		else
		{
			bgmPlayer.Stop();
		}
	}

	public void EffectBgm(bool isPlay)
	{
		bgmHighPassFilter.enabled = isPlay;
	}
}
