# YandexAPI

# Примеры работы в RoslynPad:

#### Добавлены карты YandexAPI.MapsStaticAPI.

### YandexAPI.SpeechKitCloud.TTS
```C#
#r "YandexAPI.dll"
using YandexAPI.SpeechKitCloud;
using YandexAPI.SpeechKitCloud.TTS;
YandexTTS tts = new YandexTTS("tts_or_asr_apikey");
```

```C#
byte[] voice = tts.GetVoice("Привет, Мир!", Lang.Ru);

tts.SaveAudio(voice, "helloworld", @"C:\Users\User\Desktop\", Format.MP3);
```

### YandexAPI.SpeechKitCloud.ASR
```C#
#r "YandexAPI.dll"
using YandexAPI.SpeechKitCloud;
using YandexAPI.SpeechKitCloud.TTS;
using YandexAPI.SpeechKitCloud.ASR;
YandexTTS tts = new YandexTTS("tts_or_asr_apikey");
YandexASR asr = new YandexASR("tts_or_asr_apikey");
```

```C#
byte[] voice = tts.GetVoice("Привет, Мир!", Lang.Ru); //Получаем голос
AsrResponse response = asr.VoiceToText(voice, Topic.Queries, Lang.Ru, AudioFormat.MP3); //Получаем варианты текста из голоса

foreach (Variant variant in response.variant)
    Console.WriteLine($"Мне кажется, что там сказано '{variant.text}'");
```

![alt text](http://joxi.ru/8AnX3R6fjg5Nzm.png)

### YandexAPI.Linguistics.Dictionary
```C#
#r "YandexAPI.dll"
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
#r "YandexAPI.dll"
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
#r "YandexAPI.dll"
using YandexAPI.Linguistics.Speller;
YandexSpeller speller = new YandexSpeller();

var res = speller.CheckText("Превет");

for (int i = 0; i < res.s.Length; i++)
    Console.WriteLine($"Я думаю, что тут должно быть '{res.s[i]}'");
```
![alt text](http://joxi.ru/4Ak3ZKpUyBdPaA.png)

### YandexAPI.Linguistics.Translate

```C#
#r "YandexAPI.dll"
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

#### Создано при помощи tech.yandex.ru