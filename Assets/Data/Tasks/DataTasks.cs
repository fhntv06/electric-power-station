using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static CardStruct;

[CreateAssetMenu(fileName = "Task_(type)", menuName = "Data Task")]
public class DataTasks : ScriptableObject
{
    // Task 1
    public int id = 0;
    public string title = "Îñìîòğ îãğàíè÷èòåëÿ ïåğåíàïğÿæåíèÿ";
    public string description_1 = "1. Âûïîëíèòå îáõîä òåğğèòîğèè. \n2. Âûïîëíèòå îñìîòğ ÎÏÍ - 220êÂ ïåğâîé ëèíèè.";
    public string description_2 = "" +
        "1. Îòêëş÷èòå ñèãíàëèçàöèş. \n" +
        "2. Âûïîëíèòå îñìîòğ èíäèêàòîğîâ è èçìåğèòåëüíûõ ïğèáîğîâ. \n" +
        "3. Çàôèêñèğîâàòü âğåìÿ íà÷àëà àâàğèè â æóğíàëå. \n" +
        "4. Âûïîëíèòå ïåğåêëş÷åíèÿ: \n" +
        "4.1.\tîòêëş÷èòü âûêëş÷àòåëü ÌÊÏ – 220 – 2 \n" +
        "4.2.\tîòêëş÷èòü ëèíåéíûå ğàçúåäèíèòåëè: ĞÍ – 220 / 1250 – 6, ĞÍ – 220 / 1250 – 8, ĞÍ – 220 / 1250 – 12 \n" +
        "4.3.\tâêëş÷èòü íîæè çàçåìëåíèÿ  ëèíåéíûõ ğàçúåäèíèòåëåé ĞÍ – 220 / 1250 – 6, ĞÍ – 220 / 1250 – 8, ĞÍ – 220 / 1250 – 12 ñî ñòîğîíû ëèíèé; \n" +
        "4.4.\tîòêëş÷àåòñÿ êëş÷îì óïğàâëåíèÿ àâòîìàòè÷åñêèé ââîä ğåçåğâà ñåêöèîííîãî âûêëş÷àòåëÿ è âêëş÷àåòñÿ ñåêöèîííûé âûêëş÷àòåëü; \n" +
        "4.5.\tîòêëş÷àåòñÿ êëş÷îì óïğàâëåíèÿ âûêëş÷àòåëü âòîğîé ñåêöèè øèí ÿ÷åéêè Q14;";

    public string commonInfo_1 = "Â÷åğà áûëà ïğîâåäåíà óñòàíîâêà ÎÏÍ - 220 êÂ ïåğâîé ëèíèè. Óäîñòîâåğüòåñü, ÷òî ÎÏÍ - 220 êÂ ïåğâîé ëèíèè èñïğàâåí.";
    public string commonInfo_2 = "";
    public string type = "ScenarioOPN";
    public int balls = 10;
    public int level = 1;
    public string tag = "Task";

    public int Id { get => id; }
    public string Title { get => title; }
    public string Description_1 { get => description_1; }
    public string Description_2 { get => description_2; }
    public string CommonInfo_1 { get => commonInfo_1; }
    public string CommonInfo_2 { get => commonInfo_2; }
    public string Type { get => type; }
    public int Balls { get => balls; }
    public int Level { get => level; }
    public string Tag { get => tag; }
}
