using LXF_Framework;
using UnityEngine;

public class AudioManager : LXF_AudioKit
{
    [SerializeField]
    AudioClip move;

    [SerializeField]
    AudioClip jump;

    [SerializeField]
    AudioClip die;

    [SerializeField]
    AudioClip shoot;

    [SerializeField]
    AudioClip enemyDie;

    [SerializeField]
    AudioClip enemyHit;

    [SerializeField]
    AudioClip enemyAttack;

    [SerializeField]
    AudioClip enemySpawn;

    [SerializeField]
    AudioClip enemyHurt;

    [SerializeField]
    AudioClip enemyDeath;

    [SerializeField]
    AudioClip bossAlert;

    [SerializeField]
    AudioClip bossHurt;

    [SerializeField]
    AudioClip bossDeath;

    [SerializeField]
    AudioClip bossSpawn;

    [SerializeField]
    AudioClip bossAttack;

    [SerializeField]
    AudioClip bossCharge;

    [SerializeField]
    AudioClip bossCharge2;

    protected override void Init()
    {
        AddAudioClip("move", move);
        AddAudioClip("jump", jump);
        AddAudioClip("die", die);
        AddAudioClip("shoot", shoot);
        AddAudioClip("enemyDie", enemyDie);
        AddAudioClip("enemyHit", enemyHit);
        AddAudioClip("enemyAttack", enemyAttack);
        AddAudioClip("enemySpawn", enemySpawn);
        AddAudioClip("enemyHurt", enemyHurt);
        AddAudioClip("enemyDeath", enemyDeath);
        AddAudioClip("bossAlert", bossAlert);
        AddAudioClip("bossHurt", bossHurt);
        AddAudioClip("bossDeath", bossDeath);
        AddAudioClip("bossSpawn", bossSpawn);
        AddAudioClip("bossAttack", bossAttack);
        AddAudioClip("bossCharge", bossCharge);
        AddAudioClip("bossCharge2", bossCharge2);
    }
}
