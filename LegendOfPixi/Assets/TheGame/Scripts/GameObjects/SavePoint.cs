using UnityEngine;

public class SavePoint : Collectible
{
    private float _lockEnd = 0f;
    private SimpleSpriteAnimator _simpleSpriteAnimator;

    public void Start()
    {
        _simpleSpriteAnimator = GetComponent<SimpleSpriteAnimator>();

        if (SaveGameDataSingleton.instance.SavePoint.Equals(gameObject.name))
        {
            SetLocked();
            FindObjectOfType<Hero>().transform.position =
                (transform.position + new Vector3(0.5f, -0.5f, 0f));
        }
    }

    public override void OnCollect()
    {
        base.OnCollect();

        if (IsLocked())
        {
            return;
        }

        SaveGameDataSingleton.instance.SavePoint = gameObject.name;
        SaveGameDataSingleton.instance.Save();
        SetLocked();
    }

    public void Update()
    {
        if (IsLocked())
        {
            _simpleSpriteAnimator.PlayDisabled = true;
        }
        else
        {
            _simpleSpriteAnimator.PlayDisabled = false;
        }
    }

    private void SetLocked()
    {
        _simpleSpriteAnimator.PlayDisabled = true;
        _lockEnd = Time.time + 10f;
    }

    private bool IsLocked()
    {
        return _lockEnd > Time.time;
    }
}
