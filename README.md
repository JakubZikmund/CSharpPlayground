# CSharpPlayground
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
- Význam jako v Javě `final` - třída nemůže dědit dál