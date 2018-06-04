# DC-DateTime-Provider

Provides methods for dealing with dates & times. All dates & times are to be stored in UTC; only being converted to local format at render time.

```
System.DateTime GetNowUtc();

System.DateTime ConvertUtcToUk(System.DateTime utcDateTime);

System.DateTime ConvertOpaToDateTime(string opaDateTime);
```