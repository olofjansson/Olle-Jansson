# DC Motor Beräkningsresultat

## Sammanfattning av Beräkningar

### Indata

| Parameter | Enhet | Värde |
|-----------|-------|-------|
| Spänning (V) | V | 12 |
| No load speed (rpm) | rpm | 6000 |
| Moment (Nm) | Nm | 0.02 |
| Verkningsgrad (η) | % | 85 |
| Induktans (L) | H | 0.013 |
| Motstånd (R) | Ω | 6 |
| Eddy Current Losses (ECL) | W | 0 |
| Tröghetsmoment (J) | kg·m² | 0 |
| Viskös friktionskoefficient (B) | Nm·s/rad | 0 |

### Utdata

| Parameter | Enhet | Värde |
|-----------|-------|-------|
| Ström (I) | A | 1.047 |
| Output rpm | rpm | 2858 |
| Mekanisk effekt | W | 5.987 |
| Elektrisk effekt | W | 12.566 |
| Kt | Nm/A | 0.01910 |
| Ke | V/(rad/s) | 0.01910 |
| Kv | rpm/V | 500.0 |

### Noteringar

- Den beräknade verkningsgraden (47.64%) skiljer sig från den angivna (85%)
- Detta beror på betydande resistansförluster (I²R) i detta fall
- För detaljerade beräkningar och formler, se CALCULATIONS.md
- För C# implementation, se DCMotorCalculator/

### Körning av C# Program

```bash
cd DCMotorCalculator
dotnet build
dotnet run
```

Programmet visar alla indata- och utdatavärden formaterat i konsolen.
