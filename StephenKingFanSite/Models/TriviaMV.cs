using Microsoft.EntityFrameworkCore;
using System;

namespace StephenKingFanSite.Models
{
    [Keyless]
    public class TriviaMV
    {
        //maybe remove "userAnswer" and can iterate?//
        public String UserAnswer1 { get; set; }
        public String RightOrWrong1 { get; set; }
        public String UserAnswer2 { get; set; }
        public String RightOrWrong2 { get; set; }
        public String UserAnswer3 { get; set; }
        public String RightOrWrong3 { get; set; }
        public String UserAnswer4 { get; set; }
        public String RightOrWrong4 { get; set; }
        public String UserAnswer5 { get; set; }
        public String RightOrWrong5 { get; set; }
        public String UserAnswer6 { get; set; }
        public String RightOrWrong6 { get; set; }
        public String UserAnswer7 { get; set; }
        public String RightOrWrong7 { get; set; }
        public String UserAnswer8 { get; set; }
        public String RightOrWrong8 { get; set; }
        public String UserAnswer9 { get; set; }
        public String RightOrWrong9 { get; set; }
        public String UserAnswer10 { get; set; }
        public String RightOrWrong10 { get; set; }
        /*public String UserAnswer11 { get; set; }
        public String RightOrWrong11 { get; set; }
        public String UserAnswer12 { get; set; }
        public String RightOrWrong12 { get; set; }
        public String UserAnswer13 { get; set; }
        public String RightOrWrong13 { get; set; }
        public String UserAnswer14 { get; set; }
        public String RightOrWrong14 { get; set; }
        public String UserAnswer15 { get; set; }
        public String RightOrWrong15 { get; set; }
        public String UserAnswer16 { get; set; }
        public String RightOrWrong16 { get; set; }
        public String UserAnswer17 { get; set; }
        public String RightOrWrong17 { get; set; }
        public String UserAnswer18 { get; set; }
        public String RightOrWrong18 { get; set; }
        public String UserAnswer19 { get; set; }
        public String RightOrWrong19 { get; set; }
        public String UserAnswer20 { get; set; }
        public String RightOrWrong20 { get; set; }
        public String UserAnswer21 { get; set; }
        public String RightOrWrong21 { get; set; }
        public String UserAnswer22 { get; set; }
        public String RightOrWrong22 { get; set; }
        public String UserAnswer23 { get; set; }
        public String RightOrWrong23 { get; set; }
        public String UserAnswer24 { get; set; }
        public String RightOrWrong24 { get; set; }
        public String UserAnswer25 { get; set; }
        public String RightOrWrong25 { get; set; }
        public String UserAnswer26 { get; set; }
        public String RightOrWrong26 { get; set; }
        public String UserAnswer27 { get; set; }
        public String RightOrWrong27 { get; set; }
        public String UserAnswer28 { get; set; }
        public String RightOrWrong28 { get; set; }
        public String UserAnswer29 { get; set; }
        public String RightOrWrong29 { get; set; }
        public String UserAnswer30 { get; set; }
        public String RightOrWrong30 { get; set; }
        public String UserAnswer31 { get; set; }
        public String RightOrWrong31 { get; set; }
        public String UserAnswer32 { get; set; }
        public String RightOrWrong32 { get; set; }
        public String UserAnswer33 { get; set; }
        public String RightOrWrong33 { get; set; }
        public String UserAnswer34 { get; set; }
        public String RightOrWrong34 { get; set; }
        public String UserAnswer35 { get; set; }
        public String RightOrWrong35 { get; set; }
        public String UserAnswer36 { get; set; }
        public String RightOrWrong36 { get; set; }
        public String UserAnswer37 { get; set; }
        public String RightOrWrong37 { get; set; }
        public String UserAnswer38 { get; set; }
        public String RightOrWrong38 { get; set; }
        public String UserAnswer39 { get; set; }
        public String RightOrWrong39 { get; set; }
        public String UserAnswer40 { get; set; }
        public String RightOrWrong40 { get; set; }
        public String UserAnswer41 { get; set; }
        public String RightOrWrong41 { get; set; }
        public String UserAnswer42 { get; set; }
        public String RightOrWrong42 { get; set; }
        public String UserAnswer43 { get; set; }
        public String RightOrWrong43 { get; set; }
        public String UserAnswer44 { get; set; }
        public String RightOrWrong44 { get; set; }
        public String UserAnswer45 { get; set; }
        public String RightOrWrong45 { get; set; }
        public String UserAnswer46 { get; set; }
        public String RightOrWrong46 { get; set; }
        public String UserAnswer47 { get; set; }
        public String RightOrWrong47 { get; set; }
        public String UserAnswer48 { get; set; }
        public String RightOrWrong48 { get; set; }
        public String UserAnswer49 { get; set; }
        public String RightOrWrong49 { get; set; }
        public String UserAnswer50 { get; set; }
        public String RightOrWrong50 { get; set; }*/

