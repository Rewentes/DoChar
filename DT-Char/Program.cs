using System;
using System.Collections.Generic;
using System.Text;

class Program
{
  static bool isRusChar(char Ch)
    {
        if ((int)Ch >= 1040 && (int)Ch <= 1105 || (int)Ch == 1025 || (int)Ch ==1105)
        {
          return true;
        }
      return false;
    }

    static bool isEngChar(char Ch)
    {
      if ((int)Ch >= 65 && (int)Ch <= 90 || (int)Ch >= 97 && (int)Ch <= 122)
      {
        return true;
      }
      return false;
    }

    static bool isNumChar(char Ch)
    {
      if ((int)Ch >= 48 && (int)Ch <= 57)
      {
        return true;
      }
    return false;
    }
  
    static bool isAllChar(char Ch)
    {
      if (((int)Ch >= 48 && (int)Ch <= 57) ||
            ((int)Ch >= 65 && (int)Ch <= 90 || (int)Ch >= 97 && (int)Ch <= 122) ||
            ((int)Ch >= 1040 && (int)Ch <= 1105 || (int)Ch == 1025 || (int)Ch == 1105))
      {
        return true;
      }
    return false;
    }

    static HashSet<char> addBlackList(string Str, HashSet<char> blackList)
    {
      foreach (var c in Str.Split("", ','))
      {
        blackList.Add(Convert.ToChar(c)); 
      }
      return blackList;
    }
    static bool isBlackListChar(char Ch, HashSet<char> blackList)
    {
      foreach (var c in blackList) 
      {
        if (Ch == c) return false;
      }
      return true;
    }
    
    static HashSet<char> addWhiteList(string Str, HashSet<char> whiteList)
    {
      foreach (var c in Str.Split("", ','))
      {
        whiteList.Add(Convert.ToChar(c)); 
      }
      return whiteList;
    }
    static bool isWhiteListChar(char Ch, HashSet<char> whiteList)
    {
      foreach (var c in whiteList) 
      {
        if (Ch == c) return true;
      }
      return false;
    }

    static char toLow(string low, char Ch)
    {
      
      if (low == "Да") 
      {
        if (((int)Ch >= 65 && (int)Ch <= 90) || ((int)Ch >= 1040 && (int)Ch <= 1071)) 
        {
          return (char) ((int) Ch + 32);
        }

        if ((int) Ch == 1025)
        {
          return (char) ((int) Ch + 80);
        }
        else return Ch;
      }
      
      else if (low == "Нет") return Ch;
      
      return '0';
    }

    static string Logic(string str, string symbol, string low, HashSet<char> blackList, HashSet<char> whiteList) 
    {
      
      bool rus = true;
      bool eng = true;
      bool num = true;
      
      if (symbol == "Русский") {
        rus = true;
        eng = false;
        num = false;
      }
      if (symbol == "Английский") {
        rus = false;
        eng = true;
        num = false; 
      }
      if (symbol == "Цифры") {
        rus = false;
        eng = false;
        num = true;     
      }

      StringBuilder sb = new StringBuilder();
      
      foreach(char c in str) {
        
        if (isWhiteListChar(c, whiteList) || (rus && isRusChar(c) && isBlackListChar(c, blackList))) 
        {
          sb.Append(toLow(low, c));
            continue;
        }
        
        if (isWhiteListChar(c, whiteList) || (eng && isEngChar(c) && isBlackListChar(c, blackList))) 
        {
          sb.Append(toLow(low, c));
            continue;
        }
        
        if (isWhiteListChar(c, whiteList) || (num && isNumChar(c) && isBlackListChar(c, blackList))) 
        {
          sb.Append(toLow(low, c));
            continue;
        }
      } 
      return sb.ToString();
    }

    static void Main()
    {
      String str, symbol, low, black, white;
      HashSet<char> blackList = new HashSet<char>(); 
      HashSet<char> whiteList = new HashSet<char>(); whiteList.Add(' ');
    
      Console.WriteLine("Какие символы оставить?: (Русский, Английский, Цифры, Все[Enter для выбора])");
      symbol = Console.ReadLine();
    
      Console.WriteLine("Добавить символ\\слово(а) в whiteList?: Да\\Нет");
      white = Console.ReadLine();
      Console.WriteLine("Добавить символ\\слово(а) в BlackList?: Да\\Нет");
      black = Console.ReadLine();

      if (white == "Да") {
        Console.WriteLine("Введите символ\\слово(а) в whiteList:");
        whiteList = addBlackList(Console.ReadLine(), whiteList);
      }
      if (black == "Да") {
        Console.WriteLine("Введите символ\\слово(а) в BlackList:");
        blackList = addBlackList(Console.ReadLine(), blackList);
      }
      
      Console.WriteLine("Перевести в нижний регистр?: Да\\Нет");
      low = Console.ReadLine();

      Console.WriteLine("Введите строку:");
      str = Console.ReadLine();
      Console.WriteLine(Logic(str, symbol, low, blackList, whiteList));
    }
}