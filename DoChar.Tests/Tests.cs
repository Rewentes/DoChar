using System;
using System.Text;
using System.Collections.Generic;
using NUnit.Framework;

namespace DoChar.Tests
{
    [TestFixture]
    public class DoCharTests
    {
        [Test]
        public void isRusChar_RusChar_TrueReturned()
        {
            String str0 = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";
            String str1 = "йцукенгшщзхъфывапролджэячсмитьбюё";
            bool exp = true;
            DoChar dt = new DoChar();
            foreach (var ch in str0)
            {
                bool act = dt.isRusChar(ch);
                Assert.AreEqual(exp, act);
            }

            foreach (var ch in str1)
            {
                bool act = dt.isRusChar(ch);
                Assert.AreEqual(exp, act);
            }

        }

        public void isEngChar_EngChar_TrueReturned()
        {
            String str0 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            String str1 = "qwertyuiopasdfghjklzxcvbnm";
            bool exp = true;
            DoChar dt = new DoChar();
            foreach (var ch in str0)
            {
                bool act = dt.isEngChar(ch);
                Assert.AreEqual(exp, act);
            }

            foreach (var ch in str1)
            {
                bool act = dt.isEngChar(ch);
                Assert.AreEqual(exp, act);
            }
        }

        public void isNumChar_NumChar_TrueReturned()
        {
            String str = "1234567890";
            bool exp = true;
            DoChar dt = new DoChar();
            foreach (var ch in str0)
            {
                boll act = dt. isNumChar(ch);
                Assert.AreEqual(exp, act);
            }
        }
        
        public void toLow_bCharEng_sCharEngReturned()
        {
            String str0 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            String exp = "qwertyuiopasdfghjklzxcvbnm";
            DoChar dt = new DoChar();
            foreach (var ch in str0)
            {
                String act = dt.toLow("Да", ch);
                Assert.AreEqual(exp, act);
            }
        }
        
        public void toLow_bCharRus_sCharRusReturned()
        {
            String str0 = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ";
            String exp = "йцукенгшщзхъфывапролджэячсмитьбюё";
            DoChar dt = new DoChar();
            foreach (var ch in str0)
            {
                String act = dt.toLow("Да", ch);
                Assert.AreEqual(exp, act);
            }
        }
        
        public void isBlackListChar_Ch_FalseReturned()
        {
            HashSet<char> blackList = new HashSet<char>(); blackList.Add('0');
            bool exp = false;
            DoChar dt = new DoChar();
            String act = dt.isBlackListChar('0', blackList);
            Assert.AreEqual(exp, act);
        }
        
        public void isWhiteListChar_Ch_TrueReturned()
        {
            HashSet<char> blackList = new HashSet<char>(); blackList.Add('0');
            bool exp = true;
            DoChar dt = new DoChar();
            String act = dt.isBlackListChar('0', blackList);
            Assert.AreEqual(exp, act);
        }
        
        public void Logic_string_clearStringReturned()
        {
            HashSet<char> blackList = new HashSet<char>();  
            HashSet<char> whiteList = new HashSet<char>();
            whiteList.Add('@');
            blackList.Add('0');
            String str = "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮЁ QWERTYUIOPASDFGHJKLZXCVBNM 1234567890 ~!@#$%^&*()_+}|{:>?}";
            String exp = "йцукенгшщзхъфывапролджэячсмитьбюё qwertyuiopasdfghjklzxcvbnm 123456789 @";
            DoChar dt = new DoChar();
            String act = dt.Logic(str, "", "Да", blackList, whiteList);
            Assert.AreEqual(exp, act);
            
        }
    }
}