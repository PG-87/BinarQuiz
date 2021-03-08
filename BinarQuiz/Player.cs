using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarQuiz
{
    class Player
    {
        string name;
        int score = 0;

        public void setPlayerName(String pname)
        {
            name = pname;
        }
        public String getPlayerName()
        {
            return name;
        }


        public void setPlayerScore(int pscore)
        {
            score += pscore;
        }
        public int getPlayerScore()
        {
            return score;
        }
    }
}
