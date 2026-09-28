using System.Linq;

List<Qualification> qualifications = LoadQualificationsFromCsv();

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== StudyManager =====");
    Console.WriteLine("1. 資格一覧");
    Console.WriteLine("2. 資格登録");
    Console.WriteLine("3. 資格検索");
    Console.WriteLine("4. 資格削除");
    Console.WriteLine("5. 資格更新");
    Console.WriteLine("6. CSV出力");
    Console.WriteLine("7. 終了");
    Console.Write("番号を入力してください：");

    string input = Console.ReadLine()!;

    switch (input)
    {
        case "1":
            ShowQualifications(qualifications);
            break;

        case "2":
            AddQualification(qualifications);
            break;

        case "3":
            SearchQualifications(qualifications);
            break;

        case "4":
            DeleteQualification(qualifications);
            break;

        case "5":
            UpdateQualification(qualifications);
            break;

        case "6":
            ExportToCsv(qualifications);
            break;

        case "7":
            Console.WriteLine("アプリを終了します。");
            isRunning = false;
            break;

        default:
            Console.WriteLine("無効な番号です。");
            break;
    }
}

// 1.資格一覧
static void ShowQualifications(List<Qualification> qualifications)
{
    Console.WriteLine();
    Console.WriteLine("===== 資格一覧 =====");

    foreach (Qualification qualification in qualifications)
    {
        Console.WriteLine("資格名：" + qualification.Name);
        Console.WriteLine("分野：" + qualification.Category);
        Console.WriteLine("勉強時間：" + qualification.StudyHours + "時間");
        Console.WriteLine("正答率：" + qualification.Accuracy + "%");
        Console.WriteLine("--------------------");
    }
}

//　2.資格登録
static void AddQualification(List<Qualification> qualifications)
{
    Console.Write("資格名：");
    string name = Console.ReadLine()!;

    Console.Write("分野：");
    string category = Console.ReadLine()!;

    Console.Write("勉強時間：");
    int studyHours = int.Parse(Console.ReadLine()!);

    Console.Write("正答率：");
    double accuracy = double.Parse(Console.ReadLine()!);

    qualifications.Add(new Qualification
    {
        Name = name,
        Category = category,
        StudyHours = studyHours,
        Accuracy = accuracy
    });

    Console.WriteLine("登録完了！");
}

// 3.資格検索
static void SearchQualifications(List<Qualification> qualifications)
{
    Console.Write("検索する資格名：");
    string keyword = (Console.ReadLine()!);

    var results = qualifications.Where(q => q.Name.Contains(keyword)).ToList();

    if (results.Count == 0)
    {
        Console.WriteLine("該当する資格がありません。");
        return;
    }

    Console.WriteLine();
    Console.WriteLine("===== 検索結果 =====");

    foreach (Qualification qualification in results)
    {
        Console.WriteLine("資格名：" + qualification.Name);
        Console.WriteLine("分野：" + qualification.Category);
        Console.WriteLine("勉強時間：" + qualification.StudyHours + "時間");
        Console.WriteLine("正答率：" + qualification.Accuracy + "%");
        Console.WriteLine("--------------------");
    }
}

// 4.資格削除
static void DeleteQualification(List<Qualification> qualifications)
{
    Console.Write("削除する資格名：");
    string keyword = Console.ReadLine()!;

    var qualification = qualifications.FirstOrDefault(q => q.Name == keyword);

    if (qualification == null)
    {
        Console.WriteLine("該当する資格がありません。");
        return;
    }

    qualifications.Remove(qualification);

    Console.WriteLine(qualification.Name + " を削除しました。");
}

// 5.資格更新
static void UpdateQualification(List<Qualification> qualifications)
{
    Console.Write("更新する資格名：");
    string keyword = Console.ReadLine()!;

    var qualification = qualifications.FirstOrDefault(q => q.Name == keyword);

    if (qualification == null)
    {
        Console.WriteLine("該当する資格がありません。");
        return;
    }

    Console.Write("新しい資格名：");
    qualification.Name = Console.ReadLine()!;

    Console.Write("新しい分野：");
    qualification.Category = Console.ReadLine()!;

    Console.Write("新しい勉強時間：");
    qualification.StudyHours = int.Parse(Console.ReadLine()!);

    Console.Write("新しい正答率：");
    qualification.Accuracy = double.Parse(Console.ReadLine()!);

    Console.WriteLine("更新完了！");
}

// 6.CSV出力
static void ExportToCsv(List<Qualification> qualifications)
{
    string outputDirectory = "../createCSV";
    string fileName = $"qualifications_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
    string filePath = Path.Combine(outputDirectory, fileName);

    List<string> lines = new List<string>();

    lines.Add("Name,Category,StudyHours,Accuracy");

    foreach (Qualification qualification in qualifications)
    {
        string line = qualification.Name + ","
                    + qualification.Category + ","
                    + qualification.StudyHours + ","
                    + qualification.Accuracy;
        lines.Add(line);
    }

    File.WriteAllLines(filePath, lines);

    Console.WriteLine("CSV出力が完了しました。");
    Console.WriteLine("出力先：" + filePath);
}

// csvファイル読み込み(システム起動時の処理)
static List<Qualification> LoadQualificationsFromCsv()
{
    string outputDirectory = "../createCSV";

    List<Qualification> qualifications = new List<Qualification>();

    if (!Directory.Exists(outputDirectory))
    {
        return qualifications;
    }

    string[] csvFiles = Directory.GetFiles(
        outputDirectory,
        "qualifications_*.csv"
    );

    if (csvFiles.Length == 0)
    {
        return qualifications;
    }

    string latestFile = csvFiles
        .OrderByDescending(file => File.GetLastWriteTime(file))
        .First();

    string[] lines = File.ReadAllLines(latestFile);

    foreach (string line in lines.Skip(1))
    {
        string[] values = line.Split(',');

        Qualification qualification = new Qualification
        {
            Name = values[0],
            Category = values[1],
            StudyHours = int.Parse(values[2]),
            Accuracy = double.Parse(values[3])
        };

        qualifications.Add(qualification);
    }

    return qualifications;
}
