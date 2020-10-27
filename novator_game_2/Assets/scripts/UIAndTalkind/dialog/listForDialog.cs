using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class listForDialog : MonoBehaviour
{
    //private dialog_class dialogClass
    public Dictionary<int, dialog_classLoc> dialog1; 
   // public Dictionary<int, dialog_classLoc> dialog2; 
    public List<Dictionary<int, dialog_classLoc>> dialogs; 
    public Dictionary<string, List<Dictionary<int, dialog_classLoc>>> MPSDialogs; 


    private Dictionary<int, dialog_classLoc> generateDict()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Приветствую тебя странник. Хватит ли у тебя силы, чтобы выполнить моё задание?", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){2, 3}); 
        //                          номер в словаре/фраза/кол-во ответов/ прогресс диалога в зависимости от ответа/сами ответы/на какую фразу перейти/(dict) учловия появления варианта ответа/(string) что взять и отдать деньги# что отдать и отдать деньги
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Возвращайся, когда станешь сильнее...", 1, new List<int>(){0}, new List<string> (){"Ok"}, new List<int>(){-1});
        
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Сходи в лес и принеси мне от туда самый большой камень, который найдёшь", 1, new List<int>(){1}, new List<string> (){"Ладно"},  new List<int>(){-1});
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDict2()
    {
        Dictionary<int, dialog_classLoc> dialog2 = new Dictionary<int, dialog_classLoc>();
        dialog2.Add(1, new dialog_classLoc());
        dialog2[1].editAllParametrs(1, "Ну что, ты достал мой камень?", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){2, 3}, new  Dictionary<int,string> (){{2, "--"}, {3, "Class stone"}}); 
        
        dialog2.Add(2, new dialog_classLoc());
        dialog2[2].editAllParametrs(2, "Без него не возвращайся!", 1, new List<int>(){0}, new List<string> (){"Принято"}, new List<int>(){-1});
        
        dialog2.Add(3, new dialog_classLoc());
        dialog2[3].editAllParametrs(3, "А ты уверен, что он самый большой?", 1, new List<int>(){0}, new List<string> (){"Да"},  new List<int>(){4});

        dialog2.Add(4, new dialog_classLoc());
        dialog2[4].editAllParametrs(4, "Кхммм.... Ну ладно, держи, заслужил....", 1, new List<int>(){1}, new List<string> (){"Взять"},  new List<int>(){-1}, "Class stone 100#--");
        return dialog2;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDicts()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDict());
        dialogs.Add(generateDict2());
        return dialogs;
    }
    //----------------------Mill----------
    private Dictionary<int, dialog_classLoc> generateDictMill()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Получить муку?", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){-1, 2}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Один мешок муки был выдан", 1, new List<int>(){0}, new List<string> (){"Ok"}, new List<int>(){-1}, "--#Type food_flour1 0");
        
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsMill()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictMill());
        return dialogs;
    }
    //----------------------------Goblin and woulf-------
        private Dictionary<int, dialog_classLoc> generateDictGoblin1()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();

        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Что привело тебя в столь отдалённые края", 3, new List<int>(){0, 0, 0}, new List<string> (){"Жажда знаний", "Ты умеешь говорить?", "Кто ты?"}, new List<int>(){2, 30, 40}, "--#$Type tolking_Goblin 0"); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Что же ты хочешь узнать?  География? Может быть тебя интересует демографическая ситуация? Или же тебя интересуют Скелеты в шкафу у жителей?", 3, new List<int>(){0,0,0}, new List<string> (){"География", "демография", "Скелеты"}, new List<int>(){3, 7, 10});
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Чтож, ладно. Мы живём в местности, полностью окруженной скалами, через середину мира протекала река. Воды в ней давным давно нет, ибо злой <i><color=#DF01D7>Колдун</color></i> направил отсутствие дождя на нашу голову......", 1, new List<int>(){0,}, new List<string> (){"Продолжайте"}, new List<int>(){4}, "--#$Type tolking_Goblin_geograf 0");
        dialog1.Add(4, new dialog_classLoc());
        dialog1[4].editAllParametrs(4, "С тех пор водица исталась только в бескрайне глубоких колодцах......", 1, new List<int>(){0,}, new List<string> (){"Мгмм..."}, new List<int>(){5});
        dialog1.Add(5, new dialog_classLoc());
        dialog1[5].editAllParametrs(5, "Ах да, на чем это я! Хоть река давно пересохла, русло ее остается не менее опасным! оно окружено крутыми обрывами.... Говорят, от туда еще никто не выбирался......", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){6});
        dialog1.Add(6, new dialog_classLoc());
        dialog1[6].editAllParametrs(6, "Овраг делит мир на 2 части: деревня и заречье. Соеденены они двумя мостами. Так, ну это, пожалуй, все. Ступай теперь куда нога поведёт!", 2, new List<int>(){4, 1}, new List<string> (){"Прощай", "Прощай."}, new List<int>(){-1, -1});
        
        dialog1.Add(7, new dialog_classLoc());
        dialog1[7].editAllParametrs(7, "Скажи, не замечал ли ты, что в деревне много женщин, много мужчин, а детей? А детей НЕТ! Поговаривают, что всех детей, которые появляются, <i><color=#DF01D7>Колдун</color></i> заставляет работать на своей плонтации за горами", 1, new List<int>(){0}, new List<string> (){"О, как!"}, new List<int>(){8});
        dialog1.Add(8, new dialog_classLoc());
        dialog1[8].editAllParametrs(8, "В полне возможно что скелеты за одно с этим противным животным (<i><color=#DF01D7>Колдуном</color></i>), ведь уменьшение числа жителей поможет победить им в давней негластной борьбе за дома, которые они когда-то построили для себя и которые были захвачены жителями деревни", 1, new List<int>(){0}, new List<string> (){"О, как!!"}, new List<int>(){9});
        dialog1.Add(9, new dialog_classLoc());
        dialog1[9].editAllParametrs(9, "Одним словом, плохо все у них! Хуже только у нас! А в целом про народонаселение большего знать и не надо!, Чтож, до встречи!", 2, new List<int>(){0,1}, new List<string> (){"Прощай", "Прощай."}, new List<int>(){-1, -1});
        
        dialog1.Add(10, new dialog_classLoc());
        dialog1[10].editAllParametrs(10, "Чтож, скелеты, так стелеты! Моим братьям пришлось попотеть, чтобы достать информацию подобного рода! Но для тебя она достанется даром! 15 монет - не цена для таких сведений", 2, new List<int>(){0, 0}, new List<string> (){"15!? нет, так не пойдёт!", "Согласен!"}, new List<int>(){11, 14});
        dialog1.Add(11, new dialog_classLoc());
        dialog1[11].editAllParametrs(11, "Да понятно все с тобой! Ни копейки за душой у тебя нет! Ну чтож, ладно, если тебе так нужно, сделаю тебе одолжение! Как на счёт 12 монет?", 2, new List<int>(){0, 0}, new List<string> (){"Это оскорбление для меня!", "Согласен!"}, new List<int>(){12, 13});
        dialog1.Add(12, new dialog_classLoc());
        dialog1[12].editAllParametrs(12, "Ну чтож, гордец, прощай.", 1, new List<int>(){2}, new List<string> (){"Прощай."}, new List<int>(){-1});
        dialog1.Add(13, new dialog_classLoc());
        dialog1[13].editAllParametrs(13, "Давай сюда и секрет будет твой!", 1, new List<int>(){0}, new List<string> (){"Отдать"}, new List<int>(){15}, "--#Type Null 12");
        dialog1.Add(14, new dialog_classLoc());
        dialog1[14].editAllParametrs(14, "Давай сюда и секрет будет твой!", 1, new List<int>(){0}, new List<string> (){"Отдать"}, new List<int>(){15}, "--#Type Null 15");
        
        dialog1.Add(15, new dialog_classLoc());
        dialog1[15].editAllParametrs(15, "Чей секрет тебе интересен?", 2, new List<int>(){0, 0}, new List<string> (){"Бруто", "Миллина",}, new List<int>(){16, 20});
        
        dialog1.Add(16, new dialog_classLoc());
        dialog1[16].editAllParametrs(16, "*шепчет* Об этом запрещено даже упоминать, но тебе я скажу. Дело в том, что он лет 10 назад руководил партизанским отрядом. Они не подчинились <i><color=#DF01D7>Колдуну</color></i>. Борясь с ним эти люди нанесли ему непоправимый ущерб...", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){17});
        dialog1.Add(17, new dialog_classLoc());
        dialog1[17].editAllParametrs(17, "*шепчет* Сломав волшебную мельницу, они оставили <i><color=#DF01D7>Колдуна</color></i> и его слуг голодными. В ту зиму полегло врагов больше, чем в <b><color=red>Великой Битве</color></b>....", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){18});
        dialog1.Add(18, new dialog_classLoc());
        dialog1[18].editAllParametrs(18, "*шепчет* Месть <i><color=#DF01D7>Колдуна</color></i> была страшной! Любому бы показалось, что смерть лучше такой магической кары. Посмотри на его тело. Все в шрамах и магических символах.", 1, new List<int>(){0}, new List<string> (){"Нууу... и..."}, new List<int>(){19});
        dialog1.Add(19, new dialog_classLoc());
        dialog1[18].editAllParametrs(19, "Ну и что и? На этом история заканчивается. Но под конец, даю тебе совет: не пытайся бороться с <i><color=#DF01D7>Колдуном</color></i>! Не связывайся ни с чем, что связано с ним! Иначе ты будешь страдать! И ты будешь страдать и все остальные! Он не оставит  в стороне никого!", 1, new List<int>(){0}, new List<string> (){"Хорошо!"}, new List<int>(){-1});
        
        dialog1.Add(20, new dialog_classLoc());
        dialog1[20].editAllParametrs(20, "Эта Девушка, владеющая мельницей, - вызывает не мало вопросов.... Почему она сама не ходит на мельницу? На свою мельницу!? Откуда она берёт такие большие деньги, которые отдаёт за мешок? Куда она их девает?", 1, new List<int>(){0}, new List<string> (){"И????"}, new List<int>(){21});
        dialog1.Add(21, new dialog_classLoc());
        dialog1[21].editAllParametrs(21, "Но Самый главный из них: Кто приносит зерно на мельницу? Откуда в ней столько муки? Мы с братьями видим здесь промысел <i><color=#DF01D7>Колдуна</color></i> Вполне возможно, что она - тайный агент волшебника! Остерегайся её!", 1, new List<int>(){0}, new List<string> (){"Понял!"}, new List<int>(){-1});
        
        dialog1.Add(30, new dialog_classLoc());
        dialog1[30].editAllParametrs(30, "А что по-твоему? Гоблины - не люди!? Обладая кое-какими сведениями о жителях вашей деревушки, скажу тебе: 'Гоблины подчас человесние людей'", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){31});
        dialog1.Add(31, new dialog_classLoc());
        dialog1[31].editAllParametrs(31, "А теперь проваливай, коли так думаешь!!!", 1, new List<int>(){3}, new List<string> (){"..."}, new List<int>(){-1});
        
        dialog1.Add(40, new dialog_classLoc());
        dialog1[40].editAllParametrs(40, "Мы - представители древней цивилизации! Давным давно, когда люди еще не стояли на двух лапах, отважные гоблины бороздили промторы морей, строили магаполисы и даже путешестаовали по воздуху! Но относительно недавно случилось величайшее несчастье! Откуда ни возьмись налетела <i><color=#DF01D7>фиолетовая</color></i> буря и стерла все достижения древнейшегно, благородного народа с лица земли!", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){41});
        dialog1.Add(41, new dialog_classLoc());
        dialog1[41].editAllParametrs(41, "Немногие выжили в той ужасной неразберихе... Отдельные разрозненные группы оставшихся в живых разбрелись по миру. Теперь они живут по лесам, горам, опасаясь приследования", 1, new List<int>(){4}, new List<string> (){"Интересно...."}, new List<int>(){-1});
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictGoblin2()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();

        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Я не хочу говорить! ты со мной уже попрощался!", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){-1}); 
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictGoblin3()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();

        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ты слишком горд для разговора с гоблинами, не так ли? Иди от сюда, пока мой меч не оказался в твоем капсульном теле!", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){-1}); 
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictGoblin4()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();

        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Мы же не умеем разговаривать??? мы ж НЕ ЛЮДИ!!!!!", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){-1}); 
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictGoblin5()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();

        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "О! снова ты, любознательный странник?! Что заставило тебя посетить меня на этот раз?", 2, new List<int>(){0, 0}, new List<string> (){"Жажда знаний", "Да тут конфликт один..."}, new List<int>(){2, 22},  new  Dictionary<int,string> (){{2, "--"}, {22, "$Type quarrelPrins"}}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Что же ты хочешь узнать?  География? Может быть тебя интересует демографическая ситуация? Или же тебя интересуют Скелеты в шкафу у жителей?", 3, new List<int>(){0,0,0}, new List<string> (){"География", "демография", "Скелеты"}, new List<int>(){3, 7, 10});
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Чтож, ладно. Мы живём в местности, полностью окруженной скалами, через середину мира протекала река. Воды в ней давным давно нет, ибо злой <i><color=#DF01D7>Колдун</color></i> направил отсутствие дождя на нашу голову......", 1, new List<int>(){0,}, new List<string> (){"Продолжайте"}, new List<int>(){4});
        dialog1.Add(4, new dialog_classLoc());
        dialog1[4].editAllParametrs(4, "С тех пор водица исталась только в бескрайне глубоких колодцах......", 1, new List<int>(){0,}, new List<string> (){"Мгмм..."}, new List<int>(){5});
        dialog1.Add(5, new dialog_classLoc());
        dialog1[5].editAllParametrs(5, "Ах да, на чем это я! Хоть река давно пересохла, русло ее остается не менее опасным! оно окружено крутыми обрывами.... Говорят, от туда еще никто не выбирался......", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){6});
        dialog1.Add(6, new dialog_classLoc());
        dialog1[6].editAllParametrs(6, "Овраг делит мир на 2 части: деревня и заречье. Соеденены они двумя мостами. Так, ну это, пожалуй, все. Ступай теперь куда нога поведёт!", 2, new List<int>(){0, 1}, new List<string> (){"Прощай", "Прощай."}, new List<int>(){-1, -1});
        
        dialog1.Add(7, new dialog_classLoc());
        dialog1[7].editAllParametrs(7, "Скажи, не замечал ли ты, что в деревне много женщин, много мужчин, а детей? А детей НЕТ! Поговаривают, что всех детей, которые появляются, <i><color=#DF01D7>Колдун</color></i> заставляет работать на своей плонтации за горами", 1, new List<int>(){0}, new List<string> (){"О, как!"}, new List<int>(){8});
        dialog1.Add(8, new dialog_classLoc());
        dialog1[8].editAllParametrs(8, "В полне возможно что скелеты за одно с этим противным животным (<i><color=#DF01D7>Колдуном</color></i>), ведь уменьшение числа жителей поможет победить им в давней негластной борьбе за дома, которые они когда-то построили для себя и которые были захвачены жителями деревни", 1, new List<int>(){0}, new List<string> (){"О, как!!"}, new List<int>(){9});
        dialog1.Add(9, new dialog_classLoc());
        dialog1[9].editAllParametrs(9, "Одним словом, плохо все у них! Хуже только у нас! А в целом про народонаселение большего знать и не надо!, Чтож, до встречи!", 2, new List<int>(){0,1}, new List<string> (){"Прощай", "Прощай."}, new List<int>(){-1, -1});
        
        dialog1.Add(10, new dialog_classLoc());
        dialog1[10].editAllParametrs(10, "Чтож, скелеты, так стелеты! Моим братьям пришлось попотеть, чтобы достать информацию подобного рода! Но для тебя она достанется даром! 15 монет - не цена для таких сведений", 2, new List<int>(){0, 0}, new List<string> (){"15!? нет, так не пойдёт!", "Согласен!"}, new List<int>(){11, 14});
        dialog1.Add(11, new dialog_classLoc());
        dialog1[11].editAllParametrs(11, "Да понятно все с тобой! Ни копейки за душой у тебя нет! Ну чтож, ладно, если тебе так нужно, сделаю тебе одолжение! Как на счёт 12 монет?", 2, new List<int>(){0, 0}, new List<string> (){"Это оскорбление для меня!", "Согласен!"}, new List<int>(){12, 13});
        dialog1.Add(12, new dialog_classLoc());
        dialog1[12].editAllParametrs(12, "Ну чтож, гордец, прощай.", 1, new List<int>(){2}, new List<string> (){"Прощай."}, new List<int>(){-1});
        dialog1.Add(13, new dialog_classLoc());
        dialog1[13].editAllParametrs(13, "Давай сюда и секрет будет твой!", 1, new List<int>(){0}, new List<string> (){"Отдать"}, new List<int>(){15}, "--#Type Null 12");
        dialog1.Add(14, new dialog_classLoc());
        dialog1[14].editAllParametrs(14, "Давай сюда и секрет будет твой!", 1, new List<int>(){0}, new List<string> (){"Отдать"}, new List<int>(){15}, "--#Type Null 15");
        
        dialog1.Add(15, new dialog_classLoc());
        dialog1[15].editAllParametrs(15, "Чей секрет тебе интересен?", 2, new List<int>(){0, 0}, new List<string> (){"Бруто", "Миллина",}, new List<int>(){16, 20});
        
        dialog1.Add(16, new dialog_classLoc());
        dialog1[16].editAllParametrs(16, "*шепчет* Об этом запрещено даже упоминать, но тебе я скажу. Дело в том, что он лет 10 назад руководил партизанским отрядом. Они не подчинились <i><color=#DF01D7>Колдуну</color></i>. Борясь с ним эти люди нанесли ему непоправимый ущерб...", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){17});
        dialog1.Add(17, new dialog_classLoc());
        dialog1[17].editAllParametrs(17, "*шепчет* Сломав волшебную мельницу, они оставили <i><color=#DF01D7>Колдуна</color></i> и его слуг голодными. В ту зиму полегло врагов больше, чем в <b><color=red>Великой Битве</color></b>....", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){18});
        dialog1.Add(18, new dialog_classLoc());
        dialog1[18].editAllParametrs(18, "*шепчет* Месть <i><color=#DF01D7>Колдуна</color></i> была страшной! Любому бы показалось, что смерть лучше такой магической кары. Посмотри на его тело. Все в шрамах и магических символах.", 1, new List<int>(){0}, new List<string> (){"Нууу... и..."}, new List<int>(){19});
        dialog1.Add(19, new dialog_classLoc());
        dialog1[18].editAllParametrs(19, "Ну и что и? На этом история заканчивается. Но под конец, даю тебе совет: не пытайся бороться с <i><color=#DF01D7>Колдуном</color></i>! Не связывайся ни с чем, что связано с ним! Иначе ты будешь страдать! И ты будешь страдать и все остальные! Он не оставит  в стороне никого!", 1, new List<int>(){0}, new List<string> (){"Хорошо!"}, new List<int>(){-1});
        
        dialog1.Add(20, new dialog_classLoc());
        dialog1[20].editAllParametrs(20, "Эта Девушка, владеющая мельницей, - вызывает не мало вопросов.... Почему она сама не ходит на мельницу? На свою мельницу!? Откуда она берёт такие большие деньги, которые отдаёт за мешок? Куда она их девает?", 1, new List<int>(){0}, new List<string> (){"И????"}, new List<int>(){21});
        dialog1.Add(21, new dialog_classLoc());
        dialog1[21].editAllParametrs(21, "Но Самый главный из них: Кто приносит зерно на мельницу? Откуда в ней столько муки? Мы с братьями видим здесь промысел <i><color=#DF01D7>Колдуна</color></i> Вполне возможно, что она - тайный агент волшебника! Остерегайся её!", 1, new List<int>(){0}, new List<string> (){"Понял!"}, new List<int>(){-1});
        
        dialog1.Add(22, new dialog_classLoc());
        dialog1[22].editAllParametrs(22, "Всевидящее око говорит мне, что ты поцапался с одним из жителей Деревни. Мы с братьями знаем этого человека. Он счёл себя самым умным и не даёт никаму жить спокойно.", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){23});
        dialog1.Add(23, new dialog_classLoc());
        dialog1[23].editAllParametrs(23, "Твой поступок мы с братьями расцениваем как единственно правильный! В награду за твою прямоту и честность мы с братьями можем сделать то, чего еще не для кого не делали!!!", 1, new List<int>(){0}, new List<string> (){"Продолжай"}, new List<int>(){24});
        dialog1.Add(24, new dialog_classLoc());
        dialog1[24].editAllParametrs(24, "Мы можем сделать тебя одним из нас!!!!! За совсем символическую плату в 100 монет ты станешь Красивым Зелёным Человеком с не менее красивым волком! Как будешь готов к этому превращению - найди меня!!!", 1, new List<int>(){1}, new List<string> (){"Хорошо!"}, new List<int>(){-1});
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictGoblin6()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();

        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ну что, ты принёс 100 монет?", 2, new List<int>(){0,0}, new List<string> (){"Ещё нет...", "Да, я готово!"}, new List<int>(){2,3}); 
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Возвращайся скорее!!!", 1, new List<int>(){1}, new List<string> (){"Хорошо!"}, new List<int>(){-1});
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "*звуки магии и волшебства*", 1, new List<int>(){1}, new List<string> (){"Крайне благодарен вам!"}, new List<int>(){-1}, "--#$Type Goblin_potion 100");
        
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsGoblin()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictGoblin1());
        dialogs.Add(generateDictGoblin2());
        dialogs.Add(generateDictGoblin3());
        dialogs.Add(generateDictGoblin4());
        dialogs.Add(generateDictGoblin5());
        dialogs.Add(generateDictGoblin6());
        return dialogs;
    }
    // ---------------------------Хозяйка мельницы---------------
    private Dictionary<int, dialog_classLoc> generateDictMillina1()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ооо Страннник, здравствуй! Ессли ттебя не ззатрудннит, нне ммог бы тты принести мне мешочек мукки с ммельницы? Я сслишшком слаба, а тты ммусулистый красавец, ккоторый ввыглядит ккрайне благгородно! Я увверена, этто не ддоставит ттебе ммного ххлопот!", 2, new List<int>(){0, 0}, new List<string> (){"У меня много дел", "Мне будет только в радость!"}, new List<int>(){2, 3}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Ккак жжаль, воззвращайся сккорее!", 1, new List<int>(){1}, new List<string> (){"лаааадно...."}, new List<int>(){-1});

        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "О, я так рада! Сспасибо ттебе огромное!!! Ты насстоящий ммужчина!!!!", 1, new List<int>(){2}, new List<string> (){"Я скоро!"}, new List<int>(){-1});
        
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictMillina2()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "O тты вернулся? Замечательно! Ну ччто, тты сможешь принести мне ммешочек муки?", 2, new List<int>(){0, 0}, new List<string> (){"У меня все еще много дел", "Мне будет только в радость!"}, new List<int>(){2, 3}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Ккак жжаль, воззвращайся сккорее!", 1, new List<int>(){0}, new List<string> (){"лаааадно...."}, new List<int>(){-1});

        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "О, я так рада! Сспасибо ттебе огромное!!! Ты насстоящий ммужчина!!!!", 1, new List<int>(){1}, new List<string> (){"Я скоро!"}, new List<int>(){-1});
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictMillina3()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Нну ччто?? Ккак, достал мешочек муки мне???", 2, new List<int>(){0, 0}, new List<string> (){"Конечно нет....", "Конечно да!"}, new List<int>(){2, 3}, new  Dictionary<int,string> (){{2, "--"}, {3, "Type food_flour1"}}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Ккак жжаль, воззвращайся сс мешком сккорее!", 1, new List<int>(){0}, new List<string> (){"лаааадно...."}, new List<int>(){-1});

        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Оооо, спасибо тебе, мой дорого мужчина!", 1, new List<int>(){0}, new List<string> (){"Дда, пожалуйста.."}, new List<int>(){4});
        dialog1.Add(4, new dialog_classLoc());
        dialog1[4].editAllParametrs(4, "Ввот держи! скромная награда для тебя!", 1, new List<int>(){-1}, new List<string> (){"О, вот это не плохо!"}, new List<int>(){-1}, "Type food_flour1 5#--");
        
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsMillina()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictMillina1());
        dialogs.Add(generateDictMillina2());
        dialogs.Add(generateDictMillina3());
        return dialogs;
    }
    //----------------------------Prinse-------------------
    private Dictionary<int, dialog_classLoc> generateDictPrinse1()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Привет, путник! Думою, ты будишь заинтерисован в том, чтобы получить некаторую суму залотых!", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){-1, 2}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Это просто велекалепное исвестие! Ходят слухи, что в лису за рикой живут гоблины - декари, наесдники на валках! Даподлено не исвесно, насколька они расвиты. Васможно им даже присуща речь - один из ключавых паказатилей расвития.", 1, new List<int>(){0}, new List<string> (){"Иииии?"}, new List<int>(){3});
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Мне жисненно неабходимо, чтобы ты встретелся с одним ис них и ответел мне на парачку вапросав об этих декорях", 2, new List<int>(){0, 1}, new List<string> (){"У меня нет времяни", "Я согласен"}, new List<int>(){-1,-1});
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictPrinse2()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ну, что? Ты уже погаварил с гогблином?", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){2, 3},  new  Dictionary<int,string> (){{2, "--"}, {3, "$Type tolking_Goblin"}}); 
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Пока не погаваришь - Не восвращайся!!!!", 1, new List<int>(){0}, new List<string> (){"Оооок...."}, new List<int>(){-1}); 
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "О как! ну и счто? Спасобны они к чиловечиской речи?", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){4, 6}); 
        dialog1.Add(4, new dialog_classLoc());
        dialog1[4].editAllParametrs(4, "Я так и сзнал!!! Тлько претстафь! Кокие бесгронисчные восможности нем это дайот!!! Мы можем поробатить их!!! Зделать сваими Рабами! Мне односначно нужно время, для дальнейшего опдумования этой идеи! а тебе полагаеться награда!", 1, new List<int>(){0}, new List<string> (){"Я жду..."}, new List<int>(){5}); 
        dialog1.Add(5, new dialog_classLoc());
        dialog1[5].editAllParametrs(5, "Воть, держи! Заслужил!", 2, new List<int>(){0,0}, new List<string> (){"СпОсибА", "Всегда рад помочь!"}, new List<int>(){5}, "$Type tolking_Goblin 10#--"); 
        
        dialog1.Add(6, new dialog_classLoc());
        dialog1[6].editAllParametrs(6, "Как страно! Я-то думал, что эти бесмосглые жевотные и говарить не умеют!", 1, new List<int>(){0}, new List<string> (){"Вы про волков?"}, new List<int>(){7}); 
        dialog1.Add(7, new dialog_classLoc());
        dialog1[7].editAllParametrs(7, "Да, и про них тоже! (Ха-ха) Но прешде всего про этих бесмозглых варворав! Ходят они себе помиру с первобытным оружием и ничего не понямают!", 1, new List<int>(){0}, new List<string> (){"Эммм..."}, new List<int>(){8}); 
        dialog1.Add(8, new dialog_classLoc());
        dialog1[8].editAllParametrs(8, "То, что они умеют говарить - ничего еще не сзначит! <color=#848484>(*отдает деньги за миссию*)</color> Я уверин - они не спасобны орентироваца в прастранстве! Таким жевотным это непод силу! Ох, как этто былобы зсдораво, еслибы ты смок поттвердить Мойо претполажение!", 2, new List<int>(){0, 2}, new List<string> (){"Эммм, нет, давай потом!", "Я готов помочь тебе!"}, new List<int>(){9, -1}, "$Type tolking_Goblin 8#--"); 
        dialog1.Add(9, new dialog_classLoc());
        dialog1[9].editAllParametrs(9, "Я буду ждать тебя, восврощайся путник быстрее!", 1, new List<int>(){1}, new List<string> (){"Ладно..."}, new List<int>(){-1}); 
        
        dialog1.Add(10, new dialog_classLoc());
        dialog1[10].editAllParametrs(10, "Ты что, передразнивать меня вздумал!!!! Или.... Быть может, ты самневаешься в моем разговорном языке?", 1, new List<int>(){0}, new List<string> (){"Эмммм"}, new List<int>(){11}); 
        dialog1.Add(11, new dialog_classLoc());
        dialog1[11].editAllParametrs(11, "Ты оскорбил меня! Я лучший в этом го... кхм кхм деревне владею языком! Думаю, после этого ты достоин только вызава на дуэль!!! Но мне не хочется марать честь, стреляясь с тобой!", 2, new List<int>(){0, 0}, new List<string> (){"Вот еще, дуэль", "Я вызываю тебя!"}, new List<int>(){12, 13}); 
        dialog1.Add(12, new dialog_classLoc());
        dialog1[12].editAllParametrs(12, "Тогда прощай! было непреятно с тобой говорить!", 1, new List<int>(){3}, new List<string> (){"...."}, new List<int>(){-1}); 
        dialog1.Add(13, new dialog_classLoc());
        dialog1[13].editAllParametrs(13, "Ха вот еще! Дуэль! Стобой!? Неееет! Ни за что! Проваливай, пока я не убил тебя так!", 1, new List<int>(){3}, new List<string> (){"...."}, new List<int>(){-1}); 
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictPrinse3()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ну что, уже ты готов снова отправиться к гоблинам? Я точно уверин, что с пространствиным мышленеем у нех проблемы! Докажешь это - с голоду не умрёшь точно!", 2, new List<int>(){0, 0}, new List<string> (){"Как-нибудь в другой раз", "Я готов!"}, new List<int>(){-1, 2}); 
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Тогда отпровляйся в их логаво - Заречный лес и разузнай у них, как у них дела с географией!", 1, new List<int>(){1}, new List<string> (){"Уже иду!"}, new List<int>(){-1});

        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictPrinse4()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ну что, лоси заречного леса не сьели тебя? Ты уже розузнал об ихнем опыте орентираваться в пространстве?", 2, new List<int>(){0, 0}, new List<string> (){"Нет", "Да"}, new List<int>(){2, 3},  new  Dictionary<int,string> (){{2, "--"}, {3, "$Type tolking_Goblin_geograf"}}); 
        
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "А жаль, что несьели! Даже не думой восвращаться без этой информацыи!!!!", 1, new List<int>(){0}, new List<string> (){"...."}, new List<int>(){-1});
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Ну и как? Веть мои догатки поттвердились!", 2, new List<int>(){0, 0}, new List<string> (){"Нет! Многие гоблины лучше людей!", "Они ничего не знают!"}, new List<int>(){4,7});
        dialog1.Add(4, new dialog_classLoc());
        dialog1[4].editAllParametrs(4, "Как!!! То езть, ты счетаешь, что кокой-та мерзский гоблин может быть лучше такого прекрастного человека, как Я?", 1, new List<int>(){0}, new List<string> (){"Я ТАКОГО НЕ ГОВОРИЛ!"}, new List<int>(){5});
        dialog1.Add(5, new dialog_classLoc());
        dialog1[5].editAllParametrs(5, "Можеть, ты скажишь, чтои языковые навыки у этих зелоных мерзских гоблинов лучше моих???", 1, new List<int>(){0}, new List<string> (){"Ну вообще-то, ДА!"}, new List<int>(){6});
        dialog1.Add(6, new dialog_classLoc());
        dialog1[6].editAllParametrs(6, "Чтож, нам тогда неочем говорить!!! Проваливай к своим НОВЫМ зелёным друзьям!!! И не смей подходить ко мне!!!", 1, new List<int>(){1000}, new List<string> (){"...."}, new List<int>(){-1}, "--#$Type quarrelPrins 0");
        
        dialog1.Add(7, new dialog_classLoc());
        dialog1[7].editAllParametrs(7, "Я так и снал! Эти бесмозглые саздания нечего не могут! Их бкдет очень легко порабатить!!!! Я надеюсь, ты со мной заодно!?", 2, new List<int>(){0,0}, new List<string> (){"Конечно нет!", "Естественно да!"}, new List<int>(){8, -1});
        dialog1.Add(8, new dialog_classLoc());
        dialog1[8].editAllParametrs(8, "Лладдно, ппохоже наши вкусы по отношению к рабам расходятся (неловко). Знаешь, давай так, всего этого НЕБЫЛО. Я \"сотру твою память\" а взамен дав вот эти сапожки, которые ускоряют скорость твоего перидвижения", 1, new List<int>(){-3}, new List<string> (){"...."}, new List<int>(){-1}, "--#$Type thinksSpeedBoorts 0");
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictPrinse5()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Уходи прочъ! Я не хочу с тобой гаворить!", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){-1}); 
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictPrinse6()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Уходи прочъ! Я не хочу с тобой гаворить!", 1, new List<int>(){0}, new List<string> (){"..."}, new List<int>(){-1}); 
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsPrinse()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictPrinse1());
        dialogs.Add(generateDictPrinse2());
        dialogs.Add(generateDictPrinse3());
        dialogs.Add(generateDictPrinse4());
        dialogs.Add(generateDictPrinse5());   
        dialogs.Add(generateDictPrinse6());  
        return dialogs;
    }
    //----------------------------Finish---------
    private Dictionary<int, dialog_classLoc> generateDictFinish()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Вы оседлали волка и, тем самым, прошли квест! Поздравляем! Теперь вы можете вдоволь насладиться всеми прелестями верховой езды!", 1, new List<int>(){0}, new List<string> (){"Понял"}, new List<int>(){-1}); 
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsFinish()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictFinish());
        return dialogs;
    }
    //----------------------------Start--------
    private Dictionary<int, dialog_classLoc> generateDictStart()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Игрок! Ты проходишь квест! Для выигрыша всего-то навсего необходимо оседлать волка! В игре целенаправленно заложены сюжетные тупики, чтобы сбить тебя с толку! Но не отчаевайся! НАша команда верит в твои силы! Удачи!", 1, new List<int>(){1}, new List<string> (){"Я пройду этот квест!"}, new List<int>(){-1}); 
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Дерзай!", 1, new List<int>(){0}, new List<string> (){"Я пройду этот квест!"}, new List<int>(){-1}); 
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictStart2()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Дерзай!", 1, new List<int>(){0}, new List<string> (){"Я пройду этот квест!"}, new List<int>(){-1}); 
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsStart()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictStart());
        dialogs.Add(generateDictStart2());
        return dialogs;
    }
    //----------------------------Bruto----------
        private Dictionary<int, dialog_classLoc> generateDictBruto()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Мой друг! Мне очень нужна твоя помощь! Не согласился бы ты принести мне молоток!", 2, new List<int>(){0, 1}, new List<string> (){"У меня много дел..", "Мне не сложно!"}, new List<int>(){2, 3}); 
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Помни, я всегда жду твоей помощи!", 1, new List<int>(){0}, new List<string> (){"Я скоро!"}, new List<int>(){-1}); 
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "До меня доходили слухи, что на лесопилке их много! В первую очередь проверь там!", 1, new List<int>(){1}, new List<string> (){"Будет сделано!"}, new List<int>(){-1}); 
        
        return dialog1;
    }
    private Dictionary<int, dialog_classLoc> generateDictBruto2()
    {
        dialog1 = new Dictionary<int, dialog_classLoc>();
        dialog1.Add(1, new dialog_classLoc());
        dialog1[1].editAllParametrs(1, "Ну что, нашёл молоток?", 2, new List<int>(){0, 1}, new List<string> (){"Еще нет..", "Да!"}, new List<int>(){2, 3}); 
        dialog1.Add(2, new dialog_classLoc());
        dialog1[2].editAllParametrs(2, "Ну, чтож, он точно гдето есть!", 1, new List<int>(){0}, new List<string> (){"Я скоро!"}, new List<int>(){-1}); 
        dialog1.Add(3, new dialog_classLoc());
        dialog1[3].editAllParametrs(3, "Да, такая работа требует оплаты! Вот, держи!", 1, new List<int>(){1}, new List<string> (){"Будет сделано!"}, new List<int>(){-1}); 
        
        return dialog1;
    }
    public List<Dictionary<int, dialog_classLoc>> GetListForDictsBruto()
    {
        dialogs = new List<Dictionary<int, dialog_classLoc>>();
        dialogs.Add(generateDictBruto());
        dialogs.Add(generateDictBruto2());
        return dialogs;
    }
    //----------------------------AllEnd------------
    public Dictionary<string, List<Dictionary<int, dialog_classLoc>>> GetAllDialogs()
    {
        if (MPSDialogs == null){
            MPSDialogs = new Dictionary<string, List<Dictionary<int, dialog_classLoc>>>();
            MPSDialogs["Шкаф"] = GetListForDicts();
            MPSDialogs["Mill"] = GetListForDictsMill();
            MPSDialogs["GobWoulf"] = GetListForDictsGoblin();
            MPSDialogs["Millina"] = GetListForDictsMillina();
            MPSDialogs["Prinse"] = GetListForDictsPrinse();
            MPSDialogs["Finish"] = GetListForDictsFinish();
            MPSDialogs["Start"] = GetListForDictsStart();
            MPSDialogs["Bruto"] = GetListForDictsBruto();
        }
        return MPSDialogs;
    }
}

public class dialog_classLoc : dialog_class
{

}
//name = имя
//[{1:, <<"фраза1">, <"2">, <"да", "нет">, <"2", "3">>}
// {2: <фраза2, 1 [ок], [-1]>}
// {3: <задание, 0, [], [4]>}
// {4: <ты согласен, 1, [да], [-1]>}












//]









