# Olle-Jansson
Kalkulering och C#

## DC Motor Beräkningsmodell

Detta projekt innehåller en beräkningsmodell för DC-motorer med tillhörande C# implementation.

### Innehåll

- **CALCULATIONS.md** - Detaljerad dokumentation av beräkningsformler och exempel
- **DCMotorCalculator/** - C# console applikation för DC-motor beräkningar

### Körning

För att köra C# programmet:

```bash
cd DCMotorCalculator
dotnet run
```

Programmet kommer att fråga dig om motorparametrar. Du kan:
- Ange egna värden för varje parameter
- Trycka Enter för att använda standardvärdena (visas inom hakparenteser)
- Använda antingen komma (`,`) eller punkt (`.`) som decimaltecken

**Exempel:**
```
Spänning (V) [12]: 24
No load speed (rpm) [6000]: 
Moment (Nm) [0.02]: 0,025
```

### Beräkningsexempel

Programmet beräknar följande från motorns specifikationer:
- Ström (I)
- Output rpm
- Mekanisk effekt
- Elektrisk effekt
- Kt (Torque constant)
- Ke (Back EMF constant)
- Kv (Speed constant)

Se `CALCULATIONS.md` för detaljerade beräkningar och formler.
