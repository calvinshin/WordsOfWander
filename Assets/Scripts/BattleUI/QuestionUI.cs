using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionUI : MonoBehaviour
{
    // initialize variables
    public List<string> words;
    public List<string> answers;
    public List<Word> wordClasses;
    public List<Problem> problemList;

    System.Random random = new System.Random ();


    public void addWord(Word word)
    {
        words.Add(word.word);
        answers.Add(word.definition);
        wordClasses.Add(word);
    }

    public void addWordList(List<Word> wordList)
    {
        for(int i = 0; i < wordList.Count; i++)
        {
            addWord(wordList[i]);
        }
    }

    public void createProblems()
    {
        // Use the List<word> to create problems once all the words have been appended.
        for(int i = 0; i < wordClasses.Count; i++)
        {
            Problem newProblem = new Problem ();
            Word tempWord = wordClasses[i];
            
            newProblem.word.word = tempWord.word;
            newProblem.word.definition = tempWord.definition;
            newProblem.makeAnswersString(answers);

            problemList.Add(newProblem);
        }

        // Shuffle the problems
        Shuffle(problemList);
    }

    public void Shuffle(List<Problem> list)
    {
        int n = list.Count;  
        Problem temp;

        for (int i = 0; i < n; i++)
        {
            int r = i + (int)(random.NextDouble() * (n - i));
            temp = list[r];
            list[r] = list[i];
            list[i] = temp;
        }
        // No need for a return because C# copies a reference, not the List<> itself.
    }

    public void setProblemText(Problem problem)
    {

    }

    public static QuestionUI instance;

    void Awake ()
    {
        instance = this;
    }
}
