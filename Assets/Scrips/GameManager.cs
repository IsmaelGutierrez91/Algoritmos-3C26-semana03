using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]CustomDoublyLinkedList CharacterList;
    List<Character> listCharacter = new List<Character>();
    private void Start()
    {
        listCharacter.Add(new Character("a", 14f));
        listCharacter.Add(new Character("b", 13f));
        listCharacter.Add(new Character("c", 12f));
        listCharacter.Add(new Character("d", 11f));
        listCharacter.Add(new Character("e", 10f));
        SortBySpeed();
        for (int i = 0; i < listCharacter.Count; i++)
        {
            CharacterList.Add(listCharacter[i]);
        }

        CharacterList.ReadAll();
    }
    public void SortBySpeed()
    {
        for (int i = 0; i < listCharacter.Count; i++)
        {
            for (int j = i + 1; j < listCharacter.Count; j++)
            {
                Character newCharacter = listCharacter[i];
                listCharacter[i] = listCharacter[j];
                listCharacter[j] = newCharacter;
            }
        }
    }
}
