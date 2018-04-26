using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDialogueBehavior
{
    void Talk();
}

public class CanTalk : IDialogueBehavior
{
    Character currentCharacter;

    public CanTalk(Character character)
    {
        currentCharacter = character;
    }
    public void Talk()
    {
        // Logic for talking
    }
}

public class CannotTalk : IDialogueBehavior
{
    public void Talk()
    {
        // Logic for not being able to talk
    }
}
