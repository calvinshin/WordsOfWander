using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Problem
{
    public Word word;
    // Looks like this should be List<Text> or Text[] answers;
    public List<string> answers;
    System.Random random = new System.Random ();


    // Finds the correct answer regardless of the position of the word.
    public int correctAnswer()
    {
        return answers.IndexOf(word.definition);
        // return System.List.IndexOf(answers, word.definition);
    }
    
    // Confirms that the answer string has answers
    // Then shuffles the string array to randomize
    public void makeAnswersString(List<string> answerList)
    {
        List<string> tempAnswers = new List<string> (answerList);

        // If answers has no values, then populate it
        if(answers.Count == 0)
        {
            // Add the word definition
            answers.Add(word.definition);
            // Remove this from the tempAnswers Array
            tempAnswers.RemoveAt(tempAnswers.IndexOf(word.definition));

            // Add three more answers from the tempAnswers Array
            for(int i = 0; i < 3; i++)
            {
                int j = random.Next(0, tempAnswers.Count);
                answers.Add(tempAnswers[j]);
                tempAnswers.RemoveAt(j);
            }
        }

        // then shuffle the list
        Shuffle(answers);
    }

    public void Shuffle(List<string> list)
    {
        int n = list.Count;  
        string temp;

        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(random.NextDouble() * (n - i));
            temp = list[r];
            list[r] = list[i];
            list[i] = temp;
        }
        // No need for a return because C# copies a reference, not the List<> itself.
    }
}