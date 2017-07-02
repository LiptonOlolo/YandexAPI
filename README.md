# YandexAPI

# Примеры работы в RoslynPad:

### YandexAPI.Linguistics.Dictionary
```C#
#r "C:\Users\Allah\Desktop\YandexAPI\YandexAPI\bin\Release\YandexAPI.dll"
using YandexAPI.Linguistics.Dictionary;
YandexDictionary yd = new YandexDictionary("apikey");
```

```C#
var res = yd.GetLangs();

foreach (var element in res)
    Console.WriteLine(element);
```

```C#
var res = yd.Lookup("ru-ru", "время");
```

### YandexAPI.Linguistics.Predictor

```C#
#r "C:\Users\Allah\Desktop\YandexAPI\YandexAPI\bin\Release\YandexAPI.dll"
using YandexAPI.Linguistics.Predictor;
YandexPredictor yp = new YandexPredictor("apikey");
```

```C#
var res = yp.GetLangs();

foreach (var element in res)
    Console.WriteLine(element);
```

```C#
var res = yp.Complete("ru", "Прив", 10);

for (int i = 0; i < res.text.Length; i++)
    Console.WriteLine($"Может '{res.text[i]}'?");
```
![alt text](http://joxi.ru/V2VnGPBsxLb9k2.png)

### YandexAPI.Linguistics.Speller
Спеллер работает без API ключа (!)

```C#
#r "C:\Users\Allah\Desktop\YandexAPI\YandexAPI\bin\Release\YandexAPI.dll"
using YandexAPI.Linguistics.Speller;
YandexSpeller speller = new YandexSpeller();

var res = speller.CheckText("Превет");

for (int i = 0; i < res.s.Length; i++)
    Console.WriteLine($"Я думаю, что тут должно быть '{res.s[i]}'");
```

### YandexAPI.Linguistics.Translate

```C#
#r "C:\Users\Allah\Desktop\YandexAPI\YandexAPI\bin\Release\YandexAPI.dll"
using YandexAPI.Linguistics.Translate;
YandexTranslate ytr = new YandexTranslate("apikey");
```

```C#
var res = ytr.DetectLang("Я думаю, что этот текст написан на Русском языке. Хотя кто его знает.");
Console.WriteLine($"Текст написан на '{res.lang}'");
```

![alt text](http://joxi.ru/Dr8KoJ6U4YwQRA.png)

```C#
var res = ytr.GetLangs(); //res.langs -> Dictionary<string, string>

//res.dirs <-- возможные направления для перевода, например: en-ru, ru-en ...
foreach (var element in res.langs)
    Console.WriteLine($"Код страны: {element.Key}, Имя: {element.Value}");
```

![alt text](http://joxi.ru/E2pvMOdS9JlRdr.png)

```C#
var res = ytr.Translate("Привет", "en"); //можно указать явный перевод: ytr.Translate("Привет", "ru-en);
Console.WriteLine($"Текст переведен {res.text[0]} [{res.lang}]");
```

![alt text](http://joxi.ru/vAWDVP3u1X9vXr.png)
