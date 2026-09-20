List<Qualification> qualifications = new List<Qualification>();

qualifications.Add(new Qualification
{
    Name = "AWS CLF",
    Category = "AWS",
    StudyHours = 20,
    Accuracy = 72.4
});

qualifications.Add(new Qualification
{
    Name = "JP1認定エンジニア",
    Category = "JP1",
    StudyHours = 30,
    Accuracy = 70.0
});

qualifications.Add(new Qualification
{
    Name = "Java Silver 11",
    Category = "Java",
    StudyHours = 50,
    Accuracy = 83.0
});


bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== StudyManager =====");
    Console.WriteLine("1. 資格一覧");
    Console.WriteLine("2. 資格登録");
    Console.WriteLine("3. 資格検索");
    Console.WriteLine("4. 資格削除");
    Console.WriteLine("5. 終了");
    Console.Write("番号を入力してください：");

    string input = Console.ReadLine()!;

    switch (input)
    {
        case "1":
            ShowQualifications(qualifications);
            break;

        case "2":
            Console.WriteLine("資格登録はまだ実装されていません。");
            break;

        case "3":
            Console.WriteLine("資格検索はまだ実装されていません。");
            break;

        case "4":
            Console.WriteLine("資格削除はまだ実装されていません。");
            break;

        case "5":
            Console.WriteLine("アプリを終了します。");
            isRunning = false;
            break;

        default:
            Console.WriteLine("無効な番号です。");
            break;
    }
}


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