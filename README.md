# C# Playground
nějaké random ass info k projektu..

## Notes
### Namespace
- Slouží k organizaci kódu a zabraňuje kolizím
- Většinou kopíruje strukturu složek
- Příklad:
  - `namespace CSharpPlayground.Models.Module1;`
  - `using CSharpPlayground.Models.Module1;`

### Viditelnost
- Pro třídy, rozhraní a struktury
  - Public = viditelné odkudkoli
  - internal = uvnitř stejného projektu
- Pro metody, atributy, pole,...
  - public = dostupné odkudkoli
  - internal = jen v rámci projektu
  - protected = jen uvnitř dědičných tříd 
  - private = jen uvnitř stejné třídy
  - protected internal = kombinace - dostupné v rámci projektu nebo v dědičných třídách
  - private protected = dostupné jen v dědičných třídách, ale pouze uvnitř stejného projektu
- Výchozí hodnoty
  - Třída - default je internal
  - Metoda - default je private

#### Sealed
- Význam jako v Javě `final` - třída nemůže dál dědit

#### Format
- price:C = naformátuj string jako měnu
- price:N = naformátuj číslo s oddělovači tisíců
- price:F2 = fixní počet desetinných míst (2)
- price:P = jako procenta

#### Record
- Speciální typ zaměřený na data
- Value-based equality - neporovnávají se reference, ale hodnoty vlastností
- Má automatický toString
- Defaultně se nadá neměnit, je immutable. Vytvoříš a už se nemůže měnit
- Jednoduché kopírování s úpravou pomocí `with`:
  - `var book = new Product("Book", 50);`
  - `var cheapBook = book with { Price = 20 };`

#### ValueTuple
- zapisuje se pomocí kulatých závorek
- `var (name, price) = new Product("Book", 50);`
- Je to lehký datový typ na seskupení hodnot
- Skvělý pro návrat více hodnot a nemuset zakládat novou třídu

#### out
- Speciální klíčové slovo - říká, že metoda nastaví hodnotu parametru
- Volající nemusí mít proměnnou inicializovanou, metoda jí naplní.
- Hodnota se naplní vždy a nenajde se to, tak se uloží defaultní hodnota (0 nebo null)