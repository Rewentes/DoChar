﻿using System;
using System.Collections.Generic;
using System.Text;


class Program
{
    static bool isRusChar(char Ch)
    {
        if (!((int)Ch >= 1040 && (int)Ch <= 1105 || (int)Ch == 1025))
        {
          return true;
        }
      return false;
    }

    static bool isEngChar(char Ch)
    {
      if (!((int)Ch >= 65 && (int)Ch <= 90 || (int)Ch >= 97 && (int)Ch <= 122))
      {
        return true;
      }
      return false;
    }

    static bool isNumChar(char Ch)
    {
      if (!((int)Ch >= 48 && (int)Ch <= 57))
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

    static void Elems(string symbol, bool rus, bool eng, bool num)
    {
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
    }

    static string toLow(string low, string Str)
    {
        if (low == "Да") return Str.ToLower();
        if (low == "Нет") return Str;

        return "0";
    }

    static string Logic(string str) 
    {
      foreach(char c in str) {
      
        bool rus = true;
        bool eng = true;
        bool num = true;
      
        StringBuilder sb = new StringBuilder();
        
        if (rus && isRusChar(c)) {
          sb.Append(c);
            continue;
        }
      
      
        if (eng && isEngChar(c)) {
          sb.Append(c);
            continue;
        }
      
        if (num && isNumChar(c)) {
          sb.Append(c);
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
        string Str = Console.ReadLine();
        Console.WriteLine(Logic(Str));
    }
}