using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class textControl : MonoBehaviour {

    List<string> question = new List<string>() { "Hold The Keyboard Down", "Press Light Blue", "Press Dark Blue", "Press Purple", "Press Pink", "Press Red", "Press Orange", "Press Yellow", "Press Light Green", "Press Dark Green", "Press Grey", "Press Black", "Task Complete! Please take off your Headset"};

    List<string> correctAnswer = new List<string>() {"Kb", "LB", "DB", "Pu", "Pi", "R", "O", "Y", "LG", "DG", "G", "Bl" };

    List<string> correctSubList = new List<string>();

    List<int> availableQuestions = new List<int>();

    public static string selectedAnswer;

    public static string choiceSelected = "n";

    public static float timeTaken = 0;

    public static int randQuestion = 0;

    public static float timeLeft = 120.0f;

    public static string sceneName;

    public static ContactPoint contact;

    public static string fileName;

    public static string eval;

    public static string testTime = System.DateTime.Now.ToString("dd_MM_yyyy_H-mm");

    public static string buttonSize;

    public static string localSpaceCollisionPoint;

    public Dictionary<int, int> useChecker = new Dictionary<int, int>();


	// Use this for initialization
    // creates the file, sets the time limit if it is the trial test
	void Start () {

        //GetComponent<TextMesh>().text = question[0];
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        Debug.Log(sceneName);

        fileName = sceneName + "_" + testTime + ".csv";
        string filePath = getPath();
        // Directory.CreateDirectory(filePath + fileName);
        StreamWriter writer = new StreamWriter(filePath);
        writer.WriteLine("Time,Test,Correct?,TimeTaken,ChosenAnswer,CorrectAnswer,Finger,WX,WY,WZ,ButSizeX,ButSizeY,ButSizeZ,LX,LY,LZ");
        writer.Flush();
        writer.Close();

        if (sceneName == "test0") {
            timeLeft = 30.0f;
        }
        buildUseChecker();
        buildAvailableQuestions();

	}

	// Update is called once per frame
	void Update () {

        timeLeft -= Time.deltaTime;


        // Sorts between test finished, hold kb and which questions to ask
        if (timeLeft < 0) {
            GetComponent<TextMesh>().text = question[12];
        }
        else {
            if (randQuestion == 0) {
                GetComponent<TextMesh>().text = question[randQuestion];
            }
            System.Random rnd = new System.Random();

            if (randQuestion == -1) {
                if (sceneName == "test0") {
                    randQuestion = UnityEngine.Random.Range(1,4);
                }
                if (sceneName == "test1" || sceneName == "test4") {
                    int availableQIndex = rnd.Next(availableQuestions.Count);
                    randQuestion = availableQuestions[availableQIndex];

                }
                if (sceneName == "test2") {
                    int availableQIndex = rnd.Next(availableQuestions.Count);
                    randQuestion = availableQuestions[availableQIndex];

                }
                if (sceneName == "test3") {
                    int availableQIndex = rnd.Next(availableQuestions.Count);
                    randQuestion = availableQuestions[availableQIndex];

                }

            }

            // Start timer for answering the question
            if (randQuestion > -1){
                GetComponent<TextMesh>().text = question[randQuestion];
                timeTaken += Time.deltaTime;
            }

            // output the quantative data
            if (choiceSelected == "y") {

                choiceSelected = "n";
                // Debug.Log(timeLeft);

                string contactCoords = contact.point.ToString("F3");
                contactCoords = contactCoords.Substring(1, contactCoords.Length-2);


                buttonSize = buttonSize.Substring(1, buttonSize.Length-2);

                if (correctAnswer[randQuestion]==selectedAnswer) {

                    eval = testTime+","+sceneName+","+"y,"+timeTaken+","+selectedAnswer+","+correctAnswer[randQuestion]+","+contact.otherCollider.name+","+contactCoords+","+buttonSize+","+localSpaceCollisionPoint;
                    Save();
                    // Debug.Log(hit.textureCoord);

                    // find index of selectedAnswer, then decrement the value --
                    int indexOfSelected = correctAnswer.FindIndex(s => s.Equals(selectedAnswer));
                    // Debug.Log(indexOfSelected);
                    if (useChecker[indexOfSelected] != 0) {
                        useChecker[indexOfSelected] = useChecker[indexOfSelected] - 1;
                    }
                    buildAvailableQuestions();
                    timeTaken = 0;
                    textControl.randQuestion = 0;

                }else{
                    eval = testTime+","+sceneName+","+"n,"+timeTaken+","+selectedAnswer+","+correctAnswer[randQuestion]+","+contact.otherCollider.name+","+contactCoords+","+buttonSize+","+localSpaceCollisionPoint;
                    Save();

                    int indexOfSelected = correctAnswer.FindIndex(s => s.Equals(selectedAnswer));
                    // Debug.Log(indexOfSelected);
                    if (useChecker[indexOfSelected] != 0) {
                        useChecker[indexOfSelected] = useChecker[indexOfSelected] - 1;
                    }
                    // Debug.Log(indexOfSelected);
                    buildAvailableQuestions();
                    timeTaken = 0;
                    // Debug.Log(hit.textureCoord);
                    textControl.randQuestion = 0;

                }

            }

        }

	}

    // Builds the useChecker Dictionary
    void buildUseChecker() {

        if (sceneName == "test1" || sceneName == "test4"){
            correctSubList = correctAnswer.GetRange(1, 11);

            for (int i = 1; i < correctSubList.Count+1; i++ ) {
                useChecker.Add(i,2);
            }
        }
        else if (sceneName == "test2"){
            correctSubList = correctAnswer.GetRange(1, 4);
            for (int i = 1; i < correctSubList.Count+1; i++ ) {
                useChecker.Add(i,5);
            }
        }
        else if (sceneName == "test3"){
            correctSubList = correctAnswer.GetRange(1, 7);
            for (int i = 1; i < correctSubList.Count+1; i++ ) {
                useChecker.Add(i,4);

            }
        }

    }

    // Builds the availableQuestions list by using useChecker
    void buildAvailableQuestions() {
        int totalQuestions = correctSubList.Count;
        int Ototal = 0;
        availableQuestions.Clear();
        foreach (KeyValuePair<int,int> i in useChecker) {
            if (i.Value != 0) {
                availableQuestions.Add(i.Key);
            }
            else {
                Ototal++;
            }

            // Debug.Log(i.Key);
            // Debug.Log(i.Value);

        }
        Debug.Log(totalQuestions);
        Debug.Log(Ototal);

        // foreach (int q in availableQuestions) {
        //     Debug.Log(q);
        // }


        if (Ototal == totalQuestions) {
            Debug.Log("Rebuild!");
            useChecker.Clear();
            buildUseChecker();
            buildAvailableQuestions();


        }
    }



    // appends the file
    void Save(){

        string filePath = getPath();
        string filePathHard = getHardPath();
        StreamWriter writer = new StreamWriter(filePath,true);
        StreamWriter writerHard = new StreamWriter(filePathHard,true);
        writer.WriteLine(eval);
        writerHard.WriteLine(eval);
        writer.Flush();
        writerHard.Flush();
        writer.Close();
        writerHard.Close();



    }

    private string getPath () {

        return Application.dataPath + "/output/" + fileName;

    }

    private string getHardPath() {

        return Application.dataPath + "/output/allData.csv";
    }




}
