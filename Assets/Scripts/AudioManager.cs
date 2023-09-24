using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

	// 배경음
	[Header("# BGM")]
	public AudioClip bgmClip;
	public float bgmVolum;
	AudioSource bgmPlayer;
	AudioHighPassFilter bgmHighPassFilter;


	// 효과음
	[Header("# SFX")]
	public AudioClip[] sfxClips;
	public float sfxVolum;
	public int channels;	// 채널 개수
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
		// 배경음 플에이어 초기화
		GameObject bgmObject = new GameObject("BgmPlayer");
		bgmObject.transform.parent = transform;
		bgmHighPassFilter = Camera.main.GetComponent<AudioHighPassFilter>();
		// AddComponent - 컴포넌트 생성함수 AudioSource 반환
		bgmPlayer = bgmObject.AddComponent<AudioSource>();
		bgmPlayer.playOnAwake = false;
		bgmPlayer.loop = true;
		bgmPlayer.volume = bgmVolum;
		bgmPlayer.clip = bgmClip;

		// 효과음 플에이어 초기화
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

	// 효과음 재생
	public void SfxPlay(Sfx sfx)
	{
		// 채널 개수 만큼
		for (int i = 0; i < channels; i++)
		{
			int loopIndex = (i + channelIndex) % sfxPlayers.Length;

			// 해당 채널이 이용중이라면 continue
			if (sfxPlayers[loopIndex].isPlaying) { continue; }

			channelIndex = loopIndex;
			sfxPlayers[loopIndex].clip = sfxClips[(int)sfx];
			sfxPlayers[loopIndex].Play();
			break;
		}
	}

	// 배경음 재생
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
