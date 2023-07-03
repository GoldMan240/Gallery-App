using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpriteCache
{
    private static readonly Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public static void Add(Sprite sprite) => sprites[sprite.name] = sprite;

    public static Sprite Get(string url) => sprites[url];

    public static bool HasSprite(string url) => sprites.ContainsKey(url);
}
