using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarQuiz
{
    class Questions
    {
        public string[] questions = new string[5];
        string[] answers = new string[5];

        public void FillArraysWithQuestionsAndAnswers()
        {
            questions[0] = "Hur många effektiviserade fabriker har Binar hjälpt?";
            answers[0] = "600";
            
            questions[1] = "Hur många arbetsstationer finns det med BPS?";
            answers[1] = "1000";

            questions[2] = "Hur många utvecklingsprojekt?";
            answers[2] = "5000";

            questions[3] = "Hur många konstruerade kretskort har Binar gjort?";
            answers[3] = "1000";

            questions[4] = "Hur många uppätna knäckebröd?";
            answers[4] = "80000";
        }

        public string GetAnswer(int i)
        {
            return answers[i];
        }

        public string GetQuestion(int i)
        {
            return questions[i];
        }

        
    }

    
}
