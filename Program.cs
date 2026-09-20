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


static void ShowQualifications(List<Qualification> qualifications)
{
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
ShowQualifications(qualifications);