        public void CheckAnswers()
        {
            RightOrWrong1 = UserAnswer1 == "1947" ? "Correct" : "Wrong he was born in 1947";
            RightOrWrong2 = UserAnswer2 == "Carrie" ? "Correct" : "Wrong his first book was Carrie";
            RightOrWrong3 = UserAnswer3 == "86" ? "Correct" : "Wrong King has written 86 books";
            RightOrWrong4 = UserAnswer4 == "200" ? "Correct" : "Wrong King has writen at least 200 short stories";
            RightOrWrong5 = UserAnswer5 == "Richard Bachman" ? "Correct" : "Wrong King used the pen name Richard Bachman";
            RightOrWrong6 = UserAnswer6 == "34" ? "Correct" : "Wrong 34 of his books have been adaoted into movies";
            RightOrWrong7 = UserAnswer7 == "Maine" ? "Correct" : "Wrong he was horn in Maine";
            RightOrWrong8 = UserAnswer8 == "Cheesecake" ? "Correct" : "Wrong Mr. King's favorite food is cheesecake";
            RightOrWrong9 = UserAnswer9 == "True" ? "Correct" : "Wrong King does in fact own 3 radio stations";
            RightOrWrong10 = UserAnswer10 == "Tabitha" ? "Correct" : "Wrong his wife's name is Tabitha";
            /*RightOrWrong11 = UserAnswer11 == "3" ? "Correct" : "Wrong";
            RightOrWrong12 = UserAnswer12 == "300000000" ? "Correct" : "Wrong";
            RightOrWrong13 = UserAnswer13 == "1971" ? "Correct" : "Wrong";
            RightOrWrong14 = UserAnswer14 == "False" ? "Correct" : "Wrong";
            RightOrWrong15 = UserAnswer15 == "823" ? "Correct" : "Wrong";
            RightOrWrong16 = UserAnswer16 == "The Shining" ? "Correct" : "Wrong";
            RightOrWrong17 = UserAnswer17 == "True" ? "Correct" : "Wrong";
            RightOrWrong18 = UserAnswer18 == "1975" ? "Correct" : "Wrong";
            RightOrWrong19 = UserAnswer19 == "True" ? "Correct" : "Wrong";
            RightOrWrong20 = UserAnswer20 == "False" ? "Correct" : "Wrong";
            RightOrWrong21 = UserAnswer21 == "False" ? "Correct" : "Wrong";
            RightOrWrong22 = UserAnswer22 == "True" ? "Correct" : "Wrong";
            RightOrWrong23 = UserAnswer23 == "Peter Straub" ? "Correct" : "Wrong";
            RightOrWrong24 = UserAnswer24 == "True" ? "Correct" : "Wrong";
            RightOrWrong25 = UserAnswer25 == "2015" ? "Correct" : "Wrong";
            RightOrWrong26 = UserAnswer26 == "False" ? "Correct" : "Wrong";
            RightOrWrong27 = UserAnswer27 == "False" ? "Correct" : "Wrong";
            RightOrWrong28 = UserAnswer28 == "True" ? "Correct" : "Wrong";
            RightOrWrong14 = UserAnswer29 == "True" ? "Correct" : "Wrong";
            RightOrWrong20 = UserAnswer30 == "True" ? "Correct" : "Wrong";
            RightOrWrong31 = UserAnswer31 == "True" ? "Correct" : "Wrong";
            RightOrWrong32 = UserAnswer32 == "The Three Billy Goats Gruff" ? "Correct" : "Wrong";
            RightOrWrong33 = UserAnswer33 == "True" ? "Correct" : "Wrong";
            RightOrWrong34 = UserAnswer34 == "Red Sox" ? "Correct" : "Wrong";
            RightOrWrong35 = UserAnswer35 == "2" ? "Correct" : "Wrong";
            RightOrWrong36 = UserAnswer36 == "Time" ? "Correct" : "Wrong";
            RightOrWrong37 = UserAnswer37 == "1983" ? "Correct" : "Wrong";
            RightOrWrong38 = UserAnswer38 == "The Stanley Hotel" ? "Correct" : "Wrong";
            RightOrWrong39 = UserAnswer39 == "The Overlook Hotel" ? "Correct" : "Wrong";
            RightOrWrong40 = UserAnswer40 == "Mike Flanagan" ? "Correct" : "Wrong";
            RightOrWrong41 = UserAnswer41 == "False" ? "Correct" : "Wrong";
            RightOrWrong42 = UserAnswer42 == "False" ? "Correct" : "Wrong";
            RightOrWrong43 = UserAnswer43 == "True" ? "Correct" : "Wrong";
            RightOrWrong44 = UserAnswer44 == "8" ? "Correct" : "Wrong";
            RightOrWrong45 = UserAnswer45 == "Michael Gornick" ? "Correct" : "Wrong";
            RightOrWrong46 = UserAnswer46 == "1993" ? "Correct" : "Wrong";
            RightOrWrong47 = UserAnswer47 == "Maine" ? "Correct" : "Wrong";
            RightOrWrong48 = UserAnswer48 == "True" ? "Correct" : "Wrong";
            RightOrWrong49 = UserAnswer49 == "3" ? "Correct" : "Wrong";
            RightOrWrong50 = UserAnswer50 == "False" ? "Correct" : "Wrong";*/
        }
    }
}
