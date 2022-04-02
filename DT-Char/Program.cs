using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static bool isRusChar(char Ch)
    {
        if ((int)Ch >= 1040 && (int)Ch <= 1105 || (int)Ch == 1025)
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
            ((int)Ch >= 1040 && (int)Ch <= 1105 || (int)Ch == 1025) || Ch == ' ')
      {
        return true;
      }
    return false;
    }

    static bool isBlackListChar(char Ch, HashSet<String> blackList)
    {
      foreach (var item in blackList) 
      {
        foreach (var chr in item) 
        {
          if (Ch == chr) return true;
        }
      }
    return false;
    }

    static char toLow(string low, char Ch)
    {
      if ((low == "Да") && ((int)Ch >= 65 && (int)Ch <= 90) || ((int)Ch >= 1040 && (int)Ch <= 1071)) 
      {
        return (char) ((int) Ch + 32);
      }
      else if (low == "Нет") return Ch;
      
      return '0';
    }

    static string Logic(string str, string symbol, string low) 
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
        
        if (rus && isRusChar(c)) {
          sb.Append(toLow(low, c));
            continue;
        }
        
        if (eng && isEngChar(c)) {
          sb.Append(toLow(low, c));
            continue;
        }
        
        if (num && isNumChar(c)) {
          sb.Append(toLow(low, c));
            continue;
        }
      } 
      return sb.ToString();
    }

    static void Main()
    {
      HashSet<String> whiteList = new HashSet<String>();
      HashSet<String> blackList = new HashSet<String>();
      String symbol, low, black;
    
      Console.WriteLine("Какие символы оставить?: (Русский, Английский, Цифры)");
      symbol = Console.ReadLine();
    
      Console.WriteLine("Добавить символ\\слово(а) в BlackList?: Да\\Нет");
      black = Console.ReadLine();

      if (black == "Да") {
        Console.WriteLine("Введите символ\\слово(а):");
        foreach(var elem in Console.ReadLine().Split(' ', ','))
          blackList.Add(elem); 
      }
      
      Console.WriteLine("Перевести в нижний регистр?: Да\\Нет");
      low = Console.ReadLine();

      Console.WriteLine("Введите строку:");
      String str = Console.ReadLine();
      Console.WriteLine(Logic(str, symbol, low));
    }
}