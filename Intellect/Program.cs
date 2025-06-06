﻿using System.Text;
using Serilog;
using Newtonsoft.Json;
using Intellect.Model;

namespace Intellect;

class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();
        
        Console.WriteLine("等待E听说下载完最新试卷后 点击任意键继续...");
        Console.ReadKey();
        
        Console.Clear();
        Log.Information("Progress started.");
        var lastExam = GetLatestExam();
        Log.Information("Last exam data directory: " + lastExam.Name);

        var fileName = DateTime.Now.ToString("yyyy-MMM-dd HH-mm-ss");
        
        File.WriteAllText($".\\{fileName}.txt", GetAnswer(lastExam));
        
        Log.Information("Data parsing completed.");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.WriteLine("数据解析完成，文件名：" + fileName + ".txt");
        Console.WriteLine("按任意键退出...");
        Console.WriteLine();
        Console.ReadKey();
    }

    private static DirectoryInfo GetLatestExam()
    {
        try
        {
            var path = $"{Environment.GetEnvironmentVariable("APPDATA")}\\74656D705F74656D705F74656D705F74002\\";
            Log.Debug("ETS exam path: " + path);
            var directoryInfo = new DirectoryInfo(path);
            var latestDirectory = directoryInfo.GetDirectories()
                .OrderByDescending(d => d.LastWriteTime).Where(d => d.Name != "common").FirstOrDefault();
            return latestDirectory;
        }
        catch (Exception e)
        {
            Log.Fatal(e.ToString());
            Log.Fatal("Get latest exam failed. Perhaps there is no any exam data?");
            Console.WriteLine("出现错误 请按任意键退出...");
            Console.ReadKey();
            Environment.Exit(int.MinValue);
        }
        return null;
    }

    private static string GetAnswer(DirectoryInfo directoryInfo)
    {
        StringBuilder sb = new StringBuilder();
        
        var dirs = directoryInfo.GetDirectories().Where(x => x.Name.Contains("content"));
        
        var jsonPaths = dirs.Select(dir => dir.FullName + "\\content2.json").ToList();
        var jsonData = new List<string>();
        foreach (var jsonPath in jsonPaths)
        {
            jsonData.Add(File.ReadAllText(jsonPath));
            Log.Information("Json data: " + jsonPath);
        }
        
        Log.Information("Exam json data read.");
        var generics = jsonData.Select(data => JsonConvert.DeserializeObject<GenericModel>(data)).ToList();
        Log.Information("Json data deserialized into objects.");
        

        for (var i = 0; i < generics.Count; i++)
        {
            switch (generics[i].structure_type)
            {
                case "collector.choose": //选择题
                    sb.AppendLine(GetCollectorChooseAnswer(jsonData[i]));
                    sb.AppendLine("===============================================================");
                    sb.AppendLine();
                    Log.Information($"Index: {i}, Question type: collector.choose, resolved.");
                    break;
                case "collector.fill":  //听力填词
                    sb.AppendLine(GetCollectorFillAnswer(jsonData[i]));
                    sb.AppendLine("===============================================================");
                    sb.AppendLine();
                    Log.Information($"Index: {i}, Question type: collector.fill, resolved.");
                    break;
                case "collector.picture":  //听后转述
                    sb.AppendLine(GetCollectorPictureAnswer(jsonData[i]));
                    sb.AppendLine("===============================================================");
                    sb.AppendLine();
                    Log.Information($"Index: {i}, Question type: collector.picture, resolved.");
                    break;
                case "collector.read":  //朗读短文
                    sb.AppendLine(GetCollectorReadAnswer(jsonData[i]));
                    sb.AppendLine("===============================================================");
                    sb.AppendLine();
                    Log.Information($"Index: {i}, Question type: collector.read, resolved.");
                    break;
                case "collector.dialogue": //朗读短文后的回答问题
                    sb.AppendLine(GetCollectorDialogueAnswer(jsonData[i]));
                    sb.AppendLine("===============================================================");
                    sb.AppendLine();
                    Log.Information($"Index: {i}, Question type: collector.dialogue, resolved.");
                    break;
            }
        }
        
        return sb.ToString();
    }

    private static string GetCollectorChooseAnswer(string json)
    {
        Log.Information(nameof(GetCollectorChooseAnswer));
        /*
         * 形式
         * ■ 选择题
         * 1. Question
         * 答案：A
         */

        var root = JsonConvert.DeserializeObject<CollectorChoose.Root>(json);
        var sb = new StringBuilder();
        sb.AppendLine("■ 选择题");
        
        foreach (var item in root.info.xtlist)
        {
            sb.AppendLine(item.xt_nr);
            sb.AppendLine($"答案: {item.answer}");
        }
        return sb.ToString();
    }

    private static string GetCollectorFillAnswer(string json)
    {
        Log.Information(nameof(GetCollectorFillAnswer));
        /*
         * 形式
         * ■ 听力填词
         * 1. a
         * 2. b
         * 3. c
         * 4. d
         */
        var root = JsonConvert.DeserializeObject<CollectorFill.Root>(json);
        var sb = new StringBuilder();
        sb.AppendLine("■ 听力填词");
        
        foreach (var item in root.info.std)
        {
            sb.AppendLine($"{item.xth}. {item.value}");
        }

        return sb.ToString();
    }
    
    private static string GetCollectorPictureAnswer(string json)
    {
        Log.Information(nameof(GetCollectorPictureAnswer));
        /*
         * 形式
         * ■ 听后转述
         * 标准答案1.
         * 标准答案2.
         * 标准答案3.
         */
        var root = JsonConvert.DeserializeObject<CollectorPicture.Root>(json);
        var sb = new StringBuilder();
        sb.AppendLine("■ 听后转述");

        var count = 0;
        foreach (var item in root.info.std)
        {
            sb.AppendLine($"标准答案{++count}: {item.value}");
        }

        return sb.ToString();
    }
    
    private static string GetCollectorReadAnswer(string json)
    {
        Log.Information(nameof(GetCollectorReadAnswer));
        return "■ 阅读短文，答案略\r\n";
    }
    
    private static string GetCollectorDialogueAnswer(string json)
    {
        Log.Information(nameof(GetCollectorDialogueAnswer));
        /*
         * 形式
         * ■ 听后回答问题
         * 1. Question
         * 标准答案1.
         * 标准答案2.
         * 标准答案3.
         * 判分要点.
         * * 2. Question
         * 标准答案1.
         * 标准答案2.
         * 标准答案3.
         * 判分要点.
         * * 3. Question
         * 标准答案1.
         * 标准答案2.
         * 标准答案3.
         * 判分要点.
         */
        var root = JsonConvert.DeserializeObject<CollectorDialogue.Root>(json);
        var sb = new StringBuilder();
        sb.AppendLine("■ 听后回答问题");


        foreach (var questionItem in root.info.question)
        {
            sb.AppendLine(questionItem.ask);
            
            for (var i = 0; i < questionItem.std.Count; i++)
            {
                if (i >= 3)
                    break;
                sb.AppendLine($"标准答案{i + 1}: {questionItem.std[i].value}");
            }

            sb.AppendLine($"判分要点: {questionItem.keywords}");
        }

        return sb.ToString();
    }
}