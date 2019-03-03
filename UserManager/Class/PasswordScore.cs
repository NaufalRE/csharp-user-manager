using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager.Class
{
    class PasswordScore
    {
        //これはパスワードのスコア
        //public enum PasswordScoreResult
        //{
        //    Blank = 0,
        //    VeryWeak = 1,
        //    Weak = 2,
        //    Medium = 3,
        //    Strong = 4,
        //    VeryStrong = 5
        //}

        public static int CheckStrength(string password)
        {
            int score = 0;

            if (password.Length < 4)
                return score;
            if (password.Length >= 8)
                score += 20;
            if (password.Length >= 12)
                score += 20;
            if (password.Length >= 15)
                score += 20;
            if (Regex.Match(password, @"[A-Z]", RegexOptions.ECMAScript).Success)
                score += 20;
            if (Regex.Match(password, @"[\W]", RegexOptions.ECMAScript).Success)
                score += 20;
            if (score == 100)
                return score;
            return score;
        }
    }
}
