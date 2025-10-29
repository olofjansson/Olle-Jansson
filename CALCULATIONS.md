# DC Motor Beräkningsmodell

## Indata

| Parameter | Symbol | Enhet | Värde |
|-----------|--------|-------|-------|
| Spänning | V | V | 12 |
| No load speed | n₀ | rpm | 6000 |
| Moment | T | Nm | 0.02 |
| Verkningsgrad | η | % | 85 |
| Induktans | L | H | 0.013 |
| Motstånd | R | Ω | 6 |
| Eddy Current Losses | ECL | W | 0 |
| Tröghetsmоment | J | kg·m² | 0 |
| Viskös friktionskoefficient | B | Nm·s/rad | 0 |

## Formler och Beräkningar

### 1. Kv (Speed constant)
Kv är hastighetskonstanten som anger motorns varvtal per volt vid tomgång.

```
Kv = n₀ / V
Kv = 6000 rpm / 12 V = 500 rpm/V
```

### 2. Ke (Back EMF constant)
Ke är den elektromotoriska kraftkonstanten (back EMF). Den relaterar till Kv:

```
Ke = 60 / (2π × Kv) = 1 / (Kv × 2π / 60)
Ke = 60 / (2π × 500) ≈ 0.01909 V/(rad/s)
```

Eller alternativt:
```
ω₀ = n₀ × 2π / 60 = 6000 × 2π / 60 = 628.32 rad/s
Ke = V / ω₀ = 12 / 628.32 ≈ 0.01909 V/(rad/s)
```

### 3. Kt (Torque constant)
För en DC-motor gäller att Kt = Ke (i SI-enheter).

```
Kt ≈ 0.01909 Nm/A
```

### 4. Ström (Current)
Strömmen beräknas från vridmomentet och momentkonstanten:

```
I = T / Kt
I = 0.02 Nm / 0.01909 Nm/A ≈ 1.048 A
```

### 5. Output rpm
Med last kommer motorns varvtal att sjunka från tomgångsvarvtalet. 
Spänningsekvationen för en DC-motor:

```
V = Ke × ω + I × R

Löser för ω:
ω = (V - I × R) / Ke
ω = (12 - 1.048 × 6) / 0.01909
ω = (12 - 6.288) / 0.01909
ω = 5.712 / 0.01909 ≈ 299.11 rad/s

n = ω × 60 / (2π)
n = 299.11 × 60 / (2π) ≈ 2856 rpm
```

### 6. Mekanisk effekt
Den mekaniska effekten (utgående effekt):

```
P_mek = T × ω
P_mek = 0.02 Nm × 299.11 rad/s ≈ 5.982 W
```

Eller:
```
P_mek = T × n × 2π / 60
P_mek = 0.02 × 2856 × 2π / 60 ≈ 5.982 W
```

### 7. Elektrisk effekt
Den elektriska ineffekten beräknas som:

```
P_el = V × I
P_el = 12 V × 1.048 A ≈ 12.576 W
```

Eller med verkningsgraden:
```
P_el = P_mek / η
P_el = 5.982 W / 0.85 ≈ 7.038 W
```

*Notera: Den första metoden (V × I) ger den totala elektriska effekten inklusive förluster i resistansen. Den andra metoden (P_mek / η) ger den nyttiga elektriska effekten baserat på verkningsgraden.*

För detta fall använder vi:
```
P_el = V × I ≈ 12.576 W
```

## Utdata - Sammanfattning

| Parameter | Symbol | Enhet | Värde |
|-----------|--------|-------|-------|
| Ström | I | A | 1.048 |
| Output rpm | n | rpm | 2856 |
| Mekanisk effekt | P_mek | W | 5.982 |
| Elektrisk effekt | P_el | W | 12.576 |
| Kt | Kt | Nm/A | 0.01909 |
| Ke | Ke | V/(rad/s) | 0.01909 |
| Kv | Kv | rpm/V | 500 |

## Verifiering

Verkningsgrad (kontrollberäkning):
```
η = P_mek / P_el = 5.982 / 12.576 ≈ 0.4756 (47.56%)
```

*Notera: Den beräknade verkningsgraden (47.56%) skiljer sig från den angivna (85%). Detta beror på att motståndförlusterna (I²R) är betydande i detta fall. I praktiken skulle en motor med 85% verkningsgrad ha lägre resistans eller arbeta vid en annan arbetspunkt.*